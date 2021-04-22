using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Helpers;

namespace WebshopFrontend.Controller
{
    class BookInfoController
    {
        public static WebShop.WebShopApi api = new WebShop.WebShopApi();
        /// <summary>
        /// Method that will display the information about a certain book
        /// You are also asked if you want to buy the book
        /// </summary>
        public static void BookInfoLogic()
        {
            int bookId;
            Console.WriteLine("╔════════════════════════════╗");
            Console.WriteLine("║  Enter the id of the book  ║");
            Console.WriteLine("║  ────────────╬──────────── ║");
            Console.WriteLine("║  That you want to inspect  ║");
            Console.WriteLine("╚════════════════════════════╝");
            
            if (Int32.TryParse(Console.ReadLine(), out bookId))
            {
                    api.GetBook(LoginController.userId, bookId);     
            }
            else
            {
                WrongInput.InputErrorMessage();
            }
        }
    }
}
