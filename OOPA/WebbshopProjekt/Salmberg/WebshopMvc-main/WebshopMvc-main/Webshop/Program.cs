using WebshopAPI;
using WebshopMVC.Controllers;

namespace Webshop
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //Creates database and table if not existent
            Startup.InitialiseDatabase();

            //Creates initial data
            Startup.InitialiseSeed();

            //Start and end of program flow
            MainMenuController.MainMenu(Startup.sessionCookie);
        }
    }
}