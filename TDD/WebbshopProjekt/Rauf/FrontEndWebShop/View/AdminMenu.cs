using System;
using System.Collections.Generic;
using System.Text;
using ConsoleTableExt;
using MyBackend;

namespace FrontEndWebShop.View
{
    class AdminMenu
    {
        public static void ShowAdminMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("1. Add book");
            Console.WriteLine("2. Set Amount");
            Console.WriteLine("3. List users");
            Console.WriteLine("4. Find user");
            Console.WriteLine("5. Update book");
            Console.WriteLine("6. Delete book");
            Console.WriteLine("7. Add category");
            Console.WriteLine("8. Add book to category");
            Console.WriteLine("9. Update category");
            Console.WriteLine("10. Delete category");
            Console.WriteLine("11. Add user");
            Console.WriteLine("12. Promote user");
            Console.WriteLine("13. Demote user");
            Console.WriteLine("14. Activate user");
            Console.WriteLine("15. Inactivate user");
            Console.WriteLine("q. Quit");
            Console.WriteLine("=========================");
            Console.Write("Your choise: ");
        }

        public static void ShowBooks()
        {
            var books = WebbShopAPI.GetAllBooks();
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Id}. {book.Title} by {book.Author}. Price: {book.Price} sek. Available amount: {book.Amount}");
            }
        }

        public static void ShowCategories()
        {
            var categories = WebbShopAPI.GetCategories();
            foreach (var cat in categories)
            {
                Console.WriteLine($"{cat.Id}. {cat.Name}");
            }
        }
    }
}
