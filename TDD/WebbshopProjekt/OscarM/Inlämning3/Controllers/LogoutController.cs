using Inlämning2WebbShop;
using Inlämning3.Helpers;
using System;

namespace Inlämning3.Controllers
{
    internal class LogoutController
    {
        private WebbShopAPI api = new WebbShopAPI();

        /// <summary>
        /// Logs out the user if it is not already logged out
        /// </summary>
        public void LogoutAndGoToMainMenu()
        {
            var HomeController = new HomeController();
            if (!Account.IsLoggedIn)
            {
                Console.WriteLine("You are already logged out!");
                UpdateAccountInfo();
                HomeController.Home();
            }
            else
            {
                api.Logout(Account.UserId);
                UpdateAccountInfo();
                Messages.SuccessMessage();
                HomeController.Home();
            }
        }

        public void LogOutAndExit()
        {
            api.Logout(Account.UserId);
            UpdateAccountInfo();
        }

        /// <summary>
        /// Update the Account to its default values
        /// </summary>
        private void UpdateAccountInfo()
        {
            Account.IsAdmin = false;
            Account.IsLoggedIn = false;
            Account.UserId = 0;
        }
    }
}