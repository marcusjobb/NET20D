using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Helpers;

namespace WebshopFrontend.Controller
{
    class AddNewCategoryController
    {
        public static WebShop.WebShopApi api = new WebShop.WebShopApi();
        /// <summary>
        /// Method that lets the admin to create a new book category
        /// </summary>
        public static void AddNewCategoryLogic()
        {
            string categoryName;
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║ Enter desired name for your new category ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            categoryName = Console.ReadLine();
            api.AddCategory(LoginController.userId, categoryName);
        }
    }
}
