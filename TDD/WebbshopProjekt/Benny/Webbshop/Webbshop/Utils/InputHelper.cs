using System;

namespace Webbshop.Utils
{
    internal class InputHelper
    {
        /// <summary>
        /// Asks the user for plain menu input
        /// </summary>
        /// <returns>returns the string</returns>
        public static string AskForMenuInput()
        {
            Console.Write("\n\tGör ditt val >");
            return Console.ReadLine();
        }

        /// <summary>
        /// Validates the menu input if it was a number or not.
        /// </summary>
        /// <param name="userInput">Takes the user input mad by the user</param>
        /// <returns>returns the number if validated correctly, 
        /// 0 if anything else then a number was typed in.</returns>
        public static int ValidateMenuInput(string userInput)
        {
            int number;
            if (int.TryParse(userInput, out number))
            {
                return number;
            }

            return number;
        }

        /// <summary>
        /// Input free text without any "heading"
        /// </summary>
        /// <returns>returns the text typed in by the user.</returns>
        internal static string InputFreeText()
        {
            return Console.ReadLine();
        }
    }
}