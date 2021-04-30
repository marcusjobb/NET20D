using System;
using WebbutikFrontend.Views.Shared;

namespace WebbutikFrontend.Views.Home
{
    public static class Register
    {
        /// <summary>
        /// The register view for the home menu.
        /// </summary>
        public static void View()
        {
            Console.Clear();
            Console.ForegroundColor = Layout.BannerInputColor;
            Console.WriteLine(
                "\n\t   ___           _     __\n" +
                "\t  / _ \\___ ___ _(_)__ / /____ ____\n" +
                "\t / , _/ -_) _ `/ (_-</ __/ -_) __/\n" +
                "\t/_/|_|\\__/\\_, /_/___/\\__/\\__/_/\n" +
                "\t         /___/\n");
            Console.ForegroundColor = Layout.OriginalForegroundColor;
        }
    }
}
