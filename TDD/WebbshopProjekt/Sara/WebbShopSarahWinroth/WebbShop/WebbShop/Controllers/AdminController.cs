using System;
using System.Collections.Generic;
using WebbShop.Utils;
using WebbShop.Views.Admin;
using WebbShop.Views.Home;
using WebbShop.Views.Shared;

namespace WebbShop.Controllers
{
    internal class AdminController
    {
        public static WebbShopApi.API api = new WebbShopApi.API();
        public static UserAccessController userAccess = new UserAccessController();
        public static UserController userController = new UserController();
        /// <summary>
        /// Metoden tar emot input/namn och hämtar användarens Id genom namnet och sätter kolumnen IsActive till true genom Id.
        /// </summary>
        public void ActivateUser(int userId)
        {
            Console.Clear();
            bool loggedIn = api.CheckSessionTimer(userId);
            if (loggedIn)
            {
                string name = AdminView.ActivateUser();
                int activateUserId = api.GetUserId(name);
                bool userActivated = api.Activate(userId, activateUserId);
                if (userActivated)
                {
                    MessageView.ActivateUserSucceeded();
                    MessageView.BackToMenu();
                }
                else
                {
                    MessageView.ActivateUserFailed();
                    MessageView.BackToMenu();
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
        /// Lägger till en bok i databasen. Om boken redan finns så plussas den bokens Amount med 1.
        /// </summary>
        public void Addbook(int userId)
        {
            Console.Clear();
            bool loggedIn = api.CheckSessionTimer(userId);
            if (loggedIn)
            {
                WebbShopApi.Models.Book book = AdminView.AddBook();
                bool bookAdded = api.AddBook(userId, book.Title, book.Author, book.Price, book.Amount);
                if (bookAdded)
                {
                    MessageView.AddBookSucceeded();
                    MessageView.BackToMenu();
                }
                else
                {
                    MessageView.AddBookFailed();
                    MessageView.BackToMenu();
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
        /// Metoden hämtar bokens id och kategorins id genom inputs från användaren och om 
        /// båda existerar så anges kategorins id i bokens categoryId
        /// </summary>
        public void AddBookToCategory(int userId)
        {
            Console.Clear();
            bool loggedIn = api.CheckSessionTimer(userId);
            if (loggedIn)
            {
                string title = AdminView.GetBookToAddCategory();
                string category = AdminView.GetCategoryToAddToBook();
                int bookId = api.GetBookId(title);
                int categoryId = api.GetCategoryId(category);
                if (bookId != 0 && categoryId != 0)
                {
                    bool categoryAdded = api.AddBookToCategory(userId, bookId, categoryId);
                    if (categoryAdded)
                    {
                        MessageView.AddCategorySucceeded();
                        MessageView.BackToMenu();
                    }
                    else
                    {
                        MessageView.AddCategoryFailed();
                        MessageView.BackToMenu();
                    }
                }
                else
                {
                    MessageView.BookOrCategoryDontExist();
                    MessageView.BackToMenu();
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
        /// Lägger till en ny kategori i databasen.
        /// </summary>
        public void AddCategory(int userId)
        {
            Console.Clear();
            bool loggedIn = api.CheckSessionTimer(userId);
            if (loggedIn)
            {
                string name = AdminView.AddCategory();
                bool categoryAdded = api.AddCategory(userId, name);
                if (categoryAdded)
                {
                    MessageView.AddCategorySucceeded();
                    MessageView.BackToMenu();
                }
                else
                {
                    MessageView.AddCategoryFailed();
                    MessageView.BackToMenu();
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
        /// Lägger till en användare i databasen.
        /// </summary>
        public void AddUser(int userId)
        {
            Console.Clear();
            bool loggedIn = api.CheckSessionTimer(userId);
            if (loggedIn)
            {
                var user = AdminView.AddUser();
                bool userAdded = api.AddUser(userId, user.Name, user.Password);
                if (userAdded)
                {
                    MessageView.AddUserSucceeded();
                    MessageView.BackToMenu();
                }
                else
                {
                    MessageView.AddUserFailed();
                    MessageView.BackToMenu();
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
        /// Meny som visar all hantering och valmöjligheter av böcker
        /// </summary>
        public void BookMenu(int userId)
        {
            try
            {
                bool run = true;

                while (run)
                {
                    int input = AdminView.BookMenu();

                    switch (input)
                    {
                        case 1:
                            userController.GetInfoAboutBook(userId);
                            break;

                        case 2:
                            userController.SearchBooks(userId);
                            break;

                        case 3:
                            userController.SearchBooksByAuthor(userId);
                            break;

                        case 4:
                            userController.GetAllAvailebleBooks(userId);
                            break;

                        case 5:
                            userController.SearchBooksByCategory(userId);
                            break;

                        case 6:
                            Addbook(userId);
                            break;

                        case 7:
                            UpdateBook(userId);
                            break;

                        case 8:
                            DeleteBook(userId);
                            break;

                        case 9:
                            AddBookToCategory(userId);
                            break;

                        case 10:
                            SetAmountOfBook(userId);
                            break;

                        case 11:
                            ListAllSoldBooks(userId);
                            break;

                        case 12:
                            MoneyEarned(userId);
                            break;

                        case 0:
                            Menu(userId);
                            run = false;
                            break;
                    }
                }
            }
            catch
            {
                MessageView.WrongInput();
                BookMenu(userId);
            }
        }
        /// <summary>
        /// Meny som visar all hantering och valmöjligheter av kategorier
        /// </summary>
        public void CategoryMenu(int userId)
        {
            try
            {
                bool run = true;

                while (run)
                {
                    int input = AdminView.CategoryMenu();

                    switch (input)
                    {
                        case 1:
                            userController.SearchCategory(userId);
                            break;

                        case 2:
                            userController.GetCategories(userId);
                            break;

                        case 3:
                            AddCategory(userId);
                            break;

                        case 4:
                            UpdateCategory(userId);
                            break;

                        case 5:
                            DeleteCategory(userId);
                            break;

                        case 0:
                            Menu(userId);
                            run = false;
                            break;
                    }
                }
            }
            catch
            {
                MessageView.WrongInput();
                CategoryMenu(userId);
            }
        }
        /// <summary>
        /// Tar bort en bok. Genom att söka på bokens titel så minskas den bokens Amount med 1. 
        /// Om Amount är 0 så tas hela boken bort från databasen.
        /// </summary>
        public void DeleteBook(int userId)
        {
            Console.Clear();
            bool keepGoing = true;
            bool loggedIn = api.CheckSessionTimer(userId);
            if (loggedIn)
            {
                string input = AdminView.GetBookToDelete();
                while (keepGoing)
                {
                    int bookId = api.GetBookId(input);
                    if (bookId != 0)
                    {
                        var book = api.GetBook(bookId);
                        PrintView.Item(book.ToString());
                        var userInput = AdminView.DeleteBook();

                        if (userInput.Trim().ToLower() == "q")
                        {
                            keepGoing = false;
                        }
                        else
                        {
                            bool bookDeleted = api.DeleteBook(userId, bookId);
                            if (bookDeleted)
                            {
                                MessageView.BookDeleteSucceeded();
                            }
                            else
                            {
                                MessageView.BookDeleteFailed();
                            }
                        }
                    }
                    else
                    {
                        MessageView.BookSearchFailed();
                    }
                    MessageView.BackToMenu();
                    keepGoing = false;
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
        /// Användaren matar in vilken kategori som skall hanteras och kategorin tas bort från databasen.
        /// </summary>
        public void DeleteCategory(int userId)
        {
            Console.Clear();
            bool keepGoing = true;
            bool loggedIn = api.CheckSessionTimer(userId);
            if (loggedIn)
            {
                string userInput = AdminView.GetCategoryToDelete();
                while (keepGoing)
                {
                    int categoryId = api.GetCategoryId(userInput);
                    if (categoryId != 0)
                    {
                        WebbShopApi.Models.Category category = api.GetACategory(categoryId);
                        PrintView.CategoryItem(category.ToString());
                        string input = AdminView.DeleteCategory();

                        if (input.Trim().ToLower() == "q")
                        {
                            keepGoing = false;
                        }
                        else
                        {
                            bool categoryDeleted = api.DeleteCategory(userId, categoryId);
                            if (categoryDeleted)
                            {
                                MessageView.CategoryDeleteSucceeded();
                            }
                            else
                            {
                                MessageView.CategoryDeleteFailed();
                            }
                        }
                    }
                    else
                    {
                        MessageView.CategorySearchFailed();
                    }
                    MessageView.BackToMenu();
                    keepGoing = false;
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
        /// Nedgraderar användaren från IsAdmin = true till IsAdmin = false.
        /// </summary>
        public void DemoteUser(int userId)
        {
            Console.Clear();
            bool loggedIn = api.CheckSessionTimer(userId);
            if (loggedIn)
            {
                string name = AdminView.DemoteUser();
                int demoteUserId = api.GetUserId(name);
                bool userDemoted = api.Demote(userId, demoteUserId);
                if (userDemoted)
                {
                    MessageView.DemoteUserSucceeded();
                    MessageView.BackToMenu();
                }
                else
                {
                    MessageView.DemoteUserFailed();
                    MessageView.BackToMenu();
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
        /// Söker efter användare och skriver ut dess uppgifter.
        /// </summary>
        public void FindUser(int userId)
        {
            Console.Clear();
            bool loggedIn = api.CheckSessionTimer(userId);
            if (loggedIn)
            {
                string input = AdminView.FindUser();
                var users = api.FindUser(userId, input);
                Util.PrintList(users);
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
        /// Hämtar och skriver ut namnet på användaren som köpt flest böcker.
        /// </summary>
        public void GetBestCustomer(int userId)
        {
            Console.Clear();
            bool loggedIn = api.CheckSessionTimer(userId);
            if (loggedIn)
            {
                AdminView.ShowBestCostumer();
                string user = api.BestCustomer(userId);
                if (user != string.Empty)
                {
                    AdminView.BestCostumer(user);
                }
                else
                {
                    MessageView.GetBestCustomerFailed();
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
        /// Metoden tar emot input/namn och hämtar användarens Id genom namnet och sätter kolumnen IsActive till false genom Id.
        /// </summary>
        public void InactivateUser(int userId)
        {
            Console.Clear();
            bool loggedIn = api.CheckSessionTimer(userId);
            if (loggedIn)
            {
                string name = AdminView.InactivateUser();
                int inactivateUserId = api.GetUserId(name);
                bool userInactivated = api.Inactivate(userId, inactivateUserId);
                if (userInactivated)
                {
                    MessageView.InactivateUserSucceeded();
                    MessageView.BackToMenu();
                }
                else
                {
                    MessageView.InactivateUserFailed();
                    MessageView.BackToMenu();
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
        /// Skriver ut information om alla sålda böcker.
        /// </summary>
        public void ListAllSoldBooks(int userId)
        {
            Console.Clear();
            bool loggedIn = api.CheckSessionTimer(userId);
            if (loggedIn)
            {
                AdminView.ListAllSoldBooks();
                var soldBooks = api.SoldItems(userId);
                Util.PrintList(soldBooks);
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
        /// Skriver ut information om alla användare.
        /// </summary>
        public void ListAllUsers(int userId)
        {
            Console.Clear();
            bool loggedIn = api.CheckSessionTimer(userId);
            if (loggedIn)
            {
                AdminView.ListAllUsers();
                List<WebbShopApi.Models.User> users = api.ListUsers(userId);
                Util.PrintList(users);
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
        /// Admins huvudmeny där admin kan välja att hantera böcker, användare eller kategorier
        /// </summary>
        public void Menu(int userId)
        {
            try
            {
                bool run = true;

                while (run)
                {
                    int input = AdminView.Menu();

                    switch (input)
                    {
                        case 1:
                            UserMenu(userId);
                            break;

                        case 2:
                            BookMenu(userId);
                            break;

                        case 3:
                            CategoryMenu(userId);
                            break;

                        case 4:
                            userController.UpdateSite(userId);
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
        /// Visar vinsten av alla sålda böcker.
        /// </summary>
        public void MoneyEarned(int userId)
        {
            Console.Clear();
            bool loggedIn = api.CheckSessionTimer(userId);
            if (loggedIn)
            {
                AdminView.ShowMoneyEarned();
                int money = api.MoneyEarned(userId);
                if (money != 0)
                {
                    AdminView.MoneyEarned(money);
                }
                else
                {
                    MessageView.GetMoneyEarnedFailed();
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
        /// Uppgraderar användare till Admin och ändrar användarens IsAdmin = true.
        /// </summary>
        public void PromoteUser(int userId)
        {
            Console.Clear();
            bool loggedIn = api.CheckSessionTimer(userId);
            if (loggedIn)
            {
                string name = AdminView.PromoteUser();
                int promoteUserId = api.GetUserId(name);
                bool userPromoted = api.Promote(userId, promoteUserId);
                if (userPromoted)
                {
                    MessageView.PromoteUserSucceeded();
                    MessageView.BackToMenu();
                }
                else
                {
                    MessageView.PromoteUserFailed();
                    MessageView.BackToMenu();
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
        /// Metoden lägger till ett önskat antal/nummer till en boks Amount.
        /// </summary>
        public void SetAmountOfBook(int userId)
        {
            Console.Clear();
            bool loggedIn = api.CheckSessionTimer(userId);
            if (loggedIn)
            {
                string input = AdminView.GetBookToSetAmount();
                int bookId = api.GetBookId(input);
                if (bookId != 0)
                {
                    var book = api.GetBook(bookId);
                    PrintView.Item(book.ToString());
                    int newAmount = AdminView.SetAmountOfBook();
                    api.SetAmount(userId, bookId, newAmount);
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
        /// Söker efter en bok genom titel och hämtar bokens id. Boken uppdaterar sedan med de uppgifter som matas in av användare.
        /// </summary>
        public void UpdateBook(int userId)
        {
            Console.Clear();
            bool loggedIn = api.CheckSessionTimer(userId);
            if (loggedIn)
            {
                string oldTitle = AdminView.GetBookToUpdate();
                int bookId = api.GetBookId(oldTitle);
                var book = AdminView.UpdateBook();

                if (bookId != 0)
                {
                    bool bookUpdated = api.UpdateBook(userId, bookId, book.Title, book.Author, book.Price);
                    if (bookUpdated)
                    {
                        MessageView.BookUpdateSucceeded();
                    }
                    else
                    {
                        MessageView.BookUpdateFailed();
                    }
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
        /// Söker efter en kategori genom namn och hämtar kategorins id. Kategorin uppdateras sedan med de uppgifter som matas in av användare.
        /// </summary>
        public void UpdateCategory(int userId)
        {
            Console.Clear();
            bool loggedIn = api.CheckSessionTimer(userId);
            if (loggedIn)
            {
                var categoryName = AdminView.GetCategoryToUpdate();
                int categoryId = api.GetCategoryId(categoryName);

                if (categoryId != 0)
                {
                    string newCategoryName = AdminView.UpdateCategory();
                    bool categoryUpdated = api.UpdateCategory(userId, categoryId, newCategoryName);
                    if (categoryUpdated)
                    {
                        MessageView.CategoryUpdateSucceeded();
                    }
                    else
                    {
                        MessageView.CategoryUpdateFailed();
                    }
                }
                else
                {
                    MessageView.CategorySearchFailed();
                }
                MessageView.BackToMenu();
                Console.ReadLine();
            }
            else
            {
                api.Logout(userId);
                MessageView.TimedOut();
                userAccess.VerifyUser();
            }
        }
        /// <summary>
        /// Meny som visar all hantering och valmöjligheter av användare
        /// </summary>
        public void UserMenu(int userId)
        {
            try
            {
                bool run = true;

                while (run)
                {
                    int input = AdminView.UserMenu();

                    switch (input)
                    {
                        case 1:
                            ListAllUsers(userId);
                            break;

                        case 2:
                            FindUser(userId);
                            break;

                        case 3:
                            AddUser(userId);
                            break;

                        case 4:
                            PromoteUser(userId);
                            break;

                        case 5:
                            DemoteUser(userId);
                            break;

                        case 6:
                            ActivateUser(userId);
                            break;

                        case 7:
                            InactivateUser(userId);
                            break;

                        case 8:
                            GetBestCustomer(userId);
                            break;

                        case 0:
                            Menu(userId);
                            run = false;
                            break;
                    }
                }
            }
            catch
            {
                MessageView.WrongInput();
                UserMenu(userId);
            }
        }
    }
}