using BookShopIvoNazlic.Views;
using System;

namespace BookShopIvoNazlic.Controllers
{
    /// <remarks>
    /// Handles the start and end of program
    /// </remarks>
    static class Start
    {

        public static bool keepPlaying = true;
        private static MainMenu mainMenu = new MainMenu();
        private static AdminMenu adminMenu = new AdminMenu();

        public static bool IsAdmin { get; set; } = false;

        public static void StartProgram()
        {
            AddMockData();
            Layout.ProgramLayout();
            Layout.Welcome();
            Layout.ClearScreen();
            while (keepPlaying && IsAdmin == false)
            {
                mainMenu.ProgramMenu(mainMenu.menuOptions);
                MenuSystem.ProgramActions(MenuChoices.UserChoice(mainMenu.menuOptions)); //calls method that takes user menu choice. Sends the info to method UserMenuChoice in the class Menu.
            }

            while (keepPlaying && IsAdmin == true)
            {
                mainMenu.ProgramMenu(adminMenu.menuOptions);
                MenuSystem.AdminActions(MenuChoices.UserChoice(adminMenu.menuOptions)); //calls method that takes admin menu choice. Sends the info to method UserMenuChoice in the class Menu.
            }
        }

        public static void ExitProgram()
        {
            Console.WriteLine("Thanks for playing. See ya!");
            keepPlaying = false;
        }

        /// <summary>
        /// Calls method to add mock data to the database. 
        /// </summary>
        public static void AddMockData()
        {
            WebbShopIvoNazlic.Database.MockData.AddData();
        }

    }
}
