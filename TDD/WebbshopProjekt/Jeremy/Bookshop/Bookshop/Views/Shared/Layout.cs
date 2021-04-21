using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Views.Shared
{
    class Layout
    {
        /// <summary>
        /// Prints the layout for the bookshop.
        /// </summary>
        public void PrintLayout()
        {
            Console.CursorVisible = false;

            // Header
            Console.WriteLine();
            Console.Write(" ╔");
            for (int i = 0; i < 101; i++)
            {
                Console.Write("═");
            }
            Console.WriteLine("╗");
            Console.WriteLine(@" ║                               ___            _        _                                             ║
 ║                              | _ ) ___  ___ | |__ ___| |_   ___  _ __                               ║
 ║                              | _ \/ _ \/ _ \| / /(_-<| ' \ / _ \| '_ \                              ║
 ║                              |___/\___/\___/|_\_\/__/|_||_|\___/| .__/                              ║
 ║                                                                 |_|                                 ║");
            Console.Write(" ╚");
            for (int i = 0; i < 101; i++)
            {
                Console.Write("═");
            }
            Console.WriteLine("╝");


            // Menu
            Console.Write(" ┌");
            for (int i = 0; i < 20; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine("┐");
            for (int i = 0; i < 19; i++)
            {
                Console.Write(" │");
                for (int j = 0; j < 20; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("│");
            }
            Console.Write(" └");
            for (int i = 0; i < 20; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine("┘");


            // Main Content
            Console.CursorTop = 8;
            Console.CursorLeft = 23;
            Console.Write(" ┌");
            for (int i = 0; i < 78; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine("┐");
            for (int i = 0; i < 19; i++)
            {
                Console.CursorLeft = 23;
                Console.Write(" │");
                for (int j = 0; j < 78; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("│");
            }
            Console.CursorLeft = 23;
            Console.Write(" └");
            for (int i = 0; i < 78; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine("┘");
        }

        /// <summary>
        /// Clears the menu.
        /// </summary>
        public void ClearMenu()
        {
            Console.SetCursorPosition(3, 9);
            for (int i = 0; i < 19; i++) // Height
            {
                for (int j = 0; j < 19; j++) // Width
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
                Console.CursorLeft = 3;
            }
        }

        /// <summary>
        /// Clears the main content.
        /// </summary>
        public void ClearMainContent()
        {
            Console.SetCursorPosition(25, 9);
            for (int i = 0; i < 19; i++) // Height
            {
                for (int j = 0; j < 78; j++) // Width
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
                Console.CursorLeft = 25;
            }
        }
    }
}
