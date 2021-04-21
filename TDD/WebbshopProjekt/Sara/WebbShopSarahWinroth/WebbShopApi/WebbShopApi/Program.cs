using System;
using WebbShopApi.Database;

namespace WebbShopApi
{
    class Program
    {
        static void Main(string[] args)
        {
            Seeder seed = new Seeder();
            seed.AddData();
        }
    }
}
