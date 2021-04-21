using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshop.Views.AdminBooks
{
    public static class UpdateCategory
    {
        /// <summary>
        /// The menu options.
        /// </summary>
        public static List<string> menuOptions = new List<string>() { "Add book", "Edit book",
            "Add category", "Delete category", "Back"};

        /// <summary>
        /// Prints the update category page and lets the user enter a new name for the category.
        /// </summary>
        /// <returns>The new name for the category.</returns>
        public static string UseUpdateCategoryPage()
        {
            Console.SetCursorPosition(40, 18);
            Console.CursorVisible = true;
            Console.WriteLine("Enter new category name:");
            Console.SetCursorPosition(65, 18);
            string userInput = Console.ReadLine();
            Console.CursorVisible = false;

            return userInput;
        }

        /// <summary>
        /// Prints the success message.
        /// </summary>
        public static void Success()
        {
            Console.SetCursorPosition(42, 20);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The category has been successfully updated");
            Console.ResetColor();
            Thread.Sleep(3000);
        }
    }
}
