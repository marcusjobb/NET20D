using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using webshopAPI.Db;
using webshopAPI.Helpers;
using webshopAPI.Models;

namespace webshopAPI
{
    public class WebShopApi
    {
        private const int maxSessionTime = 15;
        private static Database db = new Database();

        /// <summary>
        ///
        /// </summary>
        /// <param name="adminId">Takes the user Id of the user to be promoted</param>
        /// <param name="userId">Takes a userId for activation.</param>
        /// <returns></returns>
        public bool ActivateUser(int adminId, int userId)
        {
            if (UserHelpers.IsUserApprovedForChanges(adminId))
            {
                var userToActivate = (from currentUser in db.Users
                                      where currentUser.Id == userId
                                      select currentUser).FirstOrDefault();
                try
                {
                    userToActivate.IsActive = true;
                    db.Users.Update(userToActivate);
                    db.SaveChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Adds a book to the database
        /// </summary>
        /// <param name="adminId">MANDATORY: Supply the logged in ID of the updating user.</param>
        /// <param name="amount">OPTIONAL: Supply the amount you want to add.</param>
        /// <param name="title">OPTIONAL: Supply the title of the book.</param>
        /// <param name="author">OPTIONAL: Supply the author of the book.</param>
        /// <param name="price">OPTIONAL: Supply the price of the book.</param>
        /// <param name="bookId">OPTIONAL: If you want to add X number of books
        /// to an existing book in database, supply the bookId.</param>
        /// <returns>Returns true if book is added or false if failed.
        /// </returns>
        public bool AddBook(
                    int adminId,
                    int amount = 1,
                    string title = "",
                    string author = "",
                    int price = 0,
                    int bookId = 0)
        {
            if (UserHelpers.IsUserApprovedForChanges(adminId))
            {
                UserHelpers.UpdateSessionTimer(adminId);
                var existingBook = (from book in db.Books
                                    where book.Id == bookId
                                    || book.Title == title
                                    && book.Author == author
                                    select book).FirstOrDefault();

                int addedBooksCounter = 0;
                if (existingBook == null)
                {
                    if (!string.IsNullOrEmpty(title)
                    && !string.IsNullOrEmpty(author)
                    && price >= 0)
                    {
                        existingBook = new Book()
                        {
                            Title = title,
                            Author = author,
                            Price = price,
                        };
                        existingBook.Amount++;
                        addedBooksCounter++;
                        db.Books.Add(existingBook);
                        db.SaveChanges();
                    }
                    else if (bookId > 0)
                    {
                        return false;
                    }
                    else
                    {
                        return false;
                    }
                }

                for (int books = 0; books < amount - addedBooksCounter; books++)
                {
                    existingBook.Amount++;
                }

                db.Books.Update(existingBook);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Adding a book to a specific category.
        /// Supply logged in userID, bookID and categoryID (to be added to).
        /// </summary>
        /// <param name="adminId">The logged in userID.</param>
        /// <param name="bookId">The bookID for the book.</param>
        /// <param name="categoryId">The categoryID for the
        /// category the book will be added to.</param>
        /// <returns>Returns true if add is successful,
        /// or false if it fails.</returns>
        public bool AddBookToCategory(
            int adminId,
            int bookId,
            int categoryId)
        {
            if (UserHelpers.IsUserApprovedForChanges(adminId))
            {
                UserHelpers.UpdateSessionTimer(adminId);

                var existingBook = (from book in db.Books
                                    where book.Id == bookId
                                    select book).FirstOrDefault();
                var chosenCategory = (from cat in db.BookCategories
                                      where cat.Id == categoryId
                                      select cat).FirstOrDefault();
                try
                {
                    existingBook.Category = chosenCategory;
                    db.SaveChanges();
                    db.Books.Update(existingBook);
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
        /// Adds a category to the database
        /// </summary>
        /// <param name="adminId">Suppy the userID of the logged in user.</param>
        /// <param name="categoryName">Supply the category name for the
        /// category to be added.</param>
        /// <returns>returns true if category is successfully added
        /// or false if adding category to DB fails</returns>
        public bool AddCategory(int adminId, string categoryName)
        {
            if (UserHelpers.IsUserApprovedForChanges(adminId))
            {
                UserHelpers.UpdateSessionTimer(adminId);

                if (string.IsNullOrEmpty(categoryName)
                    || string.IsNullOrWhiteSpace(categoryName))
                {
                    return false;
                }

                var alreadyExistingCategory = (from category in db.BookCategories
                                               where category.Name == categoryName
                                               select category).FirstOrDefault();

                if (alreadyExistingCategory == null)
                {
                    try
                    {
                        db.BookCategories.Add(new BookCategory(categoryName));
                        db.SaveChanges();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Adding a user (Only admins can do this).
        /// </summary>
        /// <param name="adminId">Supply the logged in userID
        /// (to check if the user is admin).</param>
        /// <param name="name">Supply the username of the new user.</param>
        /// <param name="password">Supply the desired password.</param>
        /// <returns>Returns true if user is created, false if not.
        /// </returns>
        public bool AddUser(int adminId, string name, string password)
        {
            if (UserHelpers.IsUserApprovedForChanges(adminId))
            {
                UserHelpers.UpdateSessionTimer(adminId);
                var alreadyExistingUser = (from user in db.Users
                                           where user.Name == name
                                           select name).FirstOrDefault();

                if (alreadyExistingUser == null)
                {
                    if (string.IsNullOrEmpty(name)
                        || string.IsNullOrWhiteSpace(name)
                        || string.IsNullOrEmpty(password)
                        || string.IsNullOrWhiteSpace(password))
                    {
                        return false;
                    }
                    else
                    {
                        db.Users.Add(new User(name, password, isActive: true, isAdmin: false));
                        db.SaveChanges();
                        return true;
                    }
                }

                return false;
            }

            return false;
        }

        /// <summary>
        /// Se what user that has bought the most books.
        /// </summary>
        /// <param name="adminId">Takes the user Id of the user to be checked for admin priviliges</param>
        /// <returns>Returns a tuple with user and integer (number of books bought)</returns>
        public (User, int) BestCustomer(int adminId)
        {
            if (UserHelpers.IsUserApprovedForChanges(adminId))
            {
                var ListOfCustomersWhoBoughtBooks = (from user in db.Users
                                                     join book in db.SoldBooks
                                                     on user.Id equals book.UserId
                                                     select user).Distinct().ToList();

                var customerWhoBoughtBooks = new List<(User, int)>();

                foreach (var customer in ListOfCustomersWhoBoughtBooks)
                {
                    var numberOfBooks = (from soldbook in db.SoldBooks
                                         where soldbook.UserId == customer.Id
                                         select soldbook).Count();

                    customerWhoBoughtBooks.Add((customer, numberOfBooks));
                }

                var returnValues = customerWhoBoughtBooks.OrderByDescending
                    (b => b.Item2).FirstOrDefault();

                return returnValues;
            }
            return (null, 0);
        }

        /// <summary>
        /// Method for buing a book and withdraw the right amount from book amount.
        /// </summary>
        /// <param name="userId">Supply the userId for the user</param>
        /// <param name="bookId">Supply the book</param>
        /// <returns>Returns true if book was bought or false if failed.</returns>
        public bool BuyBook(int userId, int bookId)
        {
            var user = (from currentUser in db.Users
                        where currentUser.Id == userId
                        && currentUser.IsActive
                        && currentUser.SessionTimer > DateTime.Now.AddMinutes(-maxSessionTime)
                        select currentUser).FirstOrDefault();
            if (user != null)
            {
                UserHelpers.UpdateSessionTimer(user.Id);
                var theBook = (from book in db.Books
                               where book.Id == bookId
                               select book).FirstOrDefault();

                if (theBook != null && theBook.Amount > 0)
                {
                    try
                    {
                        SoldBook theSoldBook = new SoldBook(theBook, user);
                        db.SoldBooks.Add(theSoldBook);
                        db.SaveChanges();

                        theBook.Amount--;
                        db.Books.Update(theBook);
                        db.SaveChanges();

                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Deletes a book from the database
        /// </summary>
        /// <param name="adminId">takes the user ID to check
        /// if user has admin privilages</param>
        /// <param name="bookId">Takes the book ID to delete</param>
        /// <param name="numberOfBooksToDelete">
        /// If nothing is supplied, it will delete one book,
        /// otherwise you can specify the number of books to delete.</param>
        /// <returns>Returns true if deleted, and false if not.
        /// </returns>
        public bool DeleteBook(
            int adminId,
            int bookId,
            int numberOfBooksToDelete = 1)
        {
            if (numberOfBooksToDelete < 0)
            {
                return false;
            }

            if (UserHelpers.IsUserApprovedForChanges(adminId))
            {
                UserHelpers.UpdateSessionTimer(adminId);
                var bookToRemove = (
                        from book in db.Books
                        where book.Id == bookId
                        select book).FirstOrDefault();
                if (bookToRemove == null)
                {
                    return false;
                }

                if (bookToRemove.Amount - numberOfBooksToDelete >= 1)
                {
                    for (int i = 0; i < numberOfBooksToDelete; i++)
                    {
                        bookToRemove.Amount--;
                    }
                    db.Books.Update(bookToRemove);
                    db.SaveChanges();
                }
                else
                {
                    db.Books.Remove(bookToRemove);
                    db.SaveChanges();
                }
                return true;
            }

            return false;
        }

        /// <summary>
        /// Deletes a category as long as there are no books in the category
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <returns>Returns true if successful and false if there is books
        /// in the category or if the user ain´t admin</returns>
        public bool DeleteCategory(int adminId, int categoryId)
        {
            if (UserHelpers.IsUserApprovedForChanges(adminId))
            {
                var deleteThisCategory = (from category in db.BookCategories
                                          where category.Id == categoryId
                                          select category).FirstOrDefault();

                var booksInCategory = (from book in db.Books
                                       where book.Category.Id == categoryId
                                       select book).FirstOrDefault();

                if (booksInCategory != null)
                {
                    return false;
                }

                try
                {
                    db.BookCategories.Remove(deleteThisCategory);
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
        /// Demote a user from admin to standard user
        /// </summary>
        /// <param name="adminId">Takes the user ID to check it if the user is admin</param>
        /// <param name="userId">Takes the user Id of the user to be demoted</param>
        /// <returns></returns>
        public bool Demote(int adminId, int userId)
        {
            if (UserHelpers.IsUserApprovedForChanges(adminId))
            {
                var userToDemote = (from currentUser in db.Users
                                    where currentUser.Id == userId
                                    select currentUser).FirstOrDefault();
                try
                {
                    userToDemote.IsAdmin = false;
                    db.Users.Update(userToDemote);
                    db.SaveChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Finds the user matching the searchKeyword
        /// </summary>
        /// <param name="adminId">Supply the admin ID of the user trying to use this method</param>
        /// <param name="searchKeyword">Supply the keyword to search for</param>
        /// <returns>Returns a collection of users matching the keyword</returns>
        public List<User> FindUser(int adminId, string searchKeyword)
        {
            List<User> listOfUsers = new List<User>();
            if (UserHelpers.IsUserApprovedForChanges(adminId))
            {
                return (from user in db.Users
                        where user.Name.Contains(searchKeyword)
                        select user).ToList();
            }
            return listOfUsers;
        }

        /// <summary>
        /// Get all availible (sellable) books within a category.
        /// The amount of books need to be 1 or more to count as sellable.
        /// </summary>
        /// <param name="categoryId">Supply the category Id to fetch books from</param>
        /// <returns>Returns a collection of Books (list)</returns>
        public List<Book> GetAvailibleBooks()
        {
            return (from book in db.Books
                    where book.Amount > 0
                    select book).Include(book => book.Category).ToList();
        }

        /// <summary>
        /// Fetches and returns a book matching the ID supplied.
        /// </summary>
        /// <param name="bookId">Supply the book Id to fetch</param>
        /// <returns>Returns a book matching the supplied bookId</returns>
        public Book GetBook(int bookId)
        {
            return (from book in db.Books
                    where book.Id == bookId
                    select book).SingleOrDefault();
        }

        /// <summary>
        /// Get the books matching a specific keyword.
        /// </summary>
        /// <param name="keyword">Supply the keyword to search for</param>
        /// <returns>Returns a collection of Books matching the search.</returns>
        public List<Book> GetBooks(string keyword)
        {
            //return (from book in db.Books
            //        join bookCategory in db.BookCategories
            //        on book.Category.Id equals bookCategory.Id
            //        where book.Title.Contains(keyword)
            //        select book).ToList();

            //Varför fungerar inte koden ovan?

            return (from book in db.Books
                    where book.Title.Contains(keyword)
                    && book.Amount > 0
                    select book).Include(book => book.Category).ToList();
        }

        /// <summary>
        /// Get the books written by authors matching the keyword supplied.
        /// </summary>
        /// <param name="keyword">Supply a keyword to search for</param>
        /// <returns>Returns a collection of Books matching the search keyword.</returns>
        public List<Book> GetBooksByAuthor(string keyword)
        {
            return (from book in db.Books
                    where book.Author.Contains(keyword)
                    select book).Include(book => book.Category).ToList();
        }

        /// <summary>
        /// Gets the books in a specific category
        /// </summary>
        /// <param name="categoryId">Supply the category id of the category to get books from</param>
        /// <returns>Returns a collection of books (in a list)</returns>
        public List<Book> GetBooksInCategory(int categoryId)
        {
            List<Book> listOfBooks = new List<Book>();

            listOfBooks = (from book in db.Books
                           where book.Category.Id == categoryId
                           && book.Amount > 0
                           select book).ToList();

            return listOfBooks;
        }

        /// <summary>
        /// Get all the categories in the database
        /// </summary>
        /// <returns>Returns a list of categories,
        /// no matter if the list is null or contains categories</returns>
        public List<BookCategory> GetCategories()
        {
            return (from category in db.BookCategories
                    select category).ToList();
        }

        /// <summary>
        /// Get the categories matching a specific keyword
        /// </summary>
        /// <param name="keyword">Supply a keyword to search for</param>
        /// <returns>A list of the matching categories.</returns>
        public List<BookCategory> GetCategories(string keyword)
        {
            return (from category in db.BookCategories
                    where category.Name.Contains(keyword)
                    select category).ToList();
        }

        /// <summary>
        /// Inactivate user so that they can´t use the services.
        /// </summary>
        /// <param name="adminId">Takes the user Id of the user to be checked for admin priviliges</param>
        /// <param name="userId">Takes the user Id of the user to be inactivated</param>
        /// <returns></returns>
        public bool InactivateUser(int adminId, int userId)
        {
            if (UserHelpers.IsUserApprovedForChanges(adminId))
            {
                var userToInactivate = (from currentUser in db.Users
                                        where currentUser.Id == userId
                                        select currentUser).FirstOrDefault();
                try
                {
                    userToInactivate.IsActive = false;
                    db.Users.Update(userToInactivate);
                    db.SaveChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// List all users
        /// </summary>
        /// <param name="adminId">Supply the admin ID of the user trying to list users</param>
        /// <returns>Returns a collection of Users (list)</returns>
        public List<User> ListUsers(int adminId)
        {
            List<User> listOfUsers = new List<User>();
            if (UserHelpers.IsUserApprovedForChanges(adminId))
            {
                listOfUsers = (from user in db.Users
                               select user).ToList();
            }
            return listOfUsers;
        }

        /// <summary>
        /// Login method that returns the ID of the logged in
        /// user if correctly logged in.
        /// </summary>
        /// <param name="username">Takes the username of the user.</param>
        /// <param name="password">Takes the password of the user.</param>
        /// <returns>Returns database ID of the user if match is found.
        /// Else returns 0.</returns>
        public User Login(string username, string password)
        {
            var loggedInUser = (from user in db.Users
                                where user.Name == username
                                && user.Password == password
                                && user.IsActive
                                select user).FirstOrDefault();

            if (loggedInUser != null)
            {
                loggedInUser.LastLogin = DateTime.Now;
                loggedInUser.SessionTimer = DateTime.Now;
                db.Users.Update(loggedInUser);
                db.SaveChanges();
            }

            return loggedInUser;
        }

        /// <summary>
        /// Log out the user
        /// </summary>
        /// <param name="userId">Takes the user ID as an in parameter</param>
        /// <returns>Returs a user object if you want to check
        /// if the logout was successful.
        /// To do this, check if SessionTimer on the user is set to null.</returns>
        public void Logout(int userId)
        {
            var logOutUser = (from user in db.Users
                              where user.Id == userId
                              select user).FirstOrDefault();

            try
            {
                logOutUser.SessionTimer = null;
                db.Users.Update(logOutUser);
                db.SaveChanges();
            }
            catch
            {
                //If it fails, it should do nothing.
            }
        }

        /// <summary>
        /// Calculates the money earned on all sales
        /// </summary>
        /// <param name="adminId">Takes the user ID to check it if the user is admin</param>
        /// <returns>Returns the money of the sales</returns>
        public int MoneyEarned(int adminId)
        {
            return (from book in db.SoldBooks
                    select book.Price).Sum();
        }

        /// <summary>
        /// Pings the server to check so the user is online.
        /// Checks the last activity towards the server.
        /// This can be maximum 15 minutes, or else the user will be logged out
        /// </summary>
        /// <param name="userId">Supply the user Id to check</param>
        /// <returns>Pong if user is online and active.
        /// Empty string if the user is logged out</returns>
        public string Ping(int userId)
        {
            var currentUser = (
                from user in db.Users
                where user.Id == userId
                && user.SessionTimer > DateTime.Now.AddMinutes(-maxSessionTime)
                select user).FirstOrDefault();

            if (currentUser == null)
            {
                return string.Empty;
            }

            UserHelpers.UpdateSessionTimer(currentUser.Id);
            return "Pong";
        }

        /// <summary>
        /// Promote specific user to admin
        /// </summary>
        /// <param name="adminId">Takes the user ID to check it if the user is admin</param>
        /// <param name="userId">Takes the user Id of the user to be promoted</param>
        /// <returns></returns>
        public bool Promote(int adminId, int userId)
        {
            if (UserHelpers.IsUserApprovedForChanges(adminId))
            {
                var userToPromote = (from currentUser in db.Users
                                     where currentUser.Id == userId
                                     select currentUser).FirstOrDefault();
                try
                {
                    userToPromote.IsAdmin = true;
                    db.Users.Update(userToPromote);
                    db.SaveChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method for registering a user.
        /// </summary>
        /// <param name="name">Takes a name as a username.
        /// This name can not already be in the database,
        /// in that case the registration will fail</param>
        /// <param name="password">Supply a password for the user</param>
        /// <param name="passwordVerify">Re-type the password for the user</param>
        /// <returns>true if registration was successful,
        /// false if registration failed due to not matching passwords
        /// & name already in database</returns>
        public bool Register(
            string name,
            string password,
            string passwordVerify)
        {
            var existingUser = (from user in db.Users
                                where user.Name == name
                                select user.Name).FirstOrDefault();
            if (existingUser == null)
            {
                try
                {
                    if (password == passwordVerify
                        && !string.IsNullOrEmpty(password)
                        && !string.IsNullOrWhiteSpace(password))
                    {
                        User newUser = new User(name, password, isAdmin: false);
                        db.Users.Add(newUser);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Sets the amount of books to the provided number.
        /// It´s not possible to set books to negative number.
        /// </summary>
        /// <param name="adminId">Provide the userId of the admin priviliged user.</param>
        /// <param name="bookId">Provide the book id of the book to increment or decrement</param>
        /// <param name="amountToSet">provide the amount of books to add/withdraw</param>
        /// <returns>returns true if successful, or false if failed.</returns>
        public bool SetAmount(int adminId, int bookId, int amountToSet)
        {
            if (UserHelpers.IsUserApprovedForChanges(adminId))
            {
                UserHelpers.UpdateSessionTimer(adminId);

                var updateThisBook = (from book in db.Books
                                      where bookId == book.Id
                                      select book).FirstOrDefault();

                if (updateThisBook != null &&
                    updateThisBook.Amount + amountToSet > 0)
                {
                    updateThisBook.Amount += amountToSet;
                    db.Books.Update(updateThisBook);
                    db.SaveChanges();
                    return true;
                }
                else if (updateThisBook != null &&
                    updateThisBook.Amount + amountToSet <= 0)
                {
                    amountToSet = amountToSet - amountToSet * 2; //Convert minusnumber to plus equivalent
                    var successOrFail = DeleteBook(adminId, bookId, amountToSet);
                    return successOrFail;
                }
            }
            return false;
        }

        /// <summary>
        /// This method finds all the sold items
        /// </summary>
        /// <param name="adminId">supply the admin ID of the user searching</param>
        /// <returns>returns a collection of SoldBooks (list)</returns>
        public List<SoldBook> SoldItems(int adminId)
        {
            List<SoldBook> soldBooks = new List<SoldBook>();

            if (UserHelpers.IsUserApprovedForChanges(adminId))
            {
                soldBooks = (from bookInfo in db.SoldBooks
                             select bookInfo).ToList();
            }
            return soldBooks;
        }

        /// <summary>
        /// This method updates the title, author and price of a book.
        /// If you want to re-attatch the book to another category,
        /// you should use addbooktocategory
        /// </summary>
        /// <param name="adminId">Supply the admin Id of the changing user</param>
        /// <param name="bookId">Supply the book Id to be changed</param>
        /// <param name="title">Supply the new title</param>
        /// <param name="author">Supply the author</param>
        /// <param name="price">Supply the new price</param>
        /// <returns>Returns true if successfully changed, or false if not.</returns>
        public bool UpdateBook(
            int adminId,
            int bookId,
            string title,
            string author,
            int price)
        {
            if (UserHelpers.IsUserApprovedForChanges(adminId))
            {
                var updateThisBook = (from book in db.Books
                                      where book.Id == bookId
                                      select book).FirstOrDefault();

                if (string.IsNullOrEmpty(title) ||
                    string.IsNullOrWhiteSpace(title)
                    || string.IsNullOrEmpty(author) ||
                    string.IsNullOrWhiteSpace(author)
                    || price < 0 || updateThisBook == null)
                {
                    return false;
                }

                var alreadyExistingBook = (from book in db.Books
                                           where book.Title == title
                                           && book.Author == author
                                           && book.Price == price
                                           select book).FirstOrDefault();
                if (alreadyExistingBook == null)
                {
                    updateThisBook.Title = title;
                    updateThisBook.Author = author;
                    updateThisBook.Price = price;
                    db.Books.Update(updateThisBook);
                    db.SaveChanges();
                    return true;
                }
                SetAmount(adminId, alreadyExistingBook.Id, updateThisBook.Amount);
                DeleteBook(adminId, updateThisBook.Id, updateThisBook.Amount);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Update the category with a new name.
        /// </summary>
        /// <param name="adminId">Supply the admin Id of the changing user</param>
        /// <param name="categoryId">Supply the category so
        /// the right category can be found</param>
        /// <param name="categoryName">Supply the category Name to be changed.
        /// </param>
        /// <returns>Returns true if successful, or false if not.</returns>
        public bool UpdateCategory(
            int adminId,
            int categoryId,
            string categoryName)
        {
            if (UserHelpers.IsUserApprovedForChanges(adminId))
            {
                var updateThisCategory = (from category in db.BookCategories
                                          where category.Id == categoryId
                                          select category).FirstOrDefault();
                var alreadyExistingCategory = (from category in db.BookCategories
                                               where category.Name == categoryName
                                               select category).FirstOrDefault();

                if (alreadyExistingCategory != null
                    || string.IsNullOrEmpty(categoryName) ||
                    string.IsNullOrWhiteSpace(categoryName)
                    || updateThisCategory == null)
                {
                    db.BookCategories.Remove(updateThisCategory);
                    db.SaveChanges();
                    return false;
                }

                updateThisCategory.Name = categoryName;
                db.BookCategories.Update(updateThisCategory);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}