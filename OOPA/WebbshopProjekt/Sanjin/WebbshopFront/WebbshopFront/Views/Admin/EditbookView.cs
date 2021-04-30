using InlamningDB2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebbshopFront.Views.Admin
{
   static class EditbookView
    {
        public static Books EditBook(Books oldBook)
        {
            Console.WriteLine($"{oldBook.Titel}");
            Console.Write("Ändra titel till: ");
            oldBook.Titel = Console.ReadLine();
            Console.WriteLine($"{oldBook.Author}");
            Console.Write("Ändra namn på författare till: ");
            oldBook.Author = Console.ReadLine();
            Console.WriteLine($"{oldBook.Price}");
            Console.Write("Ändra pris till: ");
            int.TryParse(Console.ReadLine(), out var Price);
            oldBook.Price = Price;

            return oldBook;
        }
    }
}
