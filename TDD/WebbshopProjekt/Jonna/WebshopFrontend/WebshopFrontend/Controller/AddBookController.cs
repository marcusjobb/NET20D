using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Helpers;

namespace WebshopFrontend.Controller
{
    class AddBookController
    {

        public static WebShop.WebShopApi api = new WebShop.WebShopApi();

        /// <summary>
        /// Controller of API method Add book
        /// Lets Admin fill in all details so a new book can be added to the webshop
        /// If any input is wrong, a error message will be displayed
        /// </summary>
        public static void AddBookLogic()
        {
            string bookTitle;
            string bookAuthor;
            int bookPrice;
            int bookAmount;

            Console.WriteLine("╔═════════════════════════════╗");
            Console.WriteLine("║ Enter the Title of the book ║");
            Console.WriteLine("║ ─────────────╬───────────── ║");
            Console.WriteLine("║    That you want to add     ║");
            Console.WriteLine("╚═════════════════════════════╝");
            bookTitle = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════╗");
            Console.WriteLine("║ Enter the Author of the book ║");
            Console.WriteLine("║ ─────────────╬────────────── ║");
            Console.WriteLine("║     That you want to add     ║");
            Console.WriteLine("╚══════════════════════════════╝");
            bookAuthor = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║  Enter the Price of the book  ║");
            Console.WriteLine("║  ────────────╬──────────────  ║");
            Console.WriteLine("║     That you want to add      ║");
            Console.WriteLine("╚═══════════════════════════════╝");
            if (Int32.TryParse(Console.ReadLine(), out bookPrice))
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════╗");
                Console.WriteLine("║  Enter the Amount of the book  ║");
                Console.WriteLine("║  ────────────╬───────────────  ║");
                Console.WriteLine("║     That you want to add       ║");
                Console.WriteLine("╚════════════════════════════════╝");
                if (Int32.TryParse(Console.ReadLine(), out bookAmount))
                {
                    api.AddBook(LoginController.userId, bookTitle, bookAuthor, bookPrice, bookAmount);
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
