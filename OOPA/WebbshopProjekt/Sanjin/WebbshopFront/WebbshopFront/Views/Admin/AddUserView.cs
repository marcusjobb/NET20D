using System;
using System.Collections.Generic;
using System.Text;

namespace WebbshopFront.Views.Admin
{
   public class AddUserView
    {
        public static List<string> AdminAddUser()
        {
            List<string> input = new List<string>();
            Console.Write("Ange användarnamn : ");
            input.Add(Console.ReadLine());
            Console.Write("Ange lösenord : ");
            input.Add(Console.ReadLine());

            return input;
        }
    }
}
