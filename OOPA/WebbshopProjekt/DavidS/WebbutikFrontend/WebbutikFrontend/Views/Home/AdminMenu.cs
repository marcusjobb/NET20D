using System;
using WebbutikFrontend.Views.Shared;

namespace WebbutikFrontend.Views.Home
{
    public static class AdminMenu
    {
        /// <summary>
        /// The index view for the admin menu.
        /// </summary>
        public static void View()
        {
            Console.ForegroundColor = Layout.BannerInputColor;
            Console.WriteLine(
                "\n\t   ___     __      _        __  ___" +
                "\n\t  / _ |___/ /_ _  (_)__    /  |/  /__ ___  __ __" +
                "\n\t / __ / _  /  ' \\/ / _ \\  / /|_/ / -_) _ \\/ // /" +
                "\n\t/_/ |_\\_,_/_/_/_/_/_//_/ /_/  /_/\\__/_//_/\\_,_/");
            Console.ForegroundColor = Layout.OriginalForegroundColor;
            Console.WriteLine(
                "\n\tMake a choice:" +
                "\n\t1. Book menu" +
                "\n\t2. Category menu" +
                "\n\t3. User menu" +
                "\n\t4. Sold books menu" +
                "\n\t5. Logout");
        }
    }
}
