using System;
using WebbShop.Models;
using WebbutikFrontend.Views.Shared;

namespace WebbutikFrontend.Views.Books
{
    public static class Update
    {
        /// <summary>
        /// The index view for the user menu.
        /// </summary>
        public static void View(Book book)
        {
            Console.Clear();
            Console.ForegroundColor = Layout.BannerInputColor;
            Console.WriteLine(
                "\t  __  __        __     __        ___            __\n" +
                "\t / / / /__  ___/ /__ _/ /____   / _ )___  ___  / /__\n" +
                "\t/ /_/ / _ \\/ _  / _ `/ __/ -_) / _  / _ \\/ _ \\/  '_/\n" +
                "\t\\____/ .__/\\_,_/\\_,_/\\__/\\__/ /____/\\___/\\___/_/\\_\\\n" +
                "\t    /_/");
            Console.ForegroundColor = Layout.OriginalForegroundColor;
            Display.BookDetails(book, "\n\t");
            Console.WriteLine("\n\tWhat do you want to change?");
            Console.WriteLine("\t1. The title");
            Console.WriteLine("\t2. The author");
            Console.WriteLine("\t3. The price");
            Console.WriteLine("\t4. Go back");
        }
    }
}
