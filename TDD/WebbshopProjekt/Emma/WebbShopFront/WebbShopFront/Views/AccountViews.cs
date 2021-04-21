using System;

namespace WebbShopFrontInlamning.Views
{
    /// <summary>
    /// Displays login guidelines for user
    /// </summary>
    class AccountViews
    {
        /// <summary>
        /// Displays login page
        /// </summary>
        public static void LoginPage()
        {
            Console.WriteLine();
            Console.WriteLine("Please fill in the following: ");
            Console.WriteLine("1. User name: ");
            Console.WriteLine("2. Password: ");
        }

        /// <summary>
        /// Displays message if login was successful
        /// </summary>
        public static void LoginSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("Login successful!");
        }

        /// <summary>
        /// Displays message if login failed
        /// </summary>
        public static void LoginFailed()
        {
            Console.WriteLine();
            Console.WriteLine("You don't seem to have an account, please register.");
        }

        /// <summary>
        /// Displays goodbye message for user
        /// </summary>
        public static void LogoutUser()
        {
            Console.WriteLine();
            Console.WriteLine("Have a nice day!");
        }
    }
}
