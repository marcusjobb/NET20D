using Inlamningsuppgift2WebbShopAPI.Database;
using Inlamningsuppgift2WebbShopAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Inlamningsuppgift2WebbShopAPI
{
    /// <summary>
    /// This Class acts as an API and fetches data and saves data to the database.
    /// </summary>
    public class WebbShopAPI
    {
        private readonly WebbShopContext db = new WebbShopContext();

        public WebbShopAPI()
        {
            
        }

        #region public Methods

        /// <summary>
        /// Activates an inactive user to an active one.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns>True if sucess, else false</returns>
        public bool ActivateUser(int adminId, int userId)
        {
            try
            {
                if (IsUserAdmin(adminId) && UserExist(userId, out var user))
                {
                    Login(user.Name, user.Password);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to actiate user " + ex);
                return false;
            }
        }

        /// <summary>
        /// Adds a book. Returns true if User is admin and input contains data. If book already exists
        /// it just adds onto that books amount.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <param name="amount"></param>
        /// <returns>A bool true if sucess, else false</returns>
        public bool AddBook(int adminId, string title, string author, int price, int amount)
        {
            try
            {
                if (IsUserAdmin(adminId) && IsUserActive(adminId))
                {
                    if (BookExist(title, author))
                    {
                        //Book does exist already
                        var book = db.Books.Where(b => b.Title.Equals(title) && b.Author.Equals(author)).FirstOrDefault();
                        if (book != null)
                        {
                            book.Amount += amount;
                            SetUserActive(adminId);         
                            db.SaveChanges();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        //Book does not exist
                        if (title != string.Empty && author != string.Empty && price > 0 && amount > 0)
                        {
                            db.Books.Add(new Book
                            {
                                Title = title,
                                Author = author,
                                Price = price,
                                Amount = amount
                            });
                            SetUserActive(adminId);
                            db.SaveChanges();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    //User is not admin
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to add book " + ex);
                return false;
            }
        }

        /// <summary>
        /// Adds a category to a book by categoryid to bookid, if user is admin
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="categoryId"></param>
        /// <returns>Returns true if successful, else false</returns>
        public bool AddBookToCategory(int adminId, int bookId, int categoryId)
        {
            try
            {
                if (IsUserAdmin(adminId) && BookExist(bookId))
                {
                    var book = db.Books.Where(b => b.Id.Equals(bookId)).Include(b => b.Category).FirstOrDefault();
                    if (book != null)
                    {
                        book.Category = db.BookCategories.Where(c => c.Id.Equals(categoryId)).FirstOrDefault();
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to add book to category " + ex);
                return false;
            }
        }

        /// <summary>
        /// Adds a new category to book categories
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryName"></param>
        /// <returns>Returns true if sucessfull else false.</returns>
        public bool AddCategory(int adminId, string categoryName)
        {
            try
            {
                if (IsUserAdmin(adminId))
                {
                    if (categoryName != string.Empty)
                    {
                        db.BookCategories.Add(new BookCategory
                        {
                            Category = categoryName
                        });
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to add category " + ex);
                return false;
            }
        }

        /// <summary>
        /// Admin can add a user.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns>True if success else false</returns>
        public bool AddUser(int adminId, string name, string password)
        {
            try
            {
                if (IsUserAdmin(adminId) && name != string.Empty && !UserExist(name))
                {
                    //Teacher wanted to add a default value.
                    //Default value can be set in migrationfile, adding defaultValue: "Codic2021"
                    //Or it can be added with fluent api overriding OnModelCreating
                    if (password == string.Empty)
                    {
                        password = "Codic2021";
                    }

                    db.Users.Add(new User
                    {
                        Name = name,
                        Password = password,
                        IsActive = false,
                        IsAdmin = false,
                    });
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to add user" + ex);
                return false;
            }
        }

        /// <summary>
        /// Gets the user that has bought most books.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>A Obj by type User</returns>
        public User BestCustomer(int adminId)
        {
            try
            {
                if (IsUserAdmin(adminId))
                {
                    var soldBooksList = db.SoldBooks.ToList();
                    if (soldBooksList != null)
                    {
                        // Learned this one at https://stackoverflow.com/questions/2655759/how-to-get-the-most-common-value-in-an-int-array-c
                        var group = soldBooksList.GroupBy(u => u.UserId).OrderByDescending(u => u.Count()).Select(u => u.Key).FirstOrDefault();

                        return db.Users.Where(u => u.Id.Equals(Convert.ToInt32(group))).FirstOrDefault();
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed retrieve best customer user obj  " + ex);
                return null;
            }
        }

        /// <summary>
        /// User Buys a book and the book gets copied to SoldBooks and also the book gets -1 in amount
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <returns>A bool if sucessful or not</returns>
        public bool BuyBook(int userId, int bookId)
        {
            try
            {
                var user = db.Users.Where(u => u.Id.Equals(userId)).FirstOrDefault();
                if (user != null)
                {
                    if (IsUserActive(user.Id))
                    {
                        var bookToBuy = db.Books.Where(b => b.Id.Equals(bookId)).Include(b => b.Category).FirstOrDefault();
                        if (bookToBuy != null && bookToBuy.Amount > 0)
                        {
                            db.SoldBooks.Add(new SoldBook
                            {
                                Title = bookToBuy.Title,
                                Author = bookToBuy.Author,
                                Category = bookToBuy.Category,
                                Price = bookToBuy.Price,
                                PurchasedDate = DateTime.Now,
                                UserId = user.Id
                            });
                            bookToBuy.Amount--;
                            user.SessionTimer = DateTime.Now;
                            db.SaveChanges();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to check if buy book is possible " + ex);
                return false;
            }
        }

        /// <summary>
        /// Deletes a book specified as bookId if user is admin
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <returns>Bool true if successful else false.</returns>
        public bool DeleteBook(int adminId, int bookId)
        {
            try
            {
                if (IsUserAdmin(adminId))
                {
                    if (BookExist(bookId))
                    {
                        var book = db.Books.Where(b => b.Id.Equals(bookId)).FirstOrDefault();
                        book.Amount--;
                        if (book.Amount <= 0)
                        {
                            db.Books.Remove(book);
                            db.SaveChanges();
                            return true;
                        }
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to delete book " + ex);
                return false;
            }
        }

        /// <summary>
        /// Deletes a category if user is admin and category exists.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <returns>True if success, else false</returns>
        public bool DeleteCategory(int adminId, int categoryId)
        {
            try
            {
                if (IsUserAdmin(adminId) && CategoryExist(categoryId, out var category) && !AnyBooksInCategory(categoryId))
                {
                    db.BookCategories.Remove(category);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to Delete a category " + ex);
                return false;
            }
        }

        /// <summary>
        /// Demotes user from admin. Makes it a normal user.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns>True if success else false.</returns>
        public bool Demote(int adminId, int userId)
        {
            try
            {
                if (IsUserAdmin(adminId) && UserExist(userId, out var user))
                {
                    user.IsAdmin = false;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to demote a user " + ex);
                return false;
            }
        }

        /// <summary>
        /// Returns a list of users which Matches the input keyword in their names
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="keyword"></param>
        /// <returns>A List of Users</returns>
        public List<User> FindUser(int adminId, string keyword)
        {
            var list = db.Users.Where(u => u.Name.Contains(keyword)).ToList();
            if (list != null)
            {
                return list;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns a list of books written by author in the keyword.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>A List of type Book</returns>
        public List<Book> GetAuthors(string keyword)
        {
            var list = db.Books.Where(b => b.Author.Contains(keyword)).Include(b => b.Category).ToList();
            if (list != null)
            {
                return list;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns a list of Books by book category id input and where the property amount is more than 0
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>List of type Book</returns>
        public List<Book> GetAvailableBooks(int categoryId)
        {
            var list = db.Books.Where(b => b.Category.Id.Equals(categoryId) && b.Amount > 0).ToList();
            if (list != null)
            {
                return list;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns all books in database as a list of type book.
        /// </summary>
        /// <returns>List of type book</returns>
        public List<Book> GetAllBooks()
        {
            var list = db.Books.Include(b => b.Category).ToList();
            if (list != null)
            {
                return list;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns a book with all information about a book by book id.
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns>A Book object</returns>
        public Book GetBook(int bookId)
        {
            try
            {
                var book = db.Books.Where(b => b.Id.Equals(bookId)).Include(b => b.Category).FirstOrDefault();
                if (book != null)
                {
                    return book;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to get book " + ex);
                return null;
            }
        }

        /// <summary>
        /// Gets a list of books by keyword of either Author or Title of the book.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>A List of type Book</returns>
        public List<Book> GetBooks(string keyword)
        {
            var list = db.Books.Where(b => b.Title.Contains(keyword) || b.Author.Contains(keyword)).Include(b => b.Category).ToList();
            if (list != null)
            {
                return list;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns a list of all BookCategories.
        /// </summary>
        /// <returns>List of type BookCategory</returns>
        public List<BookCategory> GetCategories()
        {
            var list = db.BookCategories.ToList();
            if (list != null)
            {
                return list;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns a list of book categories matching keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>A List of book categories</returns>
        public List<BookCategory> GetCategories(string keyword)
        {
            var list = db.BookCategories.Where(b => b.Category.Contains(keyword)).ToList();
            if (list != null)
            {
                return list;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets a list of books by category id input
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>List of type Book</returns>
        public List<Book> GetCategory(int categoryId)
        {
            var list = db.Books.Where(b => b.Category.Id.Equals(categoryId)).ToList();
            if (list != null)
            {
                return list;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Deactivates a user.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns>True if sucess, else false</returns>
        public bool InactivateUser(int adminId, int userId)
        {
            try
            {
                if (IsUserAdmin(adminId) && UserExist(userId, out var user))
                {
                    Logout(userId);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to Deactivate / Inactivate user " + ex);
                return false;
            }
        }

        /// <summary>
        /// Returns a list of Users. If user is Admin.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>A List of type User</returns>
        public List<User> ListUsers(int adminId)
        {
            if (IsUserAdmin(adminId))
            {
                return db.Users.ToList();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Delegate for returning a list of users. Just some delgate testing.
        /// </summary>
        public Func<int, List<User>> ListUsersDelegate;
        public void RunWebApi()
        {
            ListUsersDelegate = x => IsUserAdmin(x) ? db.Users.ToList() : null;
        }

        /// <summary>
        /// Logs a user in and returns User ID.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>User Id</returns>
        public int? Login(string username, string password)
        {
            try
            {
                var user = db.Users.Where(u => u.Name.Equals(username) && u.Password.Equals(password)).FirstOrDefault();
                if (user != null)
                {
                    user.SessionTimer = DateTime.Now;
                    user.LastLogin = DateTime.Now;
                    user.IsActive = true;
                    db.SaveChanges();
                    return user.Id;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to Login " + ex);
                return null;
            }
        }

        /// <summary>
        /// Logs the user out and sets the user session time at a default state.
        /// </summary>
        /// <param name="userId"></param>
        public void Logout(int userId)
        {
            try
            {
                var user = db.Users.Where(u => u.Id.Equals(userId)).FirstOrDefault();
                if (user != null)
                {
                    user.SessionTimer = default(DateTime);
                    user.IsActive = false;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to Logout " + ex);
            }
        }
        /// <summary>
        /// Returns total money earned from sold books in an integer.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>An Int of sum</returns>
        public int MoneyEarned(int adminId)
        {
            int sum = 0;
            try
            {
                if (IsUserAdmin(adminId))
                {
                    //return total price for all soldbooks
                    var list = SoldItems(adminId);
                    foreach (SoldBook sb in list)
                    {
                        sum += sb.Price;
                    }
                    return sum;
                }
                else
                {
                    return sum;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to get money earned " + ex);
                return sum;
            }
        }

        /// <summary>
        /// Pings the user to check if the user has been active ´the last 15 minutes.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>A string containing "Pong" if user is active last 15 min. Else return string.Empty</returns>
        public string Ping(int userId)
        {
            if (IsUserActive(userId))
            {
                return "Pong";
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Promotes a user to Admin.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns>Returns true if sucessfull, else false.</returns>
        public bool Promote(int adminId, int userId)
        {
            try
            {
                if (IsUserAdmin(adminId) && UserExist(userId, out var user))
                {
                    user.IsAdmin = true;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to Promote " + ex);
                return false;
            }
        }

        /// <summary>
        /// Registers a user with name and two passwords that must be the same.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="passwordVerify"></param>
        /// <returns>True if success, false if fail</returns>
        public bool Register(string name, string password, string passwordVerify)
        {
            try
            {
                if (!UserExist(name, password) && name != string.Empty && password == passwordVerify && passwordVerify != string.Empty && password != string.Empty)
                {
                    db.Users.Add(new User
                    {
                        Name = name,
                        Password = password,
                        IsActive = true,
                        IsAdmin = false,
                    });
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to Regist " + ex);
                return false;
            }
        }
        /// <summary>
        /// Sets the amount of a Book if User is admin.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="amount"></param>
        /// <returns>True if added amount was sucessfull. Else false.</returns>
        public bool SetAmount(int adminId, int bookId, int amount)
        {
            try
            {
                if (IsUserAdmin(adminId))
                {
                    if (BookExist(bookId, out Book book))
                    {
                        if (book != null && amount > 0)
                        {
                            book.Amount = amount;
                            db.SaveChanges();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to set amount " + ex);
                return false;
            }
        }
        /// <summary>
        /// Returns a list of sold books.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>A List of type SoldBOok, else null</returns>
        public List<SoldBook> SoldItems(int adminId)
        {
            try
            {
                if (IsUserAdmin(adminId))
                {
                    var list = db.SoldBooks.ToList();
                    if (list != null)
                    {
                        return list;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to retrieve sold items " + ex);
                return null;
            }
        }

        /// <summary>
        /// Updates a book if user is admin and bookId does exist.
        /// Updates title, author and price
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <returns>Returns true if sucessful. Else False</returns>
        public bool UpdateBook(int adminId, int bookId, string title, string author, int price)
        {
            try
            {
                if (IsUserAdmin(adminId))
                {
                    if (BookExist(bookId, out var book))
                    {
                        book.Title = title;
                        book.Author = author;
                        book.Price = price;
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to failed to update book" + ex);
                return false;
            }
        }
        /// <summary>
        /// Updates the category name by catergory id input, if user is admin.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <param name="name"></param>
        /// <returns>True if successful else false</returns>
        public bool UpdateCategory(int adminId, int categoryId, string name)
        {
            try
            {
                if (IsUserAdmin(adminId) && CategoryExist(categoryId, out var category))
                {
                    category.Category = name;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to update category " + ex);
                return false;
            }
        }
        #endregion public Methods

        #region Private methods

        /// <summary>
        /// Returns true if there are any book that has the category entered
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>Returns true if books got category. else false</returns>
        private bool AnyBooksInCategory(int categoryId)
        {
            try
            {
                //List of books
                var listofBooks = GetCategory(categoryId);

                //List of Solbooks
                var listOfSoldbooks = db.SoldBooks.Where(b => b.Category.Id.Equals(categoryId)).ToList();

                if (listofBooks.Count > 0 || listOfSoldbooks.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to check any books in category " + ex);
                return false;
            }
        }

        /// <summary>
        /// Checks if a book already exist based on title and author. Returns true if it exist.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <returns>True if exists. Else false</returns>
        private bool BookExist(string title, string author)
        {
            try
            {
                var book = db.Books.Where(b => b.Title.Equals(title) && b.Author.Equals(author)).FirstOrDefault();
                if (book != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to check if book exist " + ex);
                return false;
            }
        }

        /// <summary>
        /// Checks if a book already exist based on book id. Returns true if it exist.
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns>True if the book exists</returns>
        private bool BookExist(int bookId)
        {
            try
            {
                var book = db.Books.Where(b => b.Id.Equals(bookId)).FirstOrDefault();
                if (book != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to check if book exist " + ex);
                return false;
            }
        }

        /// <summary>
        /// Checks if a book already exist based on book id. Returns true if it exist and the book in out book.
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="book"></param>
        /// <returns>True if exists and out oject of Book Type</returns>
        private bool BookExist(int bookId, out Book book)
        {
            book = null;
            try
            {
                book = db.Books.Where(b => b.Id.Equals(bookId)).FirstOrDefault();
                if (book != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to check if book exist " + ex);
                return false;
            }
        }

        /// <summary>
        /// Checks if category extist by id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>True if successful else false</returns>
        private bool CategoryExist(int categoryId)
        {
            try
            {
                var cat = db.BookCategories.Where(c => c.Id.Equals(categoryId)).FirstOrDefault();
                if (cat != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to check if category exist " + ex);
                return false;
            }
        }

        /// <summary>
        /// Checks if category exist by id , also out BookCategory.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="category"></param>
        /// <returns>True if successful else false</returns>
        private bool CategoryExist(int categoryId, out BookCategory category)
        {
            category = null;
            try
            {
                category = db.BookCategories.Where(c => c.Id.Equals(categoryId)).FirstOrDefault();
                if (category != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to check if category exist " + ex);
                return false;
            }
        }

        /// <summary>
        /// Returns the User by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Returns a object of type User</returns>
        private User GetUser(int userId)
        {
            return db.Users.Where(u => u.Id.Equals(userId)).FirstOrDefault();            
        }

        /// <summary>
        /// Checks if user is in the 15 minute active window. Otherwise logs user out.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>A bool true if active. Else false within 15 minutes</returns>
        private bool IsUserActive(int userId)
        {
            try
            {
                var user = db.Users.Where(u => u.Id.Equals(userId)).FirstOrDefault();
                if (user != null)
                {
                    if (DateTime.Now <= user.SessionTimer.AddMinutes(15))
                    {
                        //User is still active within 15 minute window.
                        user.SessionTimer = DateTime.Now;
                        return true;
                    }
                    else
                    {
                        //User has been inactive for over 15 minutes.
                        Logout(user.Id);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to check if user is active " + ex);
                return false;
            }
        }

        /// <summary>
        /// Checks if user is admin. Returns true if the user is admin.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Returns true if user is admin. Else false</returns>
        public bool IsUserAdmin(int userId)
        {
            try
            {
                var user = db.Users.Where(u => u.Id.Equals(userId)).FirstOrDefault();
                if (user != null)
                {
                    if (user.IsAdmin)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to check if user is admin " + ex);
                return false;
            }
        }

        /// <summary>
        /// Checks if the user exists. If there is a user with exact name and password that is matching in the database it returns true.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns>A bool true if exist. Else false</returns>
        private bool UserExist(string name, string password)
        {
            try
            {
                var user = db.Users.Where(u => u.Name.Equals(name) && u.Password.Equals(password)).FirstOrDefault();
                if (user != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to check if user exist " + ex);
                return false;
            }
        }

        /// <summary>
        /// Checks if the user exists. If there is a user with exact name is matching in the database it returns true.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool UserExist(string name)
        {
            try
            {
                var user = db.Users.Where(u => u.Name.Equals(name)).FirstOrDefault();
                if (user != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to check if user exist " + ex);
                return false;
            }
        }

        /// <summary>
        /// Checks if the user exists. If there is a user id matching in the database it returns true.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool UserExist(int userId, out User user)
        {
            user = null;
            try
            {
                user = db.Users.Where(u => u.Id.Equals(userId)).FirstOrDefault();
                if (user != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to check if user exist " + ex);
                return false;
            }
        }


        /// <summary>
        /// Sets the users sessiontimer to DateTime.Now;
        /// </summary>
        /// <param name="userId"></param>
        private void SetUserActive(int userId)
        {
            try
            {
                var user = db.Users.Where(u => u.Id.Equals(userId)).FirstOrDefault();    
                user.SessionTimer = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to set user active " + ex);
            }
        }
        #endregion Private methods
    }
}