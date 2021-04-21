using Bookshop.Helpers;
using Bookshop.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Controllers
{
    class AdminStatisticsController
    {
        Layout layout = new Layout();
        MenuController menuController = new MenuController();

        /// <summary>
        /// Hanles the logic for the index page.
        /// </summary>
        public void Index()
        {
            PingHelper.CheckPing();

            layout.ClearMainContent();
            layout.ClearMenu();

            int option = menuController.Menu(Views.AdminStatistics.Index.menuOptions, false);
            switch (option)
            {
                case 0: // Sold items
                    SoldItems();
                    break;
                case 1: // Best customer
                    BestCustomer();
                    break;
                case 2: // Money earned
                    MoneyEarned();
                    break;
                case 3: // Back
                    AdminHomeController adminHomeController = new AdminHomeController();
                    adminHomeController.Index();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Handles the logic of the sold items page.
        /// </summary>
        public void SoldItems()
        {
            PingHelper.CheckPing();

            layout.ClearMainContent();
            layout.ClearMenu();

            var soldItems = GlobalVariables.Api.SoldItems(GlobalVariables.User.Id);
            Views.AdminStatistics.SoldItems.PrintSoldItems(soldItems);

            int option = menuController.Menu(Views.AdminStatistics.SoldItems.menuOptions, false);
            switch (option)
            {
                case 0: // Best customer
                    BestCustomer();
                    break;
                case 1: // Money earned
                    MoneyEarned();
                    break;
                case 2: // Back
                    Index();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Handles the logic of the best customer page.
        /// </summary>
        public void BestCustomer()
        {
            PingHelper.CheckPing();

            layout.ClearMainContent();
            layout.ClearMenu();

            string bestCustomer = GlobalVariables.Api.BestCustomer(GlobalVariables.User.Id);
            Views.AdminStatistics.BestCustomer.PrintBestCustomerPage(bestCustomer);

            int option = menuController.Menu(Views.AdminStatistics.BestCustomer.menuOptions, false);
            switch (option)
            {
                case 0: // Sold items
                    SoldItems();
                    break;
                case 1: // Money earned
                    MoneyEarned();
                    break;
                case 2: // Back
                    Index();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Handles the logic for the money earned page.
        /// </summary>
        public void MoneyEarned()
        {
            PingHelper.CheckPing();

            layout.ClearMainContent();
            layout.ClearMenu();

            int moneyEarned = GlobalVariables.Api.MoneyEarned(GlobalVariables.User.Id);
            Views.AdminStatistics.MoneyEarned.PrintMoneyEarnedPage(moneyEarned);

            int option = menuController.Menu(Views.AdminStatistics.MoneyEarned.menuOptions, false);
            switch (option)
            {
                case 0: // Sold items
                    SoldItems();
                    break;
                case 1: // Best customer
                    BestCustomer();
                    break;
                case 2: // Back
                    Index();
                    break;
                default:
                    break;
            }
        }
    }
}
