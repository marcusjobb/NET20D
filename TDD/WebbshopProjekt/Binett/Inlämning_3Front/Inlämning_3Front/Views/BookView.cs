using Inlämning_API.Models;
using System;
using System.Collections.Generic;

namespace Inlämning_3Front.Views
{
    /// <summary>
    /// Views to the BookController 
    /// </summary>
    public class BookView
    {
        public void BookMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Search book");
            Console.WriteLine("2. Get available books by category");
            Console.WriteLine("3. Get Categories by keyword");
            Console.WriteLine("4. Buy Books");
            Console.WriteLine("E. To go back");
        }

        public void ShowAvalaibleBooks(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                if (book.Amount > 0)
                {
                    Console.Write($"{book.Id}. " +
                 $"[Title: {book.Title}] " +
                 $"[Author: {book.Author}] " +
                 $"[Amount: {book.Amount}] ");
                    if (book.Category != null) Console.WriteLine($"[Category: {book.Category.Name}]");
                }
            }
            Console.WriteLine();
        }

        public void ShowBooks(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                Console.Write($"{book.Id}. " +
                 $"[Title: {book.Title}] " +
                 $"[Author: {book.Author}] " +
                 $"[Amount: {book.Amount}] ");
                if (book.Category != null) Console.WriteLine($"[Category: {book.Category.Name}]");
            }
            Console.WriteLine();
        }

        public void ShowCategory(IEnumerable<BookCategories> categories)
        {
            Console.Clear();
            foreach (var cat in categories)
            {
                Console.WriteLine($"{cat.Id}. {cat.Name}");
            }
        }

        public void SearchforTitleOrAuthor() => Console.WriteLine("1. Search book by Title: \n2. Search book by Author: ");

        public void ChooseBookById() => Console.WriteLine("Choose a book by id");

        public void SearchBuyBooks() => Console.WriteLine("Search for a book you wanna buy");

        public void SearchFor() => Console.Write("Enter keyword: ");
    }
}