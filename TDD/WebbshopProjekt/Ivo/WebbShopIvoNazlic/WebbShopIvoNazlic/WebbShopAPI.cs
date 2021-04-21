using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebbShopIvoNazlic.Database;
using WebbShopIvoNazlic.Models;
using WebbShopIvoNazlic.Helpers;

namespace WebbShopIvoNazlic
{
    /// <remarks>
    /// API - CRUD data in database
    /// </remarks>
    public static class WebbShopAPI
    {

        private static BookDatabase db = new BookDatabase();

        /// <summary>
        ///  User login if active user account exists
        /// </summary>
        /// <returns>Sser id if success, 0 if fail</returns>
        public static int Login(string username, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.Name == username && u.Password == password && u.IsActive == true);
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

        /// <summary>
        /// User logout. 
        /// </summary>
        public static void Logout(int userId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == userId);
            //var user = Helper.UserExistsAndLoggedIn(userId);
            if (user != null)
            {
                user.SessionTimer = DateTime.MinValue;
                db.Users.Update(user);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Lists all categories
        /// </summary>
        /// <returns>All available categories as a list</returns>
        public static List<Category> GetCategories(int userId)
        {
            var user = Helper.UserExistsAndLoggedIn(userId);
            if (user != null)
            {
                return db.BookCategories.ToList();
            }

            List<Category> noData = new List<Category>();
            return noData;
        }

        /// <summary>
        /// Lists all categories containing keyword
        /// </summary>
        /// <returns>List of all matched categories</returns>
        public static List<Category> GetCategories(int userId, string keyword)
        {
            var user = Helper.UserExistsAndLoggedIn(userId);
            List<Category> Categories = new List<Category>();
            if (user != null)
            {
                foreach (var category in db.BookCategories.Where(n => n.Name.ToLower().Contains(keyword.ToLower())))
                {
                    if (category != null)
                    {
                        Categories.Add(category);
                    }
                }
            }

            return Categories;
        }

        /// <summary>
        /// Lists all books of a category
        /// </summary>
        /// <returns>List of matching books</returns>
        public static List<Book> GetCategory(int userId, int categoryId)
        {
            var user = Helper.UserExistsAndLoggedIn(userId);
            List<Book> booksByCategory = new List<Book>();
            if (user != null)
            {
                foreach (var book in db.Books.Where(bc => bc.BookCategory.Id == categoryId))
                {
                    if (book != null)
                    {
                        booksByCategory.Add(book);
                    }
                }
            }

            return booksByCategory;
        }

        /// <summary>
        /// Lists all books in stock
        /// </summary>
        /// <returns>List of all books with ammount > 0</returns>
        public static List<Book> GetAvailableBooks(int userId, int categoryId)
        {
            var user = Helper.UserExistsAndLoggedIn(userId);
            List<Book> availableBooks = new List<Book>();
            if (user != null)
            {
                foreach (var book in db.Books.Where(b => b.Amount > 0 && b.BookCategory.Id == categoryId))
                {
                    if (book != null)
                    {
                        availableBooks.Add(book);
                    }
                }
            }

            return availableBooks;
        }

        /// <summary>
        /// Information about a book
        /// </summary>
        /// <returns>Book object</returns>
        public static Book GetBook(int userId, int bookId)
        {
            var user = Helper.UserExistsAndLoggedIn(userId);
            var book = Helper.BookExists(bookId);
            if (book != null && user != null)
            {
                return book;
            }

            return null;
        }

        /// <summary>
        /// Lists all books by matching keyword
        /// </summary>
        /// <returns>List of all matched books</returns>
        public static List<Book> GetBooks(int userId, string keyword)
        {
            var user = Helper.UserExistsAndLoggedIn(userId);
            List<Book> matchingBooks = new List<Book>();
            if (user != null)
            {
                foreach (var book in db.Books.Where(n => n.Title.ToLower().Contains(keyword.ToLower())))
                {
                    if (book != null)
                    {
                        matchingBooks.Add(book);
                    }
                }
            }

            return matchingBooks;
        }

        /// <summary>
        /// Lists all books by author
        /// </summary>
        /// <returns>List of all matched books</returns>
        public static List<Book> GetAuthors(int userId, string keyword)
        {
            List<Book> booksByAuthor = new List<Book>();
            var user = Helper.UserExistsAndLoggedIn(userId);
            if (user != null)
            {
                foreach (var book in db.Books.Where(n => n.Author.ToLower().Contains(keyword.ToLower())))
                {
                    if (book != null)
                    {
                        booksByAuthor.Add(book);
                    }
                }
            }

            return booksByAuthor;
        }

        /// <summary>
        /// Hanldes book purchase (reduces book stock, logs purchase info in sold books table)
        /// </summary>
        /// <returns>True if success, false if fail</returns>
        public static bool BuyBook(int userId, int bookId)
        {
            var user = Helper.UserExistsAndLoggedIn(userId);
            var book = Helper.BookExists(bookId);
            if (user != null && book != null)
            {
                if (book.Amount > 0)
                {
                    book.Amount -= 1;
                    db.Books.Update(book);
                    db.SoldBooks.Add(new SoldBook
                    {
                        Title = book.Title,
                        Author = book.Author,
                        CategoryId = book.BookCategory.Name,
                        Price = book.Price,
                        PurchasedDate = DateTime.Now,
                        Users = db.Users.FirstOrDefault(u => u.Id == userId)

                    });
                    db.SaveChanges();
                    return true;
                }
                return false;
            }

            return false;
        }

        /// <summary>
        /// Refreshes user session time
        /// </summary>
        /// <returns>Pong if user is online, string.empty if offline</returns>
        public static string Ping(int userId)
        {
            var user = Helper.UserExistsAndLoggedIn(userId);
            if (user != null)
            {
                return "pong";
            }

            return string.Empty;
        }

        /// <summary>
        /// Register new user
        /// </summary>
        /// <returns>True if user is created, 
        ///false is user already exist or if password != verify</returns>
        public static bool Register(string name, string password)
        {
            var user = Helper.UserExists(name);
            if (user == null)
            {
                Console.Write("Please comfirm password: ");
                string input = Console.ReadLine();
                if (password == input)
                {
                    db.Users.Add(new User { Name = name, Password = password });
                    db.SaveChanges();
                    return true;
                }

                return false;
            }

            return false;
        }

        /// <summary>
        /// Adds book to the database if book doesnt exist. Else increase ammount
        /// </summary>
        /// <returns>True if success, false if fail</returns>
        public static bool AddBook(int adminId, string title, string author, int price, int amount)
        {
            var user = Helper.IsAdminAndLoggedIn(adminId);
            var book = Helper.BookExists(title, author);
            if (user != null)
            {
                if (book == null)
                {
                    db.Books.Add(new Book
                    {
                        Title = title,
                        Author = author,
                        Amount = amount,
                        Price = price,
                    });
                }

                else
                {
                    book.Amount = amount;
                    db.Books.Update(book);
                }

                db.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Sets ammount of available books
        /// </summary>
        /// <returns>True if success, false if fail</returns>
        public static bool SetAmount(int adminId, int bookId)
        {
            var user = Helper.IsAdminAndLoggedIn(adminId);
            var book = Helper.BookExists(bookId);
            if (user != null && book != null)
            {
                Console.Write("Set amount of available books: ");
                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());
                    book.Amount = input;
                    db.Books.Update(book);
                    db.SaveChanges();
                    return true;
                }

                catch (System.FormatException)
                {
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Lists of all users
        /// </summary>
        /// <returns>List of all registered users</returns>
        public static List<User> ListUsers(int adminId)
        {
            var user = Helper.IsAdminAndLoggedIn(adminId);
            if (user != null)
            {
                return db.Users.ToList();
            }

            List<User> noData = new List<User>();
            return noData;
        }

        /// <summary>
        /// Lists of all usersnames containing keyword
        /// </summary>
        /// <returns>List of all matched users</returns>
        public static List<User> FindUser(int adminId, string keyword)
        {
            var loggedUser = Helper.IsAdminAndLoggedIn(adminId);
            List<User> usersByKeyword = new List<User>();
            if (loggedUser != null)
            {
                foreach (var user in db.Users.Where(u => u.Name.ToLower().Contains(keyword.ToLower())))
                {
                    usersByKeyword.Add(user);
                }
            }

            return usersByKeyword;
        }

        /// <summary>
        /// Updates book data
        /// </summary>
        /// <returns>True if success, false if fail</returns>
        public static bool UpdateBook(int adminId, int id, string title, string author, int price)
        {
            var user = Helper.IsAdminAndLoggedIn(adminId);
            var book = Helper.BookExists(id);
            if (user != null && book != null)
            {
                book.Title = title;
                book.Author = author;
                book.Price = price;
                db.Books.Update(book);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Deletes book from the database if book ammount = 0. Else decrease ammount by 1
        /// </summary>
        /// <returns>True if success, false if fail</returns>
        public static bool DeleteBook(int adminId, int bookId)
        {
            var user = Helper.IsAdminAndLoggedIn(adminId);
            var book = Helper.BookExists(bookId);
            if (user != null && book != null)
            {
                if (book.Amount > 1)
                {
                    book.Amount -= 1;
                    db.Books.Update(book);
                }

                else
                {
                    db.Books.Remove(book);
                }

                db.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Adds category to the database if category doesnt exist.
        /// </summary>
        /// <returns>True if success, false if fail</returns>
        public static bool AddCategory(int adminId, string name)
        {
            var user = Helper.IsAdminAndLoggedIn(adminId);
            var category = Helper.CategoryExists(name);
            if (user != null && category == null)
            {
                db.BookCategories.Add(new Category { Name = name });
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Adds book to the category
        /// </summary>
        /// <returns>True if success, false if fail</returns>
        public static bool AddBookToCategory(int adminId, int bookId, int categoryId)
        {
            var user = Helper.IsAdminAndLoggedIn(adminId);
            var book = Helper.BookExists(bookId);
            var category = Helper.CategoryExists(categoryId);
            if (user != null && book != null && category != null)
            {
                book.BookCategory = category;
                db.Books.Update(book);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Updates category info
        /// </summary>
        /// <returns>True if success, false if fail</returns>
        public static bool UpdateCategory(int adminId, int categoryId, string name)
        {
            var user = Helper.IsAdminAndLoggedIn(adminId);
            var category = Helper.CategoryExists(categoryId);
            if (user != null && category != null)
            {
                category.Name = name;
                db.Update(category);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Deletes category if no book is linked to it.
        /// </summary>
        /// <returns>True if success, false if fail</returns>
        public static bool DeleteCategory(int adminId, int categoryId)
        {
            var user = Helper.IsAdminAndLoggedIn(adminId);
            var category = Helper.CategoryExists(categoryId);
            if (user != null && category != null && GetCategory(adminId, category.Id).Count == 0)
            {
                db.BookCategories.Remove(category);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Adds user to the database if user doesnt exist and password !=""
        /// </summary>
        /// <returns>True if success, false if fail</returns>
        public static bool AddUser(int adminId, string name, string password)
        {
            if (String.IsNullOrEmpty(password))
            {
                return false;
            }

            var loggedUser = Helper.IsAdminAndLoggedIn(adminId);
            var user = Helper.UserExists(name);
            if (loggedUser != null && user == null)
            {
                db.Users.Add(new User { Name = name, Password = password });
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Lists all sold books
        /// </summary>
        /// <returns>List of all sold books</returns>
        public static List<SoldBook> SoldItems(int adminId)
        {
            var user = Helper.IsAdminAndLoggedIn(adminId);
            if (user != null)
            {
                return db.SoldBooks.ToList();
            }

            List<SoldBook> noData = new List<SoldBook>();
            return noData;
        }

        /// <summary>
        /// Sums all sold books
        /// </summary>
        /// <returns>Sum of all sold books</returns>
        public static int MoneyEarned(int adminId)
        {
            var user = Helper.IsAdminAndLoggedIn(adminId);
            if (user != null)
            {
                return db.SoldBooks.Select(s => s.Price).Sum();
            }

            return 0;
        }

        /// <summary>
        /// Checks the Id of the customer who bought most books
        /// </summary>
        /// <returns>Customer Id</returns>
        public static int BestCustomer(int adminId)
        {
            var user = Helper.IsAdminAndLoggedIn(adminId);
            var bestCustomer = db.SoldBooks.Include(u=> u.Users).AsEnumerable().GroupBy(u => u.Users.Id).OrderByDescending(u => u.Count()).FirstOrDefault();
            if (user != null && bestCustomer != null)
            {
                return bestCustomer.Key;
            }

            return 0;
        }

        /// <summary>
        /// Promotes user to admin (if user exists)
        /// </summary>
        /// <returns>True if method success, otherwise false</returns>
        public static bool Promote(int adminId, int userId)
        {
            var adminUser = Helper.IsAdminAndLoggedIn(adminId);
            var user = Helper.UserExists(userId);
            if (adminUser != null && user != null)
            {
                user.IsAdmin = true;
                db.Users.Update(user);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Demotes admin to user (if user exists)
        /// </summary>
        /// <returns>True if method success, otherwise false</returns>
        public static bool Demote(int adminId, int userId)
        {
            var adminUser = Helper.IsAdminAndLoggedIn(adminId);
            var user = Helper.UserExists(userId);
            if (adminUser != null && user != null)
            {
                user.IsAdmin = false;
                db.Users.Update(user);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Activates an user (if user exists)
        /// </summary>
        /// <returns>True if method success, otherwise false</returns>
        public static bool ActivateUser(int adminId, int userId)
        {
            var adminUser = Helper.IsAdminAndLoggedIn(adminId);
            var user = Helper.UserExists(userId);
            if (adminUser != null && user != null)
            {
                user.IsActive = true;
                db.Users.Update(user);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Deactivates an user (if user exists)
        /// </summary>
        /// <returns>True if method success, otherwise false</returns>
        public static bool InactivateUser(int adminId, int userId)
        {
            var adminUser = Helper.IsAdminAndLoggedIn(adminId);
            var user = Helper.UserExists(userId);
            if (adminUser != null && user != null)
            {
                user.IsActive = false;
                db.Users.Update(user);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// API-method to check if user is admin
        /// </summary>
        /// <returns>True if admin, otherwise false</returns>
        public static bool IsAdmin(int userId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == userId && u.IsAdmin);
            if (user != null)
            {
                return true;
            }

            return false;
        }

    }
}
