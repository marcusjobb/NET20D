using System;
using System.Collections.Generic;
using WebbShopEmil.Models;

namespace WebbShopFE.Views
{
    /// <summary>
    /// Methods that prints out info concerning categories.
    /// </summary>
    public static class CategoryView
    {
        /// <summary>
        /// Takes in a list
        /// and print out info about categories.
        /// </summary>
        /// <param name="categories"></param>
        public static void ShowCategory(List<BookCategory> categories)
        {
            foreach (var cat in categories)
            {
                Console.WriteLine($"{cat.Id}. {cat.Name}");
            }
        }
    }
}