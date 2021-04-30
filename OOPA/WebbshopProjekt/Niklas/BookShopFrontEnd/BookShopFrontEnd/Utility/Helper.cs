using System;
using System.Threading;

namespace BookShopFrontEnd.Utility
{
    /// <summary>
    /// Eases the programming by calling frequently used methods.
    /// </summary>
    public class Helper
    {
        /// <summary>
        /// Asks user for input > converts to int.
        /// </summary>
        /// <param name="minValue">Minimum value for alternatives.</param>
        /// <param name="maxValue">Maximum value for alternatives.</param>
        /// <returns>int - user input.</returns>
        public static int GetInputForOptions(int minValue, int maxValue)
        {
            Console.Write("\nOption: ");
            Console.ForegroundColor = ConsoleColor.White;
            string input = Console.ReadLine().Trim().ToLower();
            Console.ResetColor();
            bool success = Int32.TryParse(input, out int nr);
            if (success && nr < minValue || success && nr > maxValue)
            {
                ErrorMessage();
                Thread.Sleep(1300);
                GetInputForOptions(minValue, maxValue);
            }
            else if (input == "q")
            {
                Helper.Exit();
            }
            else if (input == "b")
            {
                Controllers.MenuController.MainMenu();
            }
            else if (!success)
            {
                ErrorMessage();
                Thread.Sleep(1300);
                GetInputForOptions(minValue, maxValue);
            }
                return nr;
        }

        /// <summary>
        /// Tries to convert string to in.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>converted number as int. 0 if conversion fails.</returns>
        public static int ConvertToInt(string input)
        {
            int nr = 0;
            try
            {
                bool success = Int32.TryParse(input, out nr);
            }
            catch
            {
                ErrorMessage();
                Thread.Sleep(1300);
            }

            return nr;
        }

        /// <summary>
        /// Sends a standardized ErrorMessage.
        /// WriteLine = Wrong Input.
        /// </summary>
        public static void ErrorMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nWrong Input. Try again.\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Exits the application.
        /// </summary>
        internal static void Exit()
        {
            Console.Clear();
            Logotypes.Exit();
            Console.WriteLine("\nExiting application.");
            Environment.Exit(0);
        }
    }
}
