using System;
using System.Collections.Generic;
using System.Text;

namespace WebbshopFront.Views.Admin
{
   public static class DeleteCategoryView
    {
        public static int DeleteCategories()
        {

            Console.Write("Ange ID på kategori ID du vill radera : ");
            Int32.TryParse(Console.ReadLine(), out int categoryId);

            return categoryId;

        }
    }
}
