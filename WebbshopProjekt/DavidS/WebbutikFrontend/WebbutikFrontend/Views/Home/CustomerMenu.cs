using System;
using WebbutikFrontend.Views.Shared;

namespace WebbutikFrontend.Views.Home
{
    public static class CustomerMenu
    {
        /// <summary>
        /// The index view for customer.
        /// </summary>
        public static void View()
        {
            Console.ForegroundColor = Layout.BannerInputColor;
            Console.WriteLine(
                "\n\t  _____         __                       __  ___" +
                "\n\t / ___/_ _____ / /____  __ _  ___ ____  /  |/  /__ ___  __ __" +
                "\n\t/ /__/ // (_-</ __/ _ \\/  ' \\/ -_) __/ / /|_/ / -_) _ \\/ // /" +
                "\n\t\\___/\\_,_/___/\\__/\\___/_/_/_/\\__/_/   /_/  /_/\\__/_//_/\\_,_/");
            Console.ForegroundColor = Layout.OriginalForegroundColor;
            Console.WriteLine(
                "\n\tMake a choice:" +
                "\n\t1. Search a book" +
                "\n\t2. Logout");
        }
    }
}
