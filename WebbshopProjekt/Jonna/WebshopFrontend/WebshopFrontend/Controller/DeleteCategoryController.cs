using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Helpers;

namespace WebshopFrontend.Controller
{
    class DeleteCategoryController
    {
        public static WebShop.WebShopApi api = new WebShop.WebShopApi();
        /// <summary>
        /// Method that will let admin remove a category with help of the id of the category
        /// </summary>
        public static void DeleteCategoryLogic()
        {
            int categoryId;
            Console.WriteLine("╔═════════════════════════════════════╗");
            Console.WriteLine("║   Enter desired category id number  ║");
            Console.WriteLine("║ ────────────────╬───────────────    ║");
            Console.WriteLine("║  To select which category to update ║");
            Console.WriteLine("╚═════════════════════════════════════╝");

            if (Int32.TryParse(Console.ReadLine(), out categoryId))
            {
                api.DeleteCategory(LoginController.userId, categoryId);
            }
            else
            {
                WrongInput.InputErrorMessage();
            }
        }
    }
}
