using System;
using WebbutikFrontend.Views.Shared;

namespace WebbutikFrontend.Views.BookMenu
{
    public static class AddBook
    {
        /// <summary>
        /// The add book view for the book menu.
        /// </summary>
        public static void View()
        {
            Console.Clear();
            Console.ForegroundColor = Layout.BannerInputColor;
            Console.WriteLine(
                "\n\t   ___     __   __  ___            __" +
                "\n\t  / _ |___/ /__/ / / _ )___  ___  / /__" +
                "\n\t / __ / _  / _  / / _  / _ \\/ _ \\/  '_/" +
                "\n\t/_/ |_\\_,_/\\_,_/ /____/\\___/\\___/_/\\_\\\n");
            Console.ForegroundColor = Layout.OriginalForegroundColor;
        }
    }
}
