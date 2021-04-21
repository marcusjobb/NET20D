using System;
using WebshopAPI.Models;

namespace WebshopMVC.Views.Messages
{
    /// <summary>
    /// Class for handling messages used in Logout method
    /// </summary>
    public class LogoutMessage
    {
        /// <summary>
        /// Prints message when user is logged out
        /// </summary>
        /// <param name="user"></param>
        public static void LoggedOut(User user)
        {
            Console.Clear();
            Console.WriteLine($"You have been logged out!\n\nHope to see you back soon, {user.Name}!");
            Prompts.ClearAndContinue();
        }
    }
}