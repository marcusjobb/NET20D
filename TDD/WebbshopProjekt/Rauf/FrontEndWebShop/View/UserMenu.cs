using System;
using System.Collections.Generic;
using System.Text;

namespace FrontEndWebShop.View
{
    class UserMenu
    {
        public static void ShowUserMenu()
        {
                Console.WriteLine("");
                Console.WriteLine("1. Show categories");
                Console.WriteLine("2. Find a category");
                Console.WriteLine("3. List of books in category");
                Console.WriteLine("4. List of available books");
                Console.WriteLine("5. Information about book");
                Console.WriteLine("6. Find a book");
                Console.WriteLine("7. Search by author");
                Console.WriteLine("8. Buy a book");
                Console.WriteLine("q. Quit");
                Console.WriteLine("=========================");
                Console.Write("Your choise: ");
        }
    }
}
