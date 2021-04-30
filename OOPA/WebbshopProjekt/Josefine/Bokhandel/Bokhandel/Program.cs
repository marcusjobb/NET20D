using Bokhandel.View;
using WebbShopJoR.Helper;

namespace Bokhandel
{
    class Program
    {
        static void Main(string[] args)
        {
            var seed = new Seeder();
            seed.AddData();
            var menu = new UserView();
            menu.Start();
        }
    }
}
