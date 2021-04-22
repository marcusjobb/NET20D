using System;

namespace Webbshop.Views
{
    class Messages
    {
        /// <summary>
        /// Sets color to a error-message that is sent
        /// in as input.
        /// </summary>
        /// <param name="input">Text sent in to be colored red</param>
        public static void ErrorMessage(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(input);
            Console.ResetColor();
        }

        /// <summary>
        /// Sets color to a success-message that is
        /// sent in as input.
        /// </summary>
        /// <param name="input">Text sent in to be colored green</param>
        public static void SuccessMessage(string input)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(input);
            Console.ResetColor();
        }

        /// <summary>
        /// Method to set color to text, 
        /// where both text and ConsoleColor
        /// as input.
        /// </summary>
        /// <param name="input">Text sent in to be colored</param>
        /// <param name="choice">The color selected to color the text.</param>
        public static void ColorText(string input, ConsoleColor choice)
        {
            Console.ForegroundColor = choice;
            Console.WriteLine(input);
            Console.ResetColor();
        }
    }
}
