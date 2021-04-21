using System;
using System.Collections.Generic;
using System.Text;
using WebShopAssignment;
using WebShopFrontend.View;

namespace WebShopFrontend.Controller.UserController
{
    public class UserMenu
    {
        public static WebShopAPI api = new WebShopAPI();
        public static void UserChoiceOfMenu(int userId, int input)
        {
            switch (input)
            {
                case 1:
                    UserBookCategory.PrintAllCategories(userId);                    
                    break;
                case 2:
                    UserBookCategory.SearchForCategories(userId);               
                    break;
                case 3:
                    UserBook.GetBooksInStock(userId);                    
                    break;
                case 4:
                    UserBook.SearchForBook(userId);
                    break;
                case 5:
                    UserBook.GetBooksFromAuthor(userId);
                    break;
                case 6:
                    Console.WriteLine("Du loggas nu ut.");
                     api.Logout(userId);
                    Environment.Exit(0);
                    break;
                default:
                    Messages.WrongInput();
                    break;

            }

        }
    }
}
