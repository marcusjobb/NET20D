using WebbShop.Helpers;
using WebbutikFrontend.Controllers;

namespace WebbutikFrontend
{
    class Program
    {
        static void Main()
        {
            Seeder.Seed();
            var home = new HomeController();
            home.Index();
        }
    }
}
