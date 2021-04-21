using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopUI.Views.UserViews
{
    class UserHome
    {
        public int UserMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome user!");
            Console.WriteLine("");
            Console.WriteLine("1. Categories");
            Console.WriteLine("2. Books");
            Console.WriteLine("3. Logout");
            int.TryParse(Console.ReadLine(), out int choice);

            return choice;


        }

    }
}
