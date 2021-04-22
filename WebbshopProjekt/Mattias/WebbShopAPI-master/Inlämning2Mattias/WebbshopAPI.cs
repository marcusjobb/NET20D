using System;
using System.Collections.Generic;
using System.Linq;
using WebbShopAPI.Models;

namespace WebbShopAPI
{
    public static class WebbshopAPI
    {
        private static readonly MyContext db = new MyContext();
        /// <summary>
        /// Handles the login of users
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static int Login(string username, string password)
        {
            var user = db.Users.FirstOrDefault(u => username == u.Name && password == u.Password);
            if(user != null && user.IsActive)
            {
                user.LastLogin = DateTime.Now;
                user.SessionTimer = SetSessionTimer(user.Id);
                db.Users.Update(user);
                db.SaveChanges();
                return user.Id;
            }
            return 0;
        }

        /// <summary>
        /// Handles the logout of user
        /// </summary>
        /// <param name="userId"></param>
        public static void Logout(int userId)
        {
            var user = db.Users.FirstOrDefault(u => userId == u.Id);
            user.SessionTimer = default;
            db.SaveChanges();
        }
        /// <summary>
        /// Handles validation of users with admin permissions
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool IsAdmin(int userId)
        {
            var user = db.Users.FirstOrDefault(u => userId == u.Id && u.IsAdmin);
            return user != null;
        }
        /// <summary>
        /// Returns a list of categories
        /// </summary>
        /// <returns></returns>
        public static List<string> GetCategories()
        {
            return db.Category.Select(c => c.Name).ToList();
        }
        /// <summary>
        /// Returns a list of categories based on keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<BookCategory> GetCategories(string keyword)
        {
            return db.Category.Where(c => c.Name.Contains(keyword)).ToList();
        }
        /// <summary>
        /// Returns a list of categories based on categoryId
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public static BookCategory GetCategory(int categoryId)
        {
            return db.Category.SingleOrDefault(c => c.Id == categoryId);
        }
        /// <summary>
        /// Return a list of books in a category avaliable for purchase
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public static List<Books> GetAvailableBooks(int categoryId)
        {
            return db.Books.Where(c => c.Amount > 0 && c.Category == categoryId).ToList();
        }
        /// <summary>
        /// Return a book based on specific bookId
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public static List<Books> GetBook(int bookId)
        {
            return db.Books.Where(c => c.Id == bookId).ToList();
        }
        /// <summary>
        /// Return a list of books based on keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<Books> GetBooks(string keyword)
        {
            return db.Books.Where(c => c.Title.Contains(keyword)).ToList();
        }
        /// <summary>
        /// Lists all avaliable books
        /// </summary>
        /// <returns></returns>
        public static List<Books> GetBooks()
        {
            return db.Books.Select(row => row).ToList();
        }
        /// <summary>
        /// Return a list of authors based on keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<Books> GetAuthors(string keyword)
        {
            //List of matching books by keyword
            return db.Books.Where(c => c.Author.Contains(keyword)).ToList();
        }
        /// <summary>
        /// Handles the purchase of a book.
        /// Parameters for purchase to go through
        /// if user has a valid session time, book is in stock
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public static bool BuyBook(int userId, int bookId)
        {
            var user = db.Users.FirstOrDefault(u => userId == u.Id);
            var books = db.Books.FirstOrDefault(b => b.Id == bookId);
            if (user!=null && books!=null)
            {
                if (books.Amount != 0 && Ping(userId) != string.Empty)
                {
                    books.Amount -= 1;
                    var soldbooks = new SoldBooks()
                    {
                        Title = books.Title,
                        Author = books.Author,
                        Price = books.Price,
                        Amount = +1,
                        Category = books.Category,
                        PurchaseDate = DateTime.Now.ToString(),
                        UserId = userId,
                    };
                    db.Books.Update(books);
                    db.SoldBooks.AddRange(soldbooks);
                    db.SaveChanges();
                    SetSessionTimer(userId);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Handles registration of a user not already in the system
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="passVerify"></param>
        /// <returns></returns>
        public static bool Register(string name, string password, string passVerify)
        {
            if(name!=string.Empty && password == passVerify)
            {
                var user = new User()
                {
                    Name = name,
                    Password = password,
                    IsActive = true
                };
                var checkuser = db.Users.Any(u => u.Name == name);
                if (!checkuser && password!=null)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Handles adding a new book with its information to the database
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static bool AddBook(int adminId, string title, string author, int price, int amount)
        {
            var exists = db.Books.Any(t => t.Title == title);

            if (IsAdmin(adminId) && !exists)
            {
                var books = new Books()
                {
                    Title = title,
                    Author = author,
                    Price = price,
                    Amount = amount
                };
                db.Books.AddRange(books);
                db.SaveChanges();
                return true;
            }
            else if (IsAdmin(adminId) && exists)
            {
                var bookAmount = db.Books.SingleOrDefault(b => b.Title == title);
                bookAmount.Amount++;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Allows an admin to set the amount of available books to purchase
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public static string SetAmount(int adminId, int bookId)
        {
            int amount;
            if (IsAdmin(adminId))
            {
                Console.WriteLine("Set amount: ");
                var newAmount = Console.ReadLine();
                var books = db.Books.SingleOrDefault(c => c.Id == bookId);
                if (int.TryParse(newAmount, out amount) && books!=null)
                {
                    books.Amount = amount;
                    db.SaveChanges();
                    return (string)$"\nAmount set to: {amount}";
                }
            }
            return (string)$"\nSomething went wrong, double check the id you entered";
        }
        /// <summary>
        /// Returns a name list of all users in the database
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public static List<string> ListUsers(int adminId)
        {
            if (IsAdmin(adminId))
            {
                return db.Users.Select(u => u.Name).ToList();
            }
            return null;
        }
        /// <summary>
        /// Return users that matches a search by keyword
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<User> FindUser(int adminId, string keyword)
        {
            if (IsAdmin(adminId))
            {
                return db.Users.Where(u => u.Name.Contains(keyword)).ToList();
            }
            return null;
        }
        /// <summary>
        /// Update a specific books credentials
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public static bool UpdateBook(int adminId, int bookId, string title, string author, int price)
        {
            var books = db.Books.SingleOrDefault(c => c.Id == bookId);
            if (IsAdmin(adminId) && books!=null)
            {
                books.Title = title;
                books.Author = author;
                books.Price = price;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Removes a specific book from the database
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public static bool DeleteBook(int adminId, int bookId)
        {
            var books = db.Books.FirstOrDefault(b => b.Id == bookId);
            if (IsAdmin(adminId))
            {
                try
                {
                    db.Books.Remove(books);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// Adds a new category if credentials are valid
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="name"></param>
        public static bool AddCategory(int adminId, string name)
        {
            if (IsAdmin(adminId) && !db.Category.Any(c => c.Name == name) && name != string.Empty)
            {
                db.Category.AddRange(new List<BookCategory>
                    {
                        new BookCategory{ Name=name },
                    });
                db.SaveChanges();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Add category to a book based on book and categoryId
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public static bool AddBookToCategory(int adminId, int bookId, int categoryId)
        {
            if (IsAdmin(adminId))
            {
                var book = db.Books.FirstOrDefault(c => c.Id == bookId);
                var category = db.Category.Any(c => c.Id == categoryId);
                if (category && book!=null)
                {
                    book.Category = categoryId;
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Update an existing category name
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool UpdateCategory(int adminId, int categoryId, string name)
        {
            if (IsAdmin(adminId))
            {
                var update = db.Category.FirstOrDefault(c => c.Id == categoryId);
                if (update != null && name!=string.Empty)
                {
                    update.Name = name;
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Delete a specific category
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public static bool DeleteCategory(int adminId, int categoryId)
        {
            if (IsAdmin(adminId))
            {
                var books = GetAvailableBooks(categoryId);
                var delete = db.Category.FirstOrDefault(c => c.Id == categoryId);
                if (books != default && delete!=null)
                {
                    db.Category.Remove(delete);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Add a user to the database
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool AddUser(int adminId, string name, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.Name.Contains(name));
            if (name != string.Empty && password != string.Empty && IsAdmin(adminId) && user == null)
            {
                var userName = new User()
                {
                    Name = name,
                    Password = password,
                    IsActive = true
                };
                db.Update(userName);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Sets the users sessionTimer thats used to validate a users activity
        /// </summary>
        /// <param name="userId"></param>
        public static DateTime SetSessionTimer(int userId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == userId);
            user.SessionTimer = DateTime.Now.AddMinutes(15);
            db.SaveChanges();
            return user.SessionTimer;
        }
        /// <summary>
        /// Checks if user has a valid session time to allow for certain actions
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string Ping(int userId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == userId);
            if (user.SessionTimer > DateTime.Now && user != null)
            {
                return "Pong";
            }
            return string.Empty;
        }
        /// <summary>
        /// Return a list of sold items
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public static List<string> SoldItems(int adminId)
        {
            var books = db.SoldBooks.Select(u => u.Title).ToList();
            if (IsAdmin(adminId))
            {
                return books;
            }
            return default;
        }
        /// <summary>
        /// Return the total amount of books sold
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public static int MoneyEarned(int adminId)
        {
            if (IsAdmin(adminId))
            {
                var books = db.SoldBooks.Sum(u => u.Price);
                return books;
            }
            return default;
        }
        /// <summary>
        /// Finds the user with the most books purchased
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public static int BestCustomer(int adminId)
        {
            if (IsAdmin(adminId))
            {
                var bestCustomer = db.SoldBooks.GroupBy(x => x.UserId)
                       .Select(u => new { User = u.Key, Bought = u.Distinct().Count() });
                var best = bestCustomer.OrderByDescending(u => u.Bought).ToList();
                return best[0].User;
            }
            return default;
        }
        /// <summary>
        /// Elevates a user to admin
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool Promote(int adminId, int userId)
        {
            if (IsAdmin(adminId))
            {
                var user = db.Users.FirstOrDefault(u  => u.Id == userId);
                if (!IsAdmin(userId) && user!=null)
                {
                    user.IsAdmin = true;
                    db.SaveChanges();
                    return true;
                }
            }
            return default;
        }
        /// <summary>
        /// Demote user from admin to default
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool Demote(int adminId, int userId)
        {
            if (IsAdmin(adminId))
            {
                var user = db.Users.FirstOrDefault(u => u.Id == userId && u.Id != adminId);
                if (IsAdmin(userId) && user!=null)
                {
                    user.IsAdmin = false;
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Set a user active status to true
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool ActivateUser(int adminId, int userId)
        {
            if (IsAdmin(adminId))
            {
                var activate = db.Users.FirstOrDefault(u => u.Id == userId);
                if (activate != null && !activate.IsActive)
                {
                    activate.IsActive = true;
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Set a user active status to false
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool InactivateUser(int adminId, int userId)
        {
            if (IsAdmin(adminId) && adminId!=userId)
            {
                var deactivate = db.Users.FirstOrDefault(u => u.Id == userId);
                if (deactivate != null && deactivate.IsActive)
                {
                    deactivate.IsActive = false;
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// NOT PART OF API - new addition
        /// Finds a user based on userId returns list
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static List<User> FindUserById(int adminId, int userId)
        {
            if (IsAdmin(adminId))
            {
                return db.Users.Where(u => u.Id==userId).ToList();
            }
            return null;
        }
    }
}
