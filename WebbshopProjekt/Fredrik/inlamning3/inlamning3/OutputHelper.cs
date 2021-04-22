using System;
using System.Collections.Generic;
using WebbShopAPI.Models;

namespace inlamning3
{
    public static class OutputHelper
    {
        /// <summary>
        /// Print a collection of items, such as books, categories, users or more.
        /// </summary>
        /// <typeparam name="T">The type of collection to print</typeparam>
        /// <param name="items">The collection</param>
        public static void PrintArray<T>(IEnumerable<T> items)
        {
            foreach (dynamic item in items)
            {
                if (item is Users)
                    Print($"{((Users)item).Id}. {((Users)item).Name}");
                else if (item is Books)
                    Print($"{item}");
                else if (item is SoldBooks)
                    Print($"{item}");
                else if (item is BookCategory)
                    Print($"{item}");
                else if (item is SoldBooks)
                    Print($"{item}");
            }
        }

        /// <summary>
        /// Print an object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Print(object obj)
        {
            if (obj == null)
                return "No result found (0)";
            Console.WriteLine(obj);
            return obj.ToString();
        }
    }
}
