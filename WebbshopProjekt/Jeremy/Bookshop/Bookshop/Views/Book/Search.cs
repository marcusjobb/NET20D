using Bookshop.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webbutik;

namespace Bookshop.Views.Book
{
    public static class Search
    {
        private static WebbShopAPI api = new WebbShopAPI();

        /// <summary>
        /// The menu options.
        /// </summary>
        public static List<string> menuOptions = new List<string>() { "Categories", "Back" };

        /// <summary>
        /// Prints the search bar.
        /// </summary>
        public static void PrintSearchBar()
        {
            Console.SetCursorPosition(48, 18);
            Console.Write("Search: ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Title, Author, Category");
            Console.ResetColor();
        }

        /// <summary>
        /// Prints the search bar and lets the user enter a search keyword.
        /// </summary>
        /// <returns>All metching books, authors and categories.</returns>
        public static string UseSearchBar()
        {
            string userInput;

            Console.CursorVisible = true;
            Console.SetCursorPosition(56, 18);
            Console.Write(new string(' ', 23));
            Console.CursorLeft = 56;
            userInput = Console.ReadLine();
            Console.CursorVisible = false;

            return userInput;
        }

        /// <summary>
        /// Prints the search result.
        /// </summary>
        /// <param name="books"></param>
        public static void ShowSearchResult(List<Webbutik.Models.Book> books)
        {
            Layout layout = new Layout();
            layout.ClearMainContent();

            Console.SetCursorPosition(27, 9);

            foreach (var item in books)
            {
                Console.Write(item.Title);
                Console.CursorLeft = 55;
                Console.Write(item.Author.Name);
                Console.CursorLeft = 80;
                Console.Write(item.Category.Name);
                Console.CursorLeft = 95;
                Console.WriteLine($"{item.Price} kr");
                Console.CursorLeft = 27;
            }
        }
    }
}
