using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshop.Views.AdminBooks
{
    public static class AddCategory
    {
        /// <summary>
        /// The menu options.
        /// </summary>
        public static List<string> menuOptions = new List<string>() { "Add book", "Edit book",
            "Update category", "Delete category", "Back"};

        /// <summary>
        /// Prints the add category page.
        /// </summary>
        public static void PrintAddCategoryPage()
        {
            Console.SetCursorPosition(40, 18);
            Console.WriteLine("Category name:");
        }

        /// <summary>
        /// Prints the add category page and lets the user enter a name for the category.
        /// </summary>
        /// <returns>The name of the category.</returns>
        public static string UseAddCategoryPage()
        {
            Console.SetCursorPosition(55, 18);
            Console.CursorVisible = true;
            string userInput = Console.ReadLine();
            Console.CursorVisible = false;

            return userInput;
        }

        /// <summary>
        /// Prints the success message.
        /// </summary>
        public static void Success()
        {
            Console.SetCursorPosition(43, 20);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The category has been successfully added");
            Console.ResetColor();
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Prints the failure messsage.
        /// </summary>
        public static void Failure()
        {
            Console.SetCursorPosition(48, 20);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The category does already exist");
            Console.ResetColor();
            Thread.Sleep(3000);
        }
    }
}
