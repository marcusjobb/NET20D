using InlamningDB2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebbshopFront.Views.Admin
{
    class AddBookToCategoryView
    {
        public static string AskForBookName()
        {
            Console.Write("Skriv in bokens titel: ");
            return Console.ReadLine();
        }
        public static string AskForCategoryName()
        {
            Console.Write("Skriv in kategorins namn: ");
            return Console.ReadLine();
        }
    }
}
