using Bookshop.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Bookshop.Views.AdminBooks
{
    public static class UpdateBook
    {
        /// <summary>
        /// The menu options.
        /// </summary>
        public static List<string> menuOptions = new List<string>() { "Change amount",
            "Remove book", "Change category", "Back"};

        /// <summary>
        /// Prints the update book page.
        /// </summary>
        public static void PrintUpdateBookPage()
        {
            Console.SetCursorPosition(25, 9);
            Console.WriteLine($@"Current title: {GlobalVariables.Api.GetBook(
                GlobalVariables.BookId).Title}");
            Console.CursorLeft = 25;
            Console.WriteLine("New title: ");

            Console.SetCursorPosition(25, 12);
            Console.WriteLine($@"Current author: {GlobalVariables.Api.GetBook(
                GlobalVariables.BookId).Author.Name}");
            Console.CursorLeft = 25;
            Console.WriteLine("New author: ");

            Console.SetCursorPosition(25, 15);
            Console.WriteLine($@"Current price: {GlobalVariables.Api.GetBook(
                GlobalVariables.BookId).Price}");
            Console.CursorLeft = 25;
            Console.WriteLine("New price: ");
        }

        /// <summary>
        /// Prints the update book page and lets the user enter the new title, author and price.
        /// </summary>
        /// <returns>A list with the new title, author and price.</returns>
        public static List<(string, string, int)> UseUpdateBookPage()
        {
            bool isNumeric = false;
            int price;
            var userInput = new List<(string title, string author, int price)>();

            Console.SetCursorPosition(40, 10);
            Console.CursorVisible = true;
            string title = Console.ReadLine();
            Console.SetCursorPosition(40, 13);
            string author = Console.ReadLine();

            do
            {
                Console.SetCursorPosition(40, 16);
                Console.WriteLine(new string(' ', 63));
                Console.SetCursorPosition(40, 16);
                isNumeric = int.TryParse(Console.ReadLine(), out price);
            } while (isNumeric == false);

            Console.CursorVisible = false;

            userInput.Add((title, author, price));
            return userInput;
        }

        /// <summary>
        /// Prints the success message.
        /// </summary>
        public static void Success()
        {
            Console.SetCursorPosition(44, 18);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The book has successfully been updated");
            Console.ResetColor();
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Prints the failure message.
        /// </summary>
        public static void Failure()
        {
            Console.SetCursorPosition(48, 18);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The book could not be updated.");
            Console.ResetColor();
            Thread.Sleep(3000);
        }
    }
}
