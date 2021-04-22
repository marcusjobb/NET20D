using Inlämning_API.Database;
using System;
using System.Linq;

namespace Inlämning_API.Helper
{
    public static class HelperMethods
    {
        public static readonly StoreContext db = new StoreContext();

        /// <summary>
        /// Checks if the user is online
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool IsUserOnline(int userId)
        {
            var user = (from u in db.Users
                        where u.ID == userId
                         && u.IsActive
                         && u.SessionTimer > DateTime.Now.AddMinutes(-15)
                        select u).FirstOrDefault();

            return user != null;
        }

        /// <summary>
        /// Checks if the user is admin and logged in
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public static bool IsUserAdmin(int adminId)
        {
            var admin = (from u in db.Users
                         where u.ID == adminId
                         && u.IsActive
                         && u.IsAdmin
                         && u.SessionTimer > DateTime.Now.AddMinutes(-15)
                         select u).FirstOrDefault();

            if (admin != null) admin.SessionTimer = DateTime.Now;
            return admin != null;
        }
    }
}