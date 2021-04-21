using AssignmentThree.Views;
using System;

namespace AssignmentThree.Controllers
{
    public static class AuthenticationController
    {
        public static void AuthMenu()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                AuthenticationView.PrintAuthMenu();
                int.TryParse(Console.ReadLine(), out var userInput);

                switch (userInput)
                {
                    case 1:
                        Login();
                        break;

                    case 2:
                        Register();
                        break;

                    case 3:
                        Logout();
                        break;

                    case 0:
                        keepRunning = false;
                        break;

                    default:
                        AuthenticationView.PrintInvalidInput();
                        break;
                }
            }
        }

        private static void Login()
        {
            var (username, password) = AuthenticationView.PrintLogin();

            var result = Program.API.Login(username, password);

            if (result != 0)
            {
                Program.User.Id = result;
                AuthenticationView.PrintSuccessful();
            }
            else
            {
                AuthenticationView.PrintWentWrong();
            }
        }

        private static void Logout()
        {
            if (Program.User.Id != 0)
            {
                Program.API.Logout(Program.User.Id);
                Program.User.Id = 0;

                AuthenticationView.PrintSuccessful();
            }
            else
            {
                AuthenticationView.PrintLogInBefore();
            }
        }

        private static void Register()
        {
            var (username, password, passwordVerify) = AuthenticationView.PrintRegister();

            var result = Program.API.Register(username, password, passwordVerify);

            if (result)
            {
                AuthenticationView.PrintSuccessful();
            }
            else
            {
                AuthenticationView.PrintWentWrong();
            }
        }
    }
}