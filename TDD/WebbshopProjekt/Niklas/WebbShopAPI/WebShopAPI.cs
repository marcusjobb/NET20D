using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebbShopAPI.Data;
using WebbShopAPI.Models;
using WebbShopAPI.Utility;

namespace WebbShopAPI
{
    /// <summary>
    /// API to be implemented in a web-shop.
    /// </summary>
    public class WebShopAPI
    {
        private static readonly DBContext context = new DBContext();
        public WebShopAPI() { }

        ///////////////////////////////////////////////////////////////
        ///                     Category                            ///
        ///////////////////////////////////////////////////////////////
        #region Categories

        /// <summary>
        /// Get category matching category name. With existing DB-connection.
        /// </summary>
        /// <param name="categoryName">Name of category.</param>
        /// <param name="db">Existing database-connection.</param>
        /// <returns>Category</returns>
        public static Category GetCategory(string categoryName, DBContext db)
        {
            var category = db.Categories.FirstOrDefault(a => a.Title == categoryName);

            if (category != null)
            {
                return category;
            }
            else { return default; }
        }

        /// <summary>
        /// Get category matching category name.
        /// </summary>
        /// <param name="categoryName">Name of category.</param>
        /// <returns>Category.</returns>
        public static Category GetCategory(string categoryName)
        {
            var category = context.Categories.FirstOrDefault(a => a.Title == categoryName);

            if (category != null)
            {
                return category;
            }
            else { return default; }
        }

        /// <summary>
        /// Get category matching ID.
        /// </summary>
        /// <param name="categoryID">ID of category.</param>
        /// <returns>Category ID.</returns>
        public static Category GetCategory(int categoryID)
        {
            try
            {
                return context.Categories.FirstOrDefault(c => c.ID == categoryID);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Gets all categories that are in the database.
        /// </summary>
        /// <returns>All categories.</returns>
        public static IEnumerable<Category> GetCategories()
        {
            return from c in context.Categories orderby c.Title select c;
        }

        /// <summary>
        /// Gets category matching input keyword.
        /// </summary>
        /// <param name="categoryName">Type of category</param>
        /// <returns>Matching categories.</returns>
        public static IEnumerable<Category> GetCategories(string categoryName)
        {
            return from c in context.Categories where c.Title.Contains(categoryName) select c;
        }

        /// <summary>
        /// Gets the category that matches ID method receives.
        /// </summary>
        /// <param name="categoryID">Category ID.</param>
        /// <returns>Category matching category matching ID.</returns>
        public static IEnumerable<Category> GetCategories(int categoryID)
        {
            try
            {
                return from c in context.Categories where c.ID == categoryID select c;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Get all categories without any books coupled to them.
        /// </summary>
        /// <returns>Categories.</returns>
        public static IEnumerable<Category> GetEmptyCategories()
        {
            return context.Categories.Where(c => c.BooksInCategory.Count == 0);
        }

        /// <summary>
        /// Gets the category ID matching the category name
        /// </summary>
        /// <param name="categoryName">Category Name.</param>
        /// <returns>ID.</returns>
        public static int GetCategoryID(string categoryName)
        {
            var category = context.Categories.FirstOrDefault(b => b.Title == categoryName);
            if (category != null)
            {
                return category.ID;
            }
            else { return default; }
        }
        #endregion Categories
        ///////////////////////////////////////////////////////////////
        ///                        Books                            ///
        ///////////////////////////////////////////////////////////////
        #region Books

        /// <summary>
        /// Gets all books in database.
        /// </summary>
        /// <returns>Books.</returns>
        public IEnumerable<Book> GetAllBooks()
        {
            try
            {
                return context.Books.Include(b => b.Author).Include(c => c.Categories).ToList();
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Gets all books in database that has books in stock.
        /// </summary>
        /// <returns>Books.</returns>
        public IEnumerable<Book> GetAvailableBooks()
        {
            try
            {
                return from b in context.Books.Include(b => b.Author).Include(c => c.Categories) where b.Stock > 0 orderby b.Title select b;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Gets books by category ID.
        /// </summary>
        /// <param name="categoryID">Category ID.</param>
        /// <returns>Books.</returns>
        public static IEnumerable<Book> GetBooksByCategoryID(int categoryID)
        {
            try
            {
                return from b in context.Books.Include(a => a.Author).Include(c => c.Categories) where b.Categories.ID == categoryID orderby b.Title select b;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Gets all books in a specific category.
        /// </summary>
        /// <param name="categoryName">Category Name.</param>
        /// <returns>Books.</returns>
        public static IEnumerable<Book> GetBooksByCategory(string categoryName)
        {
            return from b in context.Books.Include(a => a.Author).Include(c => c.Categories) where b.Categories.Title == categoryName select b;
        }

        /// <summary>
        /// Gets books by category name.
        /// </summary>
        /// <param name="category">Name of category.</param>
        /// <param name="dbc">Open connection to database.</param>
        /// <returns>Books.</returns>
        public static IEnumerable<Book> GetBooksByCategory(string category, DBContext dbc)
        {
            return from b in dbc.Books.Include(a => a.Author).Include(c => c.Categories) where b.Categories.Title == category select b;
        }

        /// <summary>
        /// Gets books by a specific author.
        /// </summary>
        /// <param name="firstName">Authors first name.</param>
        /// <param name="surname">Authors surname.</param>
        /// <returns>Books.</returns>
        public static IEnumerable<Book> GetBooksByAuthor(string firstName, string surname)
        {
            try
            {
                return from b in context.Books.Include(a => a.Author).Include(c => c.Categories) where b.Author.FirstName == firstName || b.Author.Surname == surname select b;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Get books by book id.
        /// </summary>
        /// <param name="bookID">Book ID.</param>
        /// <returns>Book.</returns>
        public static IEnumerable<Book> GetBookByBookID(int bookID)
        {
            try
            {
                return from b in context.Books.Include(a => a.Author).Include(c => c.Categories) where b.ID == bookID orderby b.Title select b;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Buy a book by entering user ID and book ID.
        /// </summary>
        /// <param name="userID">ID of user.</param>
        /// <param name="bookID">ID of book.</param>
        /// <returns>Boolean.</returns>
        public bool BuyBook(int userID, int bookID)
        {
            var user = context.Users.FirstOrDefault(u => userID == u.ID && u.IsActive);
            var book = context.Books.Include(a => a.Author).Include(c => c.Categories).FirstOrDefault(b => bookID == b.ID);

            if (user != null)
            {
                if (user.SessionTimer > DateTime.Now)
                {
                    if (user != null && book.Stock > 0)
                    {
                        var soldBook = new SoldBook
                        {
                            BoughtBy = user,
                            PurchaseDate = DateTime.Now,
                            Author = book.Author,
                            Categories = book.Categories,
                            Title = book.Title,
                            Price = book.Price,
                        };

                        book.Stock--;
                        user.SessionTimer = DateTime.Now.AddMinutes(15);
                        context.AddRange(soldBook);
                        context.Update(book);
                        context.Update(user);
                        context.SaveChanges();
                        return true;
                    }
                    else { return false; }
                }
                else { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Get ID of a book with a specific title.
        /// </summary>
        /// <param name="title">Name of book.</param>
        /// <returns>ID.</returns>
        public static int GetBookID(string title)
        {
            var book = context.Books.FirstOrDefault(b => b.Title == title);
            if (book != null)
            {
                return book.ID;
            }
            else { return default; }
        }
        #endregion Books
        ///////////////////////////////////////////////////////////////
        ///                     Authors                             ///
        ///////////////////////////////////////////////////////////////
        #region Authors   

        public static IEnumerable<Author> GetAuthors()
        {
            return from a in context.Authors orderby a.Surname select a;
        }

        /// <summary>
        /// Get authors by searching by first- and surname.
        /// </summary>
        /// <param name="firstname">Author first name.</param>
        /// <param name="surname">Authors surname.</param>
        /// <returns>Author.</returns>
        public Author GetAuthors(string firstname, string surname)
        {
            var author = context.Authors.FirstOrDefault(a => a.FirstName == firstname && a.Surname == surname);
            if (author != null)
            {
                return author;
            }
            else
            {
                return new Author { FirstName = firstname, Surname = surname };
            }
        }

        /// <summary>
        /// Same as above but with a already open database connection.
        /// </summary>
        /// <param name="firstname">Author first name.</param>
        /// <param name="surname">Author surname.</param>
        /// <param name="db">Database connections.</param>
        /// <returns>Author.</returns>
        public Author GetAuthors(string firstname, string surname, DBContext db)
        {
            var author = db.Authors.FirstOrDefault(a => a.FirstName == firstname && a.Surname == surname);
            if (author != null)
            {
                return author;
            }
            else
            {
                return new Author { FirstName = firstname, Surname = surname };
            }
        }
        #endregion Authors        
        ///////////////////////////////////////////////////////////////
        ///                         User                            ///
        ///////////////////////////////////////////////////////////////
        #region User

        ///<summary>
        ///Registers a new user.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <param name="firstName">First name.</param>
        /// <param name="surname">Surname.</param>
        public bool Register(string username, string password, string firstName, string surname)
        {
            bool success = false;
            var user = context.Users.FirstOrDefault(u => username == u.Username && password == u.Password && u.IsActive);

            if (user == null)
            {
                var newUser = new User
                {
                    Admin = false,
                    FirstName = firstName,
                    Surname = surname,
                    Username = username,
                    Password = password,
                    IsActive = true
                };

                context.Update(newUser);
                context.SaveChanges();
                success = true;
            }

            return success;
        }

        /// <summary>
        /// Logs in the user.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <returns>ID if user exists. If not, returns 0.</returns>
        public static int Login(string username, string password)
        {
            var user = context.Users.FirstOrDefault(u => username == u.Username && password == u.Password && u.IsActive);

            if (user != null)
            {
                user.LastLogIn = DateTime.Now;
                user.SessionTimer = DateTime.Now.AddMinutes(15);
                context.Update(user);
                context.SaveChanges();
                return user.ID;
            }
            return 0; //No existing user with matching username and password.
        }

        /// <summary>
        /// Logs out the user.
        /// </summary>
        /// <param name="userID">User ID.</param>
        public void LogOut(int userID)
        {
            var user = context.Users.FirstOrDefault(u => userID == u.ID && u.SessionTimer > DateTime.Now.AddMinutes(-15));

            if (user != null)
            {
                user.SessionTimer = DateTime.MinValue;
                context.Users.Update(user);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Checks if user is still active. If user if active it will write "Pong" in the console + renew the users session timer. In user is not active it will return empty string.
        /// </summary>
        /// <param name="userID">Users ID.</param>
        /// <returns>String.</returns>
        public string Ping(int userID)
        {
            var user = context.Users.FirstOrDefault(u => userID == u.ID && u.IsActive);

            if (user != null)
            {
                if (user.SessionTimer > DateTime.Now)
                {
                    user.SessionTimer.AddMinutes(15);
                    context.SaveChanges();
                    return "Pong!";
                }
                else
                {
                    return String.Empty;
                }
            }
            return "User not found";
        }
        #endregion User
        ///////////////////////////////////////////////////////////////
        ///           Administrator access to API                   ///
        ///////////////////////////////////////////////////////////////
        #region Administrator access to API
        /// <summary>
        /// Gets the users ID by entering their username.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <returns>User ID.</returns>
        public static int GetUserID(string username)
        {
            var user = context.Users.FirstOrDefault(u => u.Username == username && u.IsActive == true);

            if (user != null)
            {
                return user.ID;
            }
            else { return default; }
        }

        /// <summary>
        /// Gets the user by given ID.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        /// <param name="userID">User ID.</param>
        /// <returns>User.</returns>
        public IEnumerable<User> GetUsersByID(int adminID, IEnumerable<int> userID)
        {
            if (IsAdmin(adminID))
            {
                using (var db = new DBContext())
                {
                    var users = new List<User>();
                    foreach (var _userID in userID)
                    {
                        users.Add(db.Users.FirstOrDefault(u => u.ID == _userID && u.IsActive == true));
                    }

                    if (users != null)
                    {
                        return users;
                    }
                    else { return default; }
                }
            }
            else { return default; }
        }

        /// <summary>
        /// Get user by ID without admin.
        /// </summary>
        /// <param name="userID">User ID as int.</param>
        /// <returns>User.</returns>
        public User GetUserByID(int userID)
        {
            var user = context.Users.FirstOrDefault(u => u.ID == userID && u.IsActive == true);

            if (user != null)
            {
                return user;
            }
            else { return default; }

        }

        /// <summary>
        /// Checks if user is admin.
        /// </summary>
        /// <param name="adminID">User ID.</param>
        /// <returns>True if Admin.</returns>
        public bool IsAdmin(int adminID)
        {
            var user = context.Users.FirstOrDefault(u => adminID == u.ID && u.IsActive == true);

            if (user != null)
            {
                if (user.Admin == true)
                {
                    user.SessionTimer = DateTime.Now.AddMinutes(15);
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Adds a new book to the database.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        /// <param name="title">Book title.</param>
        /// <param name="authorFirstname">Author first name.</param>
        /// <param name="authorSurname">Author Surname.</param>
        /// <param name="category">Type of category.</param>
        /// <param name="price">Book price.</param>
        /// <param name="stock">Amount of books in stock.</param>
        /// <returns>True if passed.</returns>
        public bool AddBook(int adminID, string title, string authorFirstname, string authorSurname, string category, int price, int stock)
        {
            if (IsAdmin(adminID))
            {
                var bookExists = context.Books.FirstOrDefault(b => b.Title.Contains(title));
                if (bookExists == null)
                {
                    new ExtractedMethods().RenewSessionTimer(adminID);
                    var book = new Book
                    {
                        Title = title,
                        Author = GetAuthors(authorFirstname, authorSurname),
                        Categories = GetCategory(category, context),
                        Price = price,
                        Stock = stock
                    };
                    context.Update(book);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    bookExists.Stock++;
                    context.Update(bookExists);
                    context.SaveChanges();
                    return true;
                }
            }
            else { return false; }
        }

        /// <summary>
        /// Adds a new book to the database without a category.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        /// <param name="title">Book title.</param>
        /// <param name="authorFirstname">Author first name.</param>
        /// <param name="authorSurname">Author Surname.</param>
        /// <param name="price">Book price.</param>
        /// <param name="stock">Amount of books in stock.</param>
        /// <returns>True if passed.</returns>
        public bool AddBook(int adminID, string title, string authorFirstname, string authorSurname, int price, int stock)
        {
            if (IsAdmin(adminID))
            {
                new ExtractedMethods().RenewSessionTimer(adminID);
                var book = new Book
                {
                    Title = title,
                    Author = GetAuthors(authorFirstname, authorSurname),
                    Price = price,
                    Stock = stock
                };
                context.Update(book);
                context.SaveChanges();
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Sets the new stock amount of a book.
        /// Stock can not be lower than 0.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        /// <param name="bookID">Book ID.</param>
        /// <param name="newStock">New stock of book.</param>
        /// <returns>True if passed.</returns>
        public bool SetAmount(int adminID, int bookID, int newStock)
        {
            if (IsAdmin(adminID))
            {
                new ExtractedMethods().RenewSessionTimer(adminID);
                var book = context.Books.FirstOrDefault(b => b.ID == bookID);

                if (book != null && newStock >= 0)
                {
                    book.Stock = newStock;
                    context.Update(book);
                    context.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Lists all users that are active.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        /// <returns>Users.</returns>
        public IEnumerable<User> ListActiveUsers(int adminID)
        {
            if (IsAdmin(adminID))
            {
                new ExtractedMethods().RenewSessionTimer(adminID);
                return context.Users.Where(u => u.IsActive == true).ToList();
            }
            else { return default; }
        }

        /// <summary>
        /// Lists all inactive users.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        /// <returns>Users.</returns>
        public IEnumerable<User> ListInactiveUsers(int adminID)
        {
            if (IsAdmin(adminID))
            {
                new ExtractedMethods().RenewSessionTimer(adminID);
                return context.Users.Where(u => u.IsActive == false).ToList();
            }
            else { return default; }
        }

        /// <summary>
        /// Find user by username.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        /// <param name="username">Username.</param>
        /// <returns>User.</returns>
        public IEnumerable<User> FindUsers(int adminID, string username)
        {
            if (IsAdmin(adminID))
            {
                new ExtractedMethods().RenewSessionTimer(adminID);
                return context.Users.Include(b => b.BooksBought).Where(u => u.Username.Contains(username)).ToList();
            }
            else { return default; }
        }

        /// <summary>
        /// Updates a book.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        /// <param name="bookID">Book ID.</param>
        /// <param name="title">Book title.</param>
        /// <param name="authorFirstname">Author first name.</param>
        /// <param name="authorSurname">Author surname.</param>
        /// <param name="category">Type of category.</param>
        /// <param name="price">Book price.</param>
        /// <param name="stock">Book stock.</param>
        /// <returns>True if passed.</returns>
        public bool UpdateBook(int adminID, int bookID, string title, string authorFirstname, string authorSurname, string category, int price, int stock)
        {
            if (IsAdmin(adminID))
            {
                var book = context.Books.FirstOrDefault(b => b.ID == bookID);

                if (book != null)
                {
                    book.Title = title;
                    book.Author = GetAuthors(authorFirstname, authorSurname);
                    book.Categories = GetCategories(category).First();
                    book.Price = price;
                    book.Stock = stock;
                    new ExtractedMethods().RenewSessionTimer(adminID);
                    context.Update(book);
                    context.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Removes a book from database if stock is less than 0.
        /// Else removes 1 from the stock.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        /// <param name="bookID">Book ID.</param>
        /// <returns>True if passed.</returns>
        public bool DeleteBook(int adminID, int bookID)
        {
            if (IsAdmin(adminID))
            {
                var book = context.Books.FirstOrDefault(b => b.ID == bookID);

                if (book != null)
                {
                    if (book.Stock < 0)
                    {
                        context.Books.Attach(book);
                        context.Books.Remove(book);
                        new ExtractedMethods().RenewSessionTimer(adminID);
                        context.SaveChanges();
                    }
                    else
                    {
                        book.Stock--;
                        new ExtractedMethods().RenewSessionTimer(adminID);
                        context.Update(book);
                        context.SaveChanges();
                    }
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Adds a new category to database.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        /// <param name="category">Type of category.</param>
        /// <returns>True if passed.</returns>
        public bool AddCategory(int adminID, string category)
        {
            if (IsAdmin(adminID))
            {
                var categoryExists = GetCategory(category, context);

                if (categoryExists == null)
                {
                    var newCategory = new Category { Title = category };
                    context.Update(newCategory);
                    context.SaveChanges();
                }
                else { return false; }

                new ExtractedMethods().RenewSessionTimer(adminID);
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Adds a book to a category.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        /// <param name="bookID">Book ID.</param>
        /// <param name="categoryID">Category ID.</param>
        /// <returns>True if passed.</returns>
        public bool AddBookToCategory(int adminID, int bookID, int categoryID)
        {
            if (IsAdmin(adminID))
            {
                var book = context.Books.Include(c => c.Categories).FirstOrDefault(b => b.ID == bookID);

                if (book != null)
                {
                    book.Categories = GetCategory(categoryID);
                    new ExtractedMethods().RenewSessionTimer(adminID);

                    if (book.Categories.ID > 0)
                    {
                        context.Update(book);
                        context.SaveChanges();
                        return true;
                    }
                    else { return false; }
                }
                else { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Updates the name of a given category.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        /// <param name="categoryID">Category ID.</param>
        /// <param name="newCategoryName">Type of category.</param>
        /// <returns>True if passed.</returns>
        public bool UpdateCategory(int adminID, int categoryID, string newCategoryName)
        {
            if (IsAdmin(adminID))
            {
                var category = context.Categories.FirstOrDefault(c => c.ID == categoryID);

                if (category != null)
                {
                    category.Title = newCategoryName;
                    new ExtractedMethods().RenewSessionTimer(adminID);
                    context.Update(category);
                    context.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Removes a category from the database.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        /// <param name="categoryID">Category ID.</param>
        /// <returns>True if passed.</returns>
        public bool DeleteCategory(int adminID, int categoryID)
        {
            if (IsAdmin(adminID))
            {
                var listBooks = context.Books.FirstOrDefault(b => b.Categories.ID == categoryID);

                if (listBooks == null)
                {
                    var category = context.Categories.FirstOrDefault(c => c.ID == categoryID);
                    context.Entry(category).State = EntityState.Deleted;
                    context.SaveChanges();
                    new ExtractedMethods().RenewSessionTimer(adminID);
                }

                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Adds a new user to the database.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        /// <param name="username">Username of new user.</param>
        /// <param name="password">Password of new user.</param>
        /// <param name="firstName">First name of new user.</param>
        /// <param name="surname">Surname of new user.</param>
        /// <returns>True if passed.</returns>
        public bool AddUser(int adminID, string username, string password, string firstName, string surname)
        {
            if (IsAdmin(adminID))
            {
                var newUser = new User { Username = username, Password = password, FirstName = firstName, Surname = surname };
                new ExtractedMethods().RenewSessionTimer(adminID);
                context.Update(newUser);
                context.SaveChanges();
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Lists all sold items.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        /// <returns>All sold items.</returns>
        public IEnumerable<SoldBook> SoldItems(int adminID)
        {
            if (IsAdmin(adminID))
            {
                var books = from b in context.SoldBooks.Include(a => a.Author).Include(c => c.Categories) orderby b.Title select b;
                return books;
            }
            else { return default; }
        }

        /// <summary>
        /// Calculates how much the total sum of money earned is from sales.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        /// <returns>Amount of money earned.</returns>
        public int MoneyEarned(int adminID)
        {
            if (IsAdmin(adminID))
            {
                return context.SoldBooks.Sum(b => b.Price);
            }
            return default;
        }

        /// <summary>
        /// Calculates what customer has done the most purchases.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        /// <returns>User.</returns>
        public IEnumerable<User> BestCustomer(int adminID)
        {
            if (IsAdmin(adminID))
            {
                var soldBooks = from b in context.SoldBooks.Include(u => u.BoughtBy).Distinct() select b;
                var groupByID = from b in soldBooks.Select(u => u.BoughtBy.ID) group b by b into x select new { x.Key, Count = x.Count() };
                var maxFrequency = groupByID.Max(x => x.Count);
                IEnumerable<int> userID = groupByID.Where(x => x.Count == maxFrequency).Select(x => x.Key);
                IEnumerable<User> users = GetUsersByID(adminID, userID);

                return users;
            }
            else { return default; }
        }

        /// <summary>
        /// Promotes a user to admin.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        /// <param name="userID">User ID.</param>
        /// <returns>True if passed.</returns>
        public bool Promote(int adminID, int userID)
        {
            if (IsAdmin(adminID))
            {
                var user = context.Users.FirstOrDefault(u => u.ID == userID);

                if (user != null)
                {
                    user.Admin = true;
                    new ExtractedMethods().RenewSessionTimer(adminID);
                    context.Update(user);
                    context.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Demotes a user from admin to regular user.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        /// <param name="userID">User ID.</param>
        /// <returns>True if passed.</returns>
        public bool Demote(int adminID, int userID)
        {
            if (IsAdmin(adminID))
            {
                var user = context.Users.FirstOrDefault(u => u.ID == userID);

                if (user != null && user.Admin == true && userID != adminID)
                {
                    user.Admin = false;
                    new ExtractedMethods().RenewSessionTimer(adminID);
                    context.Update(user);
                    context.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Activates a user if user is inactivated.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        /// <param name="userID">User ID.</param>
        /// <returns>True if passed.</returns>
        public bool ActivateUser(int adminID, int userID)
        {
            if (IsAdmin(adminID))
            {
                var user = context.Users.FirstOrDefault(u => u.ID == userID);

                if (user != null)
                {
                    user.IsActive = true;
                    new ExtractedMethods().RenewSessionTimer(adminID);
                    context.Update(user);
                    context.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Inactivates a user.
        /// </summary>
        /// <param name="adminID"></param>
        /// <param name="userID"></param>
        /// <returns>True if passed.</returns>
        public bool InactivateUser(int adminID, int userID)
        {
            if (IsAdmin(adminID))
            {
                var user = context.Users.FirstOrDefault(u => u.ID == userID);

                if (user != null)
                {
                    user.IsActive = false;
                    new ExtractedMethods().RenewSessionTimer(adminID);
                    context.Update(user);
                    context.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
    }
    #endregion Administrator access to API
}
