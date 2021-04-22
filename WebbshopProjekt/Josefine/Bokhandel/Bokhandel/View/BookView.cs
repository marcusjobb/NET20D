using System;
using System.Collections.Generic;
using WebbShopAPI.Models;

namespace Bokhandel.View
{
    public class BookView
    {
        /// <summary>
        /// Ask for search word
        /// </summary>
        public static void EnterSearch()
        {
            Console.WriteLine("Enter your search");
        }
        public static void EnterValidNumber()
        {
            Console.WriteLine("You have to enter a valid number;");
        }

        /// <summary>
        /// Ask if user want to see more
        /// </summary>
        public static void SeeMore()
        {
            Console.WriteLine("Enter number to see more or x to go back");
        }

        /// <summary>
        /// Show details about one book
        /// </summary>
        /// <param name="book"></param>
        public static void ShowBook(Book book)
        {
            if (book != null)
            {
                Console.WriteLine($"Title: {book.Title}\nAuthor: {book.Author}");
                if (book.BookCategories != null)
                {
                    Console.WriteLine($"Category: {book.BookCategories.Name}");
                }
                Console.WriteLine($"Price: {book.Price}\nAvailable ex: {book.Amount}");
            }
        }

        /// <summary>
        /// Show list of books
        /// </summary>
        /// <param name="books"></param>
        public static void ShowBooks(List<Book> books)
        {
            int index = 1;
            foreach (var book in books)
            {
                Console.WriteLine($"[{index}] Title: {book.Title} Author: {book.Author}\n");
                index++;
            }
        }

        /// <summary>
        /// Show list of categories
        /// </summary>
        /// <param name="categories"></param>
        public static void ShowCathegorys(List<BookCategory> categories)
        {
            int index = 1;
            foreach (var category in categories)
            {
                Console.WriteLine($"[{index}] {category.Name}");
                index++;
            }
        }
    }
}