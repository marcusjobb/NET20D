using Inlamning2TrialRunHE.Db;
using Inlamning2TrialRunHE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Inlamning2TrialRunHE.Helper
{
    public static class HelperMethods
    {
        public static Database db = new Database();

        /// <summary>
        /// This MaxTime count idea is borrowed from Emil Örjes.
        /// </summary>
        public const int MaxTime = 15;

        /// <summary>
        /// Checks if the user is administrator and is logged in.
        /// This idea is borrowed from David Ström.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public static bool UserIsAdminAndLoggedIn(int adminId)
        {
            var adminUser = (from u in db.Users
                             where u.Id == adminId
                             && u.IsActive == true
                             && u.IsAdmin == true
                             select u).FirstOrDefault();

            return adminUser != null && adminUser.IsLoggedIn();
        }

        /// <summary>
        /// Checks if the book exists,
        /// this way I can use this method to check 
        /// if a book is available or not.
        /// This idea is borrowed from David Ström.
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="book"></param>
        /// <returns>True if the book exits,
        /// false if the book does not exist.</returns>
        public static bool BookExists(int bookId, out Book book)
        {
            book = (from b 
                    in db.Books 
                    where b.Id == bookId 
                    select b).Include(b => b.Category).FirstOrDefault();
            return book != null;
        }

        /// <summary>
        /// Checks if the category exits.
        /// This idea is borrowed from David Ström.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="category"></param>
        /// <returns>True if the category exists,
        /// false if the category does not exist.</returns>
        public static bool CategoryExists(int categoryId, 
            out BookCategory category)
        {
            category = (from c 
                        in db.BookCategories 
                        where c.Id == categoryId 
                        select c).FirstOrDefault();
            return category != null;
        }

        /// <summary>
        /// Checks if the user exits.
        /// This idea is borrowed from David Ström.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="user"></param>
        /// <returns>True if the user exists,
        /// false if the user does not exist.</returns>
        public static bool UserExists(int userId, out User user)
        {
            user = (from u 
                    in db.Users 
                    where u.Id == userId 
                    select u).FirstOrDefault();
            return user != null;
        }

        /// <summary>
        /// Checks if the user is logged in.
        /// This idea is borrowed from David Ström.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>True if the user have done something
        /// within 15 minutes. False if the user have not
        /// done anything for more then 15 minutes.</returns>
        public static bool IsLoggedIn(this User user)
        {
            return user.SessionTimer > DateTime.Now.AddMinutes(-MaxTime);
        }
    }
}