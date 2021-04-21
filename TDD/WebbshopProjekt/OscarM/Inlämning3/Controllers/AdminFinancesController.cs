using Inlämning2WebbShop;
using Inlämning3.Helpers;
using System;

namespace Inlämning3.Controllers
{
    internal class AdminFinancesController
    {
        private WebbShopAPI api = new WebbShopAPI();

        /// <summary>
        /// Method that gets a choice and then call other methods depending on the user choice
        /// </summary>
        public void Finances()
        {
            var choice = Views.Admin.AdminMenus.FinanceMenu();
            switch (choice)
            {
                case 1:
                    Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                    SeeMoneyEarned();
                    break;

                case 2:
                    Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                    SeeSoldBooks();
                    break;

                case 3:
                    Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                    SeeBestCustomer();
                    break;

                case 4:
                    Console.Clear();
                    var adminController = new AdminController();
                    adminController.AdminMenu();
                    break;

                case 5:
                    var logout = new LogoutController();
                    logout.LogoutAndGoToMainMenu();
                    break;

                default:
                    Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                    Console.Clear();
                    Messages.NotValidInput();
                    break;
            }
        }

        /// <summary>
        /// Call ApiMethod to get BestCustomer, then call ShowBestCustomerView to print the user.
        /// </summary>
        private void SeeBestCustomer()
        {
            Account.KickOutIfNotLoggedInAdmin();
            Console.Clear();
            var bestCustomer = api.BestCustomer(Account.UserId);
            if (bestCustomer != null)
            {
                Views.Admin.Finances.ShowBestCustomer(bestCustomer);
            }
            else
            {
                Console.WriteLine("Something went wrong!");
            }
        }

        /// <summary>
        /// Calls API to get all soldbooks, then calls View to print the soldbooks.
        /// </summary>
        private void SeeSoldBooks()
        {
            Account.KickOutIfNotLoggedInAdmin();
            Console.Clear();
            var soldBooks = api.SoldItems(Account.UserId);
            Views.Admin.Finances.ShowSoldBooks(soldBooks);
        }

        /// <summary>
        /// Calls API to get money earned, and then calls view to print the result.
        /// </summary>
        private void SeeMoneyEarned()
        {
            Account.KickOutIfNotLoggedInAdmin();
            Console.Clear();
            var moneyEarned = api.MoneyEarned(Account.UserId);
            Views.Admin.Finances.MoneyEarned(moneyEarned);
        }
    }
}