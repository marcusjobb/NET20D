using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopUI.Views.UserViews;
using WebbShopAPI;
using WebbShopUI.Views;
using System.Net.NetworkInformation;
using System.Data.Common;
using WebbShopUI.Views.AdminViews;

namespace WebbShopUI.Controller
{
    class AdminController
    {
        WebbShopAPInterface api = new WebbShopAPInterface();

        public void RunAdminMenu(int userId)
        {
            bool adminActive = true;
            var admin = new AdminHome();
            var categories = new AdminCategories();
            var books = new AdminBooks();
            var users = new AdminUsers();
            var message = new Messages();
            var userContr = new UserController();

            int menuChoice = admin.UserOrAdminMenu();
            if(menuChoice == 1)
            {
                userContr.RunUserMenu(userId);
            }
            if(menuChoice == 2)
            { 
                while (adminActive)
                {
                


                    int firstChoice = admin.AdminMenu();
                    switch(firstChoice)
                    { 
                        case 1:
                            api.Ping(userId);
                            int bookMenuChoice = books.AdminBooksMenu();
                            if(bookMenuChoice == 1)
                            {
                                api.Ping(userId);
                                var newBookStrings = books.AddNewBookStrings();
                                var newBookInts = books.AddNewBookInts();
                                bool newbook = api.AddBook(userId, newBookInts[0], newBookStrings[0], newBookStrings[1], newBookInts[1], newBookInts[2]);
                                if(newbook == true)
                                {
                                    message.SuccessMessage();
                                }
                                if(newbook == false)
                                {
                                    message.FailMessage();
                                }
                            }
                            if (bookMenuChoice == 2)
                            {
                                api.Ping(userId);
                                var listOfValues = books.BookToCategory();
                                bool bookToCate = api.AddBookToCategory(userId, listOfValues[0], listOfValues[1]);
                                if (bookToCate == true)
                                {
                                    message.SuccessMessage();
                                }
                                if (bookToCate == false)
                                {
                                    message.FailMessage();
                                }
                            }
                            if (bookMenuChoice == 3)
                            {
                                api.Ping(userId);
                                var amountValues = books.SetNewAmount();
                                string amountResult = api.SetAmount(userId, amountValues[0], amountValues[1]);
                                message.PrintMessage(amountResult);

                            }
                            if (bookMenuChoice == 4)
                            {
                                api.Ping(userId);
                                int bookIdInfo = books.BookID();
                                var updatedStrings = books.UpdateBookInfo();
                                int priceInfo = books.Price();
                                bool updateResult = api.UpdateBook(userId, bookIdInfo, updatedStrings[0], updatedStrings[1], priceInfo);
                                if (updateResult == true)
                                {
                                    message.SuccessMessage();
                                }
                                if (updateResult == false)
                                {
                                    message.FailMessage();
                                }
                            }
                            if (bookMenuChoice == 5)
                            {
                                api.Ping(userId);
                                int bookToDelete = books.BookID();
                                bool deleteResult = api.DeleteBook(userId, bookToDelete);
                                if (deleteResult == true)
                                {
                                    message.SuccessMessage();
                                }
                                if (deleteResult == false)
                                {
                                    message.FailMessage();
                                }
                            }

                            break;

                        case 2:
                            api.Ping(userId);
                            int categoriesChoice = categories.AdminCategoriesMenu();
                            if(categoriesChoice == 1)
                            {
                                api.Ping(userId);
                                string newName = categories.CategoryName();
                                bool cateResult = api.AddCategory(userId, newName);
                                if (cateResult == true)
                                {
                                    message.SuccessMessage();
                                }
                                if (cateResult == false)
                                {
                                    message.FailMessage();
                                }
                            }
                            if (categoriesChoice == 2)
                            {
                                api.Ping(userId);
                                int categoryId = categories.CategoryID();
                                string categoryName = categories.CategoryName();
                                bool updateCateResult = api.UpdateCategory(userId, categoryId, categoryName);
                                if (updateCateResult == true)
                                {
                                    message.SuccessMessage();
                                }
                                if (updateCateResult == false)
                                {
                                    message.FailMessage();
                                }

                            }
                            if (categoriesChoice == 3)
                            {
                                api.Ping(userId);
                                int categoryToDelete = categories.CategoryID();
                                bool deleteResult = api.DeleteCategory(userId, categoryToDelete);
                                if (deleteResult == true)
                                {
                                    message.SuccessMessage();
                                }
                                if (deleteResult == false)
                                {
                                    message.FailMessage();
                                }
                            }
                            break;

                        case 3:
                            api.Ping(userId);
                            int usersChoice = users.AdminUsersMenu();
                            if(usersChoice == 1)
                            {
                                api.Ping(userId);
                                var listOfUsers = api.ListUsers(userId);
                                users.ListUsers(listOfUsers);
                            }
                            if (usersChoice == 2)
                            {
                                api.Ping(userId);
                                string userKeyword = users.FindUserKeyword();
                                var foundUsers = api.FindUser(userId, userKeyword);
                                if(foundUsers != null)
                                {
                                    users.ListUsers(foundUsers);
                                }
                                if(foundUsers == null)
                                {
                                    message.FailMessage();
                                }
                            }
                            if (usersChoice == 3)
                            {
                                api.Ping(userId);
                                var info = users.NewUser();
                                bool userResult = api.AddUser(userId, info[0], info[1]);
                                if (userResult == true)
                                {
                                    message.SuccessMessage();
                                }
                                if (userResult == false)
                                {
                                    message.FailMessage();
                                }
                            }
                            break;

                        case 4:
                            api.Ping(userId);
                            api.LogOut(userId);
                            adminActive = false;
                            break;

                    }

                }
            }
        }
    }
}
