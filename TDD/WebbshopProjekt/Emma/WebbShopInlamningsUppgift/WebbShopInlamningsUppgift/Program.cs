using WebbShopInlamningsUppgift.Controllers;
using WebbShopInlamningsUppgift.Database;

namespace WebbShopInlamningsUppgift
{
    class Program
    {
        static void Main(string[] args)
        {
            Seeder.Seed();
            Test.Run();
            Admin.Run();
        }
    }
}
