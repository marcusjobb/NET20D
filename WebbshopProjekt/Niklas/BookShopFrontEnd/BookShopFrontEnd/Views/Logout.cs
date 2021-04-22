using BookShopFrontEnd.Controllers;
using BookShopFrontEnd.Utility;
using System;
using System.Threading;

namespace BookShopFrontEnd.Views
{
    public class Logout
    {
        /// <summary>
        /// The view for the UserController.Logout method
        /// </summary>
        public static void User(string username)
        {
            Console.Clear();
            Logotypes.Logout();
            Console.WriteLine($"Goodbye {username}");
            Thread.Sleep(1000);
        }
    }
}
