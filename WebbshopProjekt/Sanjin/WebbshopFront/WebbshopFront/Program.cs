using InlamningDB2;
using InlamningDB2.Database;
using System;
namespace WebbshopFront
{
    class Program
    {
        static void Main(string[] args)
        {
            Seeder.Seed();
            var start = new Controllers.Menu();
            start.Start();
        }
    }
}
