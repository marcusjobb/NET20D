using System;
using System.Linq;
using WebbShopJesperPersson.Database;
using WebbShopJesperPersson.Model;

namespace WebbShopJesperPersson
{
    public class APIHelper
    {
        public ApplicationDbContext context = new ApplicationDbContext();

        /// <summary>
        /// Help-method to get user by id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>User if exist otherwise null. </returns>
        public User GetUser(int userId)
        {
            return context.Users.FirstOrDefault(u => u.Id == userId);
        }

        /// <summary>
        /// Checks if user been inactive for more then 15 minutes. If yes => logged out.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>true if still online. false if </returns>
        public bool IsSessionTimeOK(User user)
        {
            if (user != null && user.SessionTimer > DateTime.Now.AddMinutes(-15))
            {
                user.SessionTimer = DateTime.Now;
                context.Update(user);
                context.SaveChanges();
                return true;
            }
            else
            {
                if (user != null)
                {
                    var api = new WebbShopAPI();
                    api.LogOut(user.Id);
                }

                return false;
            }
        }

        /// <summary>
        /// Help-method to search for category.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>Choosen category, null if dosent exist. </returns>
        protected BookCategory GetCategoryById(int categoryId)
        {
            return context.Categories.FirstOrDefault(c => c.Id == categoryId);
        }

        /// <summary>
        /// To se if user is Admin.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>True if admin. False if not.</returns>
        protected bool IsAdmin(int userId)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null && user.IsAdmin)
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Help-method to is if user is active.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true if actice and false if not.</returns>
        protected bool IsUserActive(User user)
        {
            if (user != null && user.IsActive) return true;
            else return false;
        }

        /// <summary>
        /// Help-method to see if user exist, is active and if sessiontime is not overdrawn.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>True if </returns>
        protected bool IsUserAllowedToLogin(int userId, out User user)
        {
            user = GetUser(userId);

            if (UserExsist(user) && IsUserActive(user) && IsSessionTimeOK(user)) return true;
            else return false;
        }

        /// <summary>
        /// Help-method to see if user exist in database.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>true if user exist otherwise False.</returns>
        protected bool UserExsist(User user)
        {
            if (user != null) return true;
            else return false;
        }
    }
}