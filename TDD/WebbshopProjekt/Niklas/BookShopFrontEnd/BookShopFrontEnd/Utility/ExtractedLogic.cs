using BookShopFrontEnd.Controllers;
using BookShopFrontEnd.Views;
using System;
using System.Collections.Generic;
using WebbShopAPI.Models;

namespace BookShopFrontEnd.Utility
{
    /// <summary>
    /// Some extracted logic that is repeated during coding.
    /// </summary>
    public class ExtractedLogic
    {
        /// <summary>
        /// Searches for books with no category to them.
        /// </summary>
        /// <param name="allBooks">IEnumerable<Book>.</param>
        /// <returns>IEnumerable<Book>.</returns>
        public static IEnumerable<Book> FindBooksWithNoCategory(IEnumerable<Book> allBooks)
        {
            var booksWithNoCategory = new List<Book>();
            foreach (var book in allBooks)
            {
                if (book.Categories == null) { booksWithNoCategory.Add(book); }
            }
            return booksWithNoCategory;
        }

        /// <summary>
        /// Ask user for input.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>User input as int.</returns>
        public static int GetUserInput(List<Book> list)
        {
            Console.Write("\nBook number: ");
            int number = Helper.GetInputForOptions(1, list.Count);
            return number - 1;
        }

        /// <summary>
        /// Ask user for input.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>User input as int.</returns>
        public static int GetUserInput(List<Category> list)
        {
            int number = Helper.GetInputForOptions(1, list.Count);
            return number - 1;
        }

        /// <summary>
        /// Ask user for input.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>User input as int.</returns>
        public static int GetUserInput(List<User> list)
        {
            Console.Write("\nUser number: ");
            int number = Helper.GetInputForOptions(1, list.Count);
            return number - 1;
        }

        /// <summary>
        /// Ask user for input.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>User input as int.</returns>
        public static int GetUserInput(List<Author> list)
        {
            Console.Write("\nAuthor number: ");
            int number = Helper.GetInputForOptions(1, list.Count);
            return number - 1;
        }
    }
}
