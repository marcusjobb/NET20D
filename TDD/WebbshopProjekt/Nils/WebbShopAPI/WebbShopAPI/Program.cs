using System;
using WebbShopAPI.Database;
using System.Linq;
using WebbShopAPI.Models;

namespace WebbShopAPI
{
    class Program : WebbShopAPI
    {
        /// <summary>
        /// I main metoden så körs Seed() metoden om det är första gången som programmet starts.
        /// Härifrån så utförs alla API metoder.
        /// </summary>
        static void Main()
        {
            var API = new WebbShopAPI();
            Seeder.Seed();
            //API.Login("Administrator", "CodicRulez");
            //API.Login("TestCustomer", "Codic2021");
        }
    }
}
