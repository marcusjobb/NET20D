using System.Linq;
using WebshopAPI.Database;

namespace WebshopAPI.Utils
{
    /// <summary>
    /// Class for security measures
    /// </summary>
    public static class Security
    {
        /// <summary>
        /// Verifies if user have administrator privileges
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>bool</returns>
        public static bool AdminCheck(int userId)
        {
            bool isUserAdmin = false;
            using (var db = new EFContext())
            {
                var user = db.Users?.FirstOrDefault(u => u.Id == userId);
                if (user != null && user.IsAdmin == true)
                {
                    isUserAdmin = true;
                }
                return isUserAdmin;
            }
        }
    }
}