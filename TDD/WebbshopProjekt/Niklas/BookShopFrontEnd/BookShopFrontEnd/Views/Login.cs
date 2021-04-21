using BookShopFrontEnd.Utility;
using System;
using System.Threading;

namespace BookShopFrontEnd.Views
{
    /// <summary>
    /// The view for the UserController.Login method
    /// </summary>
    public class Login
    {
        /// <summary>
        /// Registers a user to local database.
        /// </summary>
        /// <returns>string[] of credentials. Username[0], Password[1].</returns>
        public static string[] User()
        {
            string username, password;
            Console.Clear();
            Logotypes.Login();
            Console.WriteLine("Enter your username & password.\n");
            Console.Write("Username: ");
            username = Console.ReadLine().Trim();
            if (username == null)
            {
                Console.WriteLine("You need to enter a username.");
                Thread.Sleep(1300);
                User();
            }

            Console.Write("Password: ");
            password = Console.ReadLine().Trim();
            if (password == null)
            {
                Console.WriteLine("You need to enter a password.");
                Thread.Sleep(1300);
                User();
            }
            else if (password.Length < 4)
            {
                Console.WriteLine("Password needs to be longer than 4 characters.");
                Thread.Sleep(1300);
                User();
            }

            Console.WriteLine("Attempting to login...");
            string[] credentials = { username, password };
            return credentials;
        }
    }
}
