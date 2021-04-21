using WebbShop.Controllers;

namespace WebbShop
{
    class Program
    {
        /// <summary>
        /// När programmet startar instansieras klassen HomeController och metoden Start() anropas
        /// </summary>
        static void Main(string[] args)
        {
            var home = new HomeController();
            home.Start();
        }
    }
}