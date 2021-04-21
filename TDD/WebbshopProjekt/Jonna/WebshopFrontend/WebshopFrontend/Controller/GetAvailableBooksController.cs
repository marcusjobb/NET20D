using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Helpers;

namespace WebshopFrontend.Controller
{
    class GetAvailableBooksController
    {
        public static WebShop.WebShopApi api = new WebShop.WebShopApi();
        public static int wrongCat = 0;
        /// <summary>
        /// Displays books that are currently in stock in a certain category
        /// </summary>
        public static void GetAvailableBooksLogic()
        {
            int categoryId;
            Console.WriteLine("╔════════════════════════════════╗");
            Console.WriteLine("║  Enter the id of the Category  ║");
            Console.WriteLine("║  ──────────────╬─────────────  ║");
            Console.WriteLine("║    That you want to inspect    ║");
            Console.WriteLine("╚════════════════════════════════╝");
            if (Int32.TryParse(Console.ReadLine(), out categoryId))
            {
                Console.Clear();
                api.GetAvailableBooks(categoryId);
            }
            else
            {
                wrongCat = 1;
                WrongInput.InputErrorMessage();
            }
        }
    }
}
