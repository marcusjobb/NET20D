using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using WebshopFrontend.Helpers;

namespace WebshopFrontend.Controller
{
    class GetCategoryController
    {
        public static WebShop.WebShopApi api = new WebShop.WebShopApi();
        public static int wrongCat = 0;

        /// <summary>
        /// Method that takes in the Id of a category and then displays the book from that category
        /// </summary>
        public static void GetCategoryLogic()
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
                api.GetCategory(categoryId);

            }
            else
            {
                WrongInput.InputErrorMessage();
            }
        }
    }
}
