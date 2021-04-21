using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebbShopEmil.Database;
using WebbShopEmil.Models;

namespace WebbShopEmil.Helper
{
    /// <summary>
    /// Methods that makes the program easier to handle and maintain.
    /// </summary>
    public static class HelpMethods
    {
        public static WebbShopContext db = new WebbShopContext();
        private const int MaxSessionTime = -15;

        // Lånat denna metoden av David Ström,
        // han har förklarat för mig hur denna metod fungerar
        // och varför vi använder den.
        /// <summary>
        /// Checks if book exists.
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        public static bool BookExists(int bookId, out Book book)
        {
            book = (from b
                    in db.Books
                    where b.Id == bookId
                    select b).Include(b => b.Category).FirstOrDefault();

            return book != null;
        }

        // Lånat denna metoden av David Ström,
        // han har förklarat för mig hur denna metod fungerar
        // och varför vi använder den.
        /// <summary>
        /// Checks if category exists.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public static bool CategoryExists(int categoryId, out BookCategory category)
        {
            category = (from c
                        in db.BookCategories
                        where c.Id == categoryId
                        select c).FirstOrDefault();

            return category != null;
        }

        /// <summary>
        /// Prints out a list of authors that contains keyword.
        /// </summary>
        /// <param name="webbShop"></param>
        /// <param name="keyword"></param>
        public static void ForeachGetAuthorsKeyword(WebbShopAPI webbShop, string keyword)
        {
            foreach (var book in webbShop.GetAuthors(keyword))
            {
                Console.WriteLine($"Id:{book.Id}. Book author: {book.Author}");
            }
        }

        /// <summary>
        /// Prints out a list of all books by category.
        /// </summary>
        /// <param name="webbShop"></param>
        /// <param name="categoryId"></param>
        public static void ForeachGetAvailableBooks(WebbShopAPI webbShop, int categoryId)
        {
            foreach (var book in webbShop.GetAvailableBooks(categoryId))
            {
                Console.WriteLine($"Id:{book.Id}. Book title: {book.Title}");
            }
        }

        /// <summary>
        /// Prints out a list of books that contains keyword.
        /// </summary>
        /// <param name="webbShop"></param>
        /// <param name="keyword"></param>
        public static void ForeachGetBooksKeyword(WebbShopAPI webbShop, string keyword)
        {
            foreach (var book in webbShop.GetBooks(keyword))
            {
                Console.WriteLine($"Id:{book.Id}. Book title: {book.Title}");
            }
        }

        /// <summary>
        /// Prints out a list of all categories.
        /// </summary>
        /// <param name="webbShop"></param>
        public static void ForeachGetCategories(WebbShopAPI webbShop)
        {
            foreach (var category in webbShop.GetCategories())
            {
                Console.WriteLine($"Id:{category.Id}. Category name: {category.Name}");
            }
        }

        /// <summary>
        /// Prints out a list of categories that contains keyword.
        /// </summary>
        /// <param name="webbShop"></param>
        /// <param name="keyword"></param>
        public static void ForeachGetCategoriesKeyword(WebbShopAPI webbShop, string keyword)
        {
            foreach (var category in webbShop.GetCategories(keyword))
            {
                Console.WriteLine($"Id:{category.Id}. Category name: {category.Name}");
            }
        }

        /// <summary>
        /// Prints out a list of all users.
        /// </summary>
        /// <param name="webbShop"></param>
        /// <param name="adminId"></param>
        public static void ForeachListUsers(WebbShopAPI webbShop, int adminId)
        {
            foreach (var user in webbShop.ListUsers(adminId))
            {
                Console.WriteLine($"Id:{user.Id}. Username: {user.Name}");
            }
        }

        /// <summary>
        /// Changes the text to green color.
        /// </summary>
        /// <param name="input"></param>
        public static void GreenTextWL(string input)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(input);
            Console.ResetColor();
        }

        /// <summary>
        /// Prints a line of: -----
        /// </summary>
        public static void Line()
        {
            Console.WriteLine("\n--------------------------------------\n");
        }

        // Lånat denna metoden av David Ström,
        // han har förklarat för mig hur denna metod fungerar och varför vi använder den.
        /// <summary>
        /// Checks if user exists.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool UserExists(int userId, out User user)
        {
            user = (from u
                    in db.Users
                    where u.Id == userId
                    select u).FirstOrDefault();

            return user != null;
        }

        // Lånat denna metoden av David Ström,
        // han har förklarat för mig hur denna metod fungerar
        // och varför vi använder den.
        /// <summary>
        /// Checks if user is an admin,
        /// and if user is logged in.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public static bool UserIsAdminAndLoggedIn(int adminId)
        {
            var adminUser = (from u in db.Users
                             where u.Id == adminId
                             && u.IsActive == true
                             && u.IsAdmin == true
                             && u.SessionTimer > DateTime.Now.AddMinutes(MaxSessionTime)
                             select u).FirstOrDefault();

            return adminUser != null;
        }

        public static bool IsUserAdmin(int adminId)
        {
            var admin = (from u in db.Users
                         where u.Id == adminId
                         && u.IsActive
                         && u.IsAdmin
                         && u.SessionTimer > DateTime.Now.AddMinutes(MaxSessionTime)
                         select u).FirstOrDefault();

            if (admin != null) admin.SessionTimer = DateTime.Now;
            return admin != null;
        }
    }
}