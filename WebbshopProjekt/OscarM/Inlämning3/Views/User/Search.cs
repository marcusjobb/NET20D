using Inlämning2WebbShop.Models;
using System;
using System.Collections.Generic;

namespace Inlämning3.Views.User
{
    internal class Search
    {
        /// <summary>
        /// Displays search menu
        /// </summary>
        /// <returns></returns>
        public static int DisplaySearchMenu()
        {
            Console.WriteLine(@"     _______. _______     ___      .______        ______  __    __  ");
            Console.WriteLine(@"    /       ||   ____|   /   \     |   _  \      /      ||  |  |  | ");
            Console.WriteLine(@"   |   (----`|  |__     /  ^  \    |  |_)  |    |  ,----'|  |__|  | ");
            Console.WriteLine(@"    \   \    |   __|   /  /_\  \   |      /     |  |     |   __   | ");
            Console.WriteLine(@".----)   |   |  |____ /  _____  \  |  |\  \----.|  `----.|  |  |  | ");
            Console.WriteLine(@"|_______/    |_______/__/     \__\ | _| `._____| \______||__|  |__| ");
            Console.WriteLine("[1] Search books");
            Console.WriteLine("[2] Search books by categories");
            Console.WriteLine("[3] See all categories");
            Console.WriteLine("[4] Back to main menu");
            return Helpers.Helper.GetUserChoiceNumber();
        }

        /// <summary>
        /// ask user for input to search on books and returns the users input.
        /// </summary>
        /// <returns></returns>
        public static string SearchBooks()
        {
            Console.Write("Enter keyword to search on booktitle or author: ");
            return Helpers.Helper.GetUserChoiceText();
        }

        /// <summary>
        /// ask user for input to search on categories and returns the users input.
        /// </summary>
        /// <returns></returns>
        public static string SearchCategories()
        {
            Console.Write("Enter keyword to search on book category: ");
            return Helpers.Helper.GetUserChoiceText();
        }

        /// <summary>
        /// takes a list of bookCategories and displays them, then lets the user choose one of the categories. Returns the choice or -1 if the list is empty.
        /// </summary>
        /// <param name="categories"></param>
        /// <returns></returns>
        public static int SeeAllCategories(List<BookCategory> categories)
        {
            if (categories.Count > 0)
            {
                int counter = 1;
                foreach (var category in categories)
                {
                    Console.WriteLine($"[{counter}] {category}");
                    counter++;
                }
                Console.Write("Select the number next to a category to find books in that category : ");
                return Helpers.Helper.GetUserChoiceNumber() - 1;
            }
            return -1;
        }
    }
}