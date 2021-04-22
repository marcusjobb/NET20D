using Inlamning2TrialRunHE;
using Inlamning2TrialRunHE.Models;
using Inlamning3HakanEriksson.Views;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Inlamning3HakanEriksson.Controllers
{
    public class UserController
    {
        public WebbShopAPI api = new WebbShopAPI();
        /// <summary>
        /// Lets the user search for a book by doing a keyword input.
        /// </summary>
        /// <param name="userId"></param>
        public void BookByKeyword(int userId)
        {
            string keyword = ViewMessages.Keyword();
            var books = api.GetBooks(keyword);
            var choice = ViewMessages.ListBooks(books, "buy");
            if (choice > 0 && choice <= books.Count)
            {
                var book = books[choice - 1];
                bool buyBook = api.BuyBook(userId, book.Id);
                if (buyBook == true) ViewMessages.ThankYou(book.Title);
            }
            else
            {
                ViewMessages.SomethingWentWrongView();
            }
        }

        public void BooksFromAuthorByKeyword(int userId)
        {
            string keyword = ViewMessages.Keyword();
            var books = api.GetAuthors(keyword);
            var choice = ViewMessages.ListBooks(books, "buy");
            if (choice > 0 && choice <= books.Count)
            {
                var book = books[choice - 1];
                bool buyBook = api.BuyBook(userId, book.Id);
                if (buyBook == true) ViewMessages.ThankYou(book.Title);
            }
            else
            {
                ViewMessages.SomethingWentWrongView();
            }
        }

        public void BooksInCategory(int userId)
        {
            var categories = api.GetCategories();
            int result = ViewMessages.ListBookCategories(categories);
            if (result == 0)
            {
                ViewMessages.SomethingWentWrongView();
            }
            else
            {
                var category = categories[result - 1];
                List<Book> books = api.GetCategory(category.Id);
                var choice = ViewMessages.ListBooks(books, "buy");
                if (choice > 0 && choice <= books.Count)
                {
                    var book = books[choice - 1];
                    var buyBook = api.BuyBook(userId, book.Id);
                    if (buyBook == true) ViewMessages.ThankYou(book.Title);
                }
                else
                {
                    ViewMessages.SomethingWentWrongView();
                }
            }
        }

        public void BooksInStock(int userId)
        {
            var categories = api.GetCategories();
            var books = new List<Book>();
            foreach (var category in categories)
            {
                books.AddRange(api.GetAvailableBooks(category.Id));
            }
            var choice = ViewMessages.ListBooks(books, "buy");
            if (choice > 0 && choice <= books.Count)
            {
                var book = books[choice - 1];
                bool buyBook = api.BuyBook(userId, book.Id);
                if (buyBook == true) ViewMessages.ThankYou(book.Title);
            }
            else
            {
                ViewMessages.SomethingWentWrongView();
            }
        }

        public void GetAllCategories()
        {
            var list = api.GetCategories();
            foreach (var category in list)
            {
                Console.WriteLine(category.Name);
            }
            ViewMessages.PressAnyKeyMessage();
            Console.Clear();
        }

        public void GetCategoriesByKeyword()
        {
            string keyword = ViewMessages.Keyword();
            var list = api.GetCategories(keyword);
            foreach (var category in list)
            {
                Console.WriteLine(category.Name);
            }
            ViewMessages.PressAnyKeyMessage();
            Console.Clear();
        }
        /// <summary>
        /// This method checks if the users login name and password
        /// match and if so if it is a administrator or regular user.
        /// and send´s the user to the correct menu.
        /// </summary>
        public void LoginUser()
        {
            var user = new User();
            var loginData = new List<string>();
            bool keepGoing = true;
            loginData = ViewMessages.LoginMessage();
            Console.Clear();
            user = api.Login(loginData[0], loginData[1]);

            if (user.Id > 0)
            {
                api.Ping(user.Id);
                if (user.IsAdmin)
                {
                    var admin = new AdminController();
                    admin.LoggedInAdmin(user);
                }
                else
                {
                    do
                    {
                        ViewMenues.LoggedInUserMenu(user);
                        string choice = Console.ReadLine();

                        switch (choice)
                        {
                            case "1":
                                BuyBook(user);
                                api.Ping(user.Id);
                                break;

                            case "2":
                                GetAllCategories();
                                api.Ping(user.Id);
                                break;

                            case "3":
                                GetCategoriesByKeyword();
                                Console.Clear();
                                api.Ping(user.Id);
                                break;

                            case "4":
                                BooksInCategory(user.Id);
                                api.Ping(user.Id);
                                break;

                            case "5":
                                BookByKeyword(user.Id);
                                api.Ping(user.Id);
                                break;

                            case "6":
                                BooksFromAuthorByKeyword(user.Id);
                                api.Ping(user.Id);
                                break;

                            case "7":
                                BooksInStock(user.Id);
                                api.Ping(user.Id);
                                break;

                            case "8":
                                ViewMessages.Exitmessage();
                                Thread.Sleep(2000);
                                api.Logout(user.Id);
                                Environment.Exit(0);

                                break;

                            default:
                                ViewMessages.SomethingWentWrongView();
                                break;
                        }
                    } while (keepGoing);
                }
            }
            else
            {
                ViewMessages.SomethingWentWrongView();
            }
        }
        /// <summary>
        /// Lets the user buy a book from the bookstore.
        /// </summary>
        /// <param name="user"></param>
        private void BuyBook(User user)
        {
            var books = api.GetAllBooks();
            var bookChoice = ViewMessages.ListBooks(books, "buy");
            if (bookChoice > 0 && bookChoice <= books.Count)
            {
                var book = books[bookChoice - 1];
                bool buyBook = api.BuyBook(user.Id, book.Id);
                if (buyBook) ViewMessages.ThankYou(book.Title);
            }
            else
            {
                ViewMessages.SomethingWentWrongView();
            }
            Thread.Sleep(1700);
            Console.Clear();
        }
        /// <summary>
        /// Lets a new user register themselfs to the bookstore.
        /// </summary>
        public void RegisterNewUser()
        {
            List<string> registerData = ViewMessages.RegisterNewUser();
            var register = api.Register(registerData[0], registerData[1], registerData[2]);

            if (register)
            {
                Console.Clear();
                LoginUser();
            }
            else
            {
                ViewMessages.SomethingWentWrongView();
            }
        }
    }
}