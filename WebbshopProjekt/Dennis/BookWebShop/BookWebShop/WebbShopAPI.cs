using BookWebShop.Database;
using BookWebShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookWebShop
{
    public class WebbShopAPI
    {
        /// <summary>
        /// Admin User can activate a User.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool ActivateUser(int adminId, int userId)
        {
            if (IsAdmin(adminId) && IsLoggedIn(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Id == userId);

                    if (user == null)
                    {
                        return false;
                    }
                    else
                    {
                        user.IsActive = true;
                        db.Update(user);
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Admin User can Add books here. With keywords.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool AddBook(int adminId, string title, string author, int price, int amount)
        {
            if (IsAdmin(adminId) && IsLoggedIn(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    var book = db.Books.FirstOrDefault(b => b.Title == title);

                    if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title) || string.IsNullOrEmpty(author) || string.IsNullOrWhiteSpace(author))
                    {
                        return false;
                    }
                    else if (book == null)
                    {
                        db.Books.Add(new Book { Title = title, Author = author, Price = price, Amount = amount });
                        db.SaveChanges();
                        return true;
                    }
                    else if (book.Title == title)
                    {
                        book.Amount++;
                        db.Books.Update(book);
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Admin User can add Books to categories by bookId and categoryId.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public bool AddBookToCategory(int adminId, int bookId, int categoryId)
        {
            if (IsAdmin(adminId) && IsLoggedIn(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    var book = db.Books.FirstOrDefault(b => b.Id == bookId);
                    if (book != null)
                    {
                        book.Category = db.BookCategories.FirstOrDefault(bc => bc.Id == categoryId);
                        db.Update(book);
                        db.SaveChanges();
                        return true;
                    }
                    else { return false; }
                }
            }
            return false;
        }

        /// <summary>
        /// Admin User can Add new categories by keyword categoryName.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public bool AddCategory(int adminId, string categoryName)
        {
            if (IsAdmin(adminId) && IsLoggedIn(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    var bookCategory = db.BookCategories.FirstOrDefault(bc => bc.Name == categoryName);

                    if (string.IsNullOrEmpty(categoryName) || string.IsNullOrWhiteSpace(categoryName))
                    {
                        return false;
                    }
                    else if (categoryName != null)
                    {
                        db.BookCategories.Add(new BookCategory { Name = categoryName });
                        db.SaveChanges();
                        return true;
                    }
                    else { return false; }
                }
            }
            return false;
        }

        /// <summary>
        /// Admin User can add new Users with username and password.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool AddUser(int adminId, string username, string password)
        {
            if (IsAdmin(adminId) && IsLoggedIn(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Name == username);

                    if (user == null)
                    {
                        db.Users.Add(new User { Name = username, Password = password });
                        db.SaveChanges();
                        return true;
                    }
                    else if (user.Name == username || password == null)
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Admin User can check which User that has bough most books.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public User BestCustomer(int adminId)
        {
            if (IsAdmin(adminId) && IsLoggedIn(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    var bestCustomer = new List<User>();

                    if (db.SoldBooks.Count() > 0)
                    {
                        foreach (var customer in db.SoldBooks.Select(s => s.UsrId).Distinct().ToList())
                        {
                            var booksBought = db.SoldBooks.Count(s => s.UsrId == customer);
                            bestCustomer.Add(customer);
                        }
                        return bestCustomer.FirstOrDefault();
                    }
                    else { return new User(); }
                }
            }
            return new User();
        }

        /// <summary>
        /// User buy Book with userId and bookId.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public bool BuyBook(int userId, int bookId)
        {
            if (IsLoggedIn(userId))
            {
                using (var db = new WebbShopContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Id == userId);
                    var book = db.Books.FirstOrDefault(b => b.Id == bookId);
                    var bookCategory = db.BookCategories.FirstOrDefault(bc => bc.Id == book.Id);

                    if (user.SessionTimer != default && user != null)
                    {
                        db.SoldBooks.Add(new SoldBook { Title = book.Title, Author = book.Author, Price = book.Price, Category = bookCategory, PurchaseDate = DateTime.Today, UsrId = user });
                        book.Amount--;
                        db.Update(user);
                        db.Update(book);
                        db.SaveChanges();
                        return true;
                    }
                    else { return false; }
                }
            }
            return false;
        }

        /// <summary>
        /// Admin User can delete Books by bookId.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public bool DeleteBook(int adminId, int bookId)
        {
            if (IsAdmin(adminId) && IsLoggedIn(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    var book = db.Books.FirstOrDefault(b => b.Id == bookId);

                    book.Amount--;

                    if (book.Amount <= 0)
                    {
                        db.Books.Remove(book);
                        db.SaveChanges();
                        return true;
                    }

                    db.Update(book);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Admin User can delete a category by categoryId.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public bool DeleteCategory(int adminId, int categoryId)
        {
            if (IsAdmin(adminId) && IsLoggedIn(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    var bookCategory = db.BookCategories.FirstOrDefault(bc => bc.Id == categoryId);

                    if (bookCategory == null)
                    {
                        return false;
                    }
                    else if (bookCategory.Books == null)
                    {
                        db.BookCategories.Remove(bookCategory);
                        db.SaveChanges();
                        return true;
                    }
                    else { return false; }
                }
            }
            return false;
        }

        /// <summary>
        /// Admin User can Demote a User from Admin.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool Demote(int adminId, int userId)
        {
            if (IsAdmin(adminId) && IsLoggedIn(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Id == userId);

                    if (user == null)
                    {
                        return false;
                    }
                    else
                    {
                        user.IsAdmin = false;
                        db.Update(user);
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Admin User can search for a User by keyword.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public List<User> FindUser(int adminId, string username)
        {
            if (IsAdmin(adminId) && IsLoggedIn(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    return db.Users.Where(u => u.Name.Contains(username)).ToList();
                }
            }
            return new List<User>(0);
        }

        /// <summary>
        /// Gets a List of Books by Authors matching the keyword bookByAuthor.
        /// </summary>
        /// <param name="bookByAuthor"></param>
        /// <returns></returns>
        public List<Book> GetAuthors(string bookByAuthor)
        {
            using (var db = new WebbShopContext())
            {
                return db.Books.Where(b => b.Author.Contains(bookByAuthor)).Include(bc => bc.Category).ToList();
            }
        }

        /// <summary>
        /// Gets Books that are avaliable in the category.
        /// </summary>
        /// <returns></returns>
        public List<Book> GetAvaliableBooks()
        {
            using (var db = new WebbShopContext())
            {
                return db.Books.Where(b => b.Amount > 0).Include(bc => bc.Category).ToList();
            }
        }

        /// <summary>
        /// Gets info about Book from bookId.
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public List<Book> GetBook(int bookId)
        {
            using (var db = new WebbShopContext())
            {
                return db.Books.Where(b => b.Id == bookId).Include(bc => bc.Category).ToList();
            }
        }

        /// <summary>
        /// Gets a List of Books matching the keyword.
        /// </summary>
        /// <param name="bookName"></param>
        /// <returns></returns>
        public List<Book> GetBooks(string bookName)
        {
            using (var db = new WebbShopContext())
            {
                return db.Books.Where(b => b.Title.Contains(bookName)).Include(bc => bc.Category).ToList();
            }
        }

        /// <summary>
        /// Gets a List of Books by category from categoryId.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public List<Book> GetBooksInCategory(int categoryId)
        {
            using (var db = new WebbShopContext())
            {
                return db.Books.Where(b => b.Category.Id == categoryId).ToList();
            }
        }

        /// <summary>
        /// Gets a List of all categories.
        /// </summary>
        /// <returns></returns>
        public List<BookCategory> GetCategories()
        {
            using (var db = new WebbShopContext())
            {
                return db.BookCategories.ToList();
            }
        }

        /// <summary>
        /// Gets a List of categories matching keyword categoryName.
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public List<BookCategory> GetCategories(string categoryName)
        {
            using (var db = new WebbShopContext())
            {
                return db.BookCategories.Where(bc => bc.Name.Contains(categoryName)).ToList();
            }
        }

        /// <summary>
        /// Admin User can inactivate a User.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool InactivateUser(int adminId, int userId)
        {
            if (IsAdmin(adminId) && IsLoggedIn(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Id == userId);

                    if (user == null)
                    {
                        return false;
                    }
                    else
                    {
                        user.IsActive = false;
                        db.Update(user);
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Method to check if the User is Admin.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public bool IsAdmin(int adminId)
        {
            using (var db = new WebbShopContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == adminId);

                if (user.IsAdmin)
                {
                    return true;
                }
                else { return false; }
            }
        }

        /// <summary>
        /// Check if User isloggedin.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool IsLoggedIn(int userId)
        {
            using (var db = new WebbShopContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == userId);
                {
                    if (user == null || user.SessionTimer == DateTime.MinValue)
                    {
                        return false;
                    }
                    else
                    {
                        user.SessionTimer = DateTime.Now.AddMinutes(-15);
                        return true;
                    }
                }
            }
        }

        /// <summary>
        /// Admin User List all users with adminId.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public List<User> ListUsers(int adminId)
        {
            if (IsAdmin(adminId) && IsLoggedIn(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    return db.Users.ToList();
                }
            }
            return new List<User>(0);
        }

        /// <summary>
        /// Login the User by userId.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int Login(string username, string password)
        {
            using (var db = new WebbShopContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Name == username && u.Password == password);

                if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
                {
                    return 0;
                }
                else if (user != null)
                {
                    user.SessionTimer = DateTime.Now;
                    user.LastLogin = DateTime.Now;
                    db.Users.Update(user);
                    db.SaveChanges();
                    return user.Id;
                }
                return 0;
            }
        }

        /// <summary>
        /// Logout the User by userId.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int Logout(int userId)
        {
            using (var db = new WebbShopContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == userId);

                if (user == null)
                {
                    return 0;
                }

                user.SessionTimer = DateTime.MinValue;
                db.Users.Update(user);
                db.SaveChanges();
                return 0;
            }
        }

        /// <summary>
        /// Admin User can get a sum of all the money by sold Books.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public int MoneyEarned(int adminId)
        {
            if (IsAdmin(adminId) && IsLoggedIn(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    if (db.SoldBooks.Count() > 0)
                    {
                        return db.SoldBooks.Sum(sb => sb.Price);
                    }
                    else { return 0; }
                }
            }
            return 0;
        }

        /// <summary>
        /// Ping to check if User is online.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string Ping(int userId)
        {
            using (var db = new WebbShopContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == userId);

                if (user != null && user.IsActive && IsLoggedIn(user.Id))
                {
                    user.SessionTimer = DateTime.Now;
                    db.Users.Update(user);
                    db.SaveChanges();
                    return "Pong";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Admin User can Promote a User to Admin.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool Promote(int adminId, int userId)
        {
            if (IsAdmin(adminId) && IsLoggedIn(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Id == userId);

                    if (user == null)
                    {
                        return false;
                    }
                    else
                    {
                        user.IsAdmin = true;
                        db.Update(user);
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Register a new User by username and password with passwordVerify.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="passwordVerify"></param>
        /// <returns></returns>
        public bool Register(string username, string password, string passwordVerify)
        {
            using (var db = new WebbShopContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Name == username);

                if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
                {
                    return false;
                }
                else if (user == null)
                {
                    if (password == passwordVerify)
                    {
                        db.Users.Add(new User { Name = username, Password = password });
                        db.SaveChanges();
                        return true;
                    }
                    else { return false; }
                }
                return false;
            }
        }

        /// <summary>
        /// Admin User can set or increase the amount of avaliable Books.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int SetAmount(int adminId, int bookId, int amount)
        {
            if (IsAdmin(adminId) && IsLoggedIn(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    var book = db.Books.FirstOrDefault(b => b.Id == bookId);

                    book.Amount += amount;
                    db.Update(book);
                    db.SaveChanges();
                    return book.Amount;
                }
            }
            return 0;
        }

        /// <summary>
        /// Admin User can get a List of all sold books.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public List<SoldBook> SoldItems(int adminId)
        {
            if (IsAdmin(adminId) && IsLoggedIn(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    return db.SoldBooks.ToList();
                }
            }
            return default;
        }

        /// <summary>
        /// Admin User can Update the information on a Book by keyword.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public bool UpdateBook(int adminId, int bookId, string title, string author, int price)
        {
            if (IsAdmin(adminId) && IsLoggedIn(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    var book = db.Books.FirstOrDefault(b => b.Id == bookId);

                    if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title) || string.IsNullOrEmpty(author) || string.IsNullOrWhiteSpace(author))
                    {
                        return false;
                    }
                    else
                    {
                        if (book != null)
                        {
                            book.Title = title;
                            book.Author = author;
                            book.Price = price;
                            db.Update(book);
                            db.SaveChanges();
                            return true;
                        }
                        else { return false; }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Admin User can update the name of a category by categoryId.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public bool UpdateCategory(int adminId, int categoryId, string categoryName)
        {
            if (IsAdmin(adminId) && IsLoggedIn(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    var bookCategory = db.BookCategories.FirstOrDefault(bc => bc.Id == categoryId);

                    if (string.IsNullOrEmpty(categoryName) || string.IsNullOrWhiteSpace(categoryName))
                    {
                        return false;
                    }
                    else
                    {
                        bookCategory.Name = categoryName;
                        db.BookCategories.Update(bookCategory);
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }
    }
}