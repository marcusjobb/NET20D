using System;

namespace WebbutikFrontend.Views.Shared
{
    public static class Layout
    {
        /// <summary>
        /// The color used to color the background of the console.
        /// </summary>
        public const ConsoleColor BackgroundColor = ConsoleColor.Black;

        /// <summary>
        /// The color used to color the banners and input from the user.
        /// </summary>
        public const ConsoleColor BannerInputColor = ConsoleColor.DarkCyan;

        /// <summary>
        /// The color used to color the error messages.
        /// </summary>
        public const ConsoleColor ErrorColor = ConsoleColor.DarkRed;

        /// <summary>
        /// The color used to color the text.
        /// </summary>
        public const ConsoleColor OriginalForegroundColor = ConsoleColor.White;
        
        /// <summary>
        /// The width of the screen.
        /// </summary>
        public const int ScreenWidth = 80;

        /// <summary>
        /// The time to pause the thread.
        /// </summary>
        public const int SleepTime = 2000;

        /// <summary>
        /// The color used to color the success messages.
        /// </summary>
        public const ConsoleColor SuccessColor = ConsoleColor.DarkGreen;

        /// <summary>
        /// The title of the webb shop.
        /// </summary>
        public const string Title = "WebbShop";

        /// <summary>
        /// Sets layout.
        /// </summary>
        public static void SetUp()
        {
            Console.Title = Title;
            Console.BackgroundColor = BackgroundColor;
            Console.ForegroundColor = BannerInputColor;
        }
    }
}
