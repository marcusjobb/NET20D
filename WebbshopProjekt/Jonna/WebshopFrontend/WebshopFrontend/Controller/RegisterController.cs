using System;
using System.Collections.Generic;
using System.Text;

namespace WebshopFrontend.Controller
{
    class RegisterController
    {
        public static WebShop.WebShopApi api = new WebShop.WebShopApi();
        public static bool register = true;
        private static string registerName;
        private static string registerPassword;
        private static string registerPasswordVerify;
        
        /// <summary>
        /// Method that lets the user fill in new data for a new user to be stored in the database
        /// </summary>
        public static void RegisterMenuController()
        {
            register = true;
            while (register)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════╗");
                Console.WriteLine("║     Register new account     ║");
                Console.WriteLine("║ ──────────────╬───────────── ║");
                Console.WriteLine("║    Enter desired username    ║");
                Console.WriteLine("╚══════════════════════════════╝");
                registerName = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════╗");
                Console.WriteLine("║    Enter desired password    ║");
                Console.WriteLine("╚══════════════════════════════╝");
                registerPassword = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════╗");
                Console.WriteLine("║  Verify password by typing it again  ║");
                Console.WriteLine("╚══════════════════════════════════════╝");
                registerPasswordVerify = Console.ReadLine();
                api.Register(registerName, registerPassword, registerPasswordVerify);
                register = false;
            }
        }

    }
}
