using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Helpers;

namespace WebshopFrontend.Controller
{
    class BuyBookController
    {
        public static WebShop.WebShopApi api = new WebShop.WebShopApi();


        public static void BuyBookLogic()
        {
            int bookId;
            Console.WriteLine("╔═════════════════════════════╗");
            Console.WriteLine("║  Enter the Id of the book   ║");
            Console.WriteLine("║ ─────────────╬───────────── ║");
            Console.WriteLine("║    That you want to buy     ║");
            Console.WriteLine("╚═════════════════════════════╝");
            if (Int32.TryParse(Console.ReadLine(), out bookId))
            {
                api.BuyBook(LoginController.userId, bookId);
            }
            else
            {
                WrongInput.InputErrorMessage();
            }
        }
    }
}
