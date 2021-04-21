using System;

namespace BookWebShopFrontend.View.Categories
{
    public static class AdminCategoryMenu
    {
        /// <summary>
        /// Class for the view of AdminCategoryMenu.
        /// </summary>
        public static void View()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("| Admin Category Menu                                    |");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("1. Add Category");
            Console.WriteLine("2. Add Book To Category");
            Console.WriteLine("3. Update Category");
            Console.WriteLine("4. Delete Category");
            Console.WriteLine("0. Back");
        }
    }
}