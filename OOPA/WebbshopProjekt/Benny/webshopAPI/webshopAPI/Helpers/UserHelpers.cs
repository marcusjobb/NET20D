using System;
using System.Linq;
using webshopAPI.Db;

namespace webshopAPI.Helpers
{
    static public class UserHelpers
    {
        /// <summary>
        /// Database connection
        /// </summary>
        private static Database db = new Database();

        private const int maxSessionTime = 15;

        /****************************************************
                    ADMIN AND SESSION HANDLING BELOW
         ****************************************************/

        /// <summary>
        /// Checks if the current logged in users session still is active
        /// (15 min since last activity)
        /// </summary>
        /// <param name="userId">takes a user ID to check for</param>
        /// <returns>Returns true if still active, false if not.</returns>
        public static bool IsSessionActive(int userId)
        {
            var activeUser = (from user in db.Users
                              where user.Id == userId
                              && user.IsActive
                              && user.SessionTimer > DateTime.Now.AddMinutes(-maxSessionTime)
                              select user).FirstOrDefault();
            if (activeUser != null)
            {
                UpdateSessionTimer(userId);
            }
            return activeUser != null;
        }

        /// <summary>
        /// Check if the user has the right priviliges to use methods
        /// that require admin access and the user needs to be logged in.
        /// </summary>
        /// <param name="adminId">Send in the user Id (to check if it´s admin)</param>
        /// <returns>Returns true if user is admin, false if not.</returns>
        public static bool IsUserApprovedForChanges(int adminId)
        {
            var admin = (from currentUser in db.Users
                         where currentUser.Id == adminId
                         && currentUser.IsActive
                         && currentUser.IsAdmin
                         && currentUser.SessionTimer > DateTime.Now.AddMinutes(-maxSessionTime)
                         select currentUser).FirstOrDefault();

            return admin != null && IsSessionActive(adminId);
        }

        /// <summary>
        /// Updates the sessiontimer for additional 15 minutes
        /// </summary>
        /// <param name="userid">takes the user ID to update the sessiontimer on.</param>
        public static void UpdateSessionTimer(int userid)
        {
            var updateThisUser = (from user in db.Users
                                  where user.Id == userid
                                  select user).FirstOrDefault();
            updateThisUser.SessionTimer = DateTime.Now;
            db.Users.Update(updateThisUser);
            db.SaveChanges();
        }
    }
}