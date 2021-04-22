namespace FrontEndJesperPersson.Controller
{
    using System.Collections.Generic;
    using WebbShopJesperPersson;
    using WebbShopJesperPersson.Model;

    internal class CustomerController
    {
        private readonly WebbShopAPI api = new WebbShopAPI();

        /// <summary>
        /// Log in user.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>User</returns>
        public User Login(string username, string password) => api.Login(username, password);

        /// <summary>
        /// Buys a book if amount is more then 1 and exist in database. User needs to be online and active.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <returns>true if success, false if fails.</returns>
        internal bool BuyBook(int userId, int bookId) => api.BuyBook(userId, bookId);

        /// <summary>
        /// Get all books in database with a amount more then 0.
        /// </summary>
        /// <returns>a list of books.</returns>
        internal List<Book> GetAvailableBooks() => api.GetAvailableBooks();

        /// <summary>
        ///Get books by author
        /// </summary>
        /// <param name="keyword"> a letter or name.</param>
        /// <returns>a list of books where the author contains the keyword.</returns>
        internal List<Book> GetBooksByAuthors(string keyword) => api.GetAuthors(keyword);

        /// <summary>
        /// Search book by keyword.
        /// </summary>
        /// <param name="keyword">a letter or name.</param>
        /// <returns> a list of books that contains the keyword.</returns>
        internal List<Book> GetBooksByKeyword(string keyword) => api.GetBooks(keyword);

        /// <summary>
        /// Get books in a certain category.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>List of book in choosen category.</returns>
        internal List<Book> ListBookInCategory(int categoryId) => api.GetCategory(categoryId);

        /// <summary>
        /// Get all categories in database.
        /// </summary>
        /// <returns>the list of categories.</returns>
        internal List<BookCategory> ListCategories() => api.GetCategories();

        /// <summary>
        /// log out the user.
        /// </summary>
        /// <param name="userId"></param>
        internal void LogOut(int userId) => api.LogOut(userId);

        /// <summary>
        /// To make sure the user is still active and online. Updates sessiontime.
        /// </summary>
        /// <param name="userId"></param>
        internal void Ping(int userId) => api.Ping(userId);

        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="passwordVerify"></param>
        /// <returns>true if success, false if fails.</returns>
        internal bool Register(string username, string password, string passwordVerify) => api.Register(username, password, passwordVerify);

        /// <summary>
        /// Get categori by keyword.
        /// </summary>
        /// <param name="keyword">a letter or category name.</param>
        /// <returns>list of categories that contains the keyword.</returns>
        internal List<BookCategory> SearchCategories(string keyword) => api.GetCategories(keyword);
    }
}