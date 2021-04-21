namespace FrontEndJesperPersson
{
    using FrontEndJesperPersson.View;
    using WebbShopJesperPersson.Database;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var mockdata = new Seeder();
            mockdata.Seed();

            Start.Menu();
        }
    }
}