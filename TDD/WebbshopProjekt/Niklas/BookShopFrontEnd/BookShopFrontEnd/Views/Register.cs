using BookShopFrontEnd.Utility;
using System;
using System.Threading;

namespace BookShopFrontEnd.Views
{
    public class Register
    {
        /// <summary>
        /// The view for the UserController.Register method
        /// </summary>
        /// <returns>string[] of credentials. Username[0], Password[1], FirstName[2], Surname[3].</returns>
        public static string[] User()
        {
            Console.Clear();
            Logotypes.Register();
            Console.WriteLine("Step 1: Enter your username & password.");
            Console.WriteLine("Step 2: Enter your first name & surname.\n");

            Console.Write("Username: ");
            string username = Console.ReadLine().Trim();
            if (username == null)
            {
                Console.WriteLine("You need to enter a username.");
                Thread.Sleep(1300);
                User();
            }

            Console.Write("Password: ");
            string password = Console.ReadLine().Trim();
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

            Console.Write("First name: ");
            string firstName = Console.ReadLine().Trim();
            if (username == null)
            {
                Console.WriteLine("You need to enter a first name.");
                Thread.Sleep(1300);
                User();
            }

            Console.Write("Surname: ");
            string surname = Console.ReadLine().Trim();
            if (username == null)
            {
                Console.WriteLine("You need to enter a surname.");
                Thread.Sleep(1300);
                User();
            }

            Console.WriteLine("User created.");
            Thread.Sleep(1300);
            return new string[] { username, password, firstName, surname }; ;
        }
    }
}
