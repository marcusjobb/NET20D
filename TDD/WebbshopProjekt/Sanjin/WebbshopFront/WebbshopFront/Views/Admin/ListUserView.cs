using System;
using System.Collections.Generic;
using System.Text;

namespace WebbshopFront.Views.Admin
{
   static class ListUserView
    {
        public static void ListOfUsers(List<InlamningDB2.Models.User> userList)
        {
            Console.WriteLine("Listar alla användare:");
            foreach (var item in userList)
            {
                Console.WriteLine($"{item.Name}");
            }
            Console.ReadKey();       
        }
    }
}