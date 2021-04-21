namespace FrontEndJesperPersson.Controller
{
    using System.Collections.Generic;
    using WebbShopJesperPersson;
    using WebbShopJesperPersson.Model;

    internal class AdminController
    {
        private readonly WebbShopAPIAdmin api = new WebbShopAPIAdmin();

        /// <summary>
        /// Create a connection between category and book.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="categoryId"></param>
        /// <returns>true if succeed, false if fails.</returns>
        internal bool AddCategoryToBook(int adminId, int bookId, int categoryId) => api.AddBookToCategory(adminId, bookId, categoryId);

        /// <summary>
        /// To se which customer that bought most books.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>the user, null if no books been sold.</returns>
        internal User BestCustomer(int adminId) => api.BestCustomer(adminId);

        /// <summary>
        /// Make a user inactive, won´t be able to login in.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns>true if success, false if fails.</returns>
        internal bool BlockUser(int adminId, int userId) => api.InactivateUser(adminId, userId);

        /// <summary>
        /// Creates a book if it dosen´t exist. Add +1 in amount if already exists.
        /// </summary>
        /// <param name="adminId">to be able to create or add book.</param>
        /// <param name="amount">of books you want to add.</param>
        /// <param name="id">if book exist, book ID.</param>
        /// <param name="title">of the book.</param>
        /// <param name="author">of the book.</param>
        /// <param name="price">of the book.</param>
        /// <returns>true if added or created a book. False if netiher of theese.</returns>
        internal bool CreateBook(int adminId, int amount, int id, string title = "", string author = "", double price = 0) =>
            api.AddBook(adminId, title, author, price, amount, id);

        /// <summary>
        /// Create a new category to database.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryName"></param>
        /// <returns>true if succeed, false if false.</returns>
        internal bool CreateCategory(int adminId, string categoryName) => api.AddCategory(adminId, categoryName);

        /// <summary>
        /// Creates a user.
        /// </summary>
        /// <param name="adminId">admin ID</param>
        /// <param name="name">of user</param>
        /// <param name="password">Codic2021 by deafult.</param>
        /// <returns>true if user is created or false if fails.</returns>
        internal bool CreateUser(int adminId, string name, string password)
        {
            if (password == "") password = "Codic2021";
            return api.AddUser(adminId, name, password);
        }

        /// <summary>
        /// Delete a book. Reduce the amount if more then 1. Deletes from database if amount is 1 or less.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <returns>true if deleted/reduced and falase if fails.</returns>
        internal bool DeleteBook(int adminId, int bookId) => api.DeleteBook(adminId, bookId);

        /// <summary>
        /// Delete a category from databse. Only works if category dosen´t have any connection to either books or sold books.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId">of category you want to delete.</param>
        /// <returns>true if deleted, false if fails</returns>
        internal bool DeleteCategory(int adminId, int categoryId) => api.DeleteCategory(adminId, categoryId);

        /// <summary>
        /// Remove admin satus and demote to regular user.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns>true if success, false if fails.</returns>
        internal bool DemoteUser(int adminId, int userId) => api.Demote(adminId, userId);

        /// <summary>
        /// Find user by keyword.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="keyword">a letter or whole name.</param>
        /// <returns>a list of users that matches the keyword.</returns>
        internal List<User> FindUser(int adminId, string keyword) => api.FindUser(adminId, keyword);

        /// <summary>
        /// Get all users.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>List of users.</returns>
        internal List<User> ListUsers(int adminId) => api.ListUsers(adminId);

        /// <summary>
        /// Get the sum of sold books.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>the result of sold books in a double.</returns>
        internal double MoneyEarned(int adminId) => api.MoneyEarned(adminId);

        internal void Ping(int adminId) => api.Ping(adminId);

        /// <summary>
        /// Make a user admin.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns>true if success, false if fails.</returns>
        internal bool PromoteUser(int adminId, int userId) => api.Promote(adminId, userId);

        /// <summary>
        /// Set the amount of book in database.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="amount"></param>
        /// <returns>true if success, false if fails.</returns>
        internal bool SetAmount(int adminId, int bookId, int amount) => api.SetAmount(adminId, bookId, amount);

        /// <summary>
        /// Get all sold books.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>List of sold books.</returns>
        internal List<SoldBook> SoldBooks(int adminId) => api.SoldItems(adminId);

        /// <summary>
        /// Make user active again.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns>true if success, false if fails.</returns>
        internal bool UnblockUser(int adminId, int userId) => api.ActivateUser(adminId, userId);

        /// <summary>
        /// Update information about a book.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="price"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="bookId"></param>
        /// <returns>true if succeeded, false if fails.</returns>
        internal bool UpdateBook(int adminId, double price, string title, string author, int bookId)
            => api.UpdateBook(adminId, bookId, title, author, price);

        /// <summary>
        /// Update category name.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <param name="categoryname">the new name.</param>
        /// <returns>true if success, false if fails.</returns>
        internal bool UpdateCategory(int adminId, int categoryId, string categoryname) => api.UpdateCategory(adminId, categoryId, categoryname);
    }
}