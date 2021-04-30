using System;
using BookShop.Controllers;
using BookShop.Data;

namespace BookShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Seeder seed = new Seeder();
            seed.AddInitialCategories();
            seed.AddInitialBooks();
            seed.AddInitialUsers();
            RunProgram runner = new RunProgram();
            runner.Menu();
        }                
    }
}
