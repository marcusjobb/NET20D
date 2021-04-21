using BookWebShop.Database;
using BookWebShopFrontend.Controller;

namespace BookWebShopFrontend
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            Seeder.Seed();
            var menu = new HomeController();
            menu.Start();
        }
    }
}