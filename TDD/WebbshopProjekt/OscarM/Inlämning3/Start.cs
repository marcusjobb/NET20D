using Inlämning2WebbShop.Database;
using Inlämning3.Controllers;

namespace Inlämning3
{
    public static class Start
    {
        public static void Execute()
        {
            Seeder.Seed();
            var Home = new HomeController();
            Home.Home();
        }
    }
}