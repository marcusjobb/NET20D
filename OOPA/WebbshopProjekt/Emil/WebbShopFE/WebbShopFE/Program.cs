using System;
using System.Threading;
using WebbShopEmil;
using WebbShopEmil.Database;
using WebbShopFE.Controllers;

namespace WebbShopFE
{
    class Program
    {
        static void Main(string[] args)
        { 
            // Fills database with data if it is empty.
            Seeder.Seed();
            
            // Start of program.
            var start = new MenuController();
            start.MainMenu();
        }
    }
}
