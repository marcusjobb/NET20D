using System;
using System.Linq;
using System.Threading;
using Webbshop.Helpers;
using Webbshop.Views;
using WebbshopProject;

namespace Webbshop.Controllers
{
    class BookControllers
    {
        /// <summary>
        /// An instance of the WebbshopAPI. To use when calling a method in 
        /// that class.
        /// </summary>
        public static WebbshopAPI api = new WebbshopAPI();

        /// <summary>
        /// A menu that contains all the choices that
        /// is associated with books.
        /// </summary>
        /// <param name="userId">The id of the user of the program</param>
        public static void BookChoices(int userId)
        {
            UsersControllers.Ping(userId);
            Console.Clear();
            var input = "x";
            while (input != "e")
            {
                BookView.PrintBookChoices(userId);
                input = Console.ReadLine().ToLower();
                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            GetAvailableBooks();
                            break;

                        case 2:
                            GetBook();
                            break;

                        case 3:
                            SearchBook();
                            break;

                        case 4:
                            SearchAuthor();
                            break;

                        case 5:
                            BuyBook(userId);
                            break;

                        default:
                            Messages.ErrorMessage("Invalid choice!");
                            break;
                    }
                }

                else if (input == "e")
                {
                    StartupControllers.Menu(userId);
                }

                else
                {
                    Messages.ErrorMessage("Invalid choice!");
                }
            }

            Console.ReadKey();
        }

        /// <summary>
        /// A menu for admin, and that contains the choices
        /// that is associated with books.
        /// </summary>
        /// <param name="userId">The id of the user of the program</param>
        public static void BookChoicesAdmin(int userId)
        {
            UsersControllers.Ping(userId);
            Console.Clear();
            var input = "x";
            while (input != "e")
            {
                Console.Clear();
                BookView.PrintBookChoices(userId);
                input = Console.ReadLine().ToLower();
                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddBook(userId);
                            break;

                        case 2:
                            SetBookAmount(userId);
                            break;

                        case 3:
                            UpdateBook(userId);
                            break;

                        case 4:
                            DeleteBook(userId);
                            break;

                        case 5:
                            AddBookToCategory(userId);
                            break;

                        case 6:
                            ListAllSoldBooks(userId);
                            break;

                        case 7:
                            MoneyEarned(userId);
                            break;

                        default:
                            Messages.ErrorMessage("Invalid choice!");
                            break;
                    }
                }

                else if (input == "e")
                {
                    StartupControllers.Menu(userId);
                }

                else
                {
                    Messages.ErrorMessage("Invalid choice!");
                }
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Control to se if there is any books sold, and then calculates
        /// it. 
        /// Only runs if user is admin.
        /// </summary>
        /// <param name="userId">The id of the user of the program</param>
        public static void MoneyEarned(int userId)
        {
            if (HelperMethods.IsUserAdminAndLoggedIn(userId))
            {
                UsersControllers.Ping(userId);
                int moneyEarnedSoldBooks = api.MoneyEarned();
                if (moneyEarnedSoldBooks != 0)
                {
                    BookView.PrintMoneyEarnedBySoldBooks(moneyEarnedSoldBooks);
                    
                }
                else
                {
                    Messages.ErrorMessage("No books has been sold.");
                    Thread.Sleep(1500);
                    BookChoicesAdmin(userId);
                }
            }
            else
            {
                Messages.ErrorMessage("You're not authorized" +
                    " for this choice");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Prints out the available books in the database.
        /// And how many that is left.
        /// </summary>
        public static void GetAvailableBooks()
        {
            int categoryChoice = HelperMethods.ChooseCategory();
            var listOfBooks = api.GetAvailableBooks(categoryChoice);
            Console.Clear();
            if (listOfBooks.Count() != 0)
            {
                BookView.PrintBooks(listOfBooks);
            }

            else
            {
                Messages.ErrorMessage("No books in that category.");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Prints the information about a sertain book.
        /// </summary>
        public static void GetBook()
        {
            int bookChoice = BookView.GetBookSelection();
            if (bookChoice == 0)
            {
                Messages.ErrorMessage("Something went wrong. Try again!");
                Console.ReadKey();
                GetBook();
            }

            else
            {
                BookView.PrintBookInformation(bookChoice);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Lets the user search for book/books,
        /// and then prints out results from database.
        /// </summary>
        public static void SearchBook()
        {
            Console.Clear();
            var keyword = BookView.SearchBookByKeyword();
            var listOfBooks = api.GetBooks(keyword);
            if (listOfBooks.Count != 0)
            {
                BookView.SearchBookByKeywordPrintBooks(listOfBooks);
            }

            else
            {
                Messages.ErrorMessage("There is no books that" +
                    " match that search.");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Lets the user search for author/authors,
        /// and then prints out results from database.
        /// </summary>
        public static void SearchAuthor()
        {
            var keyword = BookView.SearchAuthorByKeyword();
            var listOfBooks = api.GetAuthors(keyword);
            Console.Clear();
            if (listOfBooks.Count != 0)
            {
                BookView.SearchAuthorByKeywordPrintBooks(listOfBooks);
            }

            else
            {
                Messages.ErrorMessage("There was no match " +
                    "for that search.");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Prints out all books, user
        /// can choose one to buy. And then it gets
        /// printed if it succeeded or not.
        /// </summary>
        /// <param name="userId">The id of the user of the program</param>
        public static void BuyBook(int userId)
        {
            if (HelperMethods.IsUserActiveAndLoggedIn(userId))
            {
                UsersControllers.Ping(userId);
                Console.Clear();
                var bookChoice = BookView.BuyBookView();
                bool bougthBook = api.BuyBook(
                    userId,
                    bookChoice);
                if (bougthBook)
                {
                    Messages.SuccessMessage("The purchase succeeded!");
                    Console.ReadKey();
                    BookChoices(userId);
                }

                else if (bookChoice == 0)
                {
                    Messages.ColorText("No book selected.",
                        ConsoleColor.Yellow);
                    Console.ReadKey();
                    BookChoices(userId);
                }

                else
                {
                    Messages.ErrorMessage("Something went wrong." +
                        " Try again!");
                    Console.ReadKey();
                    BuyBook(userId);
                }
            }

            else
            {
                Messages.ErrorMessage("You need to login first.");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Prints all books, and then user can choose one
        /// to add books to. If book wanted does not exist,
        /// it can be added. Only for admins.
        /// </summary>
        /// <param name="userId">The user of the program</param>
        public static void AddBook(int userId)
        {
            if (HelperMethods.IsUserAdminAndLoggedIn(userId))
            {
                UsersControllers.Ping(userId);
                Console.Clear();
                int amount;
                var bookChoice = HelperMethods.ChooseBook();
                Console.Clear();
                if (bookChoice == 0)
                {
                    var input = BookView.AddBookView();
                    if (input == "y")
                    {
                        var bookInfoCredentials = BookView.AddBookCreateNew();
                        bool answer = api.AddBook(
                            userId,
                            0,
                            bookInfoCredentials.title,
                            bookInfoCredentials.author,
                            bookInfoCredentials.price,
                            bookInfoCredentials.amount);
                        if (answer)
                        {
                            Messages.SuccessMessage("Books added.");
                        }

                        else
                        {
                            Messages.ErrorMessage("You need to login again.");
                        }
                    }

                    else
                    {
                        Console.WriteLine("Something went wrong. Try again!");
                        Thread.Sleep(2000);
                        BookChoicesAdmin(userId);
                    }
                }
                else
                {
                    var book = api.GetBook(bookChoice);
                    var booksToAdd = BookView.AddBooksToExistingBook();
                    if (string.IsNullOrEmpty(booksToAdd))
                    {
                        bool choice = int.TryParse(booksToAdd, out amount);
                        bool answer = api.AddBook(
                            userId,
                            book.Id,
                            book.Title,
                            book.Author,
                            book.Price,
                            amount);
                        if (answer)
                        {
                            Messages.SuccessMessage("Books added.");
                        }

                        else
                        {
                            Messages.ErrorMessage("Something went " +
                                "wrong. Try again!");
                        }
                    }

                    else
                    {
                        Messages.ErrorMessage("Something went " +
                            "wrong. Try again!");
                    }
                }
            }

            else
            {
                Messages.ErrorMessage("You are not authorized " +
                    "for this choice.");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Prints books out, and user can select wich book to add
        /// books to. And then how many. Only for admins.
        /// </summary>
        /// <param name="userId">The id of the user of the program</param>
        public static void SetBookAmount(int userId)
        {
            if (HelperMethods.IsUserAdminAndLoggedIn(userId))
            {
                UsersControllers.Ping(userId);
                Console.Clear();
                var bookChoice = HelperMethods.ChooseBook();
                if (bookChoice != 0)
                {
                    int amount = BookView.SetAmountOfBooksAvalible();
                    api.SetAmount(userId, bookChoice, amount);
                    Messages.SuccessMessage("Book amount updated.");
                }

                else
                {
                    Messages.ColorText("Going back to mainMenu",
                        ConsoleColor.Cyan);
                    Thread.Sleep(2000);
                    BookChoicesAdmin(userId);
                }
            }

            else
            {
                Messages.ErrorMessage("You are not authorized " +
                    "for this choice.");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Prints all books and user can serlect one.
        /// Then the book gets deleted. If there is no more books
        /// left, the book will be deleted from the database.
        /// Only for admins.
        /// </summary>
        /// <param name="userId">The id of the user of the program</param>
        public static void DeleteBook(int userId)
        {
            if (HelperMethods.IsUserAdminAndLoggedIn(userId))
            {
                UsersControllers.Ping(userId);
                Console.Clear();
                var bookChoice = HelperMethods.ChooseBook();
                if (bookChoice != 0)
                {
                    bool answer = api.DeleteBook(
                    userId,
                    bookChoice);
                    if (answer)
                    {
                        Messages.SuccessMessage("Book deleted.");
                    }
                    else
                    {
                        Messages.ErrorMessage("You need to login again.");
                    }
                }

                else
                {
                    Messages.ErrorMessage("Something went" +
                        " wrong. Try again!");
                    Thread.Sleep(2000);
                    BookChoicesAdmin(userId);
                }
            }

            else
            {
                Messages.ErrorMessage("You are not authorized" +
                    " for this choice.");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Prints all books, and user can select one.
        /// Then user gets to write changes to be
        /// added to the updated book. Only for admins.
        /// </summary>
        /// <param name="userId">The id of the user of the program</param>
        public static void UpdateBook(int userId)
        {
            if (HelperMethods.IsUserAdminAndLoggedIn(userId))
            {
                UsersControllers.Ping(userId);
                Console.Clear();
                var bookChoice = HelperMethods.ChooseBook();
                if (bookChoice != 0)
                {
                    var bookCredentials = BookView.UpdateBookCredentials();
                    bool answer = api.UpdateBook(
                        userId,
                        bookChoice,
                        bookCredentials.title,
                        bookCredentials.author,
                        bookCredentials.price);
                    if (answer)
                    {
                        Console.WriteLine("");
                        Messages.SuccessMessage("Updated book.");
                    }

                    else
                    {
                        Messages.ErrorMessage("You have to login again");
                    }
                }

                else
                {
                    Messages.ColorText("Going back to main menu",
                        ConsoleColor.Cyan);
                    Thread.Sleep(2000);
                    BookChoicesAdmin(userId);
                }
            }

            else
            {
                Messages.ErrorMessage("You are not authorized.");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Prints books for user to select. And then prints categories
        /// for user to select. The selected book gets added to
        /// selected category.
        /// </summary>
        /// <param name="userId">The id of the user of the program</param>
        public static void AddBookToCategory(int userId)
        {
            if (HelperMethods.IsUserAdminAndLoggedIn(userId))
            {
                UsersControllers.Ping(userId);
                Console.Clear();
                var choices = BookView.ChooseBookAndCategory();
                if (choices.book == 0 || choices.category == 0)
                {
                    Messages.ErrorMessage("Something went wrong");
                    Thread.Sleep(2000);
                    BookChoicesAdmin(userId);
                }

                else
                {
                    bool answer = api.AddBookToCategory(
                        userId,
                        choices.book,
                        choices.category);
                    if (answer)
                    {
                        Messages.SuccessMessage("Category added" +
                            " to book.");
                    }

                    else
                    {
                        Messages.ErrorMessage("You have to login again");
                    }
                }
            }

            else
            {
                Messages.ErrorMessage("You are not authorized.");
            }

            Console.ReadKey();
        }



        /// <summary>
        /// Prints out a list of all sold books, if there is any.
        /// </summary>
        /// <param name="userId">The id of the user of the program</param>
        public static void ListAllSoldBooks(int userId)
        {
            if (HelperMethods.IsUserAdminAndLoggedIn(userId))
            {
                UsersControllers.Ping(userId);
                Console.Clear();
                var listOfSoldBooks = api.ListSoldBooks(userId);
                if (listOfSoldBooks.Count != 0)
                {
                    BookView.PrintListOfSoldBooks(listOfSoldBooks);
                }

                else
                {
                    Messages.ErrorMessage("There is no sold books.");
                }
            }

            else
            {
                Messages.ErrorMessage("You are not authorized" +
                    "for this choice.");
            }

            Console.ReadKey();
        }
    }
}
