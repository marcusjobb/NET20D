using System;
using WebbutikFrontend.Views.Shared;

namespace WebbutikFrontend.Views.SoldBooksMenu
{
    public static class Index
    {
        /// <summary>
        /// The index view for the sold books menu.
        /// </summary>
        public static void View()
        {
            Console.ForegroundColor = Layout.BannerInputColor;
            Console.WriteLine(
                "\n\t   ____     __   __  ___            __          __  ___" +
                "\n\t  / __/__  / /__/ / / _ )___  ___  / /__ ___   /  |/  /__ ___  __ __" +
                "\n\t _\\ \\/ _ \\/ / _  / / _  / _ \\/ _ \\/  '_/(_-<  / /|_/ / -_) _ \\/ // /" +
                "\n\t/___/\\___/_/\\_,_/ /____/\\___/\\___/_/\\_\\/___/ /_/  /_/\\__/_//_/\\_,_/");
            Console.ForegroundColor = Layout.OriginalForegroundColor;
            Console.WriteLine(
                "\n\tMake a choice:" +
                "\n\t1. See all the sold books" +
                "\n\t2. See money earned" +
                "\n\t3. See who is the best customer" +
                "\n\t4. Go back");
        }
    }
}
