using System;
using WebshopApiFrontend.Models;

namespace WebshopApiFrontend.Utility
{
    public static class LoginMenu
    {
        public static int LoggedInUser { get; set; }
        /// <summary>
        /// Login menu which allows users to login, register as a new user or choose to exit completely
        /// </summary>
        public static void LoginRegistrationMenu()
        {
            bool activeSeassion = true;
            do
            {
                Console.WriteLine("\n**************************************\n" +
                                    "* 1. Login\n" +
                                    "* 2. Register\n" +
                                    "* 0. Exit\n" +
                                    "**************************************\n");
                Console.Write(">> ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string menuChoice = Console.ReadLine();
                Console.ResetColor();
                switch (menuChoice)
                {
                    case "1":
                        LoggedInUser = UserInputs.UserLogin();
                        if (LoggedInUser != 0)
                        {
                            Console.WriteLine("Välkommen!");
                            CurrentUser.LoggedInUser = LoggedInUser;
                            MainMenu.ProgramMenu(LoggedInUser);
                            WebbShopAPI.Database.Seeder.Seed();
                        }
                        break;
                    case "2":
                        var registerUser = UserInputs.UserRegistration();
                        if(!registerUser)
                            Console.WriteLine(Errorhandeling.Registrationfailed);
                        break;
                    case "0":
                        activeSeassion = false;
                        break;
                }
            } while (activeSeassion);
        }
    }
}
