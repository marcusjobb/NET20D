using System;
using System.Collections.Generic;
using WebbShop.Utils;
using WebbShop.Views.Home;
using WebbShop.Views.Shared;
using WebbShop.Views.User;

namespace WebbShop.Controllers
{
    internal class UserController
    {
        public static WebbShopApi.API api = new WebbShopApi.API();
        public static UserAccessController userAccess = new UserAccessController();
        /// <summary>
        /// Användaren söker efter en bok och köper den. (Bokens Amount minskas med 1 och bokens uppgifter kopieras till tabellen SoldBooks)
        /// </summary>
        public void BuyBook(int userId)
        {
            Console.Clear();
            bool keepBuying = true;
            bool loggedIn = api.CheckSessionTimer(userId);
            if (loggedIn)
            {
                string input = UserView.GetBookToBuy();
                while (keepBuying)
                {
                    int bookId = api.GetBookId(input);
                    if (bookId != 0)
                    {
                        WebbShopApi.Models.Book book = api.GetBook(bookId);
                        PrintView.Item(book.ToString());
                        string userInput = UserView.BuyBook();

                        if (userInput.Trim().ToLower() == "q")
                        {
                            keepBuying = false;
                        }
                        else
                        {
                            bool purchased = api.BuyBook(userId, bookId);
                            if (purchased)
                            {
                                MessageView.PurchaseSucceeded();
                            }
                            else
                            {
                                MessageView.PurchaseFailed();
                            }
                        }
                    }
                    else
                    {
                        MessageView.BookSearchFailed();
                    }
                    MessageView.BackToMenu();
                    keepBuying = false;
                }
            }
            else
            {
                api.Logout(userId);
                MessageView.TimedOut();
                userAccess.VerifyUser();
            }
        }
        /// <summary>
        /// Hämtar och skriver ut alla tillgängliga böcker som finns i databasen (där bok Amount är mer än 0).
        /// </summary>
        public void GetAllAvailebleBooks(int userId)
        {
            Console.Clear();
            bool loggedIn = api.CheckSessionTimer(userId);
            if (loggedIn)
            {
                string input = UserView.GetAllAvailableBooks();
                int categoryId = api.GetCategoryId(input);
                if (categoryId != 0)
                {
                    List<WebbShopApi.Models.Book> books = api.GetAvailableBooks(categoryId);
                    if(books.Count == 0)
                    {
                        MessageView.BookSearchFailed();
                    }
                    Util.PrintList(books);
                }
                else
                {
                    MessageView.BookSearchFailed();
                }
                MessageView.BackToMenu();
            }
            else
            {
                api.Logout(userId);
                MessageView.TimedOut();
                userAccess.VerifyUser();
            }
        }
        /// <summary>
        /// Hämtar och skriver ut alla kategorier som finns i databasen.
        /// </summary>
        public void GetCategories(int userId)
        {
            Console.Clear();
            bool loggedIn = api.CheckSessionTimer(userId);
            if (loggedIn)
            {
                UserView.AllCategories();
                List<WebbShopApi.Models.Category> categories = api.GetCategories();
                if (categories.Count != 0)
                {
                    Util.PrintList(categories);
                }
                else
                {
                    MessageView.CategorySearchFailed();
                }
                MessageView.BackToMenu();
            }
            else
            {
                api.Logout(userId);
                MessageView.TimedOut();
                userAccess.VerifyUser();
            }
        }
        /// <summary>
        /// Hämtar information om en bok i databasen genom att söka på bokens titel och får man fram Id som man hämtar boken genom.
        /// </summary>
        public void GetInfoAboutBook(int userId)
        {
            Console.Clear();
            bool loggedIn = api.CheckSessionTimer(userId);
            if (loggedIn)
            {
                string input = UserView.GetInfoAboutBook();
                int bookId = api.GetBookId(input);
                if (bookId != 0)
                {
                    WebbShopApi.Models.Book book = api.GetBook(bookId);
                    PrintView.Item(book.ToString());
                }
                else
                {
                    MessageView.BookSearchFailed();
                }
                MessageView.BackToMenu();
            }
            else
            {
                api.Logout(userId);
                MessageView.TimedOut();
                userAccess.VerifyUser();
            }
        }
        /// <summary>
        /// Användarens huvudmeny.
        /// </summary>
        public void Menu(int userId)
        {
            try
            {
                bool run = true;

                while (run)
                {
                    int input = UserView.Menu();

                    switch (input)
                    {
                        case 1:
                            GetCategories(userId);
                            break;

                        case 2:
                            SearchCategory(userId);
                            break;

                        case 3:
                            SearchBooksByCategory(userId);
                            break;

                        case 4:
                            GetAllAvailebleBooks(userId);
                            break;

                        case 5:
                            GetInfoAboutBook(userId);
                            break;

                        case 6:
                            SearchBooks(userId);
                            break;

                        case 7:
                            SearchBooksByAuthor(userId);
                            break;

                        case 8:
                            BuyBook(userId);
                            break;

                        case 9:
                            UpdateSite(userId);
                            break;

                        case 0:
                            api.Logout(userId);
                            UserAccessView.Logout();
                            run = false;
                            break;
                    }
                }
            }
            catch
            {
                MessageView.WrongInput();
                Menu(userId);
            }
        }
        /// <summary>
        /// Söker efter böcker som matchar inmatningen från användaren.
        /// </summary>
        public void SearchBooks(int userId)
        {
            Console.Clear();
            bool loggedIn = api.CheckSessionTimer(userId);
            if (loggedIn)
            {
                string input = UserView.SearchBooks();
                List<WebbShopApi.Models.Book> books = api.GetBooks(input);
                if (books.Count != 0)
                {
                    Util.PrintList(books);
                }
                else
                {
                    MessageView.BookSearchFailed();
                }
                MessageView.BackToMenu();
            }
            else
            {
                api.Logout(userId);
                MessageView.TimedOut();
                userAccess.VerifyUser();
            }
        }
        /// <summary>
        /// Söker efter böcker vars författare matchar inmatningen från användaren.
        /// </summary>
        public void SearchBooksByAuthor(int userId)
        {
            Console.Clear();
            bool loggedIn = api.CheckSessionTimer(userId);
            if (loggedIn)
            {
                string input = UserView.SearchBooksByAuthor();
                List<WebbShopApi.Models.Book> books = api.GetAuthors(input);
                if (books.Count != 0)
                {
                    Util.PrintList(books);
                }
                else
                {
                    MessageView.BookSearchFailed();
                }
                MessageView.BackToMenu();
            }
            else
            {
                api.Logout(userId);
                MessageView.TimedOut();
                userAccess.VerifyUser();
            }
        }
        /// <summary>
        /// Söker efter böcker som är kopplad till den kategori som matchar inmatningen från användaren.
        /// </summary>
        public void SearchBooksByCategory(int userId)
        {
            Console.Clear();
            bool loggedIn = api.CheckSessionTimer(userId);
            if (loggedIn)
            {
                string input = UserView.SearchBooksByCategory();
                int categoryId = api.GetCategoryId(input);
                if (categoryId != 0)
                {
                    List<WebbShopApi.Models.Book> books = api.GetCategory(categoryId);
                    Util.PrintList(books);
                }
                else
                {
                    MessageView.BookSearchFailed();
                }
                MessageView.BackToMenu();
            }
            else
            {
                api.Logout(userId);
                MessageView.TimedOut();
                userAccess.VerifyUser();
            }
        }
        /// <summary>
        /// Söker efter kategorier som matchar inmatningen från användaren.
        /// </summary>
        public void SearchCategory(int userId)
        {
            Console.Clear();
            bool loggedIn = api.CheckSessionTimer(userId);
            if (loggedIn)
            {
                string input = UserView.SearchCategory();
                List<WebbShopApi.Models.Category> categories = api.GetCategories(input);
                if (categories.Count != 0)
                {
                    Util.PrintList(categories);
                }
                else
                {
                    MessageView.CategorySearchFailed();
                }
                MessageView.BackToMenu();
            }
            else
            {
                api.Logout(userId);
                MessageView.TimedOut();
                userAccess.VerifyUser();
            }
        }
        /// <summary>
        /// Uppdaterar/reset användarens SessionTimer om avändaren varit aktiv inom de senaste 15 minuterna
        /// </summary>
        public void UpdateSite(int userId)
        {
            string message = api.Ping(userId);
            if (message != string.Empty)
            {
                MessageView.ConnectionReset(message);
                MessageView.BackToMenu();
            }
            else
            {
                api.Logout(userId);
                MessageView.TimedOut();
                userAccess.VerifyUser();
            }
        }
    }
}