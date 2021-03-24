using Models;
using System;
using System.Collections.Generic;

namespace Views
{
    internal class Users
    {
        internal void List(List<User> users)
        {
            foreach (var item in users)
            {
                Console.WriteLine(item.Name + "\t\t" + item.Address);
            }
            Console.ReadLine();
        }

        internal User Add(List<User> users)
        {
            Console.Write("Ange namn   :");
            var fname = Console.ReadLine();
            Console.Write("Ange adress :");
            var address = Console.ReadLine();
            return new User { Name = fname, Address = address };
        }
    }
}