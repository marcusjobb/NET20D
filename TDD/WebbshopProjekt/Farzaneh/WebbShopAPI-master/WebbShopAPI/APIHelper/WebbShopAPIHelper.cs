namespace WebbShopAPI.APIHelper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WebbShopAPI.Database;
    using WebbShopAPI.Models;

    /// <summary>
    /// Defines the <see cref="WebbShopAPIHelper" />.
    /// </summary>
    internal class WebbShopAPIHelper
    {
        /// <summary>
        /// Defines the db.
        /// </summary>
        private static WebbShopContext db = new WebbShopContext();

        /// <summary>
        /// Logs in users
        /// </summary>
        /// <param name="userName">The userName<see cref="string"/>.</param>
        /// <param name="password">The password<see cref="string"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int Login(string userName, string password)
        {
            var customer = db.Users.FirstOrDefault(c => c.Name == userName && c.Password == password);
            if (customer != null)
            {
                customer.LastLogIn=DateTime.Now;
                db.Update(customer);
                db.SaveChanges();
                UpdateSessionTimer(customer.ID);
                return customer.ID;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Logs out users.
        /// </summary>
        /// <param name="userID">The userID<see cref="int"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool Logout(int userID)
        {
            var customer = db.Users.FirstOrDefault(c => c.ID == userID);
            if (customer != null)
            {
                customer.SessionTimer = default(DateTime);
                db.Update(customer);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets list of all categories that exists in databse
        /// </summary>
        /// <returns>The <see cref="List{BookCategory}"/>.</returns>
        public static List<BookCategory> GetCategories()
        {
            var categories = from c in db.BookCategories select c;
            return categories.ToList();
        }

        /// <summary>
        /// Gets list of categories matching keyword
        /// </summary>
        /// <param name="keyword">The keyword<see cref="string"/>.</param>
        /// <returns>The <see cref="List{BookCategory}"/>.</returns>
        public static List<BookCategory> GetCategories(string keyword)
        {
            var category = db.BookCategories.Where(c => c.Name.StartsWith(keyword));
            return category.ToList();
        }

        /// <summary>
        /// Gets list of books in the category
        /// </summary>
        /// <param name="catgoryid">The catgoryid<see cref="string"/>.</param>
        /// <returns>The <see cref="List{Book}"/>.</returns>
        public List<Book> GetCategory(string catgoryid)
        {
            var books = db.Books.Where(b => b.CategoryId == catgoryid);
            return books.ToList();
        }

        /// <summary>
        /// Gets list of books with amount>0 in the category.
        /// </summary>
        /// <param name="Categoryid">The Categoryid<see cref="string"/>.</param>
        /// <returns>The <see cref="List{Book}"/>.</returns>
        public static List<Book> GetAvailableBooks(string Categoryid)
        {
            var books = db.Books.Where(b => b.CategoryId == Categoryid && b.Amount > 0);
            return books.ToList();
        }

        /// <summary>
        /// Gets information about book.
        /// </summary>
        /// <param name="bookID">The bookID<see cref="int"/>.</param>
        /// <returns>The <see cref="Book"/>.</returns>
        public static Book GetBook(int bookID)
        {
            var book = db.Books.FirstOrDefault(b => b.Id == bookID);
            return book;
        }

        /// <summary>
        /// Gets information about book.
        /// </summary>
        /// <param name="bookTitle">The bookID<see cref="string"/>.</param>
        /// <returns>The <see cref="Book"/>.</returns>
        public static Book GetBook(string bookTitle)
        {
            var book = db.Books.FirstOrDefault(b => b.Title.Contains(bookTitle));
            return book;
        }

        /// <summary>
        /// Gets list of books that their title matching keyword
        /// </summary>
        /// <param name="keyword">The keyword<see cref="string"/>.</param>
        /// <returns>The <see cref="List{Book}"/>.</returns>
        public List<Book> GetBooks(string keyword)
        {
            var books = db.Books.Where(b => b.Title.Contains(keyword));
            return books.ToList();
        }

        /// <summary>
        /// Gets List of books that their author matching keyword 
        /// </summary>
        /// <param name="keyword">The keyword<see cref="string"/>.</param>
        /// <returns>The <see cref="List{Book}"/>.</returns>
        public List<Book> GetAuthors(string keyword)
        {
            var books = db.Books.Where(b => b.Author.Contains(keyword));
            return books.ToList();
        }

        /// <summary>
        /// This is a method to buy a book
        /// Returns false if user does not exist and user is not online
        /// Copies book data to soldbooks,fills in with date purchase and userID
        /// </summary>
        /// <param name="userid">The userid<see cref="int"/>.</param>
        /// <param name="bookId">The bookId<see cref="int"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool BuyBook(int userid, int bookId)
        {
            var user = db.Users.FirstOrDefault(u => u.ID == userid);
            if (user != null)
            {
                DateTime currentTime = DateTime.Now;
                if (Ping(userid) == "pong")
                {
                    var book = GetBook(bookId);
                    if (book != null && book.Amount > 0)
                    {
                        book.Amount = book.Amount - 1;
                        db.Update(book);
                        db.SoldBooks.Add(new SoldBook
                        {
                            Author = book.Author,
                            Title = book.Title,
                            CategoryId = book.CategoryId,
                            Price = book.Price,
                            PurchasedDate = currentTime,
                            UserId = userid
                        });
                        db.SaveChanges();
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// This is a method to check if user is online 
        /// User is not online if sessiontimer is not been updated less than 15 minutes
        /// </summary>
        /// <param name="userId">The userId<see cref="int"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string Ping(int userId)
        {
            const string pong = "pong";
            var user = db.Users.FirstOrDefault(u => u.ID == userId);
            if (user != null)
            {
                DateTime currentTime = DateTime.Now;
                TimeSpan ts = currentTime - user.SessionTimer;
                if (ts.TotalMinutes < 15)
                {
                    return pong;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// This method Creates a new user.
        /// </summary>
        /// <param name="name">The name<see cref="string"/>.</param>
        /// <param name="password">The password<see cref="string"/>.</param>
        /// <param name="passwordVerify">The passwordVerify<see cref="string"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool Register(string name, string password, string passwordVerify)
        {
            if (!ExistUser(name) && (password == passwordVerify))
            {
                db.Users.Add(new User { Name = name, Password = password });
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// This mtheod updates SessionTimer.
        /// </summary>
        /// <param name="userId">The userId<see cref="int"/>.</param>
        public void UpdateSessionTimer(int userId)
        {
            var user = db.Users.FirstOrDefault(u => u.ID == userId);
            user.SessionTimer = DateTime.Now;
            db.Update(user);
            db.SaveChanges();
        }

        /// <summary>
        /// This method Checks if User is admin
        /// </summary>
        /// <param name="adminId">The adminId<see cref="int"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool IsAdmin(int adminId)
        {
            var user = db.Users.FirstOrDefault(u => u.ID == adminId);
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This method checks if user is admin then adds a new book in databse.
        /// </summary>
        /// <param name="adminId">The adminId<see cref="int"/>.</param>
        /// <param name="title">The title<see cref="string"/>.</param>
        /// <param name="author">The author<see cref="string"/>.</param>
        /// <param name="price">The price<see cref="int"/>.</param>
        /// <param name="amount">The amount<see cref="int"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool AddBook(int adminId, string title, string author, int price, int amount)
        {
            if (IsAdmin(adminId))
            {
                var book = db.Books.FirstOrDefault(b => b.Title == title);
                if (book != null)
                {
                    book.Amount = book.Amount + 1;
                    db.Update(book);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    db.Books.Add(new Book { Title = title, Author = author, Amount = amount, Price = price });
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// This method checks if user is admin then sets amount of a book.
        /// </summary>
        /// <param name="adminId">The adminId<see cref="int"/>.</param>
        /// <param name="bookId">The bookId<see cref="int"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int SetAmount(int adminId, int bookId)
        {
            if (IsAdmin(adminId))
            {
                var book = db.Books.FirstOrDefault(b => b.Id == bookId);
                if (book != null)
                {
                    return book.Amount;
                }
            }
            return 0;
        }

        /// <summary>
        /// This method checks if user is admin then Gets List of users in database
        /// </summary>
        /// <param name="adminId">The adminId<see cref="int"/>.</param>
        /// <returns>The <see cref="List{User}"/>.</returns>
        public List<User> ListUsers(int adminId)
        {
            if (IsAdmin(adminId))
            {
                var users = from u in db.Users select u;
                return users.ToList();
            }
            return null;
        }

        /// <summary>
        /// This method checks if user is admin then searches a user and gets information of the user.
        /// </summary>
        /// <param name="adminId">The adminId<see cref="int"/>.</param>
        /// <param name="keyword">The keyword<see cref="string"/>.</param>
        /// <returns>The <see cref="List{User}"/>.</returns>
        public List<User> FindUser(int adminId, string keyword)
        {
            if (IsAdmin(adminId))
            {
                var users = db.Users.Where(u => u.Name.StartsWith(keyword));
                return users.ToList();
            }
            return null;
        }

        /// <summary>
        /// This method checks if user is admin then searches a book in database and updates information of book if it exists.
        /// </summary>
        /// <param name="adminId">The adminId<see cref="int"/>.</param>
        /// <param name="bookId">The bookId<see cref="int"/>.</param>
        /// <param name="title">The title<see cref="string"/>.</param>
        /// <param name="author">The author<see cref="string"/>.</param>
        /// <param name="price">The price<see cref="int"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool UpdateBook(int adminId, int bookId, string title, string author, int price)
        {
            if (IsAdmin(adminId))
            {
                var book = db.Books.FirstOrDefault(b => b.Id == bookId);
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
        /// This method checks if user is admin then Searches a book in database and decreases amount of the book if it exists.
        /// If amount of book is 0 then deletes the book from database.
        /// </summary>
        /// <param name="adminId">The adminId<see cref="int"/>.</param>
        /// <param name="bookId">The bookId<see cref="int"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool DeleteBook(int adminId, int bookId)
        {
            if (IsAdmin(adminId))
            {
                var book = GetBook(bookId);
                if (book != null)
                {
                    if (book.Amount> 1)
                    {
                        book.Amount = book.Amount - 1;
                        db.Update(book);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        db.Books.Remove(book);
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// This method checks if user is admin then adds a new category in database if the category does not exist.
        /// </summary>
        /// <param name="adminId">The adminId<see cref="int"/>.</param>
        /// <param name="catrgoryName">The catrgoryName<see cref="string"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool AddCategory(int adminId, string catrgoryName)
        {
            if (IsAdmin(adminId))
            {
                var category = db.BookCategories.FirstOrDefault(c => c.Name == catrgoryName);
                if (category == null)
                {
                    db.BookCategories.Add(new BookCategory { Name = catrgoryName });
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// This method checks if user is admin then checks if category and book exist then adds a the book in the category.
        /// </summary>
        /// <param name="adminId">The adminId<see cref="int"/>.</param>
        /// <param name="bookId">The bookId<see cref="int"/>.</param>
        /// <param name="categoryId">The categoryId<see cref="string"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool AddBookToCategory(int adminId, int bookId, string categoryId)
        {
            if (IsAdmin(adminId))
            {
                var category = db.BookCategories.FirstOrDefault(c => c.Name == categoryId);
                if (category != null)
                {
                    var book = db.Books.FirstOrDefault(b => b.Id == bookId);
                    if (book != null)
                    {
                        book.CategoryId = categoryId;
                        db.Update(book);
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// This method checks if user is admin then searches a category.
        /// If the category does not exist then add the category to database.
        /// </summary>
        /// <param name="adminId">The adminId<see cref="int"/>.</param>
        /// <param name="categoryId">The categoryId<see cref="int"/>.</param>
        /// <param name="categoryName">The categoryName<see cref="string"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool UpdateCategory(int adminId, int categoryId, string categoryName)
        {
            if (IsAdmin(adminId))
            {
                var name = db.BookCategories.FirstOrDefault(c => c.Name == categoryName);
                var category = db.BookCategories.FirstOrDefault(c => c.Id == categoryId);
                if (category != null&&name==null)
                {
                    category.Name = categoryName;
                    db.Update(category);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// This method checks if user is admin then searches a category if category exists and is empty, deletes the category.
        /// </summary>
        /// <param name="adminId">The adminId<see cref="int"/>.</param>
        /// <param name="categoryId">The categoryId<see cref="int"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool DeleteCategory(int adminId, int categoryId)
        {
            if (IsAdmin(adminId))
            {
                var category = db.BookCategories.FirstOrDefault(c => c.Id == categoryId);
                if (category != null)
                {
                    var books = GetCategory(category.Name);
                    if (books.Count == 0)
                    {
                        db.BookCategories.Remove(category);
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// This method checks if user is admin then adds a new user if it does not exist.
        /// </summary>
        /// <param name="adminId">The adminId<see cref="int"/>.</param>
        /// <param name="username">The username<see cref="string"/>.</param>
        /// <param name="password">The password<see cref="string"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool AddUser(int adminId, string username, string password)
        {
            if (IsAdmin(adminId))
            {
                if (!ExistUser(username) && password != null)
                {
                    db.Users.Add(new User { Name = username, Password = password });
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// This method checks if a user exists.
        /// </summary>
        /// <param name="name">The name<see cref="string"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool ExistUser(string name)
        {
            var user = db.Users.FirstOrDefault(u => u.Name == name);
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This method checks if user is admin then gets list of soldbooks.
        /// </summary>
        /// <param name="adminId">The adminId<see cref="int"/>.</param>
        /// <returns>The <see cref="List{SoldBook}"/>.</returns>
        public List<SoldBook> SoldItems(int adminId)
        {
            if (IsAdmin(adminId))
            {
                var soldItems = from s in db.SoldBooks select s;
                return soldItems.ToList();
            }
            return null;
        }

        /// <summary>
        /// This method checks if user is admin then gets amount of money earned.
        /// </summary>
        /// <param name="adminId">The adminId<see cref="int"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int MoneyEarned(int adminId)
        {
            if (IsAdmin(adminId))
            {
                var moneyEarned = db.SoldBooks.Sum(p => p.Price);
                return moneyEarned;
            }
            return 0;
        }

        /// <summary>
        /// This method checks if user is admin then gets best customr's information.
        /// Finds best customer by checking amount of orders (soldbooks).
        /// best customer has the most amount of order in all of customers.
        /// </summary>
        /// <param name="adminId">The adminId<see cref="int"/>.</param>
        /// <returns>The <see cref="User"/>.</returns>
        public User BestCustomer(int adminId)
        {
            if (IsAdmin(adminId))
            {
                var groupsOfOrders = db.SoldBooks.GroupBy(u => u.UserId).Select(g => new
                {
                    UserId = g.Key,
                    TotalOrder = g.Count()
                });
                var maxAmountOfOrders = groupsOfOrders.Max(o => o.TotalOrder);
                var BestInGroups = groupsOfOrders.FirstOrDefault(c => c.TotalOrder == maxAmountOfOrders);
                var BestCustomer = db.Users.FirstOrDefault(u => u.ID == BestInGroups.UserId);
                return BestCustomer;
            }
            return null;
        }

        /// <summary>
        /// This method checks if user is admin then make a user admin.
        /// </summary>
        /// <param name="adminId">The adminId<see cref="int"/>.</param>
        /// <param name="userId">The userId<see cref="int"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool Promote(int adminId, int userId)
        {
            if (IsAdmin(adminId))
            {
                var user = db.Users.FirstOrDefault(u => u.ID == userId);
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
        /// This method checks if user is admin then deactivates a user's admin feature.
        /// </summary>
        /// <param name="adminId">The adminId<see cref="int"/>.</param>
        /// <param name="userId">The userId<see cref="int"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool Demote(int adminId, int userId)
        {
            if (IsAdmin(adminId))
            {
                var user = db.Users.FirstOrDefault(u => u.ID == userId);
                if (user != null)
                {
                    user.IsAdmin = false;
                    db.Update(user);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// This method checks if user is admin then activates a user.
        /// </summary>
        /// <param name="adminId">The adminId<see cref="int"/>.</param>
        /// <param name="userId">The userId<see cref="int"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool ActivateUser(int adminId, int userId)
        {
            if (IsAdmin(adminId))
            {
                var user = db.Users.FirstOrDefault(u => u.ID == userId);
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
        /// This method checks if user is admin then deactivates a user.
        /// </summary>
        /// <param name="adminId">The adminId<see cref="int"/>.</param>
        /// <param name="userId">The userId<see cref="int"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool InactivateUser(int adminId, int userId)
        {
            if (IsAdmin(adminId))
            {
                var user = db.Users.FirstOrDefault(u => u.ID == userId);
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
    }
}
