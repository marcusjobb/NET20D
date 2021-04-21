using System;

namespace WebshopMVC.Views.Messages
{
    /// <summary>
    /// Class for handling messages used in Login method
    /// </summary>
    internal class LoginMessage
    {
        /// <summary>
        /// Prints Welcome userName
        /// </summary>
        /// <param name="userName"></param>
        public static void Success(string userName)
        {
            Console.Clear();
            Console.WriteLine($"Welcome {userName}!");
            Prompts.ClearAndContinue();
        }

        /// <summary>
        /// Prints error message when API.Login returns false.
        /// </summary>
        /// <returns>string</returns>
        public static string Error()
        {
            Console.Clear();
            Console.WriteLine("Something went wrong! Are you sure you typed in your user name and password correctly?");
            return Prompts.Abort();
        }
    }
}