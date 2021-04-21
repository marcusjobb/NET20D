using AssignmentThree.Views;
using System;

namespace AssignmentThree.Controllers
{
    public static class BookController
    {
        private static void BookInfo()
        {
            CategoryView.PrintCategories();
            BookView.PrintBooksInCategory();
            BookView.PrintBookInfo();
        }

        public static void BookMenu()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                BookView.PrintBookMenu();
                int.TryParse(Console.ReadLine(), out var userInput);

                switch (userInput)
                {
                    case 1:
                        BooksAvailable();
                        break;

                    case 2:
                        BookInfo();
                        break;

                    case 3:
                        BookView.PrintMatchingBooks();
                        break;

                    case 4:
                        BookView.PrintBooksByAuthor();
                        break;

                    case 5:
                        BooksInCategory();
                        break;

                    case 0:
                        keepRunning = false;
                        break;

                    default:
                        BookView.PrintInvalidInput();
                        break;
                }
            }
        }

        private static void BooksAvailable()
        {
            CategoryView.PrintCategories();
            BookView.PrintAvailableBooks();
        }

        private static void BooksInCategory()
        {
            CategoryView.PrintCategories();
            BookView.PrintBooksInCategory();
        }

        public static void BuyBook()
        {
            if (Program.User.Id != 0)
            {
                BookView.PrintMatchingBooks();
                BookView.PrintBuyBook();
                int.TryParse(Console.ReadLine(), out var userInput);

                var result = Program.API.BuyBook(Program.User.Id, userInput);

                if (result)
                {
                    BookView.PrintCompleted();
                }
                else
                {
                    BookView.PrintFailed();
                }
            }
            else
            {
                BookView.PrintLoginNeeded();
            }
        }
    }
}