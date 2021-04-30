using System;
using WebbShop.Models;
using WebbutikFrontend.Views.Shared;

namespace WebbutikFrontend.Views.SelectedCategory
{
    public static class SelectedCategory
    {
        /// <summary>
        /// The index view for the selected category.
        /// </summary>
        public static void View(BookCategory category)
        {
            Console.ForegroundColor = Layout.BannerInputColor;
            Console.WriteLine(
                "\n\t  _____     __" +
                "\n\t / ___/__ _/ /____ ___ ____  ______ __" +
                "\n\t/ /__/ _ `/ __/ -_) _ `/ _ \\/ __/ // /" +
                "\n\t\\___/\\_,_/\\__/\\__/\\_, /\\___/_/  \\_, /" +
                "\n\t                 /___/         /___/");
            Console.ForegroundColor = Layout.OriginalForegroundColor;
            Console.WriteLine(
                $"\t{category.Name}" +
                "\n\n\tWhat do you want to do?" +
                "\n\t1. Add a book to the category" +
                "\n\t2. Update category" +
                "\n\t3. Delete category" +
                "\n\t4. Go back");
        }
    }
}
