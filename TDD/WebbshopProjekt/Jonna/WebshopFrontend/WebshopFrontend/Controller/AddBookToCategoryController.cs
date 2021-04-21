using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Helpers;
using WebshopFrontend.Views;

namespace WebshopFrontend.Controller
{
    class AddBookToCategoryController
    {
        public static WebShop.WebShopApi api = new WebShop.WebShopApi();
        /// <summary>
        /// Controller for API method Add book to category
        /// Which gives inputs for the admin to connect a book to a category
        /// If theres bad input, a error message will be displayed
        /// </summary>
        public static void AddBookToCategoryLogic()
        {

            int bookId;
            int categoryId;

            Console.WriteLine("╔═════════════════════════════════════════════╗");
            Console.WriteLine("║         Enter desired book id number        ║");
            Console.WriteLine("║  ────────────────────╬────────────────────  ║");
            Console.WriteLine("║  To select which book to add to a category  ║");
            Console.WriteLine("╚═════════════════════════════════════════════╝");

            if (Int32.TryParse(Console.ReadLine(), out bookId))
            {
                Console.Clear();
                ShowAllCategories.DisplayCategories();
                Console.WriteLine("╔══════════════════════════════════════╗");
                Console.WriteLine("║   Enter desired category id number   ║");
                Console.WriteLine("║  ─────────────────╬───────────────── ║");
                Console.WriteLine("║   To assign above chosen book to it  ║");
                Console.WriteLine("╚══════════════════════════════════════╝");

                if (Int32.TryParse(Console.ReadLine(), out categoryId))
                {
                    api.AddBookToCategory(LoginController.userId, bookId, categoryId);
                }
                else
                {
                    WrongInput.InputErrorMessage();
                }
            }
            else
            {
                WrongInput.InputErrorMessage();
            }
        }
    }
}
