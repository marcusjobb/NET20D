using InlamningDB2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebbshopFront.Views.Admin
{
    class AddCategoryView
    {
        public static string AddCategories()
        {       
            Console.Write("Lägg till en ny kategori: ");
            return Console.ReadLine();
        }
    }
}
