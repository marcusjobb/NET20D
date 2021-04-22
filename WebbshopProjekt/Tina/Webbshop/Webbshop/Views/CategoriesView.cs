using System;
using System.Collections.Generic;
using WebbshopProject.Models;
using Webbshop.Helpers;

namespace Webbshop.Views
{
    class CategoriesView
    {
        /// <summary>
        /// Prints a menu of categories-choices. Depending on 
        /// if user is admin or not. Different choices will
        /// be presented.
        /// </summary>
        /// <param name="userId"></param>
        public static void PrintMenu(int userId)
        {
            Console.WriteLine("What do you want to do?");
            if (!HelperMethods.IsUserAdminAndLoggedIn(userId))
            {
                Console.Clear();
                Messages.ColorText("[1] Get categories\n" +
                    "[2] Search for category\n" +
                    "[3] List books in category\n" +
                    "[E] Exit to main",
                    ConsoleColor.Yellow);
                Console.Write("Enter choice: ");
            }
            else
            {
                Console.Clear();
                Messages.ColorText("[1] Add new category\n" +
                    "[2] Update Category\n[3] Delete category\n" +
                    "[E] Exit to main",
                    ConsoleColor.Yellow);
                Console.Write("Enter choice: ");
            }
        }
        /// <summary>
        /// Prints a list of all the categories in the database.
        /// </summary>
        /// <param name="listOfCategories"></param>
        public static void PrintAllCategories(
            List<BookCategory> listOfCategories)
        {
            foreach (var category in listOfCategories)
            {
                Messages.ColorText(category.Name, ConsoleColor.Cyan);
            }
        }
        /// <summary>
        /// Prints question to enter a search for category.
        /// </summary>
        internal static void PrintCategorySearch()
        {
            Console.Clear();
            Console.Write("Enter search: ");
        }
        /// <summary>
        /// Prints a list of categories matching a search.
        /// </summary>
        /// <param name="listOfCategories"></param>
        public static void PrintCategoriesMatchingSearch(
            List<BookCategory> listOfCategories)
        {
            Messages.ColorText("Hits on search: ", ConsoleColor.Yellow);
            foreach (var cat in listOfCategories)
            {
                Messages.ColorText(cat.Name, ConsoleColor.Cyan);
            };
        }
        /// <summary>
        /// Prints all books in sertain category.
        /// </summary>
        /// <param name="listOfBooks"></param>
        public static void PrintBooksInCategory(List<Book> listOfBooks)
        {
            foreach (var book in listOfBooks)
            {
                Messages.ColorText(book.Title, ConsoleColor.Cyan);
            }
        }
        /// <summary>
        /// Prints a question to add a new category-name.
        /// </summary>
        public static void AddCategoryView()
        {
            Messages.ColorText("What category do you want to add?",
            ConsoleColor.Cyan);
            Console.Write("Enter name: ");
        }
        /// <summary>
        /// Prints a question to add a name to update category.
        /// </summary>
        internal static void CredentialsToUpdateCategory()
        {
            Console.WriteLine("What do you want to change it to?");
            Console.Write("Enter name: ");
        }
    }
}
