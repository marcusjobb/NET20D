using Bookshop.Helpers;
using Bookshop.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Controllers
{
    class AdminHomeController
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

            int option = menuController.Menu(Views.AdminHome.Index.menuOptions, false);
            switch (option)
            {
                case 0: // Users
                    AdminUsersController adminUsersController = new AdminUsersController();
                    adminUsersController.Index();
                    break;
                case 1: // Books
                    AdminBooksController adminBooksController = new AdminBooksController();
                    adminBooksController.Index();
                    break;
                case 2: // Statistics
                    AdminStatisticsController adminStatisticsController = new 
                        AdminStatisticsController();
                    adminStatisticsController.Index();
                    break;
                case 3: // Logout
                    HomeController homeController = new HomeController();
                    homeController.Logout();
                    break;
                default:
                    break;
            }
        }
    }
}
