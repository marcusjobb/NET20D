using WebbShopFrontInlamning.Helpers;
using WebbShopFrontInlamning.Views;
using WebbShopInlamningsUppgift;
using WebbShopInlamningsUppgift.Database;

namespace WebbShopFrontInlamning.Controllers
{
    /// <summary>
    /// Controls the home functionality
    /// </summary>
    class Home
    {
        private int userId = 0;

        /// <summary>
        /// Runs the home functionality page
        /// </summary>
        public void Run()
        {
            Seeder.Seed();
            bool keepGoing = true;

            while (keepGoing)
            {
                HomeView.MainMeny();
                var input = InputHelper.ParseInput();
                if(userId > 0)
                {
                    WebbShopAPI api = new WebbShopAPI();
                    api.Ping(userId);
                }
                switch (input)
                {
                    case 1:
                        userId = new Login().Run();
                        break;
                    case 2:
                        new User().RegisterAccount();
                        break;
                    case 3:
                        new Book().Run();
                        break;
                    case 4:
                        new Purchase().Run(userId);
                        break;
                    case 5:
                        userId = new Admin().Run();
                        break;
                    case 6:
                        new Logout().Run(userId);
                        keepGoing = false;
                        break;
                    default:
                        MessageViews.DisplayNonAvailableMessage();
                        break;
                }
            }
        }
    }
}
