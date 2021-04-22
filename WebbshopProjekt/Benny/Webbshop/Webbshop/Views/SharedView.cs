using System;
using System.Collections.Generic;
using System.Threading;
using webshopAPI.Models;

namespace Webbshop.Views
{
    internal static class SharedView
    {
        /// <summary>
        /// Prints out a list with book categories
        /// </summary>
        /// <param name="categories">takes a list with categories</param>
        public static void ListCategories(List<BookCategory> categories)
        {
            if (categories.Count > 0)
            {
                for (int i = 0; i < categories.Count; i++)
                {
                    Console.WriteLine($"\t{i + 1}. {categories[i]}");
                }
            }
            else
            {
                Console.WriteLine("Inga kategorier funna. Lägg till en kategori först.");
                Thread.Sleep(2500);
            }
        }

        /// <summary>
        /// Prints text in dark grey
        /// </summary>
        /// <param name="text">takes the text to print</param>
        public static void PrintWithDarkGreyText(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Prints green text
        /// </summary>
        /// <param name="text">Takes the text to print</param>
        public static void PrintWithGreenText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Prints red text
        /// </summary>
        /// <param name="text">Takes the text to print</param>
        public static void PrintWithRedText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        /// <summary>
        /// Prints out menu for buying a book
        /// </summary>
        internal static void BuyBook()
        {
            SharedView.PrintWithDarkGreyText("Köp en bok");
            Console.WriteLine("\tLeta reda på boken du vill köpa på följande sätt");
            Console.WriteLine("\t1. Sök efter bok (nyckelord)");
            Console.WriteLine("\t2. Sök efter författare");
            Console.WriteLine("\t3. Sök efter kategori");
            Console.WriteLine("\t4. Lista samtliga kategorier");
            Console.WriteLine("\tX. Backa ett steg");
        }
    }
}