using System;
using System.Diagnostics;
using Controllers;
using Pages;

namespace Views
{
    internal class ViewConsole
    {
#region Internal Methods

        /// <summary>
        /// Constructor sets some colors and size to the console window
        /// </summary>
        internal ViewConsole()
        {
            try
            {
                Console.SetWindowSize(120, 60); //Only works on windows machines running the console window
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Blue;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("User is not on windows" + ex);
            }
        }

        /// <summary>
        /// Sends parameter input to Console.WriteLine()
        /// </summary>
        /// <param name="msg"></param>
        internal void PrintToConsole(string msg)
        {
            Console.WriteLine(msg);
        }

        /// <summary>
        /// Changes the color of the text in the console window
        /// </summary>
        /// <param name="color"></param>
        internal void ChangeForeGroundColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        /// <summary>
        /// Clears the console window of all text. Makes it blank
        /// </summary>
        internal void ClearConsole()
        {
            Console.Clear();
        }
        
        /// <summary>
        /// Displays a message within a page to the console window
        /// </summary>
        /// <param name="page"></param>
        internal void Display(Page page)
        {
            
            Console.WriteLine(page.Message);
            Console.WriteLine("\nInput e to Exit program");
        }
#endregion
    }
}