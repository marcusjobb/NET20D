using System;

namespace WebshopMVC.Views.Messages
{
    /// <summary>
    /// Class for handling user prompt to press enter to continue for marking a change in console view
    /// </summary>
    internal class Prompts
    {
        /// <summary>
        /// Prints "Press enter to continue..." and clears console window.
        /// </summary>
        public static void ClearAndContinue()
        {
            Console.WriteLine("\nPress enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }

        /// <summary>
        /// Gives user choice to abort or try again.
        /// </summary>
        /// <returns>string</returns>
        public static string Abort()
        {
            Console.WriteLine("\nPress enter to try again or x to abort...");
            var input = Console.ReadLine();
            return input;
        }
    }
}