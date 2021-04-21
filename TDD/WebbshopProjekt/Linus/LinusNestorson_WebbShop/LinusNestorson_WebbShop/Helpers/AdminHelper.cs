using System;
using LinusNestorson_WebbShop.Database;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel.Design;

namespace LinusNestorson_WebbShop.Helpers
{
    public class AdminHelper
    {
        private ShopContext context = new ShopContext();

        /// <summary>
        /// Method to check if user is Admin.
        /// </summary>
        /// <param name="adminId">Id of user</param>
        /// <returns>True if successful, false if not</returns>
        public bool IfAdmin(int adminId)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == adminId);
            if (user != null && user.IsAdmin)
            {
                return true;
            }
            else return false;
        }
    }
}
