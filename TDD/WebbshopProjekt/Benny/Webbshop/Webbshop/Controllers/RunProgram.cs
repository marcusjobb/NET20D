using webshopAPI.Helpers;

namespace Webbshop.Controllers
{
    internal class RunProgram
    {
        /// <summary>
        /// A method for starting up the program.
        /// </summary>
        public void StartProgram()
        {
            Seeder.Seed();
            Menu.PrintMainMenu();
        }
    }
}