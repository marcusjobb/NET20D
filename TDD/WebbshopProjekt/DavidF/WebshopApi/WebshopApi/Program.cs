using WebshopApi.Database;
using WebshopApi.Helpers;

namespace WebshopApi
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Seeder.Seed();
            Tester.Test();
        }
    }
}