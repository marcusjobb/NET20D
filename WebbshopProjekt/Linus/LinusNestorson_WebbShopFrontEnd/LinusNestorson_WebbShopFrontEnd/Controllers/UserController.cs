using System.Collections.Generic;
using LinusNestorson_WebbShop;
using LinusNestorson_WebbShop.Models;

namespace LinusNestorson_WebbShopFrontEnd.Controller
{
    class UserController
    {
        private WebbShopAPI userApi = new WebbShopAPI();
        /// <summary>
        /// Search for all categories in database.
        /// </summary>
        /// <returns>List with categories</returns>
        public List<Category> GetCategories()
        {
            return userApi.GetCategories();
        }
        /// <summary>
        /// Searching for categories based on keyword from user.
        /// </summary>
        /// <param name="keyword">Keyword from user</param>
        /// <returns>List with categories</returns>
        public List<Category> GetCategories(string keyword)
        {
            return userApi.GetCategories(keyword);
        }
        /// <summary>
        /// Seatch for books in specific category.
        /// </summary>
        /// <param name="categoryId">Id of category</param>
        /// <returns>List of books</returns>
        public List<Book> GetCategory(int categoryId)
        {
            return userApi.GetCategory(categoryId);
        }
        /// <summary>
        /// Search for books with stock > 0 withing a specific category.
        /// </summary>
        /// <param name="categoryId">Id of category</param>
        /// <returns>List of books</returns>
        public List<Book> GetAvailableBooks(int categoryId)
        {
            return userApi.GetAvailableBooks(categoryId);
        }
        /// <summary>
        /// Search for specific book in database.
        /// </summary>
        /// <param name="bookId">Id of book</param>
        /// <returns>String with information about book</returns>
        public string GetBook(int bookId)
        {
            return userApi.GetBook(bookId);
        }
        /// <summary>
        /// Search for books matching keyword.
        /// </summary>
        /// <param name="keyword">Keyword from user</param>
        /// <returns>List of matching books</returns>
        public List<Book> GetBooks(string keyword)
        {
            return userApi.GetBooks(keyword);
        }
        /// <summary>
        /// Search for book by author specified by user with keyword.
        /// </summary>
        /// <param name="keyword">Keyword from user</param>
        /// <returns>List of books</returns>
        public List<Book> GetBooksByAuthor(string keyword)
        {
            return userApi.GetAuthors(keyword);
        }
        /// <summary>
        /// Allows the user to buy a book based on Id.
        /// </summary>
        /// <param name="userId">Id of user</param>
        /// <param name="bookId">Id of book</param>
        /// <returns></returns>
        public bool BuyBook(int userId, int bookId)
        {
            return userApi.BuyBook(userId, bookId);
        }
        /// <summary>
        /// Method for logging out currently logged in user.
        /// </summary>
        /// <param name="userId">Id of user</param>
        public void Logout(int userId)
        {
            userApi.Logout(userId);
        }
        /// <summary>
        /// Pings each time an user makes an active choice.
        /// </summary>
        /// <param name="userId">Id of user</param>
        /// <returns>String with Pong if Ping was successfull</returns>
        public string Ping(int userId)
        {
            return userApi.Ping(userId);
        }
    }
}
