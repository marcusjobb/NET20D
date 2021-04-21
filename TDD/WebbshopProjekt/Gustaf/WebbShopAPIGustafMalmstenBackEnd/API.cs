using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Crypto.Engines;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using WebbShopAPIGustafMalmsten.Model;

namespace WebbShopAPIGustafMalmsten
{
    public class API
    {
        /// <summary>
        /// Creates the Databas object used for this API
        /// </summary>
        public API()
        {
            Db = new Databas();
            Db.Seed();
        }
        Databas Db { get; set; }

        internal Databas Databas
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Attempts to log in the user with username and password
        /// </summary>
        /// <param name="username">Username to log in</param>
        /// <param name="password">Password to the username</param>
        /// <returns>UserID if success, -1 if login fails</returns>
        public int Login(string username, string password)
        {          
            if(username is null || Db.ReadUser(username) is null || password is null)
            {
                return -1;
            }
            User user = Db.ReadUser(username);
            if (user.Password.Equals(password))
            {
                user.IsActive = true;
                user.LastLogin = DateTime.Now;
                user.SessionTimer = DateTime.Now;
                Db.Update(user);
                return user.UserID;
            }
            return -1;
        }
        /// <summary>
        /// Attempts to log out user
        /// </summary>
        /// <param name="userID">The UserID to log out</param>
        /// <returns>UserID if successful, -1 if logout fails</returns>
        public int Logout(int userID)
        {
            if (Db.ReadUser(userID) is null)
            {
                return -1;
            }
            User user = Db.ReadUser(userID);
            user.IsActive = false;
            Db.Update(user);
            return user.UserID;
        }
        /// <summary>
        /// Gets all bookcategories 
        /// </summary>
        /// <returns>A list of string with the bookcategories</returns>
        public List<string> GetCategories()
        {
            List<string> result = new();
            List<BookCategory> temp = Db.ReadBookCategories();
            if (temp is null)
            { 
                return result; 
            }
            temp.ForEach(n => result.Add(n.BookCategoryName));
            return result;
        }
        /// <summary>
        /// Gets matching bookcategories depending on the keyword
        /// </summary>
        /// <param name="keyword">The search string to use</param>
        /// <returns>A list of strings with matching bookcategories</returns>
        public List<string> GetCategories(string keyword)
        {
            List<string> result = new();
            List<BookCategory> temp = Db.ReadBookCategories(keyword);
            if(temp is null)
            {
                return result;
            }
            temp.ForEach(n => result.Add(n.BookCategoryName));
            return result;
        }
        /// <summary>
        /// Get all books with matching CategoryId
        /// </summary>
        /// <param name="id">The CategoryID to search for</param>
        /// <returns>A list of strings with the matching books. Null if nothing was found</returns>
        public List<string> GetCategory(int id)
        {
            List<string> result = new();
            List<Book> temp = Db.ReadBooks(id);
            if(temp is null)
            {
                return result;
            }
            temp.ForEach(n => result.Add(n.Title));
            return result;
        }
        /// <summary>
        /// Gets all bookcategories
        /// </summary>
        /// <returns>All bookcategories</returns>
        public List<BookCategory> GetBookCategories()
        {
            return Db.ReadBookCategories();
        }
        /// <summary>
        /// Returns all bookcategories with at least one book in them.
        /// </summary>
        /// <returns>Bookcategories with at least one book in them.</returns>
        public List<BookCategory> GetNonEmptyCategories()
        {
            List<BookCategory> result = GetBookCategories();
            foreach(BookCategory item in GetBookCategories())
            {
                if (GetAvaialableBooks(item.BookCategoryID).Any() == false)
                {
                    result.Remove(item);
                }
            }
            return result;
        }
        /// <summary>
        /// Get all available books within an categoryID (book.amount > 0)
        /// </summary>
        /// <param name="categoryID">The CategoryID to search for</param>
        /// <returns>A list of books in the matching Category with Amount > 0</returns>
        public List<Book> GetAvaialableBooks(int categoryID)
        {           
            List<Book> result = new();
            List<Book> temp = Db.ReadBooks(categoryID);
            foreach(Book book in temp)
            {
                if(book.Amount > 0)
                {
                    result.Add(book);
                }
            }
            return result;
        }
        /// <summary>
        /// Gets information about a book with the selected bookID
        /// </summary>
        /// <param name="bookID">The BookID to search for</param>
        /// <returns>A list of strings representing the information about the book</returns>
        public Book GetBook(int bookID)
        {
            Book result = Db.ReadBook(bookID);
            return result;
        }
        /// <summary>
        /// Returns information about a book when searching for book title
        /// </summary>
        /// <param name="title">The book title to search for</param>
        /// <returns>A list of strings representing the information about the bookk</returns>
        public List<string> GetBook(string title)
        {
            List<string> result = new();
            var temp = Db.ReadBook(title);
            if (temp is null)
            {
                return result;
            }
            result.Add(temp.ID.ToString());
            result.Add(temp.Title);
            result.Add(temp.Author);
            result.Add(temp.Price.ToString());
            result.Add(temp.Amount.ToString());

            return result;
        }
        /// <summary>
        /// Returns books matching the keyword
        /// </summary>
        /// <param name="keyword">The searchstring</param>
        /// <returns>The matching books</returns>
        public List<Book> GetBooks(string keyword)
        {
            List<Book> result = Db.ReadBooks(keyword);
            return result;
        }
        /// <summary>
        /// Gets the matching books that have keyword as Author
        /// </summary>
        /// <param name="keyword">The author to look for</param>
        /// <returns>A list of books with the same author</returns>
        public List<Book> GetAuthors(string keyword)
        {
            List<Book> result = Db.ReadBooks(keyword);
            return result;
        }
        /// <summary>
        /// Attempts to buy a book. User must be logged in, and the book must be available (amount > 0)
        /// </summary>
        /// <param name="userID">The UserID to attempt to buy</param>
        /// <param name="bookID">The book to buy</param>
        /// <returns>True if successful, false if fail</returns>
        public bool BuyBook(int userID, int bookID)
        {
            if (!IsLoggedIn(userID) || Db.ReadBook(bookID) is null || Db.ReadBook(bookID).Amount == 0)
            {
                return false;
            }
            var temp1 = Db.ReadUser(userID);
            var temp2 = Db.ReadBook(bookID);
            var temp3 = new SoldBook
            {
                Title = temp2.Title,
                Author = temp2.Author,
                Price = temp2.Price,
                UserID = userID,
                BookCategoryID = temp2.BookCategoryID,
                PurchaseDate = DateTime.Now
            };
            temp2.Amount -= 1;
            Db.Update(temp1);
            Db.Update(temp2);
            Db.Create(temp3);
            return true;
        }
        /// <summary>
        /// Pings an user to keep the connection alive
        /// </summary>
        /// <param name="userID">The UserID to ping</param>
        /// <returns>string "Pong" if successful, string.empty if fail</returns>
        public string Ping(int userID)
        {
            if(IsLoggedIn(userID))
                return "Pong";
            else
                return string.Empty;
        }
        /// <summary>
        /// Register a brand new customer. Must have matching password & passwordVerify, name must be unique
        /// </summary>
        /// <param name="name">Username, must be unique</param>
        /// <param name="password">Password</param>
        /// <param name="passwordVerify">Verify the password</param>
        /// <returns>True if successful, false if fail</returns>
        public bool Register(string name, string password, string passwordVerify)
        {         
            if (password.Equals(passwordVerify)  && Db.ReadUser(name) is null && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(name))
            {
                User user = new()
                {
                    Name = name,
                    Password = password,
                    LastLogin = DateTime.Now,
                    SessionTimer = DateTime.Now,
                    IsActive = true,
                    IsAdmin = false
                };
                Db.Create(user);
                return true;                
            }
            return false;
        }
        /// <summary>
        /// Adds a book to the database. If book is not present, add it to the database.
        /// If the bookid is present, add the amount of books to that bookid.
        /// Returns true if successful, false if fail
        /// </summary>
        /// <param name="adminID">The Admin to add the book</param>
        /// <param name="bookID">The BookID to add</param>
        /// <param name="title">Title of the book</param>
        /// <param name="author">Author of the book</param>
        /// <param name="price">Price of the book</param>
        /// <param name="amount">Amount of books to add</param>
        /// <returns>True if successful, false if fail</returns>
        public bool AddBook(int adminID, string title, string author, double price, int amount, int categoryID, int bookID = -1)
        {
            if(!AdminLoggedIn(adminID) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author)) 
            {
                return false;
            }
            Book book = new()
            {
                Title = title,
                Author = author,
                Price = price,
                Amount = amount                                       
            };
            if(Db.ReadBook(bookID) is null)
            {
                book.BookCategoryID = categoryID;
                Db.Create(book);
            }
            else
            {
                var temp2 = Db.ReadBook(bookID);
                temp2.Amount += amount;
                Db.Update(temp2);
            }
            return true;
        }
        /// <summary>
        /// Sets the amount of books for the bookid
        /// </summary>
        /// <param name="adminID">Adminid to perform the action</param>
        /// <param name="bookID">BookdID to add onto</param>
        /// <param name="amount">The amount of books to add</param>
        public void SetAmount(int adminID, int bookID, int amount)
        {
            if(!AdminLoggedIn(adminID))
            {
                return;
            }
            if (Db.ReadBook(bookID) is not null)
            {
                var temp2 = Db.ReadBook(bookID);
                temp2.Amount += amount;
                Db.Update(temp2);
            }
        }
        /// <summary>
        /// Returns a list of all users
        /// </summary>
        /// <param name="adminID">The AdminID to perform the action</param>
        /// <returns>All users in database. Null if fail</returns>
        public List<User> ListUsers(int adminID)
        {
            List<User> result = new();

            if (AdminLoggedIn(adminID))
            {
                result = Db.ReadUsers();
            }            
            return result;
        }
        /// <summary>
        /// Find user with matching keyword. AdminID is required
        /// </summary>
        /// <param name="adminID">AdminID to use</param>
        /// <param name="keyword">UserName to match</param>
        /// <returns>A list of users with matching username</returns>
        public List<User> FindUsers(int adminID, string keyword)
        {
            List<User> result = new();
            if (AdminLoggedIn(adminID))
            {
                result = Db.ReadUsers(keyword);
            }
            return result;
        }
        /// <summary>
        /// Updates a book in the database
        /// </summary>
        /// <param name="adminID">AdminID to use</param>
        /// <param name="bookID">BookID to update</param>
        /// <param name="title">Book title</param>
        /// <param name="author">Author</param>
        /// <param name="price">Price</param>
        /// <returns>True if successful, false if failed</returns>
        public bool UpdateBook(int adminID, int bookID, string title, string author, double price)
        {
            if (!AdminLoggedIn(adminID) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author))
            {
                return false;
            }
            if (Db.ReadBook(bookID) is not null)
            {
                Book book = Db.ReadBook(bookID);
                book.Author = author;
                book.Title = title;
                book.Price = price;
                Db.Update(book);
                return true;
            }          
            return false;
        }
        /// <summary>
        /// Delets a book from the database
        /// </summary>
        /// <param name="adminID">The adminID to use</param>
        /// <param name="bookID">The BookID to delete</param>
        /// <returns>True if successful, false if fail</returns>
        public bool DeleteBook(int adminID, int bookID)
        {
            if (!AdminLoggedIn(adminID))
            {
                return false;
            }
            if (Db.ReadBook(bookID) is not null)
            {
                Book book = Db.ReadBook(bookID);
                Db.Delete(book);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Add a bookCategory
        /// </summary>
        /// <param name="adminID">AdminID to use</param>
        /// <param name="name">Name of the BookCategory to add</param>
        /// <returns>True if successful, false if fail</returns>
        public bool AddCategory(int adminID, string name)
        {
            if (!AdminLoggedIn(adminID) || string.IsNullOrEmpty(name))
            {
                return false;
            }
            if (Db.ReadBookCategories(name).Count == 0)
            {
                BookCategory category = new()
                {
                    BookCategoryName = name
                };
                Db.Create(category);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Switches a book to a category
        /// </summary>
        /// <param name="adminID">The AdminID to use</param>
        /// <param name="bookID">The BookID to switch</param>
        /// <param name="category">The BookCategory to switch the book to</param>
        /// <returns>True if successful, false if fail</returns>
        public bool AddBookToCategory(int adminID, int bookID, int category)
        {
            if (!AdminLoggedIn(adminID))
            {
                return false;
            }
            if (Db.ReadBook(bookID) is not null)
            {
                if(Db.ReadBookCategory(category) is not null)
                {
                    Book book = Db.ReadBook(bookID);
                    book.BookCategoryID = category;
                    Db.Update(book);
                    return true;
                }
            }
           return false;
        }
        /// <summary>
        /// Updates a BookCategory
        /// </summary>
        /// <param name="adminID">The AdminID to use</param>
        /// <param name="categoryID">The CategoryID to change</param>
        /// <param name="name">The name to change to.</param>
        /// <returns></returns>
        public bool UpdateCategory(int adminID, int categoryID, string name)
        {
            if (!AdminLoggedIn(adminID) || string.IsNullOrEmpty(name))
            {
                return false;
            }
            if (Db.ReadBookCategory(categoryID) is not null)
            {
                BookCategory category = Db.ReadBookCategory(categoryID);
                category.BookCategoryName = name;
                Db.Update(category);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Delete that category
        /// </summary>
        /// <param name="adminID">AdminId to use</param>
        /// <param name="categoryID">CategoryID, represents Category to remove</param>
        /// <returns>True if successful, false if fail</returns>
        public bool DeleteCategory(int adminID, int categoryID)
        {
            if (!AdminLoggedIn(adminID))
            {
                return false;
            }
            if (Db.ReadBookCategory(categoryID) is not null)
            {
                BookCategory category = Db.ReadBookCategory(categoryID);
                Db.Delete(category);
                return true;
            }
           return false;
        }
        /// <summary>
        /// Lets an AdminID Add a User to the database
        /// </summary>
        /// <param name="adminID">The AdminID to use</param>
        /// <param name="name">The username</param>
        /// <param name="password">The password to use</param>
        /// <returns>True if succesful, false if fail</returns>
        public bool AddUser(int adminID, string name, string password)
        {
            if (!AdminLoggedIn(adminID))
            {
                return false;
            }
            if (Register(name, password, password))
            {
                return true;
            }
           return false;
        }
        /// <summary>
        /// Returns a list of books sold
        /// </summary>
        /// <param name="adminID">Adminid to access the method</param>
        /// <returns>A list of sold books</returns>
        public List<SoldBook>SoldItems(int adminID)
        {
            List<SoldBook> soldBooks = new();
            if (!AdminLoggedIn(adminID))
            {
                return soldBooks;
            }
            soldBooks = Db.ReadSoldBooks();           
            return soldBooks;
        }
        /// <summary>
        /// Returns the total amount of money sold for
        /// </summary>
        /// <param name="adminID">The adminID to accesss the method</param>
        /// <returns>The sum of the price of the books</returns>
        public double MoneyEarned(int adminID)
        {
            double result = 0.0;
            if (!AdminLoggedIn(adminID))
            {
                return result;
            }          
            result = SoldItems(adminID).Sum(x => x.Price);
            return result;
        }
        /// <summary>
        /// Returns the customer that bought the most books
        /// </summary>
        /// <param name="adminID">Admin ID to use</param>
        /// <returns>The User that bought the most books</returns>
        public User BestCustomer(int adminID)
        {
            User result = new();
            if (!AdminLoggedIn(adminID))
            {
                return result;
            }
            return Db.ReadUser(SoldItems(adminID).GroupBy(x => x.UserID).OrderByDescending(x => x.Count()).FirstOrDefault().FirstOrDefault().UserID); 
        }
        /// <summary>
        /// Promotes user to admin
        /// </summary>
        /// <param name="adminID">AdminID to use</param>
        /// <param name="userID">User to promote</param>
        /// <returns>True if success, false if fail</returns>
        public bool Promote(int adminID, int userID)
        {
            if (!AdminLoggedIn(adminID))
            {
                return false;
            }
            if(userID != adminID)
            {
                var temp2 = Db.ReadUser(userID);
                if (temp2 is not null)
                {
                    temp2.IsAdmin = true;
                    Db.Update(temp2);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Demotes user from admin to user. Cannot demote self.
        /// </summary>
        /// <param name="adminID">AdminID to use</param>
        /// <param name="userID">User to demote</param>
        /// <returns>True if success, false if fail</returns>
        public bool Demote(int adminID, int userID)
        {
            if (!AdminLoggedIn(adminID))
            {
                return false;
            }
            if (userID != adminID)
            {
                var temp2 = Db.ReadUser(userID);
                if (temp2 is not null)
                {
                    temp2.IsAdmin = false;
                    Db.Update(temp2);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Activates user.
        /// </summary>
        /// <param name="adminID">AdminID to use</param>
        /// <param name="userID">User to Activate</param>
        /// <returns>True if success, false if fail</returns>
        public bool ActivateUser(int adminID, int userID)
        {
            if (!AdminLoggedIn(adminID))
            {
                return false;
            }
            if (userID != adminID)
            {
                var temp2 = Db.ReadUser(userID);
                if (temp2 is not null)
                {
                    temp2.IsActive = true;
                    Db.Update(temp2);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Deactivates user.
        /// </summary>
        /// <param name="adminID">AdminID to use</param>
        /// <param name="userID">User to Deactivate</param>
        public bool InactivateUser(int adminID, int userID)
        {
            if (!AdminLoggedIn(adminID) && userID != adminID )
            {
                return false;
            }
            if (userID != adminID)
            {
                var temp2 = Db.ReadUser(userID);
                if (temp2 is not null)
                {
                    temp2.IsActive = false;
                    Db.Update(temp2);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Checks if the userID is an user
        /// </summary>
        /// <param name="userID">The userID to check</param>
        /// <returns>True if successful, false if fail</returns>
        public bool IsUser(int userID)
        {
            if(Db.Users.Any(x=> x.UserID == userID))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Checks if the adminID is an admin
        /// </summary>
        /// <param name="adminID">The adminID to check</param>
        /// <returns>True if successful, false if fail</returns>
        public bool IsAdmin(int adminID)
        {
            if (IsUser(adminID) && Db.Users.Any(x =>  x.UserID == adminID && x.IsAdmin == true))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Check if the user is logged in
        /// </summary>
        /// <param name="userID">The ID to check</param>
        /// <returns>True if logged in/active, false if not</returns>
        public bool IsLoggedIn(int userID)
        {
            if(IsUser(userID) && IsActive(Db.Users.FirstOrDefault(x=> x.UserID == userID)))
            { 
                return true;
            }
            return false;
        }
        /// <summary>
        /// Checks that it is an admin that is logged in
        /// </summary>
        /// <param name="adminID">The id to check</param>
        /// <returns>True if success, fail if not</returns>
        public bool AdminLoggedIn(int adminID)
        {
            return IsAdmin(adminID) && IsLoggedIn(adminID);
        }
        /// <summary>
        /// Updates the timer to datetime now
        /// </summary>
        /// <param name="user">The User object to update the Sessiontimer for</param>
        public void UpdateTimer(ref User user)
        {
            user.SessionTimer = DateTime.Now;
            Db.Update(user);
        }
        /// <summary>
        /// Checks if the user is active, max time 15 minutes. Returns true if it is, false if not.
        /// </summary>
        /// <param name="user">The user object to check</param>
        /// <returns>True if user is active, false if it is not</returns>
        public bool IsActive(User user)
        {
            if((DateTime.Now - user.SessionTimer).Minutes > 15)
            {
                Logout(user.UserID);
                Db.Update(user);
                return false;
            }
            else
            {
                UpdateTimer(ref user);
                return true;
            }           
        }
    }
}
