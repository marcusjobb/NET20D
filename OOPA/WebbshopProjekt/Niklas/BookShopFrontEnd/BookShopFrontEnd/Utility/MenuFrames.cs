using System;

namespace BookShopFrontEnd.Utility
{
    /// <summary>
    /// Prints out a dynamic menu frame.
    /// </summary>
    public static class MenuFrames
    {
        /// <summary>
        /// Dynamic menu frame.
        /// </summary>
        /// <param name="menuAlternatives">Array of alternatives for th user.</param>
        /// <param name="alternatives">number of alternatives for the user.</param>
        public static void Frame(string[] menuAlternatives)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("====================================================================");
            Console.WriteLine("|| Quit application = press 'q'.");
            Console.WriteLine("|| Back to main menu = press 'b'.");
            Console.WriteLine("||");
            for (int i = 0; i < menuAlternatives.Length; i++)
            {
                Console.WriteLine($"|| {i+1}: {menuAlternatives[i]}");
            }
            Console.WriteLine("====================================================================\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Dynamic menu frame with no numbers.
        /// </summary>
        /// <param name="menuAlternatives">Array of alternatives for th user.</param>
        /// <param name="alternatives">number of alternatives for the user.</param>
        public static void FrameNoNumbers(string[] menuAlternatives)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("====================================================================");
            Console.WriteLine("|| Quit application = press 'q'.");
            Console.WriteLine("|| Back to main menu = press 'b'.");
            Console.WriteLine("||");
            for (int i = 0; i < menuAlternatives.Length; i++)
            {
                Console.WriteLine($"|| {menuAlternatives[i]}");
            }
            Console.WriteLine("====================================================================\n");
            Console.ResetColor();
        }
    }
}
