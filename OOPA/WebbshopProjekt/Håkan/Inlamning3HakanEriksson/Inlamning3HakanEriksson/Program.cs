using Inlamning2TrialRunHE.Db;
using Inlamning3HakanEriksson.Controllers;

namespace Inlamning3HakanEriksson
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Seeder.Seed();
            var run = new HomeController();
            run.menuNotLoggedIn();
        }
    }
}