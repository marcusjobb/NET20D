using System;
using System.Threading;
using WebbShopEmil;
using WebbShopEmil.Models;
using WebbShopFE.Helper;
using WebbShopFE.Views;

namespace WebbShopFE.Controllers
{
    /// <summary>
    /// All the Menu methods that controls the program flow.
    /// </summary>
    internal class MenuController
    {
        private static readonly AdminController admin = new();
        private static readonly AuthenticationController authenticat = new();
        private static readonly ShopController shop = new();
        private readonly WebbShopAPI api = new();

        /// <summary>
        /// A menu where all the Admin methods is called.
        /// </summary>
        /// <param name="user"></param>
        internal void AdminMenu(User user)
        {
            while (true)
            {
                MenuView.AdminMenu();
                InputView.AskForChoice();
                var choice = Console.ReadLine();
                Console.Clear();

                HelpMethods.MenuHandling(choice, 19);
                switch (choice.ToLower())
                {
                    case "1":
                        admin.AddBook(user.Id);
                        break;

                    case "2":
                        admin.SetAmount(user.Id);
                        break;

                    case "3":
                        admin.ListUsers(user.Id);
                        break;

                    case "4":
                        admin.FindUser(user.Id);
                        break;

                    case "5":
                        admin.UpdateBook(user.Id);
                        break;

                    case "6":
                        admin.DeleteBook(user.Id);
                        break;

                    case "7":
                        admin.AddCategory(user.Id);
                        break;

                    case "8":
                        admin.AddBookToCategory(user.Id);
                        break;

                    case "9":
                        admin.UpdateCategory(user.Id);
                        break;

                    case "10":
                        admin.DeleteCategory(user.Id);
                        break;

                    case "11":
                        admin.AddUser(user.Id);
                        break;

                    case "12":
                        admin.SoldItems(user.Id);
                        break;

                    case "13":
                        admin.MoneyEarned(user.Id);
                        break;

                    case "14":
                        admin.BestCustomer(user.Id);
                        break;

                    case "15":
                        admin.Promote(user.Id);
                        break;

                    case "16":
                        admin.Demote(user.Id);
                        break;

                    case "17":
                        admin.ActivateUser(user.Id);
                        break;

                    case "18":
                        admin.InActivateUser(user.Id);
                        break;

                    case "19":
                        SubMenuDirection(user);
                        break;
                }

                Console.ReadKey();
            }
        }

        /// <summary>
        /// A menu where all the shop methods are called.
        /// </summary>
        /// <param name="user"></param>
        internal void BookMenu(User user)
        {
            while (true)
            {
                api.Ping(user.Id);

                MenuView.BookMenu();
                InputView.AskForChoice();
                var choice = Console.ReadLine();

                HelpMethods.MenuHandling(choice, 5);
                switch (choice)
                {
                    case "1":
                        SearchBooksMenu();
                        break;

                    case "2":
                        shop.ShowAvaliableBooks();
                        break;

                    case "3":
                        shop.ShowCategoriesByKeyword();
                        break;

                    case "4":
                        if (user.IsActive == false)
                        {
                            MessageView.LoginToBuyBooks();
                        }
                        else
                        {
                            shop.BuyBook(user);
                        }
                        break;

                    case "5":
                        if (user.IsAdmin == true && user.IsActive == true)
                        {
                            SubMenuAdmin(user);
                        }
                        else if (user.IsAdmin == false && user.IsActive == true)
                        {
                            SubMenuUser(user);
                        }
                        MainMenu();
                        break;
                }

                Console.ReadKey();
            }
        }

        /// <summary>
        /// The start menu of the program.
        /// </summary>
        internal void MainMenu()
        {
            while (true)
            {
                var user = new User();
                api.Ping(user.Id);

                MenuView.MainMenu();
                InputView.AskForChoice();
                var choice = Console.ReadLine();

                HelpMethods.MenuHandling(choice, 4);
                switch (choice)
                {
                    case "1":
                        SubMenuDirection(user);
                        break;

                    case "2":
                        authenticat.Register(user);
                        break;

                    case "3":
                        authenticat.Login();
                        break;

                    case "4":
                        Environment.Exit(0);
                        break;
                }
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Menu where you can search for books.
        /// </summary>
        internal void SearchBooksMenu()
        {
            Console.Clear();
            InputView.SearchforTitleOrAuthor();
            InputView.AskForChoice();
            var choice = Console.ReadLine();

            HelpMethods.MenuHandling(choice, 2);
            switch (choice)
            {
                case "1":
                    shop.SearchForBookByTitle();
                    break;

                case "2":
                    shop.SearchForBookByAuthor();
                    break;

                default:
                    MessageView.NoSearchMatch();
                    Thread.Sleep(1500);
                    break;
            }
        }

        /// <summary>
        /// Submenu for Admins.
        /// </summary>
        /// <param name="user"></param>
        internal void SubMenuAdmin(User user)
        {
            api.Ping(user.Id);

            MenuView.SubMenuAdmin();
            InputView.AskForChoice();
            var choice = Console.ReadLine();

            HelpMethods.MenuHandling(choice, 3);
            switch (choice)
            {
                case "1":
                    BookMenu(user);
                    break;

                case "2":
                    AdminMenu(user);
                    break;

                case "3":
                    authenticat.Logout(user.Id);
                    break;
            }
        }

        /// <summary>
        /// A method that controls the sub menu direction.
        /// </summary>
        /// <param name="user"></param>
        internal void SubMenuDirection(User user)
        {
            api.Ping(user.Id);

            if (user.IsAdmin == true && user.IsActive == true)
            {
                SubMenuAdmin(user);
            }
            else if (user.IsAdmin == false && user.IsActive == true)
            {
                SubMenuUser(user);
            }
            else
            {
                BookMenu(user);
            }
        }

        /// <summary>
        /// Submenu for users.
        /// </summary>
        /// <param name="user"></param>
        internal void SubMenuUser(User user)
        {
            api.Ping(user.Id);

            MenuView.SubMenu();
            InputView.AskForChoice();
            var choice = Console.ReadLine();

            HelpMethods.MenuHandling(choice, 2);
            switch (choice)
            {
                case "1":
                    BookMenu(user);
                    break;

                case "2":
                    authenticat.Logout(user.Id);
                    break;
            }
        }
    }
}