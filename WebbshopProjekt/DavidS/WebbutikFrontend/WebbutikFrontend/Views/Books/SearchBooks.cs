using System;
using WebbutikFrontend.Views.Shared;

namespace WebbutikFrontend.Views.Books
{
    public static class SearchBooks
    {
        /// <summary>
        /// The index view for search books.
        /// </summary>
        public static void View()
        {
            Console.ForegroundColor = Layout.BannerInputColor;
            Console.WriteLine(
                "\n\t   ____                 __     ___            __" +
                "\n\t  / __/__ ___ _________/ /    / _ )___  ___  / /__ ___" +
                "\n\t _\\ \\/ -_) _ `/ __/ __/ _ \\  / _  / _ \\/ _ \\/  '_/(_-<" +
                "\n\t/___/\\__/\\_,_/_/  \\__/_//_/ /____/\\___/\\___/_/\\_\\/___/");
            Console.ForegroundColor = Layout.OriginalForegroundColor;
            Console.WriteLine(
                "\n\tMake a choice:" +
                "\n\t1. Search by title" +
                "\n\t2. Search by author" +
                "\n\t3. Search by category" +
                "\n\t4. Free search" +
                "\n\t5. Go back");
        }

    }
}
