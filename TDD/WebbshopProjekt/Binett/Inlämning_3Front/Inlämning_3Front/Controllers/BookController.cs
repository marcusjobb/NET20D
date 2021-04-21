using Inlämning_3Front.Views;
using Inlämning_API;
using Inlämning_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inlämning_3Front.Controllers
{
    public class BookController
    {
        private WebbShopAPI api = new();
        private BookView view = new();
        private static readonly Controller controller = new();

        /// <summary>
        /// Book menu
        /// </summary>
        /// <param name="user"></param>
        public void BookMenu(User user)
        {
            while (true)
            {
                view.BookMenu();
                var input = Console.ReadKey().KeyChar;
                switch (char.ToLower(input))
                {
                    case '1':
                        api.Ping(user.ID);
                        SearchBooks();
                        break;

                    case '2':
                        api.Ping(user.ID);
                        ShowAvailableBooks();
                        break;

                    case '3':
                        api.Ping(user.ID);
                        ShowCategoriesByKeyword();
                        break;

                    case '4':
                        api.Ping(user.ID);
                        BuyBook(user);
                        break;

                    case 'e':
                        if (user.ID == 0)
                            controller.Index();
                        if (true)
                            controller.Menu(user);
                        break;

                    default:
                        MessageView.WrongInput();
                        break;
                }
                MessageView.EnterkeyToContinue();
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Let the user buy a book
        /// </summary>
        /// <param name="user"></param>
        private void BuyBook(User user)
        {
            api.Ping(user.ID);
            Console.WriteLine();
            var listOfBooks = api.GetAllBooks();
            view.ShowAvalaibleBooks(listOfBooks);

            view.ChooseBookById();
            int.TryParse(Console.ReadLine(), out int choice);
            var res = api.BuyBooks(user.ID, choice);

            if (user.ID == 0)
            {
                MessageView.RegisterMessage();
            }

            if (res == false) MessageView.SomethingWentWrong();
            if (res == true) MessageView.SuccessMessage();
            if (user.ID == 0)
            {
                Console.WriteLine("Register (y/n)");
                var input = Console.ReadLine();
                if (input.ToLower() == "y")
                {
                    controller.Register();
                }
            }
        }

        /// <summary>
        /// Lists categories by keyword
        /// </summary>
        private void ShowCategoriesByKeyword()
        {
            view.SearchFor();
            var keyword = Console.ReadLine();
            var list = api.GetCategories(keyword);
            CheckifCatListIsEmpty(list);
        }

        /// <summary>
        /// Lists available books
        /// </summary>
        private void ShowAvailableBooks()
        {
            var categoryList = api.GetCategories();
            view.ShowCategory(categoryList);
            int.TryParse(Console.ReadLine(), out int input);

            var list = api.GetAvailableBooks(input);

            CheckIfBookListIsEmpty(list);
        }

        /// <summary>
        /// Search for books by title or author
        /// </summary>
        private void SearchBooks()
        {
            Console.Clear();
            view.SearchforTitleOrAuthor();
            var input = Console.ReadKey().KeyChar;
            if (input == '1')
            {
                SearchBookByTitel();
            }
            if (input == '2')
            {
                SearchBookByAuthor();
            }
        }

        /// <summary>
        /// Search books by author
        /// </summary>
        private void SearchBookByAuthor()
        {
            view.SearchFor();
            var keyword = Console.ReadLine();
            var list = api.GetAuthors(keyword);
            CheckIfBookListIsEmpty(list);
        }

        /// <summary>
        /// Search books by title
        /// </summary>
        private void SearchBookByTitel()
        {
            view.SearchFor();
            var keyword = Console.ReadLine();
            var list = api.GetBooks(keyword);
            CheckIfBookListIsEmpty(list);
        }

        /// <summary>
        /// Checks if the list is empty
        /// </summary>
        /// <param name="list"></param>
        private void CheckIfBookListIsEmpty(IEnumerable<Book> list)
        {
            if (list.Any())
            {
                view.ShowBooks(list);
            }
            else
            {
                MessageView.EmptyList();
            }
        }

        /// <summary>
        /// Checks if the list is empty
        /// </summary>
        /// <param name="list"></param>
        private void CheckifCatListIsEmpty(IEnumerable<BookCategories> list)
        {
            if (list.Any())
            {
                view.ShowCategory(list);
            }
            else
            {
                MessageView.EmptyList();
            }
        }
    }
}