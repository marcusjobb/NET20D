using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshop.Views.AdminBooks
{
    public static class DeleteCategory
    {
        /// <summary>
        /// The menu options.
        /// </summary>
        public static List<string> menuOptions = new List<string>() { "Add book", "Edit book",
            "Add category", "Update category", "Back"};

        /// <summary>
        /// Prints the confirm message.
        /// </summary>
        public static void Confirm()
        {
            Console.SetCursorPosition(40, 15);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Are you sure you want to remove this category?");
            Console.ResetColor();
        }

        /// <summary>
        /// Prints the success message.
        /// </summary>
        public static void Success()
        {
            Console.SetCursorPosition(42, 18);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The category has been successfully removed");
            Console.ResetColor();
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Prints the failure message.
        /// </summary>
        public static void Failure()
        {
            Console.SetCursorPosition(43, 18);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The category is used by one or more books");
            Console.ResetColor();
            Thread.Sleep(3000);
        }
    }
}
