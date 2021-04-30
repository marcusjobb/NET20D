using System;
using WebbShop.Helpers;

namespace WebbShopMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            Seeder.Seed();
            Menu.MainMenu();
        }
    }
}
