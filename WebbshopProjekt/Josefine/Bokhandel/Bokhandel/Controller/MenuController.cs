using Bokhandel.View;
using System;
using System.Threading;

namespace Bokhandel.Controller
{
    internal class MenuController
    {
        /// <summary>
        /// Check if user want to see all or only available books
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="categoryId"></param>
        public static void AllOrOnlyAvailableBooks(int userId, int categoryId)
        {
            bool loop = true;
            while (loop)
            {
                UserView.SeeAllOrOnlyAvailableBooks();
                var choice = Console.ReadLine().Trim().ToLower();
                switch (choice)
                {
                    case "1":
                        BookController.ListBooksInCategory(userId, categoryId);
                        break;

                    case "2":
                        BookController.ListAvailableBooksInCategory(userId, categoryId);
                        break;

                    case "x":
                        loop = false;
                        break;

                    default:
                        BookView.EnterValidNumber();
                        break;
                }
            }
        }

        /// <summary>
        /// Ask user what to search
        /// </summary>
        /// <param name="userId"></param>
        public static void SearchChoice(int userId)
        {
            bool loop = true;
            do
            {
                UserView.SearchBook();
                var choice = Console.ReadLine().Trim().ToLower();
                switch (choice)
                {
                    case "1":
                        BookController.SearchCategory(userId);
                        break;

                    case "2":
                        BookController.SearchAuthor(userId);
                        break;

                    case "3":
                        BookController.SearchBook(userId);
                        break;

                    case "x":
                        loop = false;
                        break;

                    default:
                        BookView.EnterValidNumber();
                        break;
                }
            }
            while (loop);
        }

        /// <summary>
        /// Control choice in start menu
        /// </summary>
        public void StartChoice()
        {
            int userId = 0;
            while (true)
            {
                Thread.Sleep(2000);
                Console.Clear();
                UserView.FirstMenu();
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BookController.SeeCategories(userId);
                        break;

                    case "2":
                        SearchChoice(userId);
                        break;

                    case "3":
                        userId = UserController.Login();
                        break;

                    case "4":
                        UserController.Logout(userId);
                        break;

                    case "5":
                        UserController.Register();
                        break;

                    case "6":
                        var controller = new AdminController();
                        controller.AdminMeny(userId);
                        break;

                    default:
                        BookView.EnterValidNumber();
                        break;
                }
            }
        }
    }
}