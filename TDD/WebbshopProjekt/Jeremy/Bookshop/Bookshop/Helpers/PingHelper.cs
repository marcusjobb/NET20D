using Bookshop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Helpers
{
    public static class PingHelper
    {
        /// <summary>
        /// Checks if the user is still active.
        /// </summary>
        public static void CheckPing()
        {
            if (GlobalVariables.IsUserLoggedIn == true)
            {
                string pingReturn = GlobalVariables.Api.Ping(GlobalVariables.User.Id);
                if (pingReturn != "pong")
                {
                    GlobalVariables.IsUserLoggedIn = false;
                    HomeController homeController = new HomeController();
                    homeController.Index();
                }
            }
        }
    }
}
