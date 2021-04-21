using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Helpers;

namespace WebshopFrontend.Controller
{
    class SetAmountOfBooksController
    {
        public static WebShop.WebShopApi api = new WebShop.WebShopApi();
        /// <summary>
        /// Method that lets the admin to change the amount of books in stock for a specific book
        /// With help from inputing numbers in the console
        /// If theres any bad typo, a error message will be displayed
        /// </summary>
        public static void SetAmountOfBooksLogic()
        {
            int bookId;
            int bookAmount;
            Console.WriteLine("╔═══════════════════════════════════╗");
            Console.WriteLine("║   Enter desired book id number    ║");
            Console.WriteLine("║ ────────────────╬───────────────  ║");
            Console.WriteLine("║  To select which book to update   ║");
            Console.WriteLine("╚═══════════════════════════════════╝");

            if (Int32.TryParse(Console.ReadLine(), out bookId))
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════╗");
                Console.WriteLine("║  Type the new number with the  ║");
                Console.WriteLine("║ ───────────────╬────────────── ║");
                Console.WriteLine("║  Updated amount of this book   ║");
                Console.WriteLine("╚════════════════════════════════╝");

                if (Int32.TryParse(Console.ReadLine(), out bookAmount))
                {
                    Console.Clear();
                    api.SetAmount(LoginController.userId, bookId, bookAmount);
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
