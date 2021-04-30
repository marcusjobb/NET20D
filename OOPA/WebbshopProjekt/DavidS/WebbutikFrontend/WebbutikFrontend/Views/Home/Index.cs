using System;
using WebbutikFrontend.Views.Shared;

namespace WebbutikFrontend.Views.Home
{
    public static class Index
    {
        /// <summary>
        /// The index view for the home menu.
        /// </summary>
        public static void View()
        {
            Console.Clear();
            Console.ForegroundColor = Layout.BannerInputColor;
            Console.WriteLine(
                "\n\t _      __    __   __     ______" +
                "\n\t| | /| / /__ / /  / /    / __/ /  ___  ___" +
                "\n\t| |/ |/ / -_) _ \\/ _ \\  _\\ \\/ _ \\/ _ \\/ _ \\" +
                "\n\t|__/|__/\\__/_.__/_.__/ /___/_//_/\\___/ .__/" +
                "\n\t                                    /_/");
            Console.ForegroundColor = Layout.OriginalForegroundColor;
            Console.WriteLine(
                "\tMake a choice:" +
                "\n\t1. Register as a new user" +
                "\n\t2. Login" +
                "\n\t3. Search books" +
                "\n\t4. Exit program");
        }
    }
}
