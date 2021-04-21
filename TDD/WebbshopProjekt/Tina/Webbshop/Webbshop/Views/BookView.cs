using System;
using System.Collections.Generic;
using Webbshop.Helpers;
using WebbshopProject;
using WebbshopProject.Models;

namespace Webbshop.Views
{
    class BookView
    {
        /// <summary>
        /// An instance of the webbshopAPI.
        /// </summary>
        public static WebbshopAPI api = new WebbshopAPI();

        /// <summary>
        /// Prints the bookchoices for the user, depending on if you are
        /// admin or not different choices will be presented.
        /// </summary>
        /// <param name="userId"></param>
        public static void PrintBookChoices(int userId)
        {
            if (!HelperMethods.IsUserActiveAndLoggedIn(userId))
            {
                Console.Clear();
                Console.WriteLine("What do you want to do?");
                Messages.ColorText("[1] Get availible books\n" +
                    "[2] Read about book\n[3] Search book\n[4]" +
                    " Search author\n[5] Buy book\n" +
                    "[E] Exit to main", ConsoleColor.Yellow);
                Console.Write("Enter choice: ");


            }
            else
            {
                Console.WriteLine("What do you want to do?");
                Messages.ColorText("[1] Add Book\n" +
                    "[2] Set book amount\n[3] Update book\n" +
                    "[4] Delete book\n[5] Add category to book\n" +
                    "[6] Sold books\n[7] Money earned by sold books\n" +
                    "[E] Exit to main", ConsoleColor.Yellow);
                Console.Write("Enter choice: ");
            }
        }
        /// <summary>
        /// Prints all the books in the list of books.
        /// </summary>
        /// <param name="listOfBooks"></param>
        public static void PrintBooks(List<Book> listOfBooks)
        {
            foreach (var book in listOfBooks)
            {
                Messages.ColorText($"{book.Title}," +
                    $" {book.Amount} books left", ConsoleColor.Cyan);
            }
        }
        /// <summary>
        /// Prints out and let the user choose a book.
        /// </summary>
        /// <returns></returns>
        public static int GetBookSelection()
        {
            Messages.ColorText("Wich book do you want" +
               " to know more about?", ConsoleColor.Cyan);
            int bookChoice = HelperMethods.ChooseBook();
            return bookChoice;
        }
        /// <summary>
        /// Prints the information about a book choosen by the user.
        /// </summary>
        /// <param name="bookChoice"></param>
        internal static void PrintBookInformation(int bookChoice)
        {
            Console.WriteLine("------------------------------");
            var book = api.GetBook(bookChoice);
            Messages.ColorText($"{book.Title} is written by" +
                $" {book.Author}\nand the cost" +
                $" is {book.Price} sek", ConsoleColor.Cyan);

            Console.WriteLine("-----------------------------");
        }
        /// <summary>
        /// Prints a request for a keyword,
        /// to search for a book.
        /// And returns it to the controller.
        /// </summary>
        /// <returns></returns>
        public static string SearchBookByKeyword()
        {
            Console.Write("Enter keyword: ");
            var keyword = Console.ReadLine();
            return keyword;
        }
        /// <summary>
        /// Prints information of books in a list.
        /// </summary>
        /// <param name="listOfBooks"></param>
        public static void SearchBookByKeywordPrintBooks(
            List<Book> listOfBooks)
        {
            foreach (var book in listOfBooks)
            {
                Messages.ColorText($"{book.Title}, {book.Author}",
                    ConsoleColor.Cyan);
            }
        }
        /// <summary>
        /// Prints a request for a keyword,
        /// to search for a author.
        /// Then returns it to the controller.
        /// </summary>
        /// <returns></returns>
        public static string SearchAuthorByKeyword()
        {
            Console.Write("Enter Author: ");
            var keyword = Console.ReadLine();
            return keyword;
        }
        /// <summary>
        /// Prints out all books in a list written 
        /// by a sertain author.
        /// </summary>
        /// <param name="listOfBooks"></param>
        public static void SearchAuthorByKeywordPrintBooks(
            List<Book> listOfBooks)
        {
            foreach (var book in listOfBooks)
            {
                Messages.ColorText($"{book.Author}, {book.Title}",
                    ConsoleColor.Cyan);
            }
        }
        /// <summary>
        /// Prints a list of books to choose from, then returns 
        /// the choosen book to the controller.
        /// </summary>
        /// <returns></returns>
        public static int BuyBookView()
        {
            Console.WriteLine("Wich book do you want to buy?");
            int bookChoice = HelperMethods.ChooseBook();
            return bookChoice;
        }
        /// <summary>
        /// Prints a question to add a book, and takes a 
        /// input. Then returns the input.
        /// </summary>
        /// <returns></returns>
        public static string AddBookView()
        {
            Messages.ColorText("Do you want to add a new book? " +
                       "y/n", ConsoleColor.Cyan);
            Console.Write("Enter choice: ");
            var input = Console.ReadLine();

            return input;
        }
        /// <summary>
        /// Prints what to enter information about
        /// Lets user add a new book and then sends the
        /// information to the controller.
        /// </summary>
        /// <returns></returns>
        public static (string title, string author,
            int price,  int amount) AddBookCreateNew()
        {
            Console.Write("Enter Title: ");
            string title = Console.ReadLine();
            Console.Write("Enter Author: ");
            string author = Console.ReadLine();
            Console.Write("Price: ");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.Write("Amont of books: ");
            int amount = Convert.ToInt32(Console.ReadLine());

            return (title, author, price, amount);
        }
        /// <summary>
        /// Prints what to enter information about
        /// If book exist and user wants to change amount.
        /// </summary>
        /// <returns></returns>
        public static string AddBooksToExistingBook()
        {
            Console.WriteLine("How many do you want to add?");
            Console.Write("Enter amount: ");
            var input = Console.ReadLine();
            return input;
        }
        /// <summary>
        /// Prints what to enter information about
        /// Lets user set amount of avalible books.
        /// </summary>
        /// <returns></returns>
        public static int SetAmountOfBooksAvalible()
        {
            Console.WriteLine("How many books is available?");
            Console.Write("Enter amount: ");
            var amount = Convert.ToInt32(Console.ReadLine());
            return amount;
        }
        /// <summary>
        /// Prints what to enter information about
        /// and takes input to update a books credentials.
        /// </summary>
        /// <returns></returns>
        public static (string title, string author,
            int price) UpdateBookCredentials()
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Author: ");
            string author = Console.ReadLine();
            Console.Write("Price: ");
            int price = Convert.ToInt32(Console.ReadLine());
            return (title, author, price);
        }
        /// <summary>
        /// Prints a question to choose book, and category. Then sends
        /// the book and category back to controller.
        /// </summary>
        /// <returns></returns>
        public static (int book, int category) ChooseBookAndCategory()
        {
            Messages.ColorText("Choose book.", ConsoleColor.Yellow);
            var bookChoice = HelperMethods.ChooseBook();
            Messages.ColorText("Choose category.",
                ConsoleColor.Yellow);
            var categoryChoice = HelperMethods.ChooseCategory();

            return (bookChoice, categoryChoice);
        }
        /// <summary>
        /// Prints a list of sold books.
        /// </summary>
        /// <param name="listOfSoldBooks"></param>
        public static void PrintListOfSoldBooks(
            List<SoldBook> listOfSoldBooks)
        {
            Messages.ColorText("Here is a list of all sold" +
                      " books:", ConsoleColor.Cyan);
            foreach (var book in listOfSoldBooks)
            {
                Console.WriteLine($"-{book.Title}, {book.Author}");
            }
        }
        /// <summary>
        /// Prints how much money is earned by sold books.
        /// </summary>
        /// <param name="moneyEarnedSoldBooks"></param>
        public static void PrintMoneyEarnedBySoldBooks(
            int moneyEarnedSoldBooks)
        {
            Messages.ColorText($"{moneyEarnedSoldBooks} sek" +
                    $" was earned by sold books.", ConsoleColor.Cyan);
        }
    }
}
