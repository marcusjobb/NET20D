using LinusNestorson_WebbShop.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LinusNestorson_WebbShop.Models;
using System.Dynamic;
using LinusNestorson_WebbShop.Helpers;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;

namespace LinusNestorson_WebbShop
{
    public class WebbShopAPI
    {
        private ShopContext context = new ShopContext();
        private UserHelper userHelper = new UserHelper();

        /// <summary>
        /// Method for buying book.
        /// </summary>
        /// <param name="userId">Id of logged in user</param>
        /// <param name="bookId">Id of chosen book</param>
        /// <returns></returns>
        public bool BuyBook(int userId, int bookId)
        {
            if (userHelper.CheckSessionTimer(userId))
            {
                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                var book = context.Books.Include("Category").FirstOrDefault(b => b.Id == bookId);

                if (user != null && book != null && book.Amount > 0)
                {
                    var soldBook = new SoldBook() { Title = book.Title, Author = book.Author, User = user, Category = book.Category, Price = book.Price, PurchasedDate = DateTime.Now };
                    book.Amount--;
                    context.SoldBooks.Add(soldBook);
                    context.Books.Update(book);
                    context.Users.Update(user);
                    context.SaveChanges();
                    return true;
                }
                else return false;
            }
            else
            {
                Logout(userId);
                return false;
            }

        }
        /// <summary>
        /// Method for searching for Authors in database.
        /// </summary>
        /// <param name="keyword">Used keyword to match Authors</param>
        /// <returns>List of Authors</returns>
        public List<Book> GetAuthors(string keyword)
        {
            return context.Books.Where(b => b.Author.Contains(keyword)).ToList();
        }
        /// <summary>
        /// Method for searching for Available books in database.
        /// </summary>
        /// <returns>List of Available books</returns>
        public List<Book> GetAvailableBooks(int categoryId)
        {
            return context.Books.Where(b => (b.Category.Id == categoryId) && ( b.Amount > 0)).OrderBy(b => b.Title).ToList();
        }
        /// <summary>
        /// Get book based on the books Id.
        /// </summary>
        /// <param name="bookId">Id of wanted book</param>
        /// <returns>String with information or empty string if book does not exist</returns>
        public string GetBook(int bookId)
        {
            var book = context.Books.AsNoTracking().Include("Category").FirstOrDefault(b => b.Id == bookId);
            if (book != null)
            {

                return $"Book Title: {book.Title}\nAuthor: {book.Author}\nCategory: {book.Category.Name}\nPrice: {book.Price}\nAmount in stock: {book.Amount}";
            }
            else return string.Empty;
        }
        /// <summary>
        /// Get book based on specific keyword.
        /// </summary>
        /// <param name="keyword">Specific keyword for books to match</param>
        /// <returns>List of books that match keyword</returns>
        public List<Book> GetBooks(string keyword)
        {
            return context.Books.Where(b => b.Title.Contains(keyword)).ToList();
        }
        /// <summary>
        /// Search for all categories in database.
        /// </summary>
        /// <returns>List of available categories in database</returns>
        public List<Category> GetCategories()
        {
            return context.Categories.OrderBy(c => c.Name).ToList();
        }
        /// <summary>
        /// Search for categories that match specific keyword.
        /// </summary>
        /// <param name="keyword">Specific keyword for categories to match</param>
        /// <returns>List of categories</returns>
        public List<Category> GetCategories(string keyword)
        {
            return context.Categories.Where(c => c.Name.Contains(keyword)).ToList();
        }
        /// <summary>
        /// Search for categories based on Id of category.
        /// </summary>
        /// <param name="categoryId">The id of category to search for</param>
        /// <returns>List of categories</returns>
        public List<Book> GetCategory(int categoryId)
        {
            return context.Books.Where(b => b.Category.Id == categoryId).OrderBy(b => b.Title).ToList();
        }
        /// <summary>
        /// Method for logging in.
        /// </summary>
        /// <param name="username">Username of user regis</param>
        /// <param name="password">Password of user</param>
        /// <returns>Return the id of user if user exist</returns>
        public User Login(string username, string password)
        {
            {
                var user = context.Users.FirstOrDefault(u => u.Name == username && u.Password == password && u.IsActive == true);
                if (user != null && user.IsActive == true)
                {
                    user.LastRefresh = DateTime.Now;
                    user.SessionTimer = user.LastRefresh.AddMinutes(15);
                    context.Users.Update(user);
                    context.SaveChanges();
                    return user;
                }
            }
            return null;
        }
        /// <summary>
        /// Method for logging out user.
        /// </summary>
        /// <param name="userId">The id of logged in user</param>
        public void Logout(int userId)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                user.LastRefresh = DateTime.MinValue;
                user.SessionTimer = DateTime.MinValue;
                context.Users.Update(user);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Used to see if user is online.
        /// </summary>
        /// <param name="userId">The Id of logged in user</param>
        /// <returns>If user is active, method returns string "Pong", otherwise return empty string</returns>
        public string Ping(int userId)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null && DateTime.Now < user.SessionTimer)
            {
                user.LastRefresh = DateTime.Now;
                user.SessionTimer = user.LastRefresh.AddMinutes(15);
                context.Users.Update(user);
                context.SaveChanges();
                return "Pong";
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// To register new user.
        /// </summary>
        /// <param name="name">Username of user</param>
        /// <param name="password">Password of user</param>
        /// <param name="verPassword">Verify to see if Password was correct from user</param>
        /// <returns>Return true if action was sucessful, otherwise return false</returns>
        public bool Register(string name, string password, string verPassword)
        {
            var user = context.Users.FirstOrDefault(u => u.Name == name);
            if (user == null && password == verPassword)
            {
                user = new User() { Name = name, Password = password };
                context.Users.Add(user);
                context.SaveChanges();
                return true;
            }
            else return false;
        }
    }
}
