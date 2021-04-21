using System;
using System.Collections.Generic;
using System.Text;

namespace WebbshopFront.Views.Admin
{
  static class FindUserView
    {
        public static string FindUsers()
        {
            Console.WriteLine();
            Console.Write("Villken användare söker du efter? :");
            return Console.ReadLine();
        }
    }
}
