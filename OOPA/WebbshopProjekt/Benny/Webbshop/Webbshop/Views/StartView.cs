using System;
using System.Collections.Generic;

namespace Webbshop.Views
{
    internal static class StartView
    {
        /// <summary>
        /// List with menuchoices
        /// </summary>
        private static readonly List<string> menuOptions = new List<string> { "Logga in", "Registrera", "Avsluta" };
        /// <summary>
        /// Counter for menu
        /// </summary>
        private static int choice = 1;

        /// <summary>
        /// Print the first menu the user sees when starting the program
        /// </summary>
        public static void Print()
        {
            Console.WriteLine("Bookhandlar´n\n");
            foreach (var menuOption in menuOptions)
            {
                if (menuOption != "Avsluta")
                {
                    Console.WriteLine($"\t{choice}. {menuOption}");
                    choice++;
                    continue;
                }
                Console.WriteLine($"\tQ. {menuOption}");
                choice++;
            }
            choice = 1;
        }
    }
}