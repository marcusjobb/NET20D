using System;
using WebbShopAPI.Database;
using WebbShopAPI.Helpers;
using WebbShopAPI.Views;

namespace WebbShopAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var seed = new Seeder();
            seed.AddData();
        }
    }
}
