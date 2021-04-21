using Inlämning_3Front.Views;
using Inlämning_API;
using Inlämning_API.Models;
using System;

namespace Inlämning_3Front.Controllers
{
    public class AdminController
    {
        private WebbShopAPI api = new();
        private AdminView view = new();
        private static Controller controller = new();

        /// <summary>
        /// All methods for admin commands
        /// </summary>
        /// <param name="user"></param>
        public void AdminMenu(User user)
        {
            while (true)
            {
                view.AdminMenu(user);
                var input = Console.ReadLine();
                Console.Clear();
                switch (input.ToLower())
                {
                    case "1":
                        AddBook(user.ID);
                        break;

                    case "2":
                        SetAmount(user.ID);
                        break;

                    case "3":
                        ListUser(user.ID);
                        break;

                    case "4":
                        FindUser(user.ID);
                        break;

                    case "5":
                        UpdateBook(user.ID);
                        break;

                    case "6":
                        DeleteBook(user.ID);
                        break;

                    case "7":
                        AddCategory(user.ID);
                        break;

                    case "8":
                        AddBookToCategory(user.ID);
                        break;

                    case "9":
                        UpdateCategory(user.ID);
                        break;

                    case "10":
                        DeleteCategory(user.ID);
                        break;

                    case "11":
                        AddUser(user.ID);
                        break;

                    case "12":
                        ShowSoldBooks(user.ID);
                        break;

                    case "13":
                        ShowMoneyEarned(user.ID);
                        break;

                    case "14":
                        ShowBestCustomer(user.ID);
                        break;

                    case "15":
                        PromoteUser(user.ID);
                        break;

                    case "16":
                        DemoteUser(user.ID);
                        break;

                    case "17":
                        ActivateUser(user.ID);
                        break;

                    case "18":
                        DeactivateUser(user.ID);
                        break;

                    case "e":
                        controller.Menu(user);
                        break;

                    default:
                        MessageView.SomethingWentWrong();
                        break;
                }
                MessageView.EnterkeyToContinue();
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Sets user to Inactive
        /// </summary>
        /// <param name="adminId"></param>
        private void DeactivateUser(int adminId)
        {
            api.Ping(adminId);
            var list = api.ListUsers(adminId);
            view.ShowUsers(list);
            view.InputChoice();
            int.TryParse(Console.ReadLine(), out int choice);
            var result = api.InactiveUser(adminId, choice);
            TrueOrFalse(result);
        }

        /// <summary>
        /// Sets user to active
        /// </summary>
        /// <param name="adminId"></param>
        private void ActivateUser(int adminId)
        {
            api.Ping(adminId);
            var list = api.ListUsers(adminId);
            view.ShowUsers(list);
            view.InputChoice();
            int.TryParse(Console.ReadLine(), out int choice);
            var result = api.ActiveUser(adminId, choice);
            TrueOrFalse(result);
        }

        /// <summary>
        /// Demotes the user from admin to user
        /// </summary>
        /// <param name="adminId"></param>
        private void DemoteUser(int adminId)
        {
            api.Ping(adminId);
            var list = api.ListUsers(adminId);
            view.ShowUsers(list);
            view.InputChoice();
            int.TryParse(Console.ReadLine(), out int choice);
            var result = api.Demote(adminId, choice);
            TrueOrFalse(result);
        }

        /// <summary>
        /// Promotes the user from user to admin
        /// </summary>
        /// <param name="adminId"></param>
        private void PromoteUser(int adminId)
        {
            api.Ping(adminId);
            var list = api.ListUsers(adminId);
            view.ShowUsers(list);
            view.InputChoice();
            int.TryParse(Console.ReadLine(), out int choice);
            var result = api.Promote(adminId, choice);
            TrueOrFalse(result);
        }

        /// <summary>
        /// Show the customer who bought most books
        /// </summary>
        /// <param name="adminId"></param>
        private void ShowBestCustomer(int adminId)
        {
            api.Ping(adminId);
            var user = api.BestCustomer(adminId);
            view.DisplayUser(user);
        }

        /// <summary>
        /// Gives you the amount of sold books
        /// </summary>
        /// <param name="adminId"></param>
        private void ShowMoneyEarned(int adminId)
        {
            api.Ping(adminId);
            var sumOfSoldBooks = api.MoneyEarned(adminId);
            view.DisplayInt(sumOfSoldBooks);
        }

        /// <summary>
        /// List of All sold books
        /// </summary>
        /// <param name="adminId"></param>
        private void ShowSoldBooks(int adminId)
        {
            api.Ping(adminId);
            var listsold = api.SoldItems(adminId);
            view.ShowSoldItems(listsold);
        }

        /// <summary>
        /// Lets admin add a user
        /// </summary>
        /// <param name="adminId"></param>
        private void AddUser(int adminId)
        {
            api.Ping(adminId);
            view.AskForName();
            var username = Console.ReadLine();
            view.AskForPassword();
            var password = Console.ReadLine().Trim();
            var result = api.AddUser(adminId, username, password);
            TrueOrFalse(result);
        }

        /// <summary>
        /// Deletes a category if the category is empty
        /// </summary>
        /// <param name="adminId"></param>
        private void DeleteCategory(int adminId)
        {
            api.Ping(adminId);
            var listOfCategories = api.GetCategories();
            view.ShowCategory(listOfCategories);
            int.TryParse(Console.ReadLine(), out int catId);
            var result = api.DeleteCategory(adminId, catId);
            TrueOrFalse(result);
        }

        /// <summary>
        /// Lets the admin update a category
        /// </summary>
        /// <param name="adminId"></param>
        private void UpdateCategory(int adminId)
        {
            api.Ping(adminId);
            var listOfCategories = api.GetCategories();
            view.ShowCategory(listOfCategories);
            view.InputChoice();
            int.TryParse(Console.ReadLine(), out int catId);
            view.AskForName();
            var name = Console.ReadLine();
            var result = api.UpdateCategory(adminId, catId, name);

            TrueOrFalse(result);
        }

        /// <summary>
        /// Add a category to a book 
        /// </summary>
        /// <param name="adminId"></param>
        private void AddBookToCategory(int adminId)
        {
            api.Ping(adminId);
            var listOfBooks = api.GetAllBooks();
            view.ShowBooks(listOfBooks);
            view.AskForBookId();
            int.TryParse(Console.ReadLine(), out int bookId);
            Console.Clear();
            var listOfCategories = api.GetCategories();
            view.ShowCategory(listOfCategories);
            view.InputChoice();
            int.TryParse(Console.ReadLine(), out int catId);
            var result = api.AddBookToCategory(adminId, bookId, catId);

            TrueOrFalse(result);
        }

        /// <summary>
        /// Adds a category
        /// </summary>
        /// <param name="adminID"></param>
        private void AddCategory(int adminId)
        {
            api.Ping(adminId);
            view.AskForName();
            var input = Console.ReadLine();
            var result = api.AddCategory(adminId, input);
            TrueOrFalse(result);
        }

        /// <summary>
        /// Lets admin delete a book
        /// </summary>
        /// <param name="adminId"></param>
        private void DeleteBook(int adminId)
        {
            api.Ping(adminId);
            var list = api.GetAllBooks();
            view.ShowBooks(list);
            view.InputChoice();
            int.TryParse(Console.ReadLine(), out int input);
            var result = api.DeleteBook(adminId, input);
            TrueOrFalse(result);
        }

        /// <summary>
        /// Lets the admin update a book
        /// </summary>
        /// <param name="adminId"></param>
        private void UpdateBook(int adminId)
        {
            api.Ping(adminId);
            var list = api.GetAllBooks();
            view.ShowBooks(list);
            view.AskForBookId();
            int.TryParse(Console.ReadLine(), out int bookId);
            view.AskForTitle();
            var title = Console.ReadLine();
            view.AskForAuthor();
            var author = Console.ReadLine();
            view.AskForPrice();
            int.TryParse(Console.ReadLine(), out int price);
            var result = api.UpdateBook(adminId, bookId, title, author, price);
            TrueOrFalse(result);
        }

        /// <summary>
        /// Lets the admin search for a user by keyword
        /// </summary>
        /// <param name="adminId"></param>
        private void FindUser(int adminId)
        {
            api.Ping(adminId);
            view.EnterKeyword();
            var keyword = Console.ReadLine();
            var list = api.FindUser(adminId, keyword);
            view.ShowUsers(list);
        }

        /// <summary>
        /// Gets a list of all users
        /// </summary>
        /// <param name="adminId"></param>
        private void ListUser(int adminId)
        {
            api.Ping(adminId);
            var list = api.ListUsers(adminId);
            view.ShowUsers(list);
        }

        /// <summary>
        /// Lets admin set the amount of books
        /// </summary>
        /// <param name="adminId"></param>
        private void SetAmount(int adminId)
        {
            api.Ping(adminId);
            var list = api.GetAllBooks();
            view.ShowBooks(list);
            view.InputChoice();
            int.TryParse(Console.ReadLine(), out int choice);
            view.AskForAmount();
            int.TryParse(Console.ReadLine(), out int amount);
            api.SetAmount(adminId, choice, amount);
        }

        /// <summary>
        /// Lets admin add a book to the assortment
        /// </summary>
        /// <param name="adminId"></param>
        private void AddBook(int adminId)
        {
            api.Ping(adminId);
            view.AskForTitle();
            var title = Console.ReadLine();
            view.AskForAuthor();
            var author = Console.ReadLine();
            view.AskForPrice();
            int.TryParse(Console.ReadLine(), out int price);
            view.AskForAmount();
            int.TryParse(Console.ReadLine(), out int amount);
            view.AskForBookId();
            int.TryParse(Console.ReadLine(), out int bookId);
            var result = api.AddBook(adminId, title, author, price, amount, bookId);
            TrueOrFalse(result);
        }

        /// <summary>
        /// Checks if the return value is true or false
        /// </summary>
        /// <param name="result"></param>
        private static void TrueOrFalse(bool result)
        {
            if (result == true)
            {
                MessageView.SuccessMessage();
            }
            else
            {
                MessageView.SomethingWentWrong();
            }
        }
    }
}