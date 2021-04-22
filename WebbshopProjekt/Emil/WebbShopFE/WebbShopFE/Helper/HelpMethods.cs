using System;
using WebbShopFE.Views;

namespace WebbShopFE.Helper
{
    public static class HelpMethods
    {
        /// <summary>
        /// Console.WriteLine blue text.
        /// </summary>
        /// <param name="input"></param>
        public static void BlueTextWL(string input)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(input);
            Console.ResetColor();
        }

        /// <summary>
        /// Console.WriteLine green text.
        /// </summary>
        /// <param name="input"></param>
        public static void GreenTextWL(string input)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(input);
            Console.ResetColor();
        }

        /// <summary>
        /// Handles input from user exampel Switch statments.
        /// </summary>
        /// <param name="menuChoice"></param>
        /// <param name="numberOfMenuChoices"></param>
        public static void MenuHandling(string menuChoice, int numberOfMenuChoices)
        {
            if (!int.TryParse(menuChoice, out int menuNumber) || menuNumber < 1 || menuNumber > numberOfMenuChoices)
            {
                MessageView.TryAgain();
            }
        }

        /// <summary>
        /// Console.WriteLine red text.
        /// </summary>
        /// <param name="input"></param>
        public static void RedTextWL(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(input);
            Console.ResetColor();
        }

        /// <summary>
        /// Checks if the tresult is true or false.
        /// </summary>
        /// <param name="result"></param>
        public static void SuccessOrNot(bool result)
        {
            if (result == true)
            {
                MessageView.SuccesMessage();
            }
            else
            {
                MessageView.ErrorMessage();
            }
        }
    }
}