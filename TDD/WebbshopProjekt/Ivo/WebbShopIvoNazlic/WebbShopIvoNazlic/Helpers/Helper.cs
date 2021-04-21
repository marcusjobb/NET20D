using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebbShopIvoNazlic.Database;
using WebbShopIvoNazlic.Models;

namespace WebbShopIvoNazlic.Helpers
{
    /// <remarks>
    /// Handles helper methods to minimize repetetive code
    /// </remarks>
    static class Helper
    {

        ///<summary>
        /// Maximum allowed user idle time
        ///</summary>
        private static int MaxSessionTime { get; set; } = 15;

        private static BookDatabase db = new BookDatabase();

        /// <summary>
        /// Checks if user is admin, logged in and active
        /// </summary>
        /// <returns>user object</returns>
        public static User IsAdminAndLoggedIn(int adminId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == adminId && u.SessionTimer > DateTime.Now.AddMinutes(-MaxSessionTime) && u.IsAdmin && u.IsActive);
            if(user != null)
            {
                RefreshSessionTimer(adminId);
                return user;
            }

            return user;
        }

        /// <summary>
        /// Checks if books exists
        /// </summary>
        /// <returns>book object</returns>
        public static Book BookExists(int bookId)
        {
            var book = db.Books.Include(b => b.BookCategory).FirstOrDefault(b => b.Id == bookId);
            if (book != null)
            {
                return book;
            }

            return book;
        }

        /// <summary>
        /// Checks if books exists
        /// </summary>
        /// <returns>book object</returns>
        public static Book BookExists(string title, string author)
        {
            var book = db.Books.Include(b => b.BookCategory).FirstOrDefault(b => b.Title == title && b.Author == author);
            if (book != null)
            {
                return book;
            }

            return book;
        }

        /// <summary>
        /// Checks if category exists
        /// </summary>
        /// <returns>category object</returns>
        public static Category CategoryExists(int categoryId)
        {
            var category = db.BookCategories.FirstOrDefault(c => c.Id == categoryId);
            if (category != null)
            {
                return category;
            }

            return category;
        }

        /// <summary>
        /// Checks if category exists
        /// </summary>
        /// <returns>category object</returns>
        public static Category CategoryExists(string name)
        {
            var category = db.BookCategories.FirstOrDefault(c => c.Name == name);
            if (category != null)
            {
                return category;
            }

            return category;
        }

        /// <summary>
        /// Checks if user exists
        /// </summary>
        /// <returns>user object</returns>
        public static User UserExists (string username)
        {
            var user = db.Users.FirstOrDefault(u => u.Name == username);
            if (user != null)
            {
                return user;
            }

            return user;
        }

        /// <summary>
        /// Checks if user exists
        /// </summary>
        /// <returns>user object</returns>
        public static User UserExists(int userId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                return user;
            }

            return user;
        }

        /// <summary>
        /// Checks if user exists and is logged in
        /// </summary>
        /// <returns>user object</returns>
        public static User UserExistsAndLoggedIn(int userId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == userId && u.SessionTimer > DateTime.Now.AddMinutes(-MaxSessionTime));
            if (user != null)
            {
                RefreshSessionTimer(userId);
                return user;
            }

            return user;
        }

        /// <summary>
        /// Refreshes user session timer on activity
        /// </summary>
        /// <returns>true if success, false if fail</returns>
        public static bool RefreshSessionTimer(int userId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == userId);
            user.SessionTimer = DateTime.Now;
            db.Users.Update(user);
            db.SaveChanges();
            return true;
        }

    }
}
