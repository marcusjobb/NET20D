using System;
using WebshopMVC.UtilsMVC;

namespace WebshopMVC.Controllers.Menu
{
    /// <summary>
    /// Menu class for handling book data, no login required
    /// </summary>
    public class BookMenuController
    {
        /// <summary>
        /// Menu for handling book data
        /// </summary>
        public static void BookMenu()
        {
            bool isBookMenuRunning = true;
            while (isBookMenuRunning)
            {
                Console.Clear();
                ASCII.BookMenuASCII();
                Console.WriteLine("[1] List all books");
                Console.WriteLine("[2] Search books by title");
                Console.WriteLine("[3] Search books by author");
                Console.WriteLine("[4] Get book information by Id\n");

                Console.WriteLine("[5] Go back to main menu");
                Console.WriteLine("[6] Quit application");

                int.TryParse(Console.ReadLine(), out var bookMenuInput);

                switch (bookMenuInput)
                {
                    case 1:
                        BookController.ListAllBooks();
                        break;

                    case 2:
                        BookController.GetBooksByKeyword();
                        break;

                    case 3:
                        BookController.GetBooksByAuthor();
                        break;

                    case 4:
                        BookController.GetBookById();
                        break;

                    case 5:
                        isBookMenuRunning = false;

                        break;

                    case 6:
                        isBookMenuRunning = false;
                        MainMenuController.isMainMenuRunning = false;
                        break;
                }
            }
        }
    }
}