using Inlamning2TrialRunHE.Models;
using System;
using System.Collections.Generic;

namespace Inlamning3HakanEriksson.Views
{
    public class ViewMessages
    {
        /// <summary>
        /// Asks the administrator to input details to add to a book in the database.
        /// </summary>
        /// <returns></returns>
        public static List<string> AddBook()
        {
            List<string> addBookList = new List<string>();
            Console.Write("1. Enter title: ");
            addBookList.Add(Console.ReadLine());
            Console.Write("2. Enter author: ");
            addBookList.Add(Console.ReadLine());
            Console.Write("3. Enter price: ");
            addBookList.Add(Console.ReadLine());
            Console.Write("4. Enter amount: ");
            addBookList.Add(Console.ReadLine());
            return addBookList;
        }

        public static void Exitmessage()
        {
            Console.WriteLine("Program exit. . .");
        }
        /// <summary>
        /// Is used to ask a user what keyword they want to search for.
        /// </summary>
        /// <param name="type"></param>
        /// <returns>A string with the users input.</returns>
        public static string Keyword(string type = "book")
        {
            Console.Write($"Enter a keyword for a {type} to search with: ");
            string keyword = Console.ReadLine();
            return keyword;
        }
        /// <summary>
        /// Writes a list with the database book categories.
        /// and lets the user choose a category.
        /// </summary>
        /// <param name="categories"></param>
        /// <returns>A int with the users input value.</returns>
        public static int ListBookCategories(List<BookCategory> categories)
        {
            var counter = 1;
            foreach (var category in categories)
            {
                Console.WriteLine($"{counter}. {category.Name}");
                counter++;
            }
            Console.WriteLine("What category do you want to choose?");
            int.TryParse(Console.ReadLine(), out int result);
            return result;
        }
        /// <summary>
        /// Prints a list of the books in the database with the 
        /// specified values like book titles etc.
        /// </summary>
        /// <param name="books"></param>
        /// <param name="option"></param>
        /// <returns>a intiger containing the users choice.</returns>
        public static int ListBooks(List<Book> books, string option = "choose")
        {
            var counter = 1;
            foreach (var book in books)
            {
                Console.Write($"{counter}. Title: {book.Title} Book Id: {book.Id} Author: {book.Author} Price: {book.Price}");
                if (book.Amount == -10)
                {
                    Console.Write(" - Out of stock.");
                }
                Console.WriteLine();
                counter++;
            }
            Console.WriteLine($"What book do you want to {option}?");
            int.TryParse(Console.ReadLine(), out int result);
            return result;
        }

        /// <summary>
        /// Lets a user login with username and password.
        /// If approved the user is sent to the members menu.
        /// loggedInUser.
        /// </summary>
        /// <returns>A list with the users username and password.</returns>
        public static List<string> LoginMessage()
        {
            List<string> loginList = new List<string>() { };
            Console.Write("Type your username: ");
            loginList.Add(Console.ReadLine());
            Console.Write("Type your password: ");
            loginList.Add(Console.ReadLine());
            return loginList;
        }
        /// <summary>
        /// Tells the user to press any key to continue,
        /// then waits till a key is pressed.
        /// </summary>
        public static void PressAnyKeyMessage()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        /// <summary>
        /// Takes 3 user inputs to register a new user
        /// and stores them in the list registerData.
        /// </summary>
        /// <returns>A list with user data.</returns>
        public static List<string> RegisterNewUser()
        {
            List<string> registerData = new List<string>();
            Console.Write("Type the username you want: ");
            registerData.Add(Console.ReadLine());
            Console.Write("Type your password you want: ");
            registerData.Add(Console.ReadLine());
            Console.Write("Verify your password: ");
            registerData.Add(Console.ReadLine());
            return registerData;
        }
        /// <summary>
        /// Writes to the screen to let the user know that something went wrong.
        /// </summary>
        public static void SomethingWentWrongView()
        {
            Console.WriteLine("Ops something went wrong, try again.");
            PressAnyKeyMessage();
        }
        /// <summary>
        /// Writes a thank you message to the user after ubying a book.
        /// </summary>
        /// <param name="title"></param>
        public static void ThankYou(string title)
        {
            Console.WriteLine($"You bought {title}, thank you for your purchase!");
        }
        /// <summary>
        /// Lets the user know that the book successfully was added to the category.
        /// </summary>
        /// <param name="bookTitle"></param>
        /// <param name="categoryName"></param>
        internal static void AddBookToCategory(string bookTitle, string categoryName)
        {
            Console.WriteLine($"{bookTitle} was successfully added to the category {categoryName}!");
            PressAnyKeyMessage();
        }
        /// <summary>
        /// Asks the user to input a book title, author and price.
        /// </summary>
        /// <returns>A list of strings with user inputs.</returns>
        internal static List<string> AskUserForInput()
        {
            List<string> userInputs = new List<string>();
            Console.WriteLine("Enter the books Title: ");
            userInputs.Add(Console.ReadLine());
            Console.Write("Enter the books Author: ");
            userInputs.Add(Console.ReadLine());
            Console.Write("Enter the books Price: ");
            userInputs.Add(Console.ReadLine());
            return userInputs;
        }
        /// <summary>
        /// Writes a message to the screen letting the user know that
        /// the book was updated.
        /// </summary>
        /// <param name="title"></param>
        internal static void BookUpdated(string title)
        {
            Console.WriteLine($"{title} updated.");
        }
        /// <summary>
        ///  Lets the user know what the amount of books there is.
        /// </summary>
        /// <param name="amount"></param>
        internal static void CurrentAmount(int amount)
        {
            Console.WriteLine($"The new amount is: {amount}");
            PressAnyKeyMessage();
        }
        /// <summary>
        /// Writes a list of all the database users with user id and user name.
        /// </summary>
        /// <param name="list"></param>
        internal static void ListUsers(List<User> list)
        {
            foreach (var user in list)
            {
                Console.WriteLine($"{user.Id}. {user.Name} ");
            }
        }
        /// <summary>
        /// Asks the user to input the amount off books.
        /// </summary>
        /// <returns>A int with the users input.</returns>
        internal static int SetAmountOfBooks()
        {
            Console.WriteLine("Enter the new amount of books: ");
            int.TryParse(Console.ReadLine(), out int result);
            return result;
        }
        /// <summary>
        /// Asks the user to input the name of the category. 
        /// </summary>
        /// <param name="type"></param>
        /// <returns>The users input.</returns>
        internal static string SetCategoryName(string type = "name")
        {
            Console.Write($"What is the {type} for the category: ");
            return Console.ReadLine();
        }
        /// <summary>
        /// Asks the user to input a user name and a user password.
        /// </summary>
        /// <returns>A string Tuple.</returns>
        internal static (string, string) SetUserInfo()
        {
            (string name, string password) user;
            Console.Write("Enter name: ");
            user.name = Console.ReadLine();
            Console.Write("Enter password: ");
            user.password = Console.ReadLine();
            return user;
        }
        /// <summary>
        /// Lets the user know that the operation was successfull
        /// </summary>
        internal static void Success()
        {
            Console.WriteLine("It worked, well done! ");
            PressAnyKeyMessage();
        }
        /// <summary>
        /// Lets the user know that tha category was updated from
        /// the old name to the new name the user chosed.
        /// </summary>
        /// <param name="oldName"></param>
        /// <param name="newName"></param>
        internal static void UpdatedCategory(string oldName, string newName)
        {
            Console.WriteLine($"{oldName} was successfully changed to {newName}!");
            PressAnyKeyMessage();
        }
    }
}