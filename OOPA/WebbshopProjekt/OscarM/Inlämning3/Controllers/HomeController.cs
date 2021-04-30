using Inlämning2WebbShop;
using Inlämning3.Helpers;
using System;

namespace Inlämning3.Controllers
{
    public class HomeController
    {
        private WebbShopAPI api = new WebbShopAPI();

        /// <summary>
        /// method that calls other methods depending on the choice of the user
        /// </summary>
        public void Home()
        {
            do
            {
                Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                int choice = Views.Home.MainMenu.Display();
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        Register();
                        break;

                    case 2:
                        Login();
                        break;

                    case 3:
                        var searchController = new SearchController();
                        searchController.SearchMenu();
                        break;

                    case 4:
                        var logout = new LogoutController();
                        logout.LogoutAndGoToMainMenu();
                        break;

                    case 5:
                        Exit.LogOutAndExit();
                        break;

                    default:
                        Messages.NotValidInput();
                        break;
                }
            } while (true);
        }

        /// <summary>
        /// gets username and password and calls the API loginmethod. Pass the information over to the AccountClass.
        /// </summary>
        private void Login()
        {
            Views.Home.LoginView.Display(out string username, out string password);
            var userId = api.Login(username, password);
            if (userId != 0)
            {
                Console.Clear();
                Console.WriteLine($"{username} successfully logged in!");
                Account.UserId = userId;
                Account.IsLoggedIn = true;
                if (api.IsUserAdmin(userId))
                {
                    Account.IsAdmin = true;
                    var adminController = new AdminController();
                    adminController.AdminMenu();
                }
            }
            else
            {
                Console.Clear();
                Messages.ErrorMessage();
            }
        }

        /// <summary>
        /// Gets the necessary information to register from Registerview, and then calls api Register method
        /// </summary>
        private void Register()
        {
            Views.Home.RegisterView.Display(out string username, out string password, out string passwordVerify);
            if (api.Register(username, password, passwordVerify))
            {
                Console.Clear();
                Console.WriteLine($"{username} registered succesfully!");
                Home();
            }
            else
            {
                Console.Clear();
                Messages.ErrorMessage();
            }
        }
    }
}