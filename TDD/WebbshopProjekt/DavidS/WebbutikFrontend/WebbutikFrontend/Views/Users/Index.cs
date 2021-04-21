using System;
using WebbutikFrontend.Views.Shared;

namespace WebbutikFrontend.Views.UserMenu
{
    public static class Index
    {
        /// <summary>
        /// The index view for the user menu.
        /// </summary>
        public static void View()
        {
            Console.ForegroundColor = Layout.BannerInputColor;
            Console.WriteLine(
                "\n\t  __  __              __  ___" +
                "\n\t / / / /__ ___ ____  /  |/  /__ ___  __ __" +
                "\n\t/ /_/ (_-</ -_) __/ / /|_/ / -_) _ \\/ // /" +
                "\n\t\\____/___/\\__/_/   /_/  /_/\\__/_//_/\\_,_/");
            Console.ForegroundColor = Layout.OriginalForegroundColor;
            Console.WriteLine(
                "\n\tMake a choice:" +
                "\n\t1. Add a user" +
                "\n\t2. Find a user" +
                "\n\t3. List all users" +
                "\n\t4. Go back");
        }
    }
}