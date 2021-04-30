using System;
using WebshopAPI.Models;
using WebshopMVC.ControllersAdmin;
using WebshopMVC.UtilsMVC;

namespace WebshopMVC.Controllers.Menu
{
    /// <summary>
    /// Class for handling choices of administrator functions
    /// </summary>
    internal class AdminMenuController
    {
        /// <summary>
        /// Bool for creating while loop of Admin menu
        /// </summary>
        public static bool isAdminMenuRunning = true;

        /// <summary>
        /// Admin main menu, Admin User object as parameter for handling session timer and ping function
        /// </summary>
        /// <param name="admin"></param>
        public static void AdminMainMenu(User admin)
        {
            isAdminMenuRunning = true;
            while (isAdminMenuRunning)
            {
                Console.Clear();
                ASCII.AdminMainMenuASCII();
                Console.WriteLine("[1] Handle books");
                Console.WriteLine("[2] Handle categories");
                Console.WriteLine("[3] Handle users");
                Console.WriteLine("[4] Go back to main menu");
                Console.WriteLine("[5] Quit application");

                int.TryParse(Console.ReadLine(), out var AdminMainMenuInput);

                switch (AdminMainMenuInput)
                {
                    case 1:
                        AdminBookMenu(admin);
                        break;

                    case 2:
                        AdminCategoryMenu(admin);
                        break;

                    case 3:
                        AdminUserMenu(admin);
                        break;

                    case 4:
                        isAdminMenuRunning = false;
                        break;

                    case 5:
                        isAdminMenuRunning = false;
                        MainMenuController.isMainMenuRunning = false;
                        break;
                }
            }
        }


        /// <summary>
        /// Admin book menu, Admin User object as parameter for handling session timer and ping function
        /// </summary>
        /// <param name="admin"></param>
        public static void AdminBookMenu(User admin)
        {
            bool isAdminBookMenuRunning = true;

            while (isAdminBookMenuRunning)
            {
                Console.Clear();
                ASCII.AdminBookMenuASCII();
                Console.WriteLine("[1] Add a book to inventory");
                Console.WriteLine("[2] Set a book's amount");
                Console.WriteLine("[3] Update a book");
                Console.WriteLine("[4] Delete a book");
                Console.WriteLine("[5] List all sold books");
                Console.WriteLine("[6] Calculate sum of sold books");
                Console.WriteLine("[7] Go back to admin main menu");
                Console.WriteLine("[8] Go back to main menu");
                Console.WriteLine("[9] Quit application");

                int.TryParse(Console.ReadLine(), out var AdminBookMenuInput);

                switch (AdminBookMenuInput)
                {
                    case 1:
                        AdminBookController.AddBookToInventory(admin);
                        break;

                    case 2:
                        AdminBookController.SetAmount(admin);
                        break;

                    case 3:
                        AdminBookController.UpdateBook(admin);
                        break;

                    case 4:
                        AdminBookController.DeleteBook(admin);
                        break;

                    case 5:
                        AdminBookController.ListAllSoldBooks(admin);
                        break;

                    case 6:
                        AdminBookController.SumOfSoldBooks(admin);
                        break;

                    case 7:
                        isAdminBookMenuRunning = false;
                        break;

                    case 8:
                        isAdminBookMenuRunning = false;
                        isAdminMenuRunning = false;
                        break;

                    case 9:
                        isAdminBookMenuRunning = false;
                        isAdminMenuRunning = false;
                        MainMenuController.isMainMenuRunning = false;
                        break;
                }
            }
        }
        /// <summary>
        /// Admin category menu, Admin User object as parameter for handling session timer and ping function
        /// </summary>
        /// <param name="admin"></param>
        public static void AdminCategoryMenu(User admin)
        {
            bool isAdminCategoryMenuRunning = true;

            while (isAdminCategoryMenuRunning)
            {
                Console.Clear();
                ASCII.AdminCategoryMenuASCII();
                Console.WriteLine("[1] Add category");
                Console.WriteLine("[2] Add book to category");
                Console.WriteLine("[3] Update category");
                Console.WriteLine("[4] Delete category");
                Console.WriteLine("[5] Go back to main admin menu");
                Console.WriteLine("[6] Go back to main menu");
                Console.WriteLine("[7] Quit application");

                int.TryParse(Console.ReadLine(), out var AdminCategoryMenuInput);

                switch (AdminCategoryMenuInput)
                {
                    case 1:
                        AdminCategoryController.AddCategory(admin);
                        break;

                    case 2:
                        AdminCategoryController.AddBookToCategory(admin);
                        break;

                    case 3:
                        AdminCategoryController.UpdateCategory(admin);
                        break;

                    case 4:
                        AdminCategoryController.DeleteCategory(admin);
                        break;

                    case 5:
                        isAdminCategoryMenuRunning = false;
                        break;

                    case 6:
                        isAdminCategoryMenuRunning = false;
                        isAdminMenuRunning = false;
                        break;

                    case 7:
                        isAdminCategoryMenuRunning = false;
                        isAdminMenuRunning = false;
                        MainMenuController.isMainMenuRunning = false;
                        break;
                }
            }
        }
        /// <summary>
        /// Admin user menu, Admin User object as parameter for handling session timer and ping function
        /// </summary>
        /// <param name="admin"></param>
        public static void AdminUserMenu(User admin)
        {
            bool isAdminUserMenuRunning = true;

            while (isAdminUserMenuRunning)
            {
                Console.Clear();
                ASCII.AdminUserMenuASCII();
                Console.WriteLine("[1] List all users");
                Console.WriteLine("[2] Find user");
                Console.WriteLine("[3] Add user");
                Console.WriteLine("[4] Show best costumer");
                Console.WriteLine("[5] Promote user");
                Console.WriteLine("[6] Demote user");
                Console.WriteLine("[7] Activate user");
                Console.WriteLine("[8] Deactivate user");
                Console.WriteLine("[9] Go back to main admin menu");
                Console.WriteLine("[10] Go back to main menu");
                Console.WriteLine("[11] Quit application");

                int.TryParse(Console.ReadLine(), out var AdminUserMenuInput);

                switch (AdminUserMenuInput)
                {
                    case 1:
                        AdminUserController.ListAllUsers(admin);
                        break;

                    case 2:
                        AdminUserController.FindUser(admin);
                        break;

                    case 3:
                        AdminUserController.AddUser(admin);
                        break;

                    case 4:
                        AdminUserController.BestCostumer(admin);
                        break;

                    case 5:
                        AdminUserController.PromoteUser(admin);
                        break;

                    case 6:
                        AdminUserController.DemoteUser(admin);
                        break;

                    case 7:
                        AdminUserController.ActivateUser(admin);
                        break;

                    case 8:
                        AdminUserController.DeactivateUser(admin);
                        break;

                    case 9:
                        isAdminUserMenuRunning = false;
                        break;

                    case 10:
                        isAdminUserMenuRunning = false;
                        isAdminMenuRunning = false;
                        break;

                    case 11:
                        isAdminUserMenuRunning = false;
                        isAdminMenuRunning = false;
                        MainMenuController.isMainMenuRunning = false;
                        break;
                }
            }
        }
    }
}