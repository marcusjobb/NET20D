using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Controller;

namespace WebshopFrontend.Views
{
    class MainMenuAdminUser
    {
        public static bool AdminBaseLevelMenu = true;
        public static bool AdminActionLevelMenu = true;
        public static WebShop.WebShopApi api = new WebShop.WebShopApi();

        /// <summary>
        /// View of the Initial Menu that you get when you logged in as Admin
        /// </summary>
        public static void MainMenu()
        {
            while (AdminBaseLevelMenu)
            {
                Console.Clear();
                Console.WriteLine("╔═════════════════════════════════════════════════╗");
                Console.WriteLine("║ ── Please select desired set of menu actions ── ║");
                Console.WriteLine("╚═════════════════════════════════════════════════╝");
                Console.WriteLine("|1|  Regular user menu actions                    |");
                Console.WriteLine("───────────────────────────────────────────────────");
                Console.WriteLine("|2|  Admin user menu actions                      |");
                Console.WriteLine("───────────────────────────────────────────────────");
                Console.WriteLine("|3|  Logout                                       |");
                Console.WriteLine("───────────────────────────────────────────────────");
                MainMenuAdminUserController.MainMenuLogic();
            }
        }
        /// <summary>
        /// View of the menu with admin privilege
        /// </summary>
        public static void AdminUserMenu()
        {
            AdminActionLevelMenu = true;
            while (AdminActionLevelMenu) 
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════╗");
                Console.WriteLine("║ ────  Admin menu actions  ──── ║");
                Console.WriteLine("╚════════════════════════════════╝");
                Console.WriteLine("|1|   Add book                   |");
                Console.WriteLine("──────────────────────────────────");
                Console.WriteLine("|2|   Set amount of books        |");
                Console.WriteLine("──────────────────────────────────");
                Console.WriteLine("|3|   Update book details        |");
                Console.WriteLine("──────────────────────────────────");
                Console.WriteLine("|4|   Delete Book                |");
                Console.WriteLine("──────────────────────────────────");
                Console.WriteLine("|5|   Add new category           |");
                Console.WriteLine("──────────────────────────────────");
                Console.WriteLine("|6|   Add book to category       |");
                Console.WriteLine("──────────────────────────────────");
                Console.WriteLine("|7|   Update Category            |");
                Console.WriteLine("──────────────────────────────────");
                Console.WriteLine("|8|   Delete Category            |");
                Console.WriteLine("──────────────────────────────────");
                Console.WriteLine("|9|   List Users                 |");
                Console.WriteLine("──────────────────────────────────");
                Console.WriteLine("|10|  Find Users                 |");
                Console.WriteLine("──────────────────────────────────");
                Console.WriteLine("|11|  Add new user               |");
                Console.WriteLine("──────────────────────────────────");
                Console.WriteLine("|12|  Return to Admin Main menu  |");
                Console.WriteLine("──────────────────────────────────");
                MainMenuAdminUserController.AdminUserMenu();
            }
        }
    }
}
