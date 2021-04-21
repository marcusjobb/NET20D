using System;
using System.Collections.Generic;
using WebbShop.Models;
using WebbutikFrontend.Views.Shared;

namespace WebbutikFrontend.Views.SoldBooksMenu
{
    public static class ShowSoldBooks
    {
        /// <summary>
        /// The show sold books view for the sold books menu.
        /// </summary>
        public static void View(List<SoldBook> books)
        {
            Console.WriteLine();
            var ctr = 1;
            foreach (var book in books)
            {
                Console.Write($"\t{ctr++}. {book.Title}, {book.Author}, ");
                if (book.Category != null)
                {
                    Console.Write(book.Category.Name);
                }
                else
                {
                    Console.ForegroundColor = Layout.ErrorColor;
                    Console.Write("unknown");
                    Console.ForegroundColor = Layout.OriginalForegroundColor;
                }

                Console.WriteLine($", {book.Price} kr. " +
                    $"Purchased by: {book.User.Name}");
            }
        }
    }
}
