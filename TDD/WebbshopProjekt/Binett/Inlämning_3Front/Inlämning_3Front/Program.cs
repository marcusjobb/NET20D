using Inlämning_3Front.Controllers;
using Inlämning_API.Helper;

namespace Inlämning_3Front
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Seeder.Seed();
            var start = new Controller();
            start.Index();
        }
    }
}