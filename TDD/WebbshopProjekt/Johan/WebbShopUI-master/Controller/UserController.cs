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

namespace WebbShopUI.Controller
{
    class UserController
    {
        WebbShopAPInterface api = new WebbShopAPInterface();

        public void RunUserMenu(int userId)
        {
            bool userActive = true;
            var userHomeMenu = new UserHome();
            var bookCategories = new Categories();
            var listBooks = new Books();
            var message = new Messages();

            while(userActive)
            {
                api.Ping(userId);
                int userChoice = userHomeMenu.UserMenu();
                switch(userChoice)
                {

                    case 1:
                        api.Ping(userId);
                        var categoryChoice = bookCategories.CategoriesMenu();
                        if (categoryChoice == 1)
                        {
                            var listOfCategories = api.GetCategories();
                            bookCategories.ListCategories(listOfCategories);
                        }
                        if (categoryChoice == 2)
                        {
                            var keyword = bookCategories.SpecificCategoryKeyword();
                            var keyCategory = api.GetCategories(keyword);
                            bookCategories.ListCategories(keyCategory);
                        }
                        if (categoryChoice == 3)
                        {
                            var specificID = bookCategories.SpecificCategoryId();
                            var specificCategory = api.GetCategory(specificID);
                            bookCategories.ListBook(specificCategory);
                        }
                        
                        break;

                    case 2:
                        api.Ping(userId);
                        var booksChoice = listBooks.BooksMenu();
                        if(booksChoice == 1)
                        {
                           
                            var listOfCategories = api.GetCategories();
                            bookCategories.ListCategories(listOfCategories);
                            var categoryId = listBooks.SpecificBooksInCategory();
                            var listOfBooks = api.GetAvailableBooks(categoryId);
                            listBooks.ListAllBooks(listOfBooks);
                            int choice = listBooks.BuyBookOption();
                            if(choice > 0)
                            {
                                int bookNumber = listOfBooks.ToList()[choice - 1].Id;
                                bool bought = api.BuyBook(userId, bookNumber);
                                if (bought == true)
                                {
                                    message.SuccessMessage();
                                    Console.ReadKey();
                                }
                                if (bought == false)
                                {
                                    message.FailMessage();
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                message.ReturnMessage();
                            }
                        }

                        if(booksChoice == 2)
                        {
                           
                            var userWord = listBooks.SpecificBookKeyword();
                            var chosenBook = api.GetBooks(userWord);
                            listBooks.ListAllBooks(chosenBook);
                            int choice = listBooks.BuyBookOption();
                            if(choice > 0)
                            {
                                bool bought = api.BuyBook(userId, choice);
                                if (bought == true)
                                {
                                    message.SuccessMessage();
                                    Console.ReadKey();
                                }
                                if (bought == false)
                                {
                                    message.FailMessage();
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                message.ReturnMessage();
                            }
                        }
                        if(booksChoice == 3)
                        {
                            
                            int choice = listBooks.SpecificBookId();
                            var book = api.GetBook(choice);
                            listBooks.ListAllBooks(book);
                            int bookChoice = listBooks.BuyBookOption();
                            if (bookChoice > 0)
                            {
                                bool bought = api.BuyBook(userId, bookChoice);
                                if (bought == true)
                                {
                                    message.SuccessMessage();
                                    Console.ReadKey();
                                }
                                if (bought == false)
                                {
                                    message.FailMessage();
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                message.ReturnMessage();
                            }

                        }
                        if (booksChoice == 4)
                        {
                            
                            string authorChoice = listBooks.BookByAuthor();
                            var authorBook = api.GetAuthors(authorChoice);
                            listBooks.ListAllBooks(authorBook);
                            int bookChoice = listBooks.BuyBookOption();
                            if (bookChoice > 0)
                            {
                                bool bought = api.BuyBook(userId, bookChoice);
                                if (bought == true)
                                {
                                    message.SuccessMessage();
                                    Console.ReadKey();
                                }
                                if (bought == false)
                                {
                                    message.FailMessage();
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                message.ReturnMessage();
                            }

                        }

                        break;

                    case 3:
                        api.Ping(userId);
                        api.LogOut(userId);
                        userActive = false;
                        break;

                }

            }



        }

    }
}
