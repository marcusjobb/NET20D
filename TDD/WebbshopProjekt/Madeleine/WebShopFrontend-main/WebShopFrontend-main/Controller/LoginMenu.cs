using System;
using System.Collections.Generic;
using System.Text;
using WebShopAssignment;
using WebShopAssignment.Models;
using WebShopFrontend.View;

namespace WebShopFrontend.Controller
{
    public class LoginMenu
    {
        public static WebShopAPI api = new WebShopAPI();
        /// <summary>
        /// Kollar om användaren finns
        /// </summary>
        public static void Startup()
        {
            Console.WriteLine("Användarnamn: ");
            string name = Console.ReadLine();
            Console.WriteLine("Lösenord: ");
            string password = Console.ReadLine();
            var userOk = api.Login(name, password);
            if (userOk == 0)
            {
                UsersView.NewUser(name, password);
            }
            else if (userOk == 1)
            {
                AdminView.AdminMenu(userOk);
            }
            else
            {
                UsersView.UserMenu(userOk);
            }
        }
        /// <summary>
        /// Om annvändaren blivit utloggad
        /// </summary>
        public static void LoginAgain()
        {
            Console.WriteLine("Du har blivit utloggad pga inaktivitet.");
            Console.WriteLine("Vänligen logga in igen.");
            Startup();
        }
    }
}
