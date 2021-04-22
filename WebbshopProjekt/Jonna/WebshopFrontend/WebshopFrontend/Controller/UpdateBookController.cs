using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Helpers;

namespace WebshopFrontend.Controller
{
    class UpdateBookController
    {
        //Fetch the API
        public static WebShop.WebShopApi api = new WebShop.WebShopApi();
        /// <summary>
        /// Controller of the API method Update book
        /// Lets the admin with help of inputs in console to update a specific book
        /// If you do a bad typo, a error message will be displayed
        /// </summary>
        public static void UpdateBookLogic()
        {
            int bookId;
            string bookTitle;
            string bookAuthor;
            int bookPrice;

            Console.WriteLine("╔═════════════════════════════════════╗");
            Console.WriteLine("║     Enter desired book id number    ║");
            Console.WriteLine("║ ─────────────────╬───────────────── ║");
            Console.WriteLine("║  To select which category to update ║");
            Console.WriteLine("╚═════════════════════════════════════╝"); 
            if (Int32.TryParse(Console.ReadLine(), out bookId))
            {
                Console.Clear();
                Console.WriteLine("╔═════════════════════════════════════╗");
                Console.WriteLine("║    Type the new title of the book   ║");
                Console.WriteLine("║  ───────────────╬─────────────────  ║");
                Console.WriteLine("║            To update it             ║");
                Console.WriteLine("╚═════════════════════════════════════╝");
                bookTitle = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("╔═════════════════════════════════════╗");
                Console.WriteLine("║   Type the new author of the book   ║");
                Console.WriteLine("║  ───────────────╬─────────────────  ║");
                Console.WriteLine("║            To update it             ║");
                Console.WriteLine("╚═════════════════════════════════════╝");
                bookAuthor = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("╔═════════════════════════════════════╗");
                Console.WriteLine("║   Type the new price of the book    ║");
                Console.WriteLine("║  ───────────────╬─────────────────  ║");
                Console.WriteLine("║            To update it             ║");
                Console.WriteLine("╚═════════════════════════════════════╝"); 
                if (Int32.TryParse(Console.ReadLine(), out bookPrice))
                {
                    api.UpdateBook(LoginController.userId, bookId, bookTitle, bookAuthor, bookPrice);
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
