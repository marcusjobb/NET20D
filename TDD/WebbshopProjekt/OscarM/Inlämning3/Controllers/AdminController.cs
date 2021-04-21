using Inlämning2WebbShop;
using Inlämning3.Helpers;
using System;

namespace Inlämning3.Controllers
{
    internal class AdminController
    {
        private WebbShopAPI api = new WebbShopAPI();

        /// <summary>
        /// Method that gets a choice and then call the correct class and method depending on the choice.
        /// </summary>
        public void AdminMenu()
        {
            do
            {
                Account.KickOutIfNotLoggedInAdmin();
                int choice = Views.Admin.AdminMenus.MainMenu();
                switch (choice)
                {
                    case 1:
                        Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                        var adminUsersController = new AdminUsersController();
                        adminUsersController.ManageUsers();
                        break;

                    case 2:
                        Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                        var adminBooksController = new AdminBooksController();
                        adminBooksController.ManageBooks();
                        break;

                    case 3:
                        Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                        var adminFinanceController = new AdminFinancesController();
                        adminFinanceController.Finances();
                        break;

                    case 4:
                        api.Logout(Account.UserId);
                        Views.Home.MainMenu.Display();
                        break;

                    case 5:
                        Exit.LogOutAndExit();
                        break;

                    default:
                        Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                        Messages.NotValidInput();
                        break;
                }
            } while (true);
        }
    }
}