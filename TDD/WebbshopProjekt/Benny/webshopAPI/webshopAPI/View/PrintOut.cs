using System;

namespace webshopAPI.View
{
    public static class PrintOut
    {
        /// <summary>
        /// Prints out the text in red color
        /// </summary>
        /// <param name="text">Send in the text that you want to print</param>
        public static void Red(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Prints out the text in darkred color
        /// </summary>
        /// <param name="text">Send in the text that you want to print</param>
        public static void DarkRed(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}