using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Controller;

namespace WebshopFrontend.Views
{
    class FindUsers
    {
        /// <summary>
        /// View of the Find Users method
        /// </summary>
        public static void DisplayFoundUsers()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║     Search for users by keyword      ║");
            Console.WriteLine("║ ──────────────────╬───────────────── ║");
            Console.WriteLine("║     Example, searching for 'min'     ║");
            Console.WriteLine("║  would display the user named'admin  ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
            FindUsersController.FindUsersLogic();
            Console.ReadKey();
        }

    }
}
