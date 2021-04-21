using InlamningDB2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebbshopFront.Views
{
   public static class AdminView
    {
        public static Books AddBook()
        {
            var book = new Books();
            Console.Write("Ange titel för bok: ");
            book.Titel = Console.ReadLine();
            Console.Write("Ange författare: ");
            book.Author = Console.ReadLine();
            Console.Write("Ange pris: ");
            int.TryParse(Console.ReadLine(), out var Price);
            book.Price = Price;
            Console.Write("Ange hur många exemplar du vill ha: ");
            int.TryParse(Console.ReadLine(), out var Amount);
            book.Amount = Amount;

            return book;
        } 
    }
}
