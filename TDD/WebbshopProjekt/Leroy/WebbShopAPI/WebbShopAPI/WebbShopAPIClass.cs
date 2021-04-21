using System;
using System.Collections.Generic;
using System.Linq;
using WebbShopAPI.Model;
using WebbShopAPI.Database;

namespace WebbShopAPI
{
    public static class WebbShopAPIClass
    {
        /// <summary>
        /// Log in using name and password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        ///         
        public static User LogIn(string userName, string password)
        {
            using (var db = new WebbShopLeeContext())
            {
                try
                {
                    var user = db.Users.FirstOrDefault(_ => _.Name == userName && _.Password == password);
                    if (user != null)
                    {
                        user.SesionTimer = DateTime.Now;
                        user.LastLogIn = DateTime.Now;
                        db.SaveChanges();
                        return user;
                    }
                }
                catch
                {
                    return new User();
                }
                return new User();
            }
        }
        /// <summary>
        /// Logs a user out
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static bool LogOut(User userID)
        {
            if (userID != null)
                using (var db = new WebbShopLeeContext())
                {
                    try
                    {

                        var user = db.Users.FirstOrDefault(_ => _.ID == userID.ID);
                        if (user != null)
                        {
                            user.SesionTimer = new DateTime();
                            db.Update(user);
                            db.SaveChanges();
                            return true;
                        }
                    }
                    catch (Exception e)
                    {
                        e.ToString();
                    }
                }
            return false;
        }
        /// <summary>
        /// Returns category
        /// </summary>
        /// <returns></returns>
        public static List<BookCategory> GetCategories()
        {
            using (var db = new WebbShopLeeContext())
            {
                try
                {
                    var categories = db.BookCategories.Where(_ => _.Name != null);
                    return categories.ToList();
                }
                catch (Exception e)
                {
                    e.ToString();
                }
            }
            return new List<BookCategory>();
        }
        /// <summary>
        /// Returns a list of categories
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<BookCategory> GetCategories(string keyword)
        {
            using (var db = new WebbShopLeeContext())
            {
                var categories = db.BookCategories.Where(_ => _.Name.Contains($"{keyword}")).ToList();
                return categories;
            }
        }
        /// <summary>
        /// Returns a list of book matching a category
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public static List<Book> GetCategory(BookCategory categoryID)
        {
            using (var db = new WebbShopLeeContext())
            {
                var books = db.Books.Where(_ => _.CategoryID == categoryID.ID).ToList();
                return books;
            }
            //return new List<Book>();
        }
        /// <summary>
        /// Returns a list with available book matching category
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public static List<Book> GetAvailableBooks(BookCategory categoryID)
        {
            using (var db = new WebbShopLeeContext())
            {
                var books = db.Books.Where(_ => _.Amount > 0 && _.CategoryID == categoryID.ID);
                return books.ToList();
            }
            //return new List<Book>();
        }
        /// <summary>
        /// Returns a book based on ID
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns></returns>
        public static Book GetBook(Book bookID)
        {
            using (var db = new WebbShopLeeContext())
            {
                var book = db.Books.FirstOrDefault(_ => _.ID == bookID.ID);
                if (book != null) 
                    return book;
            }
            return new Book();
        }
        /// <summary>
        /// Returns a book based on a keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static Book GetBook(string keyword)
        {
            using (var db = new WebbShopLeeContext())
            {
                var book = db.Books.FirstOrDefault(_ => _.Title.Contains(keyword));
                if (book != null) return book;
            }
            return new Book();
        }
        /// <summary>
        /// Returns title, author price and category of a book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public static string GetInformationAboutBook(Book book)
        {
            string category = "";
            using (var db = new WebbShopLeeContext())
            {
                var cat = db.BookCategories.FirstOrDefault(_ => _.ID == book.CategoryID);
                if (cat != null)
                category = cat.Name;
                return $"Title: {book.Title}\nAuthor: {book.Author}\nPrice: {book.Price}\nCategory: {category}\nAmount available: {book.Amount}";
            }
        }
        /// <summary>
        /// Returns a list of books based on a keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<Book> GetBooks(string keyword)
        {
            using (var db = new WebbShopLeeContext())
            {
                var books = db.Books.Where(_ => _.Title.Contains(keyword)).Distinct();
                return books.ToList();
            }
            //return new List<Book>();
        }
        /// <summary>
        /// Returns a list of books based on the author
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<Book> GetAuthor(string keyword)
        {
            using (var db = new WebbShopLeeContext())
            {
                try
                {

                    var books = db.Books.Where(_ => _.Author.Contains(keyword)).ToList();
                    return books;
                }
                catch (Exception e)
                {
                    e.ToString();
                    return new List<Book>();
                }
            }
        }
        /// <summary>
        /// Returns true if the book was successfuly bought
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="bookID"></param>
        /// <returns></returns>
        public static bool BuyBook(User userID, Book bookID)
        {
            using (var db = new WebbShopLeeContext())
            {
                if ((DateTime.Now - userID.SesionTimer).TotalMinutes < 15)
                {
                    var book = db.Books.FirstOrDefault(_ => _.ID == bookID.ID);
                    if (book != null && book.Amount > 0)
                    {
                        var sold = db.SoldBooks.Add(new SoldBook
                        {
                            Title = bookID.Title,
                            Author = bookID.Author,
                            Price = bookID.Price,
                            CategoryID = bookID.CategoryID,
                            PurchaseDate = DateTime.Now,
                            UserID = userID.ID
                        });
                        book.Amount--;
                        db.Update(book);
                        var a = db.Users.FirstOrDefault(_ => _.ID == userID.ID);
                        a.SesionTimer = DateTime.Now;
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Returns pong if user is active and the session time hasn't gone over the timeout
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static string Ping(User userID)
        {
            using (var db = new WebbShopLeeContext())
            {
                if (userID != null)
                    try
                    {
                        if ((userID.SesionTimer - DateTime.Now).TotalMinutes < 15)
                        {
                            userID.SesionTimer = DateTime.Now;
                            var a = db.Users.FirstOrDefault(_ => _.ID == userID.ID);
                            a.SesionTimer = DateTime.Now;
                            db.SaveChanges();
                            return "Pong";
                        }
                    }
                    catch 
                    {
                        return string.Empty;
                    }

            }
            return string.Empty;
        }
        /// <summary>
        /// Returns tru if a new user was created
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="passwordVerify"></param>
        /// <returns></returns>
        public static bool Register(string name, string password, string passwordVerify)
        {
            using (var db = new WebbShopLeeContext())
            {
                if (name != "" && password != "" && password == passwordVerify)
                {
                    var exicting = db.Users.FirstOrDefault(_ => _.Name == name);
                    if (exicting == null)
                    {
                        db.Users.Add(new User
                        {
                            Name = $"{name}",
                            Password = $"{password}",
                            IsAdmin = false,
                            IsActive = true,
                        });
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Returns true if a book was successfully added
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="bookID"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static bool AddBook(User adminID, Book bookID, string title, string author, int price, int amount)
        {
            if (adminID.IsAdmin)
            {
                using (var db = new WebbShopLeeContext())
                {
                    var exicting = db.Books.FirstOrDefault(_ => _.ID == bookID.ID);
                    if (exicting == null)
                    {
                        db.Books.Add(new Book
                        {
                            Title = $"{title}",
                            Author = $"{author}",
                            Price = price,
                            Amount = amount
                        });
                        var a = db.Users.FirstOrDefault(_ => _.ID == adminID.ID);
                        a.SesionTimer = DateTime.Now;
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        exicting.Amount += amount;
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Sets the amout of books available
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="bookID"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        //This funktion needs to be greenlighted by the teachers
        public static bool SetAmount(User adminID, Book bookID, int amount)
        {
            if (adminID.IsAdmin)
            {
                using (var db = new WebbShopLeeContext())
                {
                    var exicting = db.Books.FirstOrDefault(_ => _.ID == bookID.ID);
                    if (exicting != null)
                    {
                        exicting.Amount = amount;
                        var a = db.Users.FirstOrDefault(_ => _.ID == adminID.ID);
                        a.SesionTimer = DateTime.Now;
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Returns a list of users if IsAdmin is true
        /// </summary>
        /// <param name="adminID"></param>
        /// <returns></returns>
        public static List<User> ListUsers(User adminID)
        {
            if (adminID.IsAdmin)
            {
                using (var db = new WebbShopLeeContext())
                {
                    var users = db.Users.Where(_ => _.ID > 0);
                    var a = db.Users.FirstOrDefault(_ => _.ID == adminID.ID);
                    a.SesionTimer = DateTime.Now;
                    db.SaveChanges();
                    return users.ToList();
                }
            }
            return new List<User>();
        }
        /// <summary>
        /// Returns list of user if IsAdmin is true based on user
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<User> FindUsers(User adminID, string keyword)
        {
            if (adminID.IsAdmin)
            {
                using (var db = new WebbShopLeeContext())
                {
                    var users = db.Users.Where(_ => _.ID > 0 && _.Name.Contains(keyword));
                    var a = db.Users.FirstOrDefault(_ => _.ID == adminID.ID);
                    if (adminID.IsAdmin && a != null)
                        a.SesionTimer = DateTime.Now;
                    db.SaveChanges();
                    return users.ToList();
                }
            }
            return new List<User>();
        }
        /// <summary>
        /// Returns true if a book is successfully updated and IsAdmin is true
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="bookID"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public static bool UpdateBook(User adminID, Book bookID, string title, string author, int price)
        {
            if (adminID.IsAdmin)
            {
                using (var db = new WebbShopLeeContext())
                {
                    var exicting = db.Books.FirstOrDefault(_ => _.ID == bookID.ID);
                    if (exicting != null)
                    {
                        exicting.Title = title;
                        exicting.Author = author;
                        exicting.Price = price;
                        var a = db.Users.FirstOrDefault(_ => _.ID == adminID.ID);
                        a.SesionTimer = DateTime.Now;
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Returns true if book was successfully deleted ad IsAmin is true
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="bookID"></param>
        /// <returns></returns>
        public static bool DeleteBook(User adminID, Book bookID)
        {
            if (adminID.IsAdmin)
            {
                using (var db = new WebbShopLeeContext())
                {
                    var exicting = db.Books.FirstOrDefault(_ => _.ID == bookID.ID);
                    if (exicting != null)
                    {
                        db.Books.Remove(exicting);
                        var a = db.Users.FirstOrDefault(_ => _.ID == adminID.ID);
                        a.SesionTimer = DateTime.Now;
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Returns true if a category was successfully added and IsAdmin is true
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public static bool AddCategory(User adminID, string category)
        {
            if (adminID.IsAdmin)
            {
                using (var db = new WebbShopLeeContext())
                {
                    var exicting = db.BookCategories.FirstOrDefault(_ => _.Name.Contains(category));
                    if (exicting == null)
                    {
                        db.BookCategories.Add(new BookCategory
                        {
                            Name = category
                        });
                        var a = db.Users.FirstOrDefault(_ => _.ID == adminID.ID);
                        a.SesionTimer = DateTime.Now;
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Returns tru if a book was successfully added to a category and IsAdmin is true
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="bookID"></param>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public static bool AddBookToCategory(User adminID, Book bookID, BookCategory categoryID)
        {
            if (adminID.IsAdmin)
            {
                using (var db = new WebbShopLeeContext())
                {
                    var exicting = db.Books.FirstOrDefault(_ => _.ID == bookID.ID);
                    if (exicting != null)
                    {
                        exicting.CategoryID = categoryID.ID;
                        var a = db.Users.FirstOrDefault(_ => _.ID == adminID.ID);
                        a.SesionTimer = DateTime.Now;
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Returns true if category was updated and IsAdmin if true
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="categoryID"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        /// 
        public static bool UpdateCategory(User adminID, BookCategory categoryID, string name)
        {
            if (adminID.IsAdmin)
            {
                using (var db = new WebbShopLeeContext())
                {
                    var exicting = db.BookCategories.FirstOrDefault(_ => _.ID == categoryID.ID);
                    if (exicting != null)
                    {
                        exicting.Name = name;
                        var a = db.Users.FirstOrDefault(_ => _.ID == adminID.ID);
                        a.SesionTimer = DateTime.Now;
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Returns true if category was deleted and IsAdmin is true
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public static bool DeleteCategory(User adminID, BookCategory categoryID)
        {
            if (adminID.IsAdmin)
            {
                using (var db = new WebbShopLeeContext())
                {
                    var exicting = db.BookCategories.FirstOrDefault(_ => _.ID == categoryID.ID);
                    if (exicting != null)
                    {
                        db.BookCategories.Remove(exicting);
                        var a = db.Users.FirstOrDefault(_ => _.ID == adminID.ID);
                        a.SesionTimer = DateTime.Now;
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Returns tru if a new user is added and IsAdmin is true
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool AddUser(User adminID, string name, string password)
        {
            if (adminID.IsAdmin)
            {
                using (var db = new WebbShopLeeContext())
                {
                    if (name != "" && password != "")
                    {
                        var exicting = db.Users.FirstOrDefault(_ => _.Name == name);
                        if (exicting == null)
                        {
                            db.Users.Add(new User
                            {
                                Name = $"{name}",
                                Password = $"{password}",
                                IsAdmin = false,
                                IsActive = true
                            });
                            var a = db.Users.FirstOrDefault(_ => _.ID == adminID.ID);
                            a.SesionTimer = DateTime.Now;
                            db.SaveChanges();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Returns a list of sold books and if IsAdmin is true
        /// </summary>
        /// <param name="adminID"></param>
        /// <returns></returns>
        public static List<SoldBook> SoldItems(User adminID)
        {
            if (adminID.IsAdmin)
            {
                using (var db = new WebbShopLeeContext())
                {
                    var booksSold = db.SoldBooks.Where(_=>_.ID != 0);
                    var a = db.Users.FirstOrDefault(_ => _.ID == adminID.ID);
                    a.SesionTimer = DateTime.Now;
                    db.SaveChanges();
                    return booksSold.ToList();
                }
            }
            return new List<SoldBook>();
        }

        /// <summary>
        /// Returns the amout of money earned and if IsAdmin is true
        /// </summary>
        /// <param name="adminID"></param>
        /// <returns></returns>
        public static int MoneyEarned(User adminID)
        {
            if (adminID.IsAdmin)
            {
                using (var db = new WebbShopLeeContext())
                {
                    var earnings = db.SoldBooks.Where(_ => _.ID > 0).Sum(_ => _.Price);
                    var a = db.Users.FirstOrDefault(_ => _.ID == adminID.ID);
                    a.SesionTimer = DateTime.Now;
                    db.SaveChanges();
                    return earnings;
                }
            }
            return 0;
        }
        /// <summary>
        /// Returns a user and if IsAdmin is true
        /// </summary>
        /// <param name="adminID"></param>
        /// <returns></returns>
        public static User BestCustomer(User adminID)
        {
            if (adminID.IsAdmin)
            {
                try
                {
                    using (var db = new WebbShopLeeContext())
                    {
                        var a = db.Users.FirstOrDefault(_ => _.ID == adminID.ID);
                        a.SesionTimer = DateTime.Now;
                        db.SaveChanges();
                        try
                        {
                            List<SoldBook> soldBooks = WebbShopAPIClass.SoldItems(adminID);
                            //var bestCustomer = db.SoldBooks.OrderByDescending(_ => _.UserID).Count();
                            var buyers = db.SoldBooks.Where(_ => _.UserID > 0).ToList();
                            var bestCustomer = buyers.GroupBy(_ => _.UserID).OrderByDescending(_ => _.Count())
                                .Select(_ => _.Key).First();
                            User user = db.Users.FirstOrDefault(_ => _.ID == bestCustomer);
                            if (user != null)
                                return user;
                        }
                        catch (Exception e)
                        {
                            e.ToString();
                            return new User();
                        }
                    }
                }
                catch (Exception e)
                {
                    e.ToString();
                }
            }
            return new User();
        }
        /// <summary>
        /// Returns  true if a user was promoted and if IsAdmin is true
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static bool Promote(User adminID, User userID)
        {
            if (adminID.IsAdmin)
            {
                using (var db = new WebbShopLeeContext())
                {
                    try
                    {
                        var user = db.Users.FirstOrDefault(_ => _.ID == userID.ID);
                        if (user != null)
                        {
                            user.IsAdmin = true;
                            var a = db.Users.FirstOrDefault(_ => _.ID == adminID.ID);
                            a.SesionTimer = DateTime.Now;
                            db.SaveChanges();
                            return true;
                        }
                    }
                    catch (Exception e)
                    {
                        e.ToString();
                    }

                }
            }
            return false;
        }
        /// <summary>
        /// Returns true if user id demoted and if IsAdmin in true
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static bool Demote(User adminID, User userID)
        {
            if (adminID.IsAdmin)
            {
                using (var db = new WebbShopLeeContext())
                {
                    var user = db.Users.FirstOrDefault(_ => _.ID == userID.ID);
                    if (user != null)
                    {
                        user.IsAdmin = false;
                        var a = db.Users.FirstOrDefault(_ => _.ID == adminID.ID);
                        a.SesionTimer = DateTime.Now;
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Returns true if user is actime ad if IsAdmin is true
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static bool ActivateUser(User adminID, User userID)
        {
            if (adminID.IsAdmin)
            {
                using (var db = new WebbShopLeeContext())
                {
                    var user = db.Users.FirstOrDefault(_ => _.ID == userID.ID);
                    if (user != null)
                    {
                        user.IsActive = true;
                        var a = db.Users.FirstOrDefault(_ => _.ID == adminID.ID);
                        a.SesionTimer = DateTime.Now;
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Returns true if user was inactivated and IsAdmin it true
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static bool InctivateUser(User adminID, User userID)
        {
            if (adminID.IsAdmin)
            {
                using (var db = new WebbShopLeeContext())
                {
                    var user = db.Users.FirstOrDefault(_ => _.ID == userID.ID);
                    if (user != null)
                    {
                        user.IsActive = false;
                        var a = db.Users.FirstOrDefault(_ => _.ID == adminID.ID);
                        a.SesionTimer = DateTime.Now;
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <param name="admin"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static bool DeleteUser(User adminID, User userID)
        {
            if(adminID.IsAdmin)
            {
                using (var db = new WebbShopLeeContext())
                {
                    var user = db.Users.FirstOrDefault(_ => _.ID == userID.ID);
                    if (adminID.ID != user.ID)
                    {
                        db.Users.Remove(user);
                        var a = db.Users.FirstOrDefault(_ => _.ID == adminID.ID);
                        a.SesionTimer = DateTime.Now;
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
