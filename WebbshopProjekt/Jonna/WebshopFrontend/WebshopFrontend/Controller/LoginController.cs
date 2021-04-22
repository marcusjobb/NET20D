using System;
using WebshopFrontend.Views;
using WebshopFrontend.Helpers;

namespace WebshopFrontend.Controller
{
    public class LoginController
    {
        public static WebShop.WebShopApi api = new WebShop.WebShopApi();

        public static int userId;
        public static bool isUserAdmin;

        private static bool login = true;
        private static string LoginUsername;
        private static string LoginPassword;

        /// <summary>
        /// Login method where entered Username and password is matched with database records
        /// Depending wether you are admin or not, you will be directed to your specific roles menu
        /// </summary>
        public static void LoginMenuLogic()
        {
            login = true;
            while (login)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════╗");
                Console.WriteLine("║ Enter your username and password ║");
                Console.WriteLine("║ ────────────────╬─────────────── ║");
                Console.WriteLine("║    Please enter your username    ║");
                Console.WriteLine("╚══════════════════════════════════╝");
                LoginUsername = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════╗");
                Console.WriteLine("║  Please enter your password  ║");
                Console.WriteLine("╚══════════════════════════════╝");
                LoginPassword = Console.ReadLine();
                userId = api.Login(LoginUsername, LoginPassword);
                if (userId == 0)
                {
                    Console.Clear();
                    CenterText.PrintLinesInCenter(
                    "╔══════════════════════════════╗",
                    "║  Login details doesnt match  ║",
                    "╚══════════════════════════════╝");
                    Console.ReadKey();
                }
                else
                {
                    if (api.IsUserAdmin == true)
                    {
                        isUserAdmin = true;
                        login = false;
                        MainMenuAdminUser.MainMenu();
                    }
                    else
                    {
                        login = false;
                        isUserAdmin = false;
                        MainMenuRegularUser.MainMenu();
                    }
                }
            }
        }
    }
}