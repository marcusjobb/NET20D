using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Helpers;
using WebshopFrontend.Views;

namespace WebshopFrontend.Controller
{
    class MainMenuAdminUserController
    {
        public static WebShop.WebShopApi api = new WebShop.WebShopApi();

        /// <summary>
        /// The base level menu for admin where you chose if you want the regular user actions
        /// Or the Admin user actions
        /// </summary>
        public static void MainMenuLogic()
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
                        MainMenuRegularUser.MainMenu();
                        break;

                    case 2:
                        MainMenuAdminUser.AdminUserMenu();
                        break;
                    case 3:
                        api.Logout(LoginController.userId);
                        MainMenuAdminUser.AdminBaseLevelMenu = false;
                        break;
                    default:
                        WrongInput.InputErrorMessage();
                        Console.ReadKey();
                    break;
                }
        }

        /// <summary>
        /// The admin user actions menu
        /// </summary>
        public static void AdminUserMenu()
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
                    AddBook.AddNewBook();
                    break;
                case 2:
                    DisplayAllBooks.ListOfBooks();
                    SetAmountOfBooks.UpdateBookAmount();
                    break;
                case 3:
                    DisplayAllBooks.ListOfBooks();
                    UpdateBook.UpdateBookInfo();
                    break;
                case 4:
                    DisplayAllBooks.ListOfBooks();
                    DeleteBook.DeleteOneBook();
                    break;
                case 5:
                    AddNewCategory.AddCategory();
                    break;
                case 6:
                    DisplayAllBooks.ListOfBooks();
                    AddBookToCategory.AddBookToThisCategory();
                    break;
                case 7:
                    ShowAllCategories.DisplayCategories();
                    UpdateCategory.UpdateCategoryDetails();
                    break;
                case 8:
                    ShowAllCategories.DisplayCategories();
                    DeleteCategory.DeleteThisCategory();
                    break;
                case 9:
                    ListUsers.ShowAllUsers();
                    break;
                case 10:
                    FindUsers.DisplayFoundUsers();
                    break;
                case 11:
                    AddUser.AddNewUser();
                    break;
                case 12:
                    MainMenuAdminUser.AdminActionLevelMenu = false;
                    break;
                default:
                    WrongInput.InputErrorMessage();
                    Console.ReadKey();
                    break;
            }
        }
    }
}
