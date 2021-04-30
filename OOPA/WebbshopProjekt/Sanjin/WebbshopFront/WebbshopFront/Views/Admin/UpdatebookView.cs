using System;
using System.Collections.Generic;
using System.Text;
using InlamningDB2;
using InlamningDB2.Models;

namespace WebbshopFront.Views.Admin
{
   static class UpdatebookView
    {
    public static int Updatebook(List<Books>listOfBooks2Update)
        {
            Console.Write("Villken bok vill du updatera? : ");
      
            return GetCategory.ShowBooks(listOfBooks2Update);
        }
    }
}
