using System.Collections.Generic;
using LinusNestorson_WebbShop;
using LinusNestorson_WebbShop.Models;

namespace LinusNestorson_WebbShopFrontEnd.Controller
{
    class AdminController
    {
        private AdminAPI adminApi = new AdminAPI();
        /// <summary>
        /// Allows admin to add new books to database.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        /// <param name="title">Title of book</param>
        /// <param name="author">Author of book</param>
        /// <param name="price">Price of book</param>
        /// <param name="amount">Amount of books in stock</param>
        /// <returns>True or false based on success of adding book</returns>
        public bool AddBook(int adminId, string title, string author, int price, int amount)
        {
            return adminApi.AddBook(adminId, title, author, price, amount);
        }
        /// <summary>
        /// Allows admin to set amount in stock of a book.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        /// <param name="bookId">Id of book</param>
        /// <param name="amount">Amount of books to set stock to</param>
        /// <returns>True or false based on success of action</returns>
        public int SetAmount(int adminId, int bookId, int amount)
        {
            return adminApi.SetAmount(adminId, bookId, amount);
        }
        /// <summary>
        /// Search database of all users.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        /// <returns>List of all users</returns>
        public List<User> ListUsers(int adminId)
        {
            return adminApi.ListUsers(adminId);
        }
        /// <summary>
        /// Allows admin to find users with keyword in common.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        /// <param name="keyword">Keyword from admin</param>
        /// <returns></returns>
        public List<User> FindUser(int adminId, string keyword)
        {
            return adminApi.FindUser(adminId, keyword);
        }
        /// <summary>
        /// Allows admin to update a book with information
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        /// <param name="bookId">Id of book</param>
        /// <param name="title">Title of book</param>
        /// <param name="author">Author of book</param>
        /// <param name="price">Price of book</param>
        /// <returns>True or false based on success of action</returns>
        public bool UpdateBook(int adminId, int bookId, string title, string author, int price)
        {
            return adminApi.UpdateBook(adminId, bookId, title, author, price);
        }
        /// <summary>
        /// Allows admin to delete a book from database.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        /// <param name="bookId">Id of book</param>
        /// <returns>True or false based on success of action</returns>
        public bool DeleteBook(int adminId, int bookId)
        {
            return adminApi.DeleteBook(adminId, bookId);
        }
        /// <summary>
        /// Add a new category to database.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        /// <param name="catName">Name of new category</param>
        /// <returns>True or false based on success of action</returns>
        public bool AddCategory(int adminId, string catName)
        {
            return adminApi.AddCategory(adminId, catName);
        }
        /// <summary>
        /// Add a book to a category.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        /// <param name="bookId">Id of book</param>
        /// <param name="categoryId">Id of category</param>
        /// <returns>True or false based on success of action</returns>
        public bool AddBookToCategory(int adminId, int bookId, int categoryId)
        {
            return adminApi.AddBookToCategory(adminId, bookId, categoryId);
        }
        /// <summary>
        /// Update category with new name.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        /// <param name="categoryId">Id of category</param>
        /// <param name="catName">Name of category</param>
        /// <returns>True or false based on success of action</returns>
        public bool UpdateCategory(int adminId, int categoryId, string catName)
        {
            return adminApi.UpdateCategory(adminId, categoryId, catName);
        }
        /// <summary>
        /// Delete category from database.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        /// <param name="categoryId">Id of category</param>
        /// <returns>True or false based on success of action</returns>
        public bool DeleteCategory(int adminId, int categoryId)
        {
            return adminApi.DeleteCategory(adminId, categoryId);
        }
        /// <summary>
        /// Add a new user to database.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        /// <param name="name">Name of user</param>
        /// <param name="password">Password of user</param>
        /// <returns>True or false based on success of action</returns>
        public bool AddUser(int adminId, string name, string password)
        {
            return adminApi.AddUser(adminId, name, password);
        }
        /// <summary>
        /// Allows admin to see all sold items.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        /// <returns>List of sold books</returns>
        public List<SoldBook> SoldItems(int adminId)
        {
            return adminApi.SoldItems(adminId);
        }
        /// <summary>
        /// Allows admin to see how much money that have been earned in total.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        /// <returns>Sum of money</returns>
        public int MoneyEarned(int adminId)
        {
            return adminApi.MoneyEarned(adminId);
        }
        /// <summary>
        /// Allows admin to see which user that has bought the most books.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        /// <returns>The id of the user.</returns>
        public int BestCustomer(int adminId)
        {
            return adminApi.BestCustomer(adminId);
        }
        /// <summary>
        /// Allows admin to promote a user to admin.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        /// <param name="userId">Id of user</param>
        /// <returns>True or false based on success of action</returns>
        public bool Promote(int adminId, int userId)
        {
            return adminApi.Promote(adminId, userId);
        }
        /// <summary>
        /// Allows admin to demote a user from admin to normal user.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        /// <param name="userId">Id of user</param>
        /// <returns>True or false based on success of action</returns>
        public bool Demote(int adminId, int userId)
        {
            return adminApi.Demote(adminId, userId);
        }
        /// <summary>
        /// Allows admin to activate a user from inactive.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        /// <param name="userId">Id of user</param>
        /// <returns>True or false based on success of action</returns>
        public bool ActivateUser(int adminId, int userId)
        {
            return adminApi.ActivateUser(adminId, userId);
        }
        /// <summary>
        /// Allows admin to inactivate a user from active.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        /// <param name="userId">Id of user</param>
        /// <returns>True or false based on success of action</returns>
        public bool InactivateUser(int adminId, int userId)
        {
            return adminApi.InactivateUser(adminId, userId);
        }

    }
}
