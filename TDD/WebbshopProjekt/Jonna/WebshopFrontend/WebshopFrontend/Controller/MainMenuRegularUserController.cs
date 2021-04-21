using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Helpers;
using WebshopFrontend.Views;

namespace WebshopFrontend.Controller
{
    class MainMenuRegularUserController
    {
        public static WebShop.WebShopApi api = new WebShop.WebShopApi();
        /// <summary>
        /// The main menu actions for both regular user and admin user, depending on your IsAdmin status
        /// </summary>
        public static void MainMenuLogic()
        {
            if (LoginController.isUserAdmin == true)
            {
                IfAdminUserSwitch();
            }
            else
            {
                IfRegularUserSwitch();
            }     
        }

        /// <summary>
        /// The switch you get as a regular user for your main menu
        /// </summary>
        private static void IfRegularUserSwitch()
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
                    ShowAllCategories.DisplayCategories();
                    Console.ReadKey();
                    break;
                case 2:
                    SearchCategoryByName.DisplayCategoryResult();
                    break;
                case 3:
                    SearchBookByTitle.DisplayResultBook();
                    break;
                case 4:
                    SearchBookByAuthor.DisplayResultBook();
                    break;
                case 5:
                    ShowAllCategories.DisplayCategories();
                    GetCategory.GetBooksInCategory();
                    break;
                case 6:
                    ShowAllCategories.DisplayCategories();
                    GetAvailableBooks.GetBooksInStock();
                    break;
                case 7:
                    DisplayAllBooks.ListOfBooks();
                    BookInfo.ShowBookInfo();
                    break;
                case 8:
                    DisplayAllBooks.ListOfBooks();
                    BuyBook.BuyThisBook();
                    break;
                case 9:
                    api.Logout(LoginController.userId);
                    MainMenuRegularUser.RegularUserActions = false;
                    break;
                default:
                    WrongInput.InputErrorMessage();
                    Console.ReadKey();
                    break;
            }
        }
        /// <summary>
        /// The switch you get as a admin user for your main menu
        /// </summary>
        private static void IfAdminUserSwitch()
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
                    ShowAllCategories.DisplayCategories();
                    Console.ReadKey();
                    break;
                case 2:
                    SearchCategoryByName.DisplayCategoryResult();
                    break;
                case 3:
                    SearchBookByTitle.DisplayResultBook();
                    break;
                case 4:
                    SearchBookByAuthor.DisplayResultBook();
                    break;
                case 5:
                    ShowAllCategories.DisplayCategories();
                    GetCategory.GetBooksInCategory();
                    break;
                case 6:
                    ShowAllCategories.DisplayCategories();
                    GetAvailableBooks.GetBooksInStock();
                    break;
                case 7:
                    DisplayAllBooks.ListOfBooks();
                    BookInfo.ShowBookInfo();
                    break;
                case 8:
                    DisplayAllBooks.ListOfBooks();
                    BuyBook.BuyThisBook();
                    break;
                case 9:
                    MainMenuRegularUser.RegularUserActions = false;
                    break;
                default:
                    WrongInput.InputErrorMessage();
                    Console.ReadKey();
                    break;
            }
        }
    }
}
