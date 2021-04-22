using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Helpers;

namespace WebshopFrontend.Controller
{
    class UpdateCategoryController
    {
        //Fetch the API
        public static WebShop.WebShopApi api = new WebShop.WebShopApi();

        /// <summary>
        /// Controller of the API method Update category
        /// Lets the admin update the information about a category with help of inputs in the console
        /// If theres a bad input, a error message will be displayed
        /// </summary>
        public static void UpdateCategoryLogic()
        {
            int categoryId;
            string categoryName;
            Console.WriteLine("╔═════════════════════════════════════╗");
            Console.WriteLine("║   Enter desired category id number  ║");
            Console.WriteLine("║ ────────────────╬───────────────    ║");
            Console.WriteLine("║  To select which category to update ║");
            Console.WriteLine("╚═════════════════════════════════════╝");
            if (Int32.TryParse(Console.ReadLine(), out categoryId))
            {
                Console.Clear();
                Console.WriteLine("╔═════════════════════════════════════╗");
                Console.WriteLine("║  Type the new name of the category  ║");
                Console.WriteLine("║  ───────────────╬─────────────────  ║");
                Console.WriteLine("║            To update it             ║");
                Console.WriteLine("╚═════════════════════════════════════╝");
                categoryName = Console.ReadLine();
                api.UpdateCategory(LoginController.userId, categoryId, categoryName);
            }
            else
            {
                WrongInput.InputErrorMessage();
            }
        }
    }
}
