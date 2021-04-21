using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopUI.Views.AdminViews
{
    class AdminHome
    {
        public int AdminMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome back superuser!");
            Console.WriteLine("");
            Console.WriteLine("1. Options related to books");
            Console.WriteLine("2. Options related to categories");
            Console.WriteLine("3. Options related to users");
            Console.WriteLine("4. Logout");
            int.TryParse(Console.ReadLine(), out int choice);

            return choice;


        }

        public int UserOrAdminMenu()
        {
            Console.WriteLine("Please choose which menus you want to use!");
            Console.WriteLine("");
            Console.WriteLine("1. User menus");
            Console.WriteLine("2. Admin menus");
            int.TryParse(Console.ReadLine(), out int choice);

            return choice;
        }


    }
}
