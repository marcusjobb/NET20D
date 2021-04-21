using System;
using WebbutikFrontend.Views.Shared;

namespace WebbutikFrontend.Views.UserMenu
{
    public static class AddUser
    {
        /// <summary>
        /// The add user view for the user menu.
        /// </summary>
        public static void View()
        {
            Console.Clear();
            Console.ForegroundColor = Layout.BannerInputColor;
            Console.WriteLine(
                "\n\t   ___     __   __  __  __" +
                "\n\t  / _ |___/ /__/ / / / / /__ ___ ____" +
                "\n\t / __ / _  / _  / / /_/ (_-</ -_) __/" +
                "\n\t/_/ |_\\_,_/\\_,_/  \\____/___/\\__/_/\n");
            Console.ForegroundColor = Layout.OriginalForegroundColor;
        }
    }
}
