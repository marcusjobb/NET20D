using System;
using System.Collections.Generic;
using System.Linq;
using WebshopAPI.Database;
using WebshopAPI.Models;
using WebshopAPI.Utils;

namespace WebshopAPI
{
    /// <summary>
    /// Webshop API, facade class containing back-end functions for webshop applications. Contains costumer functions and administrator functions
    /// </summary>
    public class API
    {
        #region USER

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>int</returns>
        public int? Login(string userName, string password)
        {
            using (var db = new EFContext())
            {
                var user = db.Users?.FirstOrDefault(u => u.Name == userName);
                if (user != null && user.Password == password && user.IsActive)
                {
                    user.SessionTimer = SessionTimer.SetSessionTimer(user.Id);
                    user.LastLogin = user.SessionTimer;
                    db.Update(user);
                    db.SaveChanges();
                    Startup.sessionCookie = user;

                    return user.Id;
                }
                else return null;
            }
        }

        /// <summary>
        /// Logout user
        /// </summary>
        /// <param name="userId"></param>
        public void Logout(int userId)
        {
            using (var db = new EFContext())
            {
                var user = db.Users?.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    user.SessionTimer = DateTime.MinValue;
                    db.Update(user);
                    db.SaveChanges();
                    Startup.sessionCookie = user;
                }
            }
        }

        /// <summary>
        /// Gets query result of book category(s)
        /// </summary>
        /// <returns>List<BookCategory></returns>
        public List<BookCategory> GetCategories()
        {
            using (var db = new EFContext())
            {
                return (db.BookCategories?.OrderBy(n => n.Name)).ToList();
            }
        }

        /// <summary>
        /// Gets query result of book category(s) matching parameter keyword.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>List<BookCategory></returns>
        public List<BookCategory> GetCategories(string keyword)
        {
            using (var db = new EFContext())
            {
                return db.BookCategories?.Where(x => x.Name.Contains(keyword)).OrderBy(n => n.Name).ToList();
            }
        }

        /// <summary>
        /// Gets query result of book(s) matching parameter categoryId.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>List<Book></returns>
        public List<Book> GetCategory(int categoryId)
        {
            using (var db = new EFContext())
            {
                return db.Books?.Where(b => b.CategoryId == categoryId).OrderBy(n => n.Title).ToList();
            }
        }

        /// <summary>
        /// Gets query result of book(s) matching parameter categoryId where book.Amount>0.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>List<Book></returns>
        public List<Book> GetAvailableBooks(int categoryId)
        {
            using (var db = new EFContext())
            {
                return db.Books?.Where(b => b.CategoryId == categoryId).Where(a => a.Amount > 0).OrderBy(n => n.Title).ToList();
            }
        }

        /// <summary>
        /// Gets query result of book matching parameter bookId.
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns>List<Book></returns>
        public Book GetBook(int bookId)
        {
            using (var db = new EFContext())
            {
                return (Book)(db.Books?.FirstOrDefault(b => b.Id == bookId));
            }
        }

        /// <summary>
        /// Gets query result of book(s) matching parameter keyword.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>List<Book></returns>
        public List<Book> GetBooks(string keyword)
        {
            using (var db = new EFContext())
            {
                return db.Books?.Where(x => x.Title.Contains(keyword)).OrderBy(n => n.Title).ToList();
            }
        }

        /// <summary>
        /// Gets query result of book(s) where book.Author matches parameter keyword.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>List<Book></returns>
        public List<Book> GetAuthors(string keyword)
        {
            using (var db = new EFContext())
            {
                return db.Books?.Where(x => x.Author.Contains(keyword)).OrderBy(n => n.Title).ToList();
            }
        }

        /// <summary>
        /// User buys book
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <returns>bool</returns>
        public bool BuyBook(int userId, int bookId)
        {
            bool isPurchaseSuccessful = false;
            using (var db = new EFContext())
            {
                var user = db.Users?.FirstOrDefault(x => x.Id == userId);

                if (user != null)
                {
                    if (SessionTimer.CheckSessionTimer(user.SessionTimer) == false)
                    {
                        var book = db.Books?.FirstOrDefault(x => x.Id == bookId);

                        if (book != null && book.Amount > 0)
                        {
                            SoldBook soldBook = new SoldBook();
                            soldBook.Title = book.Title;
                            soldBook.Author = book.Author;
                            soldBook.CategoryId = book.CategoryId;
                            soldBook.Price = book.Price;
                            soldBook.PurchaseDate = DateTime.Now;
                            soldBook.UserId = user.Id;

                            book.Amount--;

                            db.Update(book);
                            db.Update(soldBook);
                            isPurchaseSuccessful = true;
                            user.SessionTimer = SessionTimer.SetSessionTimer(user.Id);
                            Startup.sessionCookie = user;
                            db.Update(user);
                            db.SaveChanges();
                        }
                    }
                }
            }

            return isPurchaseSuccessful;
        }

        /// <summary>
        ///Sends ping to server
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>string</returns>
        public string Ping(int userId)
        {
            var ping = string.Empty;

            using (var db = new EFContext())
            {
                var user = db.Users?.FirstOrDefault(u => u.Id == userId);
                if (user != null && SessionTimer.CheckSessionTimer(user.SessionTimer) == false)
                {
                    ping = "Pong";
                    user.SessionTimer = DateTime.Now;
                    db.Update(user);
                    db.SaveChanges();
                    Startup.sessionCookie = user;
                }
            }

            return ping;
        }

        /// <summary>
        /// Registers new user
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="passwordverify"></param>
        /// <returns>bool</returns>
        public bool Register(string name, string password, string passwordverify)
        {
            bool isUserCreated = false;

            using (var db = new EFContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Name == name);
                if (user == null && password == passwordverify && password != "")
                {
                    user = new User { Name = name, Password = password, IsAdmin = false, IsActive = true };
                    db.Update(user);
                    db.SaveChanges();
                    isUserCreated = true;
                }
            }
            return isUserCreated;
        }

        /// <summary>
        /// ADDENDUM
        /// Retrieves all books in database
        /// </summary>
        /// <returns>Book List</returns>
        public List<Book> GetAllBooks()
        {
            using (var db = new EFContext())
            {
                return db.Books?.OrderBy(n => n.Title).ToList();
            }
        }

        #endregion USER

        #region ADMIN

        /// <summary>
        /// Adds new book
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <param name="amount"></param>
        /// <returns>bool</returns>
        public bool AddBook(int adminId, string title, string author, int price, int amount)
        {
            bool isBookAdded = false;
            if (Security.AdminCheck(adminId) && SessionTimer.AdminCheckSessionTimer(adminId) == false)
            {
                using (var db = new EFContext())
                {
                    var book = db.Books?.FirstOrDefault(i => i.Title == title);
                    if (book == null)
                    {
                        book = new Book();
                        book.Title = title;
                        book.Author = author;
                        book.Price = price;
                        book.Amount = amount;
                    }
                    else if (book != null)
                    {
                        book.Amount += amount;
                    }
                    SessionTimer.AdminSetSessionTimer(adminId);
                    db.Update(book);
                    db.SaveChanges();
                    isBookAdded = true;
                }
            }

            return isBookAdded;
        }

        /// <summary>
        /// Sets amount of book
        /// ADDENDUM: Added return value int amount
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="amount"></param>
        /// <returns>Tuple (bool, int)</returns>
        public (bool isAmountSet, int amount) SetAmount(int adminId, int bookId, int amount)
        {
            bool isAmountSet = false;
            if (Security.AdminCheck(adminId) && SessionTimer.AdminCheckSessionTimer(adminId) == false)
            {
                using (var db = new EFContext())
                {
                    var book = db.Books?.FirstOrDefault(i => i.Id == bookId);
                    if (book != null)
                    {
                        book.Amount = amount;
                        SessionTimer.AdminSetSessionTimer(adminId);
                        db.Update(book);
                        db.SaveChanges();
                        isAmountSet = true;
                    }
                }
            }
            return (isAmountSet,amount);
        }

        /// <summary>
        /// Lists user(s) in database
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>List</returns>
        public List<User> ListUsers(int adminId)
        {
            List<User> userList = new List<User>();
            if (Security.AdminCheck(adminId) && SessionTimer.AdminCheckSessionTimer(adminId) == false)
            {
                using (var db = new EFContext())
                {
                    SessionTimer.AdminSetSessionTimer(adminId);
                    return db.Users?.OrderBy(n => n.Name).ToList();
                }
            }
            else
            {
                return userList;
            }
        }

        /// <summary>
        /// Lists user(s) matching keyword
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="keyword"></param>
        /// <returns>List</returns>
        public List<User> FindUser(int adminId, string keyword)
        {
            List<User> userList = new List<User>();
            if (Security.AdminCheck(adminId) && SessionTimer.AdminCheckSessionTimer(adminId) == false)
            {
                using (var db = new EFContext())
                {
                    SessionTimer.AdminSetSessionTimer(adminId);
                    return db.Users?.Where(x => x.Name.Contains(keyword)).OrderBy(n => n.Name).ToList();
                }
            }
            else
            {
                return userList;
            }
        }

        /// <summary>
        /// Updates properties of book
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <returns>bool</returns>
        public bool UpdateBook(int adminId, int id, string title, string author, int price)
        {
            bool isBookUpdated = false;
            if (Security.AdminCheck(adminId) && SessionTimer.AdminCheckSessionTimer(adminId) == false)
            {
                using (var db = new EFContext())
                {
                    var book = db.Books?.FirstOrDefault(x => x.Id == id);
                    if (book != null)
                    {
                        book.Title = title;
                        book.Author = author;
                        book.Price = price;
                        SessionTimer.AdminSetSessionTimer(adminId);
                        db.Update(book);
                        db.SaveChanges();
                        isBookUpdated = true;
                    }
                }
            }

            return isBookUpdated;
        }

        /// <summary>
        /// Deletes book from table
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="amount"></param>
        /// <returns>bool</returns>
        public bool DeleteBook(int adminId, int bookId, int amount = 0)
        {
            bool isBookDeleted = false;
            if (Security.AdminCheck(adminId) && SessionTimer.AdminCheckSessionTimer(adminId) == false)
            {
                using (var db = new EFContext())
                {
                    var book = db.Books?.FirstOrDefault(x => x.Id == bookId);
                    if (book != null)
                    {
                        if (amount == 0)
                        {
                            book.Amount--;
                            db.Update(book);
                        }
                        else if (amount > 0)
                        {
                            book.Amount -= amount;
                            db.Update(book);
                        }
                        if (book.Amount <= 0)
                        {
                            db.Remove(book);
                        }
                        db.SaveChanges();
                        SessionTimer.AdminSetSessionTimer(adminId);
                        isBookDeleted = true;
                    }
                }
            }
            return isBookDeleted;
        }

        /// <summary>
        /// Adds category to table
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="name"></param>
        /// <returns>bool</returns>
        public bool AddCategory(int adminId, string name)
        {
            bool isCategoryCreated = false;
            if (Security.AdminCheck(adminId) && SessionTimer.AdminCheckSessionTimer(adminId) == false)
            {
                using (var db = new EFContext())
                {
                    var category = db.BookCategories?.FirstOrDefault(x => x.Name == name);

                    if (category == null)
                    {
                        category = new BookCategory();
                        category.Name = name;
                        SessionTimer.AdminSetSessionTimer(adminId);
                        db.Update(category);
                        db.SaveChanges();
                        isCategoryCreated = true;
                    }
                }
            }
            return isCategoryCreated;
        }

        /// <summary>
        /// Adds categoryId to book
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="categoryId"></param>
        /// <returns>bool</returns>
        public bool AddBookToCategory(int adminId, int bookId, int categoryId)
        {
            bool isBookAddedToCategory = false;
            if (Security.AdminCheck(adminId) && SessionTimer.AdminCheckSessionTimer(adminId) == false)
            {
                using (var db = new EFContext())
                {
                    var book = db.Books?.FirstOrDefault(b => b.Id == bookId);

                    if (book != null)
                    {
                        var category = db.BookCategories?.FirstOrDefault(c => c.Id == categoryId);

                        if (category != null)
                        {
                            book.CategoryId = category.Id;
                            SessionTimer.AdminSetSessionTimer(adminId);
                            db.Update(category);
                            db.SaveChanges();
                            isBookAddedToCategory = true;
                        }
                    }
                }
            }
            return isBookAddedToCategory;
        }

        /// <summary>
        /// Updates category
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <param name="name"></param>
        /// <returns>bool</returns>
        public bool UpdateCategory(int adminId, int categoryId, string name)
        {
            bool isCategoryUpdated = false;

            if (Security.AdminCheck(adminId) && SessionTimer.AdminCheckSessionTimer(adminId) == false)
            {
                using (var db = new EFContext())
                {
                    var category = db.BookCategories?.FirstOrDefault(c => c.Id == categoryId);

                    if (category != null)
                    {
                        category.Name = name;
                        SessionTimer.AdminSetSessionTimer(adminId);
                        db.Update(category);
                        db.SaveChanges();
                        isCategoryUpdated = true;
                    }
                }
            }

            return isCategoryUpdated;
        }

        /// <summary>
        /// Deletes category from table
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <returns>bool</returns>
        public bool DeleteCategory(int adminId, int categoryId)
        {
            bool isCategoryDeleted = false;
            if (Security.AdminCheck(adminId) && SessionTimer.AdminCheckSessionTimer(adminId) == false)
            {
                using (var db = new EFContext())
                {
                    var category = db.BookCategories?.FirstOrDefault(c => c.Id == categoryId);

                    if (category != null)
                    {
                        var book = db.Books?.FirstOrDefault(c => c.CategoryId == categoryId);

                        if (book == null)
                        {
                            SessionTimer.AdminSetSessionTimer(adminId);
                            db.BookCategories.Remove(category);
                            db.SaveChanges();
                            isCategoryDeleted = true;
                        }
                    }
                }
            }
            return isCategoryDeleted;
        }

        /// <summary>
        /// Adds new user to database
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns>bool</returns>
        public bool AddUser(int adminId, string name, string password)
        {
            bool isUserCreated = false;
            if (Security.AdminCheck(adminId) && SessionTimer.AdminCheckSessionTimer(adminId) == false)
            {
                using (var db = new EFContext())
                {
                    var user = db.Users?.FirstOrDefault(u => u.Name == name);

                    if (user == null)
                    {
                        user = new User { Name = name, Password = password, IsAdmin = false, IsActive = true };

                        if (user.Password == "")
                        {
                            user.Password = "Codic2021";
                        }
                        SessionTimer.AdminSetSessionTimer(adminId);
                        db.Update(user);
                        db.SaveChanges();
                        isUserCreated = true;
                    }
                }
            }
            return isUserCreated;
        }

        #endregion ADMIN

        #region ADV ADMIN

        /// <summary>
        /// Lists sold book(s)
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>List</returns>
        public List<SoldBook> SoldItems(int adminId)
        {
            List<SoldBook> bookList = new List<SoldBook>();
            if (Security.AdminCheck(adminId) && SessionTimer.AdminCheckSessionTimer(adminId) == false)
            {
                using (var db = new EFContext())
                {
                    SessionTimer.AdminSetSessionTimer(adminId);
                    return db.SoldBooks?.OrderBy(n => n.PurchaseDate).ToList();
                }
            }
            else
            {
                return bookList;
            }
        }

        /// <summary>
        /// Calculates sum of price of sold book(s)
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>int</returns>
        public int? MoneyEarned(int adminId)
        {
            int? earned = null;
            if (Security.AdminCheck(adminId) && SessionTimer.AdminCheckSessionTimer(adminId) == false)
            {
                using (var db = new EFContext())
                {
                    var books = db.SoldBooks?.ToList();
                    earned = books.Sum(b => b.Price);
                    SessionTimer.AdminSetSessionTimer(adminId);
                    return earned;
                }
            }
            else
            {
                return earned;
            }
        }

        /// <summary>
        /// Gets customer who bought most books
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>string</returns>
        public User BestCostumer(int adminId)
        {
            User bestCostumer = new User();
            if (Security.AdminCheck(adminId) && SessionTimer.AdminCheckSessionTimer(adminId) == false)
            {
                using (var db = new EFContext())
                {
                    //Solution found at:https://stackoverflow.com/questions/2655759/how-to-get-the-most-common-value-in-an-int-array-c

                    var costumer = db.SoldBooks.GroupBy(u => u.UserId).OrderByDescending(u => u.Count()).Select(u => u.Key).First();

                    bestCostumer = db.Users?.FirstOrDefault(u => u.Id == costumer);
                    SessionTimer.AdminSetSessionTimer(adminId);
                    return bestCostumer;
                }
            }
            else
            {
                return bestCostumer;
            }
        }

        /// <summary>
        /// Gives user administrator privileges
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns>bool</returns>
        public bool Promote(int adminId, int userId)
        {
            bool isPromoted = false;
            if (Security.AdminCheck(adminId) && SessionTimer.AdminCheckSessionTimer(adminId) == false)
            {
                using (var db = new EFContext())
                {
                    var user = db.Users?.FirstOrDefault(u => u.Id == userId);

                    if (user != null)
                    {
                        user.IsAdmin = true;

                        SessionTimer.AdminSetSessionTimer(adminId);
                        db.Update(user);
                        db.SaveChanges();

                        isPromoted = true;
                    }
                }
            }

            return isPromoted;
        }

        /// <summary>
        /// Revokes user's administrator privileges
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns>bool</returns>
        public bool Demote(int adminId, int userId)
        {
            bool isDemoted = false;
            if (Security.AdminCheck(adminId) && SessionTimer.AdminCheckSessionTimer(adminId) == false)
            {
                using (var db = new EFContext())
                {
                    var user = db.Users?.FirstOrDefault(u => u.Id == userId);

                    if (user != null)
                    {
                        user.IsAdmin = false;

                        SessionTimer.AdminSetSessionTimer(adminId);
                        db.Update(user);
                        db.SaveChanges();

                        isDemoted = true;
                    }
                }
            }
            return isDemoted;
        }

        /// <summary>
        /// Activates user
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns>bool</returns>
        public bool ActivateUser(int adminId, int userId)
        {
            bool isActivated = false;
            if (Security.AdminCheck(adminId) && SessionTimer.AdminCheckSessionTimer(adminId) == false)
            {
                using (var db = new EFContext())
                {
                    var user = db.Users?.FirstOrDefault(u => u.Id == userId);

                    if (user != null)
                    {
                        user.IsActive = true;

                        SessionTimer.AdminSetSessionTimer(adminId);
                        db.Update(user);
                        db.SaveChanges();

                        isActivated = true;
                    }
                }
            }
            return isActivated;
        }

        /// <summary>
        /// Inactivates user
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns>bool</returns>
        public bool InactivateUser(int adminId, int userId)
        {
            bool isInactivated = false;
            if (Security.AdminCheck(adminId) && SessionTimer.AdminCheckSessionTimer(adminId) == false)
            {
                using (var db = new EFContext())
                {
                    var user = db.Users?.FirstOrDefault(u => u.Id == userId);

                    if (user != null)
                    {
                        user.IsActive = false;

                        SessionTimer.AdminSetSessionTimer(adminId);
                        db.Update(user);
                        db.SaveChanges();

                        isInactivated = true;
                    }
                }
            }
            return isInactivated;
        }

        #endregion ADV ADMIN
    }
}