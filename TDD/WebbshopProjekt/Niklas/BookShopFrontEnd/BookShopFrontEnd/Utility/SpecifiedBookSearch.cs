using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WebbShopAPI;
using WebbShopAPI.Models;

namespace BookShopFrontEnd.Utility
{
    /// <summary>
    /// When choosing a book you get to search by author, category or all books.
    /// </summary>
    public class SpecifiedBookSearch
    {
        /// <summary>
        /// When choosing a book you get to search by author, category or all books.
        /// </summary>
        /// <returns></returns>
        public static List<Book> Alternatives()
        {
            var alternativs = new string[] { "Search book by author", "Search book by category", "All available books" };
            MenuFrames.Frame(alternativs);
            var inputNumber = Helper.GetInputForOptions(1, 3);
            if (inputNumber == 1) { return SearchBookByAuthor(); }
            else if (inputNumber == 2) { return SearchBookByCategory(); }
            else { return AllBooks(); }
        }

        /// <summary>
        /// Searches for all available books in database.
        /// </summary>
        private static List<Book> AllBooks()
        {
            Console.Clear();
            Logotypes.BookStore();
            var books = new WebShopAPI().GetAvailableBooks().ToList();
            Console.WriteLine("Available books:");
            Console.WriteLine("========================================");
            ExtractedView.DisplayBooks(books);
            return books;
        }

        /// <summary>
        /// Searches for books by chosen author.
        /// </summary>
        /// <returns>Book.</returns>
        private static List<Book> SearchBookByAuthor()
        {
            Console.Clear();
            Logotypes.BookStore();
            var authors = WebShopAPI.GetAuthors().ToList();
            Console.WriteLine("Available authors:");
            Console.WriteLine("========================================");
            int index = 1;
            foreach (var author in authors)
            {
                Console.WriteLine($"{index}: {author.FullName}");
                index++;
            }

            var inputNumber = Helper.GetInputForOptions(1, authors.Count);
            int nr = inputNumber - 1;
            Console.WriteLine($"Searching for books by: {authors[nr].FullName}..");
            Thread.Sleep(1500);
            Console.Clear();
            var booksByAuthor = WebShopAPI.GetBooksByAuthor(authors[nr].FirstName, authors[nr].Surname).ToList();
            Console.WriteLine($"Books by {authors[nr].FullName}");
            Console.WriteLine("========================================");
            ExtractedView.DisplayBooks(booksByAuthor);
            return booksByAuthor;
        }

        /// <summary>
        /// Searches for books in a chosen category.
        /// </summary>
        /// <returns>List<Book>.</returns>
        private static List<Book> SearchBookByCategory()
        {
            Console.Clear();
            Logotypes.BookStore();
            var categories = WebShopAPI.GetCategories().ToList();
            Console.WriteLine("Available categories:");
            Console.WriteLine("========================================");
            int index = 1;
            
            foreach (var category in categories)
            {
                Console.WriteLine($"{index}: {category.Title}");
                index++;
            }

            var inputNumber = Helper.GetInputForOptions(1, categories.Count);
            int nr = inputNumber - 1;
            Console.WriteLine($"Searching for books by: {categories[nr].Title}..");
            Console.WriteLine("========================================");
            Thread.Sleep(1500);
            Console.Clear();
            var booksByCategory = WebShopAPI.GetBooksByCategory(categories[nr].Title).ToList();
            Console.WriteLine($"Books in {categories[nr].Title}");
            ExtractedView.DisplayBooks(booksByCategory);
            return booksByCategory;
        }
    }
}
