using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Helpers;

namespace WebshopFrontend.Controller
{
    class DeleteBookController
    {
        public static WebShop.WebShopApi api = new WebShop.WebShopApi();
        /// <summary>
        /// Method that lets admin remove a book from the database with help from the bookId
        /// </summary>
        public static void DeleteBookLogic()
        {
            int bookId;
            Console.WriteLine("╔═══════════════════════════════════╗");
            Console.WriteLine("║   Enter desired book id number    ║");
            Console.WriteLine("║ ────────────────╬───────────────  ║");
            Console.WriteLine("║  To select which book to delete   ║");
            Console.WriteLine("╚═══════════════════════════════════╝");

            if (Int32.TryParse(Console.ReadLine(), out bookId))
            {
                api.DeleteBook(LoginController.userId, bookId);
            }
            else
            {
                WrongInput.InputErrorMessage();
            }
        }
    }
}
