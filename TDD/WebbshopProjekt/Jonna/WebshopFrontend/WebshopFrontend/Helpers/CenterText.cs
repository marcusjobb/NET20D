using System;
using System.Collections.Generic;
using System.Text;

namespace WebshopFrontend.Helpers
{
    class CenterText
    {
        /// <summary>
        /// Cool method that will print out the text in the absolute center of the screen
        /// Code taken from --->
        /// https://stackoverflow.com/questions/61378701/i-want-to-center-the-text-in-console-both-horizontally-and-vertically-using-c-sh
        /// </summary>
        /// <param name="lines"></param>
        public static void PrintLinesInCenter(params string[] lines)
        {
            int verticalStart = (Console.WindowHeight - lines.Length) / 2; // work out where to start printing the lines
            int verticalPosition = verticalStart;
            foreach (var line in lines)
            {
                // work out where to start printing the line text horizontally
                int horizontalStart = (Console.WindowWidth - line.Length) / 2;
                // set the start position for this line of text
                Console.SetCursorPosition(horizontalStart, verticalPosition);
                // write the text
                Console.Write(line);
                // move to the next line
                ++verticalPosition;
            }
        }
    }
}
