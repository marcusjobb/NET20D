using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Helpers;

namespace WebshopFrontend.Controller
{
    class AddUserController
    {
        public static WebShop.WebShopApi api = new WebShop.WebShopApi();
        /// <summary>
        /// Method that will let admin to add a new user to the database
        /// If the password is empty, it will just be assigned the default value
        /// </summary>
        public static void AddUserLogic()
        {
            string addUsername;
            string addPassword;
            Console.WriteLine("╔══════════════════════════╗");
            Console.WriteLine("║  Enter desired username  ║");
            Console.WriteLine("╚══════════════════════════╝");
            addUsername = Console.ReadLine();
            Console.Clear();
            
            
            if(addUsername != "")
            {
                Console.WriteLine("╔══════════════════════════════════════════════════════════╗");
                Console.WriteLine("║               Enter your desired password                ║");
                Console.WriteLine("║  ───────────────────────────╬──────────────────────────  ║");
                Console.WriteLine("║  If you just want the user to have the default password  ║");
                Console.WriteLine("║  ───────────────────────────╬──────────────────────────  ║");
                Console.WriteLine("║       just press [Enter] without typing anything         ║");
                Console.WriteLine("╚══════════════════════════════════════════════════════════╝");
                addPassword = Console.ReadLine();
                Console.Clear();
                api.AddUser(LoginController.userId, addUsername, addPassword);
            } else
            {
                Console.Clear();
                CenterText.PrintLinesInCenter(
                "╔══════════════════════════╗",
                "║ Username cannot be empty ║",
                "║ ────────────╬─────────── ║",
                "║     Please try again     ║",
                "╚══════════════════════════╝"
                );
                Console.WriteLine();
            }
        }
    }
}
