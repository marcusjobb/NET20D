using System;
using LinusNestorson_WebbShop;
using LinusNestorson_WebbShop.Database;
using LinusNestorson_WebbShopFrontEnd.Views;

namespace LinusNestorson_WebbShopFrontEnd
{
    class Program
    {
        /// <summary>
        /// Startup point for program. Generating data through seeder and starts the frontend.
        /// Before starting the program. Set default project to LinusNestorson_WebbShop and type in "update-database" in Package Manager Console.
        /// </summary>
        static void Main()
        {
            Seeder.GenerateData();
            StartView.Startup();
        }
    }
}
