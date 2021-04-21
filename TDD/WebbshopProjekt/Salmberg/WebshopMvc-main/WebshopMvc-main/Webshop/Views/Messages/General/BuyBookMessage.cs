using System;

namespace WebshopMVC.Views.Messages
{
    /// <summary>
    /// Class for handling messages used in BuyBook method
    /// </summary>
    internal class BuyBookMessage
    {
        /// <summary>
        /// Prints message when user is not logged in.
        /// </summary>
        public static void UserNotLoggedIn()
        {
            Console.WriteLine("You have to be logged in to purchase a book!\n" +
                "Please login or register a new user");
            Prompts.ClearAndContinue();
        }

        /// <summary>
        /// Specialized error message when API.BuyBook method returns false.
        /// </summary>
        /// <returns>string</returns>
        public static string Error()
        {
            Console.Clear();
            Console.WriteLine("Something went wrong with the purchase! Either your session timed out and you have to log in again, \n" +
                "or the book is out of stock. Are you sure you entered the correct book Id?");
            return Prompts.Abort();
        }

        /// <summary>
        /// Specialized success message when API.BuyBook method returns true.
        /// </summary>
        public static void Success()
        {
            Console.Clear();
            Console.WriteLine("Book purchased!");
            Prompts.ClearAndContinue();
        }
    }
}