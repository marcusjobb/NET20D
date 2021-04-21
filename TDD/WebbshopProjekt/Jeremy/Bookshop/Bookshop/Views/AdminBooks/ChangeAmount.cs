using Bookshop.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Views.AdminBooks
{
    public static class ChangeAmount
    {
        /// <summary>
        /// The menu options.
        /// </summary>
        public static List<string> menuOptions = new List<string>() { "Update book",
            "Remove book", "Change category", "Back"};

        /// <summary>
        /// Prints the change amount page.
        /// </summary>
        public static void PrintChangeAmountPage()
        {
            Console.SetCursorPosition(25, 9);
            Console.WriteLine(
                $"Current amount: {GlobalVariables.Api.GetBook(GlobalVariables.BookId).Amount}");
            Console.CursorLeft = 25;
            Console.WriteLine("New amount:");
        }

        /// <summary>
        /// Prints the change amount page and lets the user enter a new amount.
        /// </summary>
        /// <returns></returns>
        public static int UseChangeAmountPage()
        {
            bool isNumeric = false;
            int userInput;

            Console.CursorVisible = true;

            do
            {
                Console.SetCursorPosition(40, 10);
                Console.WriteLine(new string(' ', 63));
                Console.SetCursorPosition(40, 10);
                isNumeric = int.TryParse(Console.ReadLine(), out userInput);
            } while (isNumeric == false);

            Console.CursorVisible = false;

            return userInput;
        }
    }
}
