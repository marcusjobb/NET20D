using System;
using System.Collections.Generic;
using WebbShopInlamningsUppgift.Models;

namespace WebbShopFrontInlamning.Views
{
    /// <summary>
    /// Displays the view for books
    /// </summary>
    class BookViews
    {
        /// <summary>
        /// Displays the browse book meny
        /// </summary>
        public static void BookMeny()
        {
            Console.WriteLine();
            Console.WriteLine("1. View all categories");
            Console.WriteLine("2. Search category");
            Console.WriteLine("3. Search book by Author");
            Console.WriteLine("4. Search book by Title");
            Console.WriteLine("5. View all available books");
            Console.WriteLine("6. Return to main meny");
        }

        /// <summary>
        /// Displays the search result for books
        /// </summary>
        /// <param name="listOfBooks"></param>
        public static void DisplayBookList(List<Books> listOfBooks)
        {
            Console.WriteLine();
            Console.WriteLine("Search result for books: ");
            foreach (var book in listOfBooks)
            {
                Console.WriteLine($"{book.ID}.{book.Title} - By: {book.Author}");
            }
        }

        /// <summary>
        /// Displays all available books
        /// </summary>
        /// <param name="listOfBooks"></param>
        public static void DisplayAvailableBooks(List<Books> listOfBooks)
        {
            Console.WriteLine();
            Console.WriteLine("Result for available books: ");
            foreach (var book in listOfBooks)
            {
                Console.WriteLine($"{book.ID}.{book.Title} - By: {book.Author}\n Amount: {book.Amount}");
            }
        }

        /// <summary>
        /// Displays the search result of categories
        /// </summary>
        /// <param name="listOfCategories"></param>
        public static void DisplayCategoryList(List<BookCategory> listOfCategories)
        {
            Console.WriteLine();
            Console.WriteLine("Result for categories: ");
            foreach (var category in listOfCategories)
            {
                Console.WriteLine($"{category.ID}.{category.Genere}");
            }
        }

        /// <summary>
        /// Displays details for a book
        /// </summary>
        /// <param name="details"></param>
        public static void DisplayDetails(string details)
        {
            Console.WriteLine();
            Console.WriteLine(details);
        }

        /// <summary>
        /// Displays information needed to search for an item
        /// </summary>
        public static void SearchPage()
        {
            Console.WriteLine();
            Console.WriteLine("Enter search word here: ");
        }
    }
}
