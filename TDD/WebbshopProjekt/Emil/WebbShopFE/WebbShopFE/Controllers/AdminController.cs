using System;
using WebbShopEmil;
using WebbShopFE.Helper;
using WebbShopFE.Views;

namespace WebbShopFE.Controllers
{
    /// <summary>
    /// Methods that uses the webbShopAPI. The methods are only used by an Admin.
    /// </summary>
    internal class AdminController
    {
        private readonly WebbShopAPI api = new();

        /// <summary>
        /// Takes input from Admin
        /// and uses the WebbShopAPI to activate user.
        /// </summary>
        /// <param name="adminId"></param>
        internal void ActivateUser(int adminId)
        {
            api.Ping(adminId);

            var list = api.ListUsers(adminId);
            UserView.ShowUsers(list);

            InputView.AskForChoice();
            int.TryParse(Console.ReadLine(), out int userId);

            var result = api.ActivateUser(adminId, userId);
            HelpMethods.SuccessOrNot(result);
        }

        /// <summary>
        /// Takes input from Admin
        /// and uses the WebbShopAPI to add book.
        /// </summary>
        /// <param name="adminId"></param>
        internal void AddBook(int adminId)
        {
            api.Ping(adminId);

            InputView.AskForTitle();
            var title = Console.ReadLine();

            InputView.AskForAuthor();
            var author = Console.ReadLine();

            InputView.AskForPrice();
            int.TryParse(Console.ReadLine(), out int price);

            InputView.AskForAmount();
            int.TryParse(Console.ReadLine(), out int amount);

            var result = api.AddBook(adminId, title, author, price, amount);
            HelpMethods.SuccessOrNot(result);
        }

        /// <summary>
        /// Takes input from Admin
        /// and uses the WebbShopAPI to add book to category.
        /// </summary>
        /// <param name="adminId"></param>
        internal void AddBookToCategory(int adminId)
        {
            api.Ping(adminId);

            var listOfBooks = api.GetAllBooks();
            BookView.ShowBooks(listOfBooks);

            InputView.AskForBookId();
            int.TryParse(Console.ReadLine(), out int bookId);

            var listOfCategories = api.GetCategories();
            CategoryView.ShowCategory(listOfCategories);

            InputView.AskForChoice();
            int.TryParse(Console.ReadLine(), out int categoryId);

            var result = api.AddBookToCategory(adminId, bookId, categoryId);
            HelpMethods.SuccessOrNot(result);
        }

        /// <summary>
        /// Takes input from Admin
        /// and uses the WebbShopAPI to add category.
        /// </summary>
        /// <param name="adminId"></param>
        internal void AddCategory(int adminId)
        {
            api.Ping(adminId);

            InputView.AskForName();
            var input = Console.ReadLine();

            var result = api.AddCategory(adminId, input);
            HelpMethods.SuccessOrNot(result);
        }

        /// <summary>
        /// Takes input from Admin
        /// and uses the WebbShopAPI to add a new user.
        /// </summary>
        /// <param name="adminId"></param>
        internal void AddUser(int adminId)
        {
            api.Ping(adminId);

            InputView.AskForName();
            var username = Console.ReadLine();

            InputView.AskForPassword();
            var password = Console.ReadLine().Trim();

            var result = api.AddUser(adminId, username, password);
            HelpMethods.SuccessOrNot(result);
        }

        /// <summary>
        /// Admin uses the WebbShopAPI to show best customer.
        /// </summary>
        /// <param name="adminId"></param>
        internal void BestCustomer(int adminId)
        {
            api.Ping(adminId);

            var user = api.BestCostomer(adminId);
            UserView.DisplayBestCustomer(user);
        }

        /// <summary>
        /// Takes input from Admin
        /// and uses the WebbShopAPI to delete book.
        /// </summary>
        /// <param name="adminID"></param>
        internal void DeleteBook(int adminID)
        {
            api.Ping(adminID);

            var list = api.GetAllBooks();
            BookView.ShowBooks(list);

            InputView.AskForChoice();
            int.TryParse(Console.ReadLine(), out int bookId);

            var result = api.DeleteBook(adminID, bookId);
            HelpMethods.SuccessOrNot(result);
        }

        /// <summary>
        /// Takes input from Admin
        /// and uses the WebbShopAPI to delete category.
        /// </summary>
        /// <param name="adminId"></param>
        internal void DeleteCategory(int adminId)
        {
            api.Ping(adminId);

            var listOfCategories = api.GetCategories();
            CategoryView.ShowCategory(listOfCategories);

            InputView.AskForChoice();
            int.TryParse(Console.ReadLine(), out int categoryId);

            var result = api.DeleteCategory(adminId, categoryId);
            HelpMethods.SuccessOrNot(result);
        }

        /// <summary>
        /// Takes input from Admin
        /// and uses the WebbShopAPI to demote a user.
        /// </summary>
        /// <param name="adminId"></param>
        internal void Demote(int adminId)
        {
            api.Ping(adminId);

            var list = api.ListUsers(adminId);
            UserView.ShowUsers(list);

            InputView.AskForChoice();
            int.TryParse(Console.ReadLine(), out int userId);

            var result = api.Demote(adminId, userId);
            HelpMethods.SuccessOrNot(result);
        }

        /// <summary>
        /// Takes input from Admin
        /// and uses the WebbShopAPI to find matching users.
        /// </summary>
        /// <param name="adminId"></param>
        internal void FindUser(int adminId)
        {
            api.Ping(adminId);

            InputView.AskForKeyword();
            var keyword = Console.ReadLine();

            var list = api.FindUsers(adminId, keyword);
            UserView.ShowUsers(list);
        }

        /// <summary>
        /// Takes input from Admin
        /// and uses the WebbShopAPI to inactivate user.
        /// </summary>
        /// <param name="adminId"></param>
        internal void InActivateUser(int adminId)
        {
            api.Ping(adminId);

            var list = api.ListUsers(adminId);
            UserView.ShowUsers(list);

            InputView.AskForChoice();
            int.TryParse(Console.ReadLine(), out int userId);

            var result = api.InactivateUser(adminId, userId);
            HelpMethods.SuccessOrNot(result);
        }

        /// <summary>
        /// Admin uses the WebbShopAPI to list users.
        /// </summary>
        /// <param name="adminId"></param>
        internal void ListUsers(int adminId)
        {
            api.Ping(adminId);

            var list = api.ListUsers(adminId);
            UserView.ShowUsers(list);
        }

        /// <summary>
        /// Admin uses the WebbShopAPI to show earned money.
        /// </summary>
        /// <param name="adminId"></param>
        internal void MoneyEarned(int adminId)
        {
            api.Ping(adminId);

            var sumOfSoldBooks = api.MoneyEarned(adminId);
            BookView.DisplayMoney(sumOfSoldBooks);
        }

        /// <summary>
        /// Takes input from Admin
        /// and uses the WebbShopAPI to promote user.
        /// </summary>
        /// <param name="adminId"></param>
        internal void Promote(int adminId)
        {
            api.Ping(adminId);

            var list = api.ListUsers(adminId);
            UserView.ShowUsers(list);

            InputView.AskForChoice();
            int.TryParse(Console.ReadLine(), out int userId);

            var result = api.Promote(adminId, userId);
            HelpMethods.SuccessOrNot(result);
        }

        /// <summary>
        /// Takes input from Admin
        /// and uses the WebbShopAPI to set amount of book.
        /// </summary>
        /// <param name="adminId"></param>
        internal void SetAmount(int adminId)
        {
            api.Ping(adminId);

            var list = api.GetAllBooks();
            BookView.ShowBooks(list);

            InputView.AskForChoice();
            int.TryParse(Console.ReadLine(), out int choice);

            InputView.AskForAmount();
            int.TryParse(Console.ReadLine(), out int amount);

            api.SetAmount(adminId, choice, amount);
            BookView.NewAmount(amount);
        }

        /// <summary>
        /// Admin uses the WebbShopAPI to show sold items.
        /// </summary>
        /// <param name="adminId"></param>
        internal void SoldItems(int adminId)
        {
            api.Ping(adminId);

            var listSold = api.SoldItems(adminId);
            BookView.ShowSoldItems(listSold);
        }

        /// <summary>
        /// Takes input from Admin
        /// and uses the WebbShopAPI to update book.
        /// </summary>
        /// <param name="adminId"></param>
        internal void UpdateBook(int adminId)
        {
            api.Ping(adminId);

            var list = api.GetAllBooks();
            BookView.ShowBooks(list);

            InputView.AskForBookId();
            int.TryParse(Console.ReadLine(), out int bookId);

            InputView.AskForTitle();
            var title = Console.ReadLine();

            InputView.AskForAuthor();
            var author = Console.ReadLine();

            InputView.AskForPrice();
            int.TryParse(Console.ReadLine(), out int price);

            var result = api.UpdateBook(adminId, bookId, title, author, price);
            HelpMethods.SuccessOrNot(result);
        }

        /// <summary>
        /// Takes input from Admin
        /// and uses the WebbShopAPI to update category.
        /// </summary>
        /// <param name="adminId"></param>
        internal void UpdateCategory(int adminId)
        {
            api.Ping(adminId);

            var listOfCategories = api.GetCategories();
            CategoryView.ShowCategory(listOfCategories);

            InputView.AskForChoice();
            int.TryParse(Console.ReadLine(), out int categoryId);

            InputView.AskForName();
            var categoryName = Console.ReadLine();

            var result = api.UpdateCategory(adminId, categoryId, categoryName);
            HelpMethods.SuccessOrNot(result);
        }
    }
}