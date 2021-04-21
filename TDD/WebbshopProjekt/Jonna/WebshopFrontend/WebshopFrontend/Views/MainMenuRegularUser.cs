using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Controller;

namespace WebshopFrontend.Views
{
    class MainMenuRegularUser
    {
        public static bool RegularUserActions = true;
        public static WebShop.WebShopApi api = new WebShop.WebShopApi();
        /// <summary>
        /// View of the Main regular user menu
        /// That will display two different menus depending wether you are admin or not
        /// </summary>
        public static void MainMenu()
        {
            RegularUserActions = true;
            while (RegularUserActions) 
            {
                if (LoginController.isUserAdmin == true)
                {
                    Console.Clear();
                    Console.WriteLine("╔═══════════════════════════════════════════════╗");
                    Console.WriteLine("║ ────────    Regular user actions    ───────── ║");
                    Console.WriteLine("╚═══════════════════════════════════════════════╝");
                    Console.WriteLine("|1|  Show all categories                        |");
                    Console.WriteLine("─────────────────────────────────────────────────");
                    Console.WriteLine("|2|  Search category by name                    |");
                    Console.WriteLine("─────────────────────────────────────────────────");
                    Console.WriteLine("|3|  Search books by title                      |");
                    Console.WriteLine("─────────────────────────────────────────────────");
                    Console.WriteLine("|4|  Search books by author                     |");
                    Console.WriteLine("─────────────────────────────────────────────────");
                    Console.WriteLine("|5|  List all books in category                 |");
                    Console.WriteLine("─────────────────────────────────────────────────");
                    Console.WriteLine("|6|  List books in category currently in stock  |");
                    Console.WriteLine("─────────────────────────────────────────────────");
                    Console.WriteLine("|7|  Show information about a book              |");
                    Console.WriteLine("─────────────────────────────────────────────────");
                    Console.WriteLine("|8|  Buy book                                   |");
                    Console.WriteLine("─────────────────────────────────────────────────");
                    Console.WriteLine("|9|  Return to Main Admin menu                  |");
                    Console.WriteLine("─────────────────────────────────────────────────");
                    MainMenuRegularUserController.MainMenuLogic();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("╔═══════════════════════════════════════════════╗");
                    Console.WriteLine("║ ────────    Regular user actions    ───────── ║");
                    Console.WriteLine("╚═══════════════════════════════════════════════╝");
                    Console.WriteLine("|1|  Show all categories                        |");
                    Console.WriteLine("─────────────────────────────────────────────────");
                    Console.WriteLine("|2|  Search category by name                    |");
                    Console.WriteLine("─────────────────────────────────────────────────");
                    Console.WriteLine("|3|  Search books by title                      |");
                    Console.WriteLine("─────────────────────────────────────────────────");
                    Console.WriteLine("|4|  Search books by author                     |");
                    Console.WriteLine("─────────────────────────────────────────────────");
                    Console.WriteLine("|5|  List all books in category                 |");
                    Console.WriteLine("─────────────────────────────────────────────────");
                    Console.WriteLine("|6|  List books in category currently in stock  |");
                    Console.WriteLine("─────────────────────────────────────────────────");
                    Console.WriteLine("|7|  Show information about a book              |");
                    Console.WriteLine("─────────────────────────────────────────────────");
                    Console.WriteLine("|8|  Buy book                                   |");
                    Console.WriteLine("─────────────────────────────────────────────────");
                    Console.WriteLine("|9|  Logout                                     |");
                    Console.WriteLine("─────────────────────────────────────────────────");
                    MainMenuRegularUserController.MainMenuLogic();
                }
            }
        }
    }
}
