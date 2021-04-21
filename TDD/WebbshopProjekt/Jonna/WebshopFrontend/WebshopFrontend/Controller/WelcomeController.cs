using System;
using WebshopFrontend.Views;
using WebshopFrontend.Helpers;

namespace WebshopFrontend.Controller
{
    public class WelcomeController
    {
        /// <summary>
        /// This is the logic behind the first menu that you will see when you start the application
        /// If you do a bad typo you end up with a error message
        /// </summary>
        public static void WelcomeMenuLogic()
        {
            int input = 0;
            int.TryParse(Console.ReadLine(), out input);

            switch (input)
            {
                case 0:
                    WrongInput.InputErrorMessage();
                    Console.ReadKey();
                    break;

                case 1:
                    Login.LoginMenu();
                    break;

                case 2:
                    Register.RegisterMenu();
                    break;

                case 3:
                    System.Environment.Exit(1);
                    break;

                default:
                    WrongInput.InputErrorMessage();
                    Console.ReadKey();
                    break;
            }
        }
    }
}