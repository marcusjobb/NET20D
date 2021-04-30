using InlamningDB2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebbshopFront.Views.Admin
{
    class UpdateCategoryView
    {
        public static string UpdateCategories()
        {
            Console.Write("Vad ska den nya kategorin heta? : ");
            string categoriName = Console.ReadLine();

            return categoriName;
        }
        public static int UpdateCategoryId()
        {
            Console.WriteLine("Villken kategori vill du updatera? : ");
            Int32.TryParse(Console.ReadLine(), out int categoryId);

            return categoryId;
        }
    }
}

