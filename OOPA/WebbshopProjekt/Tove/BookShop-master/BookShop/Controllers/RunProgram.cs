using BookShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.Controllers
{
    /// <summary>
    /// Class to start program and initiate interaction with user. 
    /// </summary>
    class RunProgram
    {       
        /// <summary>
        /// Start menu, avaliable for all users.
        /// </summary>
        public void Menu()
        {
            var login = 0;
            int userInput = 0;
            while (userInput != 13 || userInput==11)
            {
                Console.WriteLine("Welcome to Seger's Book Shop");
                Console.WriteLine("How can I help you?");
                Console.WriteLine("1. Show me all book categories");
                Console.WriteLine("2. Search for a specific category ");
                Console.WriteLine("3. Search for all books in a specific category");
                Console.WriteLine("4. Search for all available books in a specific category");
                Console.WriteLine("5. Search for a specific book");
                Console.WriteLine("6. Search for a book containing a certain word in the title/author field");
                Console.WriteLine("7. Search for all books with a certain author");
                Console.WriteLine("8. Buy a book");
                Console.WriteLine("9.Register");
                Console.WriteLine("10.Login");
                Console.WriteLine("11.Logout");
                Console.WriteLine("12.Admin mode");
                Console.WriteLine("13. Exit");
                var tryUserInput = int.TryParse(Console.ReadLine(), out userInput);
                if (tryUserInput == false)
                {
                    Console.WriteLine("Input was not entered in correct format(number between 1-13). Please try again.");
                    Menu();
                }
                WebbShopAPI webb = new WebbShopAPI();
                switch (userInput)
                {
                    case 1:
                        var categoryList = webb.GetCategories();
                        foreach (var category in categoryList)
                        {
                            Console.WriteLine($"Id: {category.Id} Name:{category.Name}");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Which category do you want to search for?"); 
                        string chosenCategory = Console.ReadLine();
                        categoryList = webb.GetCategories(chosenCategory);

                        foreach (var category in categoryList)
                        {
                            Console.WriteLine($"Id: {category.Id} Name:{category.Name}");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Which category do you want to discover (search with category id)?");
                        var tryCategoryId = int.TryParse(Console.ReadLine(), out var categoryId);
                        if (tryCategoryId == false)
                        {
                            Console.WriteLine("Category id was not entered in correct format. Please try again.");
                            goto case 3;
                        }
                        var bookList = webb.GetCategory(categoryId);
                        foreach (var book in bookList)
                        {
                            Console.WriteLine($"ID:{book.Id}  Name:{book.Title}  Author:{book.Author}  Price:{book.Price} Amount:{book.Amount} Category Id:{book.CategoryId}  ");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Which category do you want to discover (search with category id)?");
                        tryCategoryId = int.TryParse(Console.ReadLine(), out categoryId);
                        if (tryCategoryId == false)
                        {
                            Console.WriteLine("Category id was not entered in correct format. Please try again.");
                            goto case 4;
                        }
                        var listInStock = webb.GetAvailableBooks(categoryId);
                        if (listInStock.Count>0)
                        {
                        foreach (var book in listInStock)
                        {
                            Console.WriteLine($"ID:{book.Id}  Name:{book.Title}  Author:{book.Author}  Price:{book.Price} Amount:{book.Amount} Category Id:{book.CategoryId}  ");
                        }
                        }
                        else
                        {
                            Console.WriteLine("Please try another category or come back later.");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Enter Id for the book you want to search for");
                        tryCategoryId = int.TryParse(Console.ReadLine(), out categoryId);
                        if (tryCategoryId == false)
                        {
                            Console.WriteLine("Category id was not entered in correct format. Please try again.");
                            goto case 5;
                        }
                        var specificbook = webb.GetBook(categoryId);
                            if (specificbook.Count > 0)
                            {
                                foreach (var book in specificbook)
                                {
                                    Console.WriteLine($"ID:{book.Id}  Name:{book.Title}  Author:{book.Author}  Price:{book.Price} Amount:{book.Amount} Category Id:{book.CategoryId}  ");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Try searching for another book or come back later.");
                            }
                            break;
                    case 6:
                        Console.WriteLine("Enter the word you want to search for");
                        string keyword = Console.ReadLine();
                        var booksWithKeyword = webb.GetBooks(keyword);
                            if (booksWithKeyword.Count > 0)
                            {
                                foreach (var book in booksWithKeyword)
                                {
                                    Console.WriteLine($"ID:{book.Id}  Name:{book.Title}  Author:{book.Author}  Price:{book.Price} Amount:{book.Amount} Category Id:{book.CategoryId}  ");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Try another keyword.");
                            }
                            break;
                    case 7:
                        Console.WriteLine("Enter the author you want to search for");
                        keyword = Console.ReadLine();
                        var booksWithSameAuthor = webb.GetAuthors(keyword);
                            if (booksWithSameAuthor.Count > 0)
                            {
                                foreach (var book in booksWithSameAuthor)
                                {
                                    Console.WriteLine($"ID:{book.Id}  Name:{book.Title}  Author:{book.Author}  Price:{book.Price} Amount:{book.Amount} Category Id:{book.CategoryId}  ");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Try searching for another author.");
                            }
                            break;
                    case 8:
                            if (login == 0)
                            {
                                Console.WriteLine("To be able to buy a book, you have to log in");
                                Console.Write("Enter user name:");
                                var name = Console.ReadLine();
                                Console.Write("Enter password:");
                                var pw = Console.ReadLine();
                                login = webb.Login(name, pw);
                            }
                            if (login != 0)
                            {
                                Console.Write("Enter the id of the book you want to buy:");
                                tryCategoryId = int.TryParse(Console.ReadLine(), out categoryId);
                                if (tryCategoryId == false)
                                {
                                    Console.WriteLine("Category id was not entered in correct format. Please try again.");
                                    goto case 8;
                                }
                            var userId = login;
                                var purchaseOk = webb.BuyBook(userId, categoryId);
                            }
                        break;

                    case 9:
                        Console.Write("Enter user name:");
                        var userName = Console.ReadLine();
                        Console.Write("Enter password:");
                        var password = Console.ReadLine();
                        Console.Write("Verify password:");
                        var verifiedPassword = Console.ReadLine();
                        var registerUser = webb.Register(userName, password, verifiedPassword);
                        break;

                    case 10:
                        Console.Write("Enter user name:");
                        userName = Console.ReadLine();
                        Console.Write("Enter password:");
                        password = Console.ReadLine();
                        login = webb.Login(userName, password);
                        break;

                    case 11:
                        bool successfulLogout = webb.Logout(login);
                        if (successfulLogout == true)
                        {
                            login = 0;
                        }
                        System.Environment.Exit(0);
                        break;

                    case 12:
                        Console.Write("Enter username:");
                        userName = Console.ReadLine();
                        Console.Write("Enter password:");
                        password = Console.ReadLine();
                        login = webb.Login(userName, password);
                        webb.CheckIfAdmin(userName, password);                       
                        break;

                        case 13:
                        Console.WriteLine("Thanks for your visit & welcome back!");
                            System.Environment.Exit(0);
                            break;
                    default:
                        Console.WriteLine("Make sure you enter a number between 1-23. Try again.");
                        break;                       
                }
            }

        }

    }
}
