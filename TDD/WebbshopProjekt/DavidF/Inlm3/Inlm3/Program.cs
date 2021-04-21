using Inlm3.Views;
using WebshopApi.Database;
using WebshopApi.Helpers;

namespace Inlm3
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            MainMeny meny = new MainMeny();
            Seeder.Seed();
           
            meny.Index();
        }
    }
}