using System;
using WebbutikFrontend.Views.Shared;

namespace WebbutikFrontend.Views.CategoryMenu
{
    public static class Index
    {
        /// <summary>
        /// The index view for the category menu.
        /// </summary>
        public static void View()
        {
            Console.ForegroundColor = Layout.BannerInputColor;
            Console.WriteLine(
                "\n\t  _____     __                           __  ___" +
                "\n\t / ___/__ _/ /____ ___ ____  ______ __  /  |/  /__ ___  __ __" +
                "\n\t/ /__/ _ `/ __/ -_) _ `/ _ \\/ __/ // / / /|_/ / -_) _ \\/ // /" +
                "\n\t\\___/\\_,_/\\__/\\__/\\_, /\\___/_/  \\_, / /_/  /_/\\__/_//_/\\_,_/" +
                "\n\t                 /___/         /___/");
            Console.ForegroundColor = Layout.OriginalForegroundColor;
            Console.WriteLine(
                "\n\tMake a choice:" +
                "\n\t1. Add a book category" +
                "\n\t2. Search a category" +
                "\n\t3. List all categories" +
                "\n\t4. Go back");
        }
    }
}
