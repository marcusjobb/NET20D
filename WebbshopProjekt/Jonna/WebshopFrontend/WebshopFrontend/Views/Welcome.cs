using ConsoleTableExt;
using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Controller;


namespace WebshopFrontend.Views
{
    class Welcome
    {
        public static bool welcome = true;
        /// <summary>
        /// View of the welcome screen of the application
        /// </summary>
        public static void WelcomeMenu()
        {
            while (welcome)
            {
                Console.Clear();
                Console.WriteLine("╔═══════════════════════════════════╗");
                Console.WriteLine("║    Welcome to the book webshop    ║");
                Console.WriteLine("║   ──────────────╬──────────────   ║");
                Console.WriteLine("║  Login or register a new account  ║");
                Console.WriteLine("╚═══════════════════════════════════╝");
                Console.WriteLine("|1| Login                           |");
                Console.WriteLine("─────────────────────────────────────");
                Console.WriteLine("|2| Register                        |");
                Console.WriteLine("─────────────────────────────────────");
                Console.WriteLine("|3| Exit                            |");
                Console.WriteLine("─────────────────────────────────────");
                WelcomeController.WelcomeMenuLogic();
            }
        }
    }
}
