using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopUI.Views
{
    public class Home
    {
        public int HomeView()
        {
            Console.Clear();
            Console.WriteLine("Welcome to WebbShop!");
            Console.WriteLine("");
            Console.WriteLine("Choose an option below!");
            Console.WriteLine("1. Register as a new user");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            int.TryParse(Console.ReadLine(), out int choice);

            return choice;
        }

    }
}
