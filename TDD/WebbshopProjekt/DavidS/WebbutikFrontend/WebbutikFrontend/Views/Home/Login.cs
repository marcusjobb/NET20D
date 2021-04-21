using System;
using WebbutikFrontend.Views.Shared;

namespace WebbutikFrontend.Views.Home
{
    public static class Login
    {
        /// <summary>
        /// The login view for the home menu.
        /// </summary>
        public static void View()
        {
            Console.Clear();
            Console.ForegroundColor = Layout.BannerInputColor;
            Console.WriteLine(
                "\n\t   __             _" +
                "\n\t  / /  ___  ___ _(_)__" +
                "\n\t / /__/ _ \\/ _ `/ / _ \\" +
                "\n\t/____/\\___/\\_, /_/_//_/" +
                "\n\t          /___/\n");
            Console.ForegroundColor = Layout.OriginalForegroundColor;
        }
    }
}
