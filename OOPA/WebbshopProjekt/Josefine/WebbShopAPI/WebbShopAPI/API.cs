using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebbShopAPI.Database;
using WebbShopAPI.Models;

namespace WebbShopJoR
{
    public class API
    {
        public static MyContext db = new MyContext();

        public static bool ActivateUser(int adminId, int userId)
        {
            var admin = IsAdminAndLoggedIn(adminId);
            if (admin)
            {
                var user = GetUser(userId);
                if (user != null)
                {
                    user.IsActive = true;
                    db.Update(user);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Search book by Id, if found check if title and author match, and increase amount
        /// if not found, search by tile and author, if not found add new book
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static bool AddBook(int adminId, int bookId, string title, string author, int price, int amount)
        {
            var admin = IsAdminAndLoggedIn(adminId);
            if (admin)
            {
                var book = GetBook(bookId);
                if (book != null && book.Title == title && book.Author == author)
                {
                    book.Amount += amount;
                    db.SaveChanges();
                    return true;
                }
                else if (book == null)
                {
                    var isBookAdded = NewBook(title, author, price, amount);
                    return isBookAdded;
                }
            }
            return false;
        }

        /// <summary>
        /// Add cathegory to a book
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public static bool AddBookToCategory(int adminId, int bookId, int categoryId)
        {
            var admin = IsAdminAndLoggedIn(adminId);
            if (admin)
            {
                var book = GetBook(bookId);
                if (book != null)
                {
                    var category = GetCathegoryById(categoryId);
                    if (category != null)
                    {
                        book.BookCategories = category;
                        db.Update(book);
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Add cathegory if not already exist
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool AddCategory(int adminId, string name)
        {
            var admin = IsAdminAndLoggedIn(adminId);
            var category = GetCategories(name);
            if (admin && category.Count < 1)
            {
                db.BookCategories.Add(new BookCategory { Name = name });
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check admin, check if user exist and add user
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool AddUser(int adminId, string name, string password)
        {
            var admin = IsAdminAndLoggedIn(adminId);
            if (admin)
            {
                var user = FindUsers(adminId, name);
                if (user.Count < 1)
                {
                    db.Users.Add(new User { Name = name, Password = password, IsAdmin = false, IsActive = true });
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public static void BestCostomer(int adminId)
        {
            var admin = IsAdminAndLoggedIn(adminId);
            if (admin)
            {
                var sold = SoldItems(adminId);
                var users = (from s in db.SoldBooks.Include("Users") group s by s.Users into u select new { User = u.Key, BoughtBooks = u.Count() });
                var nr = from u in users select u.BoughtBooks;
                var best = nr.Max();
                var user = from u in users where u.BoughtBooks == best select u;
                var bestUser = from b in db.SoldBooks where b.Users == user select b;
            }
        }

        /// <summary>
        /// Buy book, if logged in and book exist
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public static bool BuyBook(int userId, int bookId)
        {
            var active = IsActiveAndLoggedIn(userId);
            if (active)
            {
                var user = GetUser(userId);
                if (user != null)
                {
                    var book = GetBook(bookId);
                    if (book != null)
                    {
                        book.Amount -= 1;
                        SoldBook(book.Title, book.Author, book.BookCategories, book.Price, user);
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Deleting book if there is only one left, else decrease amount
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public static bool DeleteBook(int adminId, int bookId)
        {
            var admin = IsAdminAndLoggedIn(adminId);
            var book = GetBook(bookId);
            if (book != null)
            {
                book.Amount -= 1;
                if (book.Amount < 1)
                {
                    db.Remove(book);
                    return true;
                }
            }
            db.SaveChanges();
            return false;
        }

        /// <summary>
        /// Deleting cathegory if there is no books in it
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public static bool DeleteCategory(int adminId, int categoryId)
        {
            var admin = IsAdminAndLoggedIn(adminId);
            var booksInCategory = GetBooksInCategory(categoryId);
            if (admin && booksInCategory.Count < 1)
            {
                var category = GetCathegoryById(categoryId);
                if (category != null)
                {
                    db.Remove(category);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Search user with keyword
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<User> FindUsers(int adminId, string keyword)
        {
            var admin = IsAdminAndLoggedIn(adminId);
            var users = new List<User>();
            if (admin)
            {
                users = (from u in db.Users
                         where u.Name.Contains(keyword)
                         select u).ToList();
            }
            return users;
        }

        /// <summary>
        /// search author with keyword
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public static List<Book> GetAuthors(string author)
        {
            var books = (from b in db.Books
                         where b.Author.Contains(author)
                         select b).ToList();
            return books;
        }

        /// <summary>
        /// Search available books in a certain cathegory
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public static List<Book> GetAvailableBooks(int categoryId)
        {
            var availableBooks = (from b in db.Books
                                  where b.BookCategories.Id == categoryId && b.Amount > 0 //Lärt av Denis Panjuta, Udemy, 
                                  select b).ToList();                                     //att komma åt bokId så.
            return availableBooks;
        }

        public static Book GetBook(int bookId)
        {
            var book = (from b in db.Books.Include("BookCategories")
                        where b.Id == bookId
                        select b).FirstOrDefault();
            return book;
        }

        /// <summary>
        /// Search books with keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<Book> GetBooks(string keyword)
        {
            var books = (from b in db.Books
                         where b.Title.Contains(keyword) || b.Author.Contains(keyword)
                         select b).ToList();
            return books;
        }

        /// <summary>
        /// List books in a certain cathegory
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public static List<Book> GetBooksInCategory(int categoryId)
        {
            var booksInCategory = (from c in db.Books
                                   where c.BookCategories.Id == categoryId
                                   select c).ToList();
            return booksInCategory;
        }

        /// <summary>
        /// List all categorys
        /// </summary>
        /// <returns></returns>
        public static List<BookCategory> GetCategories()
        {
            var categories = (from c in db.BookCategories
                              orderby c.Name
                              select c).ToList();
            return categories;
        }

        /// <summary>
        /// Search cathegorys with keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<BookCategory> GetCategories(string keyword)
        {
            var categories = (from c in db.BookCategories
                              where c.Name.Contains(keyword)
                              select c).ToList();
            return categories;
        }

        public static BookCategory GetCathegoryById(int categoryId)
        {
            var category = (from c in db.BookCategories
                            where c.Id == categoryId
                            select c).FirstOrDefault();
            return category;
        }
        public static User GetUser(int userId)
        {
            var user = (from u in db.Users
                        where u.Id == userId
                        select u).FirstOrDefault();
            return user;
        }

        public static bool InactivateUser(int adminId, int userId)
        {
            var admin = IsAdminAndLoggedIn(adminId);
            if (admin)
            {
                var user = GetUser(userId);
                if (user != null)
                {
                    user.IsActive = false;
                    db.Update(user);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public static bool IsActiveAndLoggedIn(int userId)
        {
            var user = (from u in db.Users
                        where u.Id == userId && u.IsActive == true && u.SessionTimer > DateTime.Now.AddMinutes(-15)
                        select u).FirstOrDefault();
            if (user != null)
            {
                user.SessionTimer = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool IsAdmin(int userId)
        {
            var user = (from u in db.Users
                        where u.Id == userId && u.IsAdmin == true
                        select u).FirstOrDefault();
            if (user != null) return true;
            return false;
        }

        /// <summary>
        /// Check if user is admin and is logged in (not inactive last 15 min)
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public static bool IsAdminAndLoggedIn(int userId)
        {
            var admin = IsAdmin(userId);
            var active = IsActiveAndLoggedIn(userId);
            if (admin && active) return true;
            return false;
        }

        public static List<User> ListUsers(int adminId)
        {
            var admin = IsAdminAndLoggedIn(adminId);
            var users = new List<User>();
            if (admin)
            {
                users = (from u in db.Users
                         orderby u.Name
                         select u).ToList();
            }
            return users;
        }

        /// <summary>
        /// Logging in and set session timer
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static int Login(String username, string password)
        {
            {
                var user = (from u in db.Users
                            where u.Name == username && u.Password == password && u.IsActive
                            select u).FirstOrDefault();
                if (user != null)
                {
                    user.LastLogin = DateTime.Now;
                    user.SessionTimer = DateTime.Now;
                    db.Users.Update(user);
                    db.SaveChanges();
                    return user.Id;
                }
                return 0;
            }
        }

        public static void Logout(int id)
        {
            var user = GetUser(id);
            if (user != null)
            {
                user.SessionTimer = default;
                db.Users.Update(user);
                db.SaveChanges();
            }
        }

        public static int MoneyEarned(int adminId)
        {
            var admin = IsAdminAndLoggedIn(adminId);
            if (admin)
            {
                var sold = SoldItems(adminId);
                var earned = sold.Sum(p => p.Price);
                return earned;
            }
            return 0;
        }

        /// <summary>
        /// Search book by title and author, add new book if not found
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static bool NewBook(string title, string author, int price, int amount)
        {
            var newBook = (from b in db.Books
                           where b.Title == title && b.Author == author
                           select b).FirstOrDefault();
            if (newBook == null)
            {
                db.Books.Add(new Book
                {
                    Title = title,
                    Author = author,
                    Price = price,
                    Amount = amount,
                });
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// check if user have done anything the last 15 min.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string Ping(int userId)
        {
            var user = (from u in db.Users
                        where u.Id == userId && u.SessionTimer > DateTime.Now.AddMinutes(-15)
                        select u).FirstOrDefault();
            if (user != null)
            {
                user.SessionTimer = DateTime.Now;
                db.SaveChanges();
                return "Pong";
            }
            else
            {
                return string.Empty;
            }
        }

        public static bool Promote(int adminId, int userId)
        {
            var admin = IsAdminAndLoggedIn(adminId);
            if (admin)
            {
                var user = GetUser(userId);
                if (user != null)
                {
                    user.IsAdmin = true;
                    db.Update(user);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="passwordVerify"></param>
        /// <returns></returns>
        public static bool Register(string name, string password, string passwordVerify)
        {
            var user = (from u in db.Users
                        where u.Name == name
                        select u).FirstOrDefault();
            if (user == null && password == passwordVerify)
            {
                db.Users.Add(new User { Name = name, Password = password, IsAdmin = false, IsActive = true });
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// search book and set amount
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="amount"></param>
        public static void SetAmount(int adminId, int bookId, int amount)
        {
            var admin = IsAdminAndLoggedIn(adminId);
            if (admin)
            {
                var book = GetBook(bookId);
                if (book != null)
                {
                    book.Amount = amount;
                    db.SaveChanges();
                }
            }
        }

        public static void SoldBook(string title, string author, BookCategory cathegory, int price, User user)
        {
            db.SoldBooks.Add(new SoldBook
            {
                Title = title,
                Author = author,
                BookCategories = cathegory,
                Price = price,
                PurchasedDate = DateTime.Now,
                Users = user,
            });
            db.SaveChanges();
        }

        public static List<SoldBook> SoldItems(int adminId)
        {
            var admin = IsAdminAndLoggedIn(adminId);
            var sold = new List<SoldBook>();
            if (admin)
            {
                sold = (from s in db.SoldBooks
                        orderby s.Title
                        select s).ToList();
            }
            return sold;
        }

        /// <summary>
        /// search book and update
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public static bool UpdateBook(int adminId, int bookId, string title, string author, int price)
        {
            var admin = IsAdminAndLoggedIn(adminId);
            if (admin)
            {
                var book = GetBook(bookId);
                if (book != null)
                {
                    book.Title = title;
                    book.Author = author;
                    book.Price = price;
                    db.Update(book);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Search cathegory and update
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool UpdateCategory(int adminId, int categoryId, string name)
        {
            var admin = IsAdminAndLoggedIn(adminId);
            var category = (from c in db.BookCategories where c.Id == categoryId select c).FirstOrDefault();
            if (category != null)
            {
                category.Name = name;
                db.Update(category);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}