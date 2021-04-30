using AssignmentThree.Views;
using System;

namespace AssignmentThree.Controllers
{
    public static class MenuController
    {
        public static void MainMenu()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                MenuView.PrintMainMenu();
                int.TryParse(Console.ReadLine(), out var userInput);

                switch (userInput)
                {
                    case 1:
                        BookController.BookMenu();
                        break;

                    case 2:
                        CategoryController.CategoryMenu();
                        break;

                    case 3:
                        BookController.BuyBook();
                        break;

                    case 4:
                        AuthenticationController.AuthMenu();
                        break;

                    case 5:
                        AdminController.AdminMenu();
                        break;

                    case 0:
                        keepRunning = false;
                        break;

                    default:
                        MenuView.PrintInvalidInput();
                        break;
                }
            }
        }
    }
}