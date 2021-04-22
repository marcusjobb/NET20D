using System;
using WebbShopAPI.Database;
using System.Linq;
using WebbShopAPI.Models;
using WebbShopAPI;

namespace WebbShopFront
{
    class Program : Menu
    {
        static void Main(string[] args)
        {
            var menu = new Menu();

            Seeder.Seed();
            bool isAdmin = menu.Intro();
            if (isAdmin == true)
            {
                menu.AdminMenu();
            }
            else if (isAdmin == false)
            {
                menu.UserMenu();
            }
            
        }
    }
}
