using Inlämning2WebbShop.Models;
using Inlämning3.Helpers;
using System;
using System.Collections.Generic;

namespace Inlämning3.Views.User
{
    public class Books
    {
        /// <summary>
        /// takes a list of books and prints them and lets the user choose. Returns the users choice or -1 if the list is empty.
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        public static int PrintBooks(List<Book> books)
        {
            Console.Clear();
            if (books.Count > 0)
            {
                Console.WriteLine("Books found:");
                int counter = 1;
                foreach (var book in books)
                {
                    Console.WriteLine($"[{counter}] {book}");
                    counter++;
                }
                Console.Write("Select the number next to a book to buy it : ");
                return Helper.GetUserChoiceNumber() - 1;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Confrims with the user if the user wants to but the book. Returns the user choice in text.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public static string BuyBook(Book book)
        {
            Console.Clear();
            Console.WriteLine(book);
            Console.Write("Do you want to buy this book? Y/N : ");
            return Helper.GetUserChoiceText().ToUpper();
        }
    }
}