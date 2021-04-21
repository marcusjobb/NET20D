using System;

namespace WebshopMVC.Views.Messages
{
    /// <summary>
    /// Class for handling messages used in Register method.
    /// </summary>
    internal class RegisterMessage
    {
        /// <summary>
        /// Prints message indicating that registration was successful.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public static void Success(string userName, string password)
        {
            Console.Clear();
            Console.WriteLine($"You are now registered! Your user name is \"{userName}\" and your password is \"{password}\"\n");
            Console.WriteLine("Login to start buying books!");
            Prompts.ClearAndContinue();
        }

        /// <summary>
        /// Prints message indicating that registration was unsuccessful.
        /// </summary>
        /// <returns>string</returns>
        public static string Error()
        {
            Console.Clear();
            Console.WriteLine("Something went wrong! Either the user name is already taken, or the password verification failed.");
            return Prompts.Abort();
        }
    }
}