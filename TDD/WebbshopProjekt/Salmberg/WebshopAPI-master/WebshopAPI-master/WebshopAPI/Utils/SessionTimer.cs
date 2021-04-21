using System;
using System.Linq;
using WebshopAPI.Database;
using WebshopAPI.Models;

namespace WebshopAPI.Utils
{
    /// <summary>
    /// Class for handling SessionTimer
    /// </summary>
    public static class SessionTimer
    {
        /// <summary>
        /// Sets user's session timer
        /// </summary>
        /// <param name="id"></param>
        /// <returns>DateTime</returns>
        public static DateTime SetSessionTimer(int id)
        {
            DateTime setTime;
            setTime = DateTime.MaxValue;
            using (var db = new EFContext())
            {
                var user = db.Users?.FirstOrDefault(u => u.Id == id);
                if (user != null)
                {
                    user.SessionTimer = DateTime.Now;
                    db.Update(user);
                    db.SaveChanges();
                    setTime = user.SessionTimer;
                }
            }
            return setTime;
        }

        /// <summary>
        /// Controls if user's session timer have reached its limit
        /// </summary>
        /// <param name="setTime"></param>
        /// <returns>bool</returns>
        public static bool CheckSessionTimer(DateTime setTime)
        {
            bool isSessionLimitReached = false;
            DateTime sessionLimit = setTime.AddMinutes(15);
            DateTime sessionCompare = DateTime.Now;

            var res = DateTime.Compare(sessionCompare, sessionLimit);

            if (res >= 0)
            {
                isSessionLimitReached = true;
            }
            return isSessionLimitReached;
        }

        /// <summary>
        /// Sets administrator's session timer
        /// </summary>
        /// <param name="adminId"></param>
        public static void AdminSetSessionTimer(int adminId)
        {
            using (var db = new EFContext())
            {
                var admin = db.Users.FirstOrDefault(i => i.Id == adminId);
                admin.SessionTimer = SetSessionTimer(admin.Id);
            }
        }
        /// <summary>
        /// Controls if administrator's session timer have reached its limit
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>bool</returns>
        public static bool AdminCheckSessionTimer(int adminId)
        {
            bool isSessionLimitReached = false;
            using (var db = new EFContext())
            {
                var admin = db.Users?.FirstOrDefault(u => u.Id == adminId);
                if (admin != null)
                {
                    DateTime sessionLimit = admin.SessionTimer.AddMinutes(15);
                    DateTime sessionCompare = DateTime.Now;

                    var res = DateTime.Compare(sessionCompare, sessionLimit);

                    if (res >= 0)
                    {
                        isSessionLimitReached = true;
                    }
                }
            }
            return isSessionLimitReached;
        }
    }
}