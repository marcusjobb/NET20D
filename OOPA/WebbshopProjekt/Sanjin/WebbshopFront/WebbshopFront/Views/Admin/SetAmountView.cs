using System;
using System.Collections.Generic;
using System.Text;

namespace WebbshopFront.Views.Admin
{
   static class SetAmountView
    {
        public static void Amount(out int bookId, out int amount)
        {
            Console.Write("Skriv in ID på boken du vill ändra antalet på: ");
            Int32.TryParse(Console.ReadLine(), out bookId);
            Console.Write("Skriv in det nya buffer antalet: ");
            Int32.TryParse(Console.ReadLine(), out amount);
        }
    }
}
