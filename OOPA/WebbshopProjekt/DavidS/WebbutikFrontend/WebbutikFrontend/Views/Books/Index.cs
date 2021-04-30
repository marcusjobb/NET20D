using System;
using WebbutikFrontend.Views.Shared;

namespace WebbutikFrontend.Views.BookMenu
{
    public static class Index
    {
        /// <summary>
        /// The index view for the book menu.
        /// </summary>
        public static void View()
        {
            Console.ForegroundColor = Layout.BannerInputColor;
            Console.WriteLine(
                "\n\t   ___            __     __  ___" +
                "\n\t  / _ )___  ___  / /__  /  |/  /__ ___  __ __" +
                "\n\t / _  / _ \\/ _ \\/  '_/ / /|_/ / -_) _ \\/ // /" +
                "\n\t/____/\\___/\\___/_/\\_\\ /_/  /_/\\__/_//_/\\_,_/");
            Console.ForegroundColor = Layout.OriginalForegroundColor;
            Console.WriteLine(
                "\n\tMake a choice:" +
                "\n\t1. Add a book" +
                "\n\t2. Search for a book" +
                "\n\t3. Go back");
        }
    }
}
