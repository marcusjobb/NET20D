using System;
using System.Linq;
using System.Threading;
using WebbShopAPI.Database;
using WebbShopAPI.Models;

namespace WebbShopAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var webb = new WebbShopAPInterface();
            var db = new EFContext();
            Seeder.AddMockData();

            var loggedInUser = webb.Login("Administrator", "CodicRulez");
            var user = db.Users.FirstOrDefault(u => u.Id == loggedInUser);
            if (user != null && user.IsAdmin == true)
            {
                webb.AddBook(user.Id, 5, "Johansbok", "Jangen", 50, 2);

                webb.Ping(loggedInUser);

                var result = webb.SetAmount(1, 2, 4);
                Console.WriteLine(result);

                webb.Ping(loggedInUser);

                var listOfUsers = webb.ListUsers(loggedInUser);
                foreach (var u in listOfUsers)
                {
                    Console.WriteLine($" Name: {u.Name}" +
                        $"\n LastLogin: {u.LastLogin}");
                }

                webb.Ping(loggedInUser);

                var specificUser = webb.FindUser(1, "s");
                foreach (var u in specificUser)
                {
                    Console.WriteLine($" Name: {u.Name}" +
                        $"\n LastLogin: {u.LastLogin}");
                }

                webb.Ping(loggedInUser);

                var bookResult = webb.UpdateBook(1, 7, "Stjärnornas Krig", "George Lucas", 125);
                if (bookResult == true)
                {
                    Console.WriteLine("Book was updated with new information!");
                }
                if (bookResult == false)
                {
                    Console.WriteLine("Book was not found!");
                }

                webb.Ping(loggedInUser);

                var deleteBook = webb.DeleteBook(1, 2);
                if (deleteBook == true)
                {
                    Console.WriteLine("Book has been removed.");
                }
                if (deleteBook == false)
                {
                    Console.WriteLine("Book was either not found or is out of stock!");
                }

                webb.Ping(loggedInUser);

                var createCategory = webb.AddCategory(1, "Action");
                if (createCategory == true)
                {
                    Console.WriteLine("New Category created!");
                }
                if (createCategory == false)
                {
                    Console.WriteLine("Category already exists!");
                }

                webb.Ping(loggedInUser);

                var changeCategory = webb.AddBookToCategory(1, 3, 5);
                if (changeCategory == true)
                {
                    Console.WriteLine("Category changed!");
                }
                if (changeCategory == false)
                {
                    Console.WriteLine("The book wasn't found or category has already been set!");
                }

                webb.Ping(loggedInUser);

                var updateCategory = webb.UpdateCategory(1, 5, "Action");
                if (updateCategory == true)
                {
                    Console.WriteLine("Category changed!");
                }
                if (updateCategory == false)
                {
                    Console.WriteLine("Category wasn't found or has already been changed!");
                }

                webb.Ping(loggedInUser);

                var delCategory = webb.DeleteCategory(1, 1);
                if (delCategory == true)
                {
                    Console.WriteLine("Category deleted!");
                }
                if (delCategory == false)
                {
                    Console.WriteLine("Category can't be deleted!");
                }

                webb.Ping(loggedInUser);

                webb.AddUser(1, "", "");





            }
            // THIS SECTION IS IF THE USER ISN'T ADMIN ------------------------------
            if (user != null && user.IsAdmin == false)
            {
                var categories = webb.GetCategories("Com");
                if (categories != null)
                {
                    foreach (var cat in categories)
                    {
                        Console.WriteLine(cat.Name);
                    }
                }
                if (categories.Count() == 0)
                {
                    Console.WriteLine("Category doesn't exist.");
                }

                //webb.Ping(loggedInUser);
                //---------------------------------
                var books = webb.GetCategory(1);
                if (books != null)
                {
                    foreach (var book in books)
                    {
                        Console.WriteLine($"{book.Title} - {book.Author}");
                    }
                }

                //webb.Ping(loggedInUser);
                //---------------------------------
                var amountOfBooks = webb.GetAvailableBooks(5);
                if (amountOfBooks != null)
                {
                    foreach (var book in amountOfBooks)
                    {
                        Console.WriteLine($"{book.Title} - {book.Author}");
                    }
                }
                if (amountOfBooks.Count() == 0)
                {
                    Console.WriteLine("Book is out of stock!");
                }

                //webb.Ping(loggedInUser);
                //---------------------------------

                var bookInfo = webb.GetBook(1);
                if (bookInfo != null)
                {
                    foreach (var book in bookInfo)
                    {
                        Console.WriteLine($"Title: {book.Title}" +
                            $"\n Author: {book.Author}" +
                            $"\n Category: {book.Category}" +
                            $"\n Price: {book.Price}" +
                            $"\n Amount: {book.Amount}");

                    }

                }

                //webb.Ping(loggedInUser);
                //---------------------------------

                var books2 = webb.GetBooks("I");
                if (books2 != null)
                {
                    foreach (var book in books2)
                    {
                        Console.WriteLine($"Title: {book.Title}" +
                            $"\n Author: {book.Author}" +
                            $"\n Price: {book.Price}");

                    }
                }

                //webb.Ping(loggedInUser);
                //---------------------------------

                var authors = webb.GetAuthors("Isaa");
                if (authors != null)
                {
                    foreach (var author in authors)
                    {
                        Console.WriteLine($"Title: {author.Title}");

                    }
                }

                //webb.Ping(loggedInUser);
                //---------------------------------

                webb.BuyBook(2, 1);

                //webb.Ping(loggedInUser);
                //---------------------------------

                var register = webb.Register("Johan Jangerud", "hejsan1", "hejsan1");
                if (register == true)
                {
                    Console.WriteLine("User created!");
                }
                if (register == false)
                {
                    Console.WriteLine("User already exists!");
                }

                //webb.Ping(loggedInUser);
            }



        }
    }
}
