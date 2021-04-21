
namespace WebshoppFrontEnd
{
    using Inlämning2.Database;
    using WebbshopFrontEnd.Models;

    static class Program
    {
        static void Main(string[] args)
        {
            Seeder.Seed();
            Start.RunStart();
        }
    }
}
