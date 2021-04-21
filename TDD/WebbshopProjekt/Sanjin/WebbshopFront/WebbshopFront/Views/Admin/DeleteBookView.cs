using InlamningDB2;
using InlamningDB2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebbshopFront.Views.Admin
{
   public  class DeleteBookView
    {
        WebbShopAPI Api = new WebbShopAPI();
        public static int DeleteBooks()
        {
            Console.Write("Ange ID på bok du vill radera : ");
            Int32.TryParse(Console.ReadLine(), out int bookId);

            return bookId;
        }
    }
}
