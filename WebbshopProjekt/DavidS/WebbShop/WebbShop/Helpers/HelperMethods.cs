using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebbShop.Database;
using WebbShop.Models;

namespace WebbShop.Helpers
{
    public static class HelperMethods
    {
        /// <summary>
        /// A connection to the database.
        /// </summary>
        public static readonly Context db = new Context();

        /// <summary>
        /// The maximum time a user can be idle before getting logged out.
        /// Borrowed the idea from Emil Örjes.
        /// </summary>
        private const int MaxSessionTime = -15;

        /// <summary>
        /// Checks if a specified <see cref="Book"/>
        /// exists in the database.
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="book"></param>
        /// <returns><see langword="true"/> if the <see cref="Book"/> exists,
        /// otherwise <see langword="false"/>. The <see cref="User"/> is also
        /// passed out.</returns>
        public static bool BookExists(int bookId, out Book book)
        {
            book = db.Books.Include(b => b.Category).FirstOrDefault(b => b.Id == bookId);
            return book != null;
        }

        /// <summary>
        /// Checks if there is a <see cref="BookCategory"/> in the database
        /// that match the <paramref name="name"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <returns><see langword="true"/> if there is a match,
        /// otherwise <see langword="false"/>.</returns>
        public static bool CategoryExists(string name)
        {
            return db.BookCategories.FirstOrDefault(c => c.Name == name) != null;
        }

        /// <summary>
        /// Chceks if there is a <see cref="BookCategory"/> in the
        /// database with the id of <paramref name="categoryId"/>.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="category"></param>
        /// <returns><see langword="true"/> if there is a match,
        /// otherwise <see langword="false"/>. The <paramref name="category"/>
        /// is also passed out.</returns>
        public static bool CategoryExists(int categoryId, out BookCategory category)
        {
            category = db.BookCategories.FirstOrDefault(c => c.Id == categoryId);
            return category != null;
        }

        /// <summary>
        /// Checks if the <paramref name="book"/>
        /// is available to be purchased.
        /// </summary>
        /// <param name="book"></param>
        /// <returns><see langword="true"/> if the <paramref name="book"/>
        /// is available, otherwise <see langword="false"/>.</returns>
        public static bool IsAvailable(this Book book)
        {
            return book.Amount > 0;
        }

        /// <summary>
        /// Checks if the <paramref name="user"/> is logged in.
        /// </summary>
        /// <param name="user"></param>
        /// <returns><see langword="true"/> if the <paramref name="user"/>
        /// is logged in, otherwise <see langword="false"/>.</returns>
        public static bool IsLoggedIn(this User user)
        {
            return user.SessionTimer > DateTime.Now.AddMinutes(MaxSessionTime);
        }

        /// <summary>
        /// Checks if there is a <see cref="User"/> in the database that match
        /// <paramref name="name"/> and <paramref name="password"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <returns><see langword="true"/> if the <see cref="User"/> exists,
        /// otherwise <see langword="false"/>.</returns>
        public static bool UserExists(string name)
        {
            return db.Users.FirstOrDefault(u => u.Name == name) != null;
        }

        /// <summary>
        /// Checks if there is a <see cref="User"/> in the database that match
        /// <paramref name="name"/> and <paramref name="password"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="user"></param>
        /// <returns><see langword="true"/> if the user exist,
        /// otherwise <see langword="false"/> and the
        /// <see cref="User"/> is passed out.</returns>
        public static bool UserExists(
            string name,
            string password,
            out User user)
        {
            user = db.Users.FirstOrDefault(u => u.Name == name
                && u.Password == password);
            return user != null;
        }

        /// <summary>
        /// Checks if there is a <see cref="User"/> in the database
        /// with the id of <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns><see langword="true"/> if the user exist,
        /// otherwise <see langword="false"/>.</returns>
        public static bool UserExists(int userId)
        {
            return db.Users.FirstOrDefault(u => u.Id == userId) != null;
        }

        /// <summary>
        /// Checks if there is a <see cref="User"/> in the database
        /// with the id of <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="user"></param>
        /// <returns><see langword="true"/> if the user exist,
        /// otherwise <see langword="false"/>. The
        /// <see cref="User"/> is also passed out.</returns>
        public static bool UserExists(int userId, out User user)
        {
            user = db.Users.FirstOrDefault(u => u.Id == userId);
            return user != null;
        }

        /// <summary>
        /// Checks if the user based on <paramref name="adminId"/>
        /// is active, is an admin and is logged in.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns><see langword="true"/> if the user is an admin and
        /// is logged in, otherwise <see langword="false"/>.</returns>
        public static bool UserIsAdminAndLoggedIn(int adminId)
        {
            return UserExists(adminId, out var admin)
                && admin.IsActive
                && admin.IsAdmin
                && admin.IsLoggedIn();
        }

        /// <summary>
        /// Checks if the <paramref name="str"/> is
        /// <see langword="null"/> or empty.
        /// </summary>
        /// <param name="str"></param>
        /// <returns><see langword="true"/> if the <paramref name="str"/>
        /// is <see langword="null"/> or empty, otherwise
        /// <see langword="false"/>.</returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str?.Trim());
        }
    }
}
