namespace FrontEndJesperPersson.View
{
    using FrontEndJesperPersson.Controller;
    using System.Collections.Generic;
    using WebbShopJesperPersson.Model;

    internal class Books
    {
        private List<Book> BookList = new List<Book>();
        private int Choice;
        private CustomerController Controller = new CustomerController();
        private bool KeepGoing;

        /// <summary>
        /// Prints out menu for Books
        /// </summary>
        /// <param name="userId"></param>
        public void Menu(int userId)
        {
            do
            {
                KeepGoing = true;
                ViewHelper.CreateMenu(@"---Böcker---", "Tillgängliga böcker", "Sök genom nyckelord",
                    "Sök genom författare", "Köp bok", "Tillbaka");
                Choice = ViewHelper.InputInt();
                switch (Choice)
                {
                    case 1:
                        AvailableBooks(userId);
                        break;

                    case 2:
                        SeachByKeyword(userId);
                        break;

                    case 3:
                        SearchByAuthor(userId);
                        break;

                    case 4:
                        BuyBook(userId);
                        break;

                    case 5:
                        KeepGoing = false;
                        break;
                }
            } while (KeepGoing);
        }

        /// <summary>
        /// Prints out all available books in database.
        /// </summary>
        /// <param name="userId"></param>
        private void AvailableBooks(int userId)
        {
            var books = Controller.GetAvailableBooks();
            ViewHelper.WriteOutList(books);
            Controller.Ping(userId);
        }

        /// <summary>
        /// Prints out instrucitons to pick the right book and then success or errormessage depending of the outcome.
        /// </summary>
        /// <param name="userId"></param>
        private void BuyBook(int userId)
        {
            var book = ViewHelper.GetBook();
            if (book != null)
            {
                if (Controller.BuyBook(userId, book.Id))
                    ViewHelper.SuccessMessage($"{book.Title} har nu köpts");
            }
            else ViewHelper.ErrorMessage("Boken verkar inte finnas");

            Controller.Ping(userId);
        }

        /// <summary>
        /// Prints out instructions to search for a book and then the result of choosen book if succeeded. Otherwise an errormessage.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private void SeachByKeyword(int userId)
        {
            var keyword = ViewHelper.InputString("Sök efter bok:");
            var books = Controller.GetBooksByKeyword(keyword);
            ViewHelper.WriteOutList(books);

            Controller.Ping(userId);
        }

        /// <summary>
        /// Prints out list of books written by auther that contains the keyword user search for.
        /// </summary>
        /// <param name="userId"></param>
        private void SearchByAuthor(int userId)
        {
            var keyword = ViewHelper.InputString("Skriv in författarens för eller efternamn");
            var books = Controller.GetBooksByAuthors(keyword);
            ViewHelper.WriteOutList(books);
            Controller.Ping(userId);
        }
    }
}