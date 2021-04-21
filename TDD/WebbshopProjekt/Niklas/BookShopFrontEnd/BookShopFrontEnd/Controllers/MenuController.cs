using BookShopFrontEnd.Utility;
using BookShopFrontEnd.Views;
using System;
using WebbShopAPI;

namespace BookShopFrontEnd.Controllers
{
    /// <summary>
    /// Make the calls for the menus in the application.
    /// </summary>
    public class MenuController
    {
        /// <summary>
        /// First menu shown to user.
        /// </summary>
        public static void StartUpMenu()
        {
            StartupMenuView.Menu();
            int inputNumber = Helper.GetInputForOptions(1, 3);
            if (inputNumber == 1) { UserController.UserLogin(); }
            else if (inputNumber == 2) { UserController.UserRegister(); }
            else if (inputNumber == 3) { Helper.Exit(); }
            else { StartUpMenu(); }
            if (UserController.LoggedUser != null)
            {
                MainMenu();
            }
        }

        /// <summary>
        /// Main menu. Displays the options: Buy book, Admin interface(if user is admin) and logout.
        /// </summary>
        public static void MainMenu()
        {
            if (UserController.LoggedUser != null)
            {
                var isAdmin = new WebShopAPI().IsAdmin(UserController.LoggedUser.ID);
                if (isAdmin)
                {
                    Console.Clear();
                    Logotypes.MainMenu();
                    MenuFrames.Frame(new string[] { "Buy book", "Admin interface", "Log out" });
                    var input = Helper.GetInputForOptions(1, 3);
                    if (input == 1) { StoreController.BuyBook(); }
                    else if (input == 2) { AdminController.AdminInterface(); }
                    else { Logout.User(UserController.LoggedUser.Username); }
                }
                else
                {
                    Console.Clear();
                    MenuFrames.Frame(new string[] { "Buy book", "Log out" });
                    var input = Helper.GetInputForOptions(1, 2);
                    if (input == 1) { StoreController.BuyBook(); }
                    else { Logout.User(UserController.LoggedUser.Username); }
                }
            }
            else
            {
                Helper.ErrorMessage();
                MenuController.StartUpMenu();
            }
        }
    }
}
