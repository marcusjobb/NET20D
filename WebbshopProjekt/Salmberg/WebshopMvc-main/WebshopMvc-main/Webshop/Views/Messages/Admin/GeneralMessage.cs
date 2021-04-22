using System;

namespace WebshopMVC.Views.Messages.Admin
{
    /// <summary>
    /// Class for general messages.
    /// </summary>
    internal class GeneralMessage
    {
        /// <summary>
        /// Prints message for when Administrator is not logged in
        /// </summary>
        public static void AdminNotLoggedIn()
        {
            Console.Clear();
            Console.WriteLine("Session limit reached!\n" +
                "Please login again");
            Prompts.ClearAndContinue();
        }
    }
}