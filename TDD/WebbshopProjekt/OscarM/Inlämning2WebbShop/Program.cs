using Inlämning2WebbShop.Database;
using Inlämning2WebbShop.Helpers;

namespace Inlämning2WebbShop
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Seeder.Seed();
            Test.TestApiMethods();
        }
    }
}