using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Controller;

namespace WebshopFrontend.Views
{
    class SearchCategoryByName
    {
        /// <summary>
        /// View of the Search category by name method
        /// </summary>
        public static void DisplayCategoryResult()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║   Search for categories by keyword   ║");
            Console.WriteLine("║ ──────────────────╬───────────────── ║");
            Console.WriteLine("║     Example, searching for 'ror'     ║");
            Console.WriteLine("║    would display category 'horror'   ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
            SearchCategoryByNameController.SearchCategoryByNameLogic();
            Console.ReadKey();
        }

    }
}
