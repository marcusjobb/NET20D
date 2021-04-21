using System;
using WebbShop.Models;
using WebbutikFrontend.Views.Shared;

namespace WebbutikFrontend.Views.Books
{
    public static class SelectedBook
    {
        /// <summary>
        /// The index view for the selected book.
        /// </summary>
        public static void View(Book book)
        {
            Console.ForegroundColor = Layout.BannerInputColor;
            Console.WriteLine(
                "\t   ___            __\n" +
                "\t  / _ )___  ___  / /__\n" +
                "\t / _  / _ \\/ _ \\/  '_/\n" +
                "\t/____/\\___/\\___/_/\\_\\");
            Console.ForegroundColor = Layout.OriginalForegroundColor;
            Display.BookDetails(book, "\n\t");
            Console.WriteLine(
                "\n\tWhat do you want to do?\n" +
                "\t1. Set the amount\n" +
                "\t2. Add book to a category\n" +
                "\t3. Update book\n" +
                "\t4. Delete book\n" +
                "\t5. Go back");
        }
    }
}
