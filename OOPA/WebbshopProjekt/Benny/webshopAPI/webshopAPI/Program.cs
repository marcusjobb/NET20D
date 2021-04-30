using System;
using System.Collections.Generic;
using webshopAPI.Helpers;
using webshopAPI.Models;
using webshopAPI.View;

namespace webshopAPI
{
    internal static class Program
    {
        private static int LoopThruTheMenu(List<BookCategory> loopThruTheseChoices = null)
        {
            bool reloop = true;
            int userChoice = 0;
            do
            {
                Console.Write("Choose category >");
                var input = Console.ReadLine();
                try
                {
                    int.TryParse(input, out userChoice);
                    if (loopThruTheseChoices.Count >= userChoice && userChoice != 0)
                    {
                        reloop = false;
                    }
                }
                catch
                {
                    reloop = true;
                }
            } while (reloop);
            return userChoice;
        }

        private static int LoopThruTheMenu(List<Book> loopThruTheseChoices = null)
        {
            bool reloop = true;
            int userChoice = 0;
            do
            {
                Console.Write("Choose book >");
                var input = Console.ReadLine();
                try
                {
                    int.TryParse(input, out userChoice);
                    if (loopThruTheseChoices.Count >= userChoice && userChoice != 0)
                    {
                        reloop = false;
                    }
                }
                catch
                {
                    reloop = true;
                }
            } while (reloop);
            return userChoice;
        }

        private static void Main(string[] args)
        {
            /**************************************************************
                            Create instance of WebshopAPI
             **************************************************************/
            WebShopApi api = new WebShopApi();

            /**************************************************************
                            Create mockdata if not already created
             **************************************************************/
            Seeder.Seed();
            // Users created

            /* User             Password        Active  Admin
               Administrator    CodicRulez      YES     YES
               TestCustomer     Codic2021       YES     NO
               InactiveCustomer Codic2021       NO      NO
            */

            /**************************************************************
                             Register specified user
             **************************************************************/
            PrintOut.Red("Register()");
            //wrong verification password
            Console.WriteLine($"registration successful: " +
                $"{api.Register("Benny", "password", "pasword")}");
            //Tries to register a user that already exists
            Console.WriteLine($"registration successful: " +
                $"{api.Register("Administrator", "password", "password")}");
            //Registers a non existing user (at first run at least)
            Console.WriteLine($"registration successful: " +
                $"{api.Register("Benny", "password", "password")}");
            /**************************************************************
                             Log in the specified user
             **************************************************************/
            User loggedInUser = null;
            PrintOut.Red("LogIn()");
            //loggedInUser.IdId = api.Login("Benny", "Password");
            loggedInUser = api.Login("Administrator", "CodicRulez");
            ///loggedInUser.IdId = api.Login("TestCustomer", "Codic2021");
            //loggedInUser.IdId = api.Login("InactiveCustomer", "Codic2021");
            //loggedInUser.IdId = api.Login("", "");
            //loggedInUser.IdId = api.Login("WrongCredetials", "SoSoWrong");

            if (loggedInUser.Id > 0)
            {
                Console.WriteLine($"User with id {loggedInUser.Id} is logged in");
            }
            else
            {
                Console.WriteLine("Not logged in, inactive user or wrong credentials.");
            }

            /**************************************************************
                             Promote()
             **************************************************************/
            PrintOut.Red("Promote() - Admin Function");
            Console.WriteLine("Promoting Benny to Admin");
            var listOfUsers = api.FindUser(loggedInUser.Id, "Benny");
            var success = false;
            if (listOfUsers.Count != 0)
            {
                success = api.Promote(
                loggedInUser.Id,
                listOfUsers[0].Id);
                Console.WriteLine($"successful: {success}");
            }
            else
            {
                Console.WriteLine("Either you don´t have admin priviliges " +
                    "or there are no such user in the database.");
            }

            Console.ReadKey();

            /**************************************************************
                             Demote()
             **************************************************************/
            PrintOut.Red("Demote() - Admin Function");
            Console.WriteLine("Demoting Benny to User");
            listOfUsers.Clear();
            listOfUsers = api.FindUser(loggedInUser.Id, "Benny");
            if (listOfUsers.Count != 0)
            {
                success = api.Demote(
                    loggedInUser.Id, listOfUsers[0].Id);
                Console.WriteLine($"successful: {success}");
            }
            else
            {
                Console.WriteLine("Either you don´t have admin priviliges " +
                    "or there are no such user in the database.");
            }
            Console.ReadKey();

            /**************************************************************
                             ActivateUser()
             **************************************************************/
            PrintOut.Red("ActivateUser() - Admin Function");
            Console.WriteLine("Activating \"InactiveCustomer\"");
            listOfUsers.Clear();
            listOfUsers = api.FindUser(loggedInUser.Id, "InactiveCustomer");
            if (listOfUsers.Count != 0)
            {
                success = api.ActivateUser(
                    loggedInUser.Id, listOfUsers[0].Id);
                Console.WriteLine($"successful: {success}");
            }
            else
            {
                Console.WriteLine("Either you don´t have admin priviliges " +
                    "or there are no such user in the database.");
            }
            Console.ReadKey();

            /**************************************************************
                             InactivateUser()
             **************************************************************/
            PrintOut.Red("InactivateUser() - Admin Function");
            Console.WriteLine("Inactivating \"InactiveCustomer\"");
            listOfUsers.Clear();
            listOfUsers = api.FindUser(loggedInUser.Id, "InactiveCustomer");
            if (listOfUsers.Count != 0)
            {
                success = api.InactivateUser(
                    loggedInUser.Id, listOfUsers[0].Id);
                Console.WriteLine($"successful: {success}");
            }
            else
            {
                Console.WriteLine("Either you don´t have admin priviliges " +
                    "or there are no such user in the database.");
            }
            Console.ReadKey();

            /**************************************************************
                             AddUser()
             **************************************************************/
            PrintOut.Red("AddUser() - Admin Function");
            Console.WriteLine("Adding user \"Nisse\" to database");
            bool successful = api.AddUser(loggedInUser.Id, "Nisse", "MittLösenord");
            Console.WriteLine($"Was add successful? {successful}");
            if (!successful)
            {
                Console.WriteLine("Probably due to wrong user priviliges or duplicate of user");
            }
            /**************************************************************
                             ListUsers()
             **************************************************************/
            PrintOut.Red("ListUsers()");
            Console.WriteLine("Users in database:");
            foreach (var item in api.ListUsers(loggedInUser.Id))
            {
                Console.WriteLine($"\t{item.Name}");
            }

            if (loggedInUser.Id == 0)
            {
                Console.WriteLine("You are not logged in or has no priviliges to see users");
            }
            PrintOut.DarkRed("Press enter()");
            Console.ReadKey();

            /**************************************************************
                             FindUsers()
             **************************************************************/
            PrintOut.Red("FindUsers()");
            Console.WriteLine("Users in database matching the keyword sto:");
            foreach (var item in api.FindUser(loggedInUser.Id, "sto"))
            {
                Console.WriteLine($"\t{item.Name}");
            }

            if (loggedInUser.Id == 0)
            {
                Console.WriteLine("You are not logged in or has no priviliges to see users");
            }
            PrintOut.DarkRed("Press enter()");
            Console.ReadKey();

            /**************************************************************
                            GetCategories(keyword)
            **************************************************************/
            PrintOut.Red("Get categories(keyword) - THIS IS NOT USED IN THE STEP WHERE YOU CAN CHOOSE CATEGORY.");
            var categories = api.GetCategories("Hu");
            Console.WriteLine("Listing Categories with searchkeyword Hu:");

            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine($"\t{i + 1}. {categories[i].Name}");
            }
            PrintOut.DarkRed("Press enter()");
            Console.ReadKey();

            /**************************************************************
                            GetCategory()
            **************************************************************/
            PrintOut.Red("Get category() - THIS IS NOT USED IN THE STEP WHERE YOU CAN CHOOSE CATEGORY.");
            if (categories.Count > 0)
            {
                var booksInCategory = api.GetBooksInCategory(categories[0].Id);
                Console.WriteLine("Listing books in category Humor:");

                for (int i = 0; i < booksInCategory.Count; i++)
                {
                    Console.WriteLine($"\t{i + 1}. {booksInCategory[i].Title}");
                }
            }
            else
            {
                Console.WriteLine("Ingen träff");
            }
            PrintOut.DarkRed("Press enter()");
            Console.ReadKey();

            /**************************************************************
                            AddBook()
            **************************************************************/
            PrintOut.Red("AddBook()");
            var amount = 1;
            var title = "I cirkelns utkant";
            var author = "Dan Brown";
            var price = 199;
            Console.WriteLine($"Adding {title} by {author} with amount {amount} and the price {price}.");
            Console.WriteLine($"Was it successful? " +
                $"{api.AddBook(loggedInUser.Id, amount, title, author, price)}");

            PrintOut.DarkRed("Press enter()");
            Console.ReadKey();

            /**************************************************************
                            UpdateBook()
            **************************************************************/
            PrintOut.Red("UpdateBook()");
            title = "I cirkelns mitt";
            author = "Dan Brown";
            price = 199;
            var books = api.GetBooks("I cirkelns utkant");
            try
            {
                Console.WriteLine($"Updating book with {title} by {author} and the price {price}.");
                Console.WriteLine($"Was it successful? " +
                    $"{api.UpdateBook(loggedInUser.Id, books[0].Id, title, author, price)}");
                books.Clear();
            }
            catch
            {
                Console.WriteLine("Either you don´t have admin priviliges " +
                    "or there are no such book in the database.");
            }

            PrintOut.DarkRed("Press enter()");
            Console.ReadKey();

            /**************************************************************
                             AddCategory()
             **************************************************************/
            PrintOut.Red("AddCategory()");
            Console.WriteLine("Adding \"Thrillers\" to the categories");
            Console.WriteLine($"Was it successful? " +
                $"{api.AddCategory(loggedInUser.Id, "Thrillers")}");

            /**************************************************************
                             UpdateCategory()
             **************************************************************/
            PrintOut.Red("UpdateCategory()");
            Console.WriteLine("Updating \"Thrillers\" to \"Thriller\"");
            var updateThisCategory = api.GetCategories("Thrillers");
            try
            {
                successful = api.UpdateCategory(loggedInUser.Id, updateThisCategory[0].Id, "Thriller");
                Console.WriteLine($"Was it successful? {successful}");
                if (!successful)
                {
                    Console.WriteLine("Probably due to wrong admin priviliges " +
                        "or category already existing");
                }
            }
            catch
            {
                Console.WriteLine("No such category or you don´t have the right priviliges");
            }

            /**************************************************************
                             AddBookToCategory()
             **************************************************************/
            PrintOut.Red("AddBookToCategory()");
            Console.WriteLine("Adding {title} to \"Thriller\" category");
            books = api.GetBooks("I cirkelns mitt");
            try
            {
                var listOfCategories = api.GetCategories("Thriller");
                Console.WriteLine($"Was it successful? " +
                    $"{api.AddBookToCategory(loggedInUser.Id, books[0].Id, listOfCategories[0].Id)}");
                books.Clear();
            }
            catch
            {
                Console.WriteLine("No such category or you don´t have the right priviliges");
            }

            /**************************************************************
                            GetBooksByAuthor()
            **************************************************************/
            PrintOut.Red("GetBooksByAuthor() - THIS IS NOT USED IN THE NEXT STEP WHERE YOU CAN CHOOSE CATEGORY.");
            var booksByAuthor = api.GetBooksByAuthor("Stephen");
            Console.WriteLine("Listing books by authors with keyword \"Stephen\":");

            for (int i = 0; i < booksByAuthor.Count; i++)
            {
                Console.WriteLine($"\t{i + 1}. {booksByAuthor[i].Title}");
            }
            PrintOut.DarkRed("Press enter()");
            Console.ReadKey();

            /**************************************************************
                             GetCategories()
             **************************************************************/
            PrintOut.Red("Get categories()");
            categories = api.GetCategories();
            Console.WriteLine("Categories:");

            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine($"\t{i + 1}. {categories[i].Name}");
            }

            int userChoice = LoopThruTheMenu(categories);

            /**************************************************************
                             GetAvailibleBooks()
             **************************************************************/
            //PrintOut.Red("GetAvailibleBooks()");
            //books = api.GetAvailibleBooks(categories[userChoice - 1].Id);

            //for (int i = 0; i < books.Count; i++)
            //{
            //    Console.WriteLine($"\t{i + 1}. {books[i].Title}");
            //}

            //userChoice = LoopThruTheMenu(books);
            /**************************************************************
                             Get book from keyword()
             **************************************************************/
            PrintOut.Red("GetBooks(keyword)");
            var listOfBooks = api.GetBooks(books[userChoice - 1].Title);
            Console.WriteLine($"I've retrieved the books for you. confirm your choice:");

            for (int i = 0; i < listOfBooks.Count; i++)
            {
                Console.WriteLine($"\t{i + 1}. {listOfBooks[i].Title}");
            }

            userChoice = LoopThruTheMenu(listOfBooks);

            /**************************************************************
                             GetBook()
             **************************************************************/
            PrintOut.Red("GetBook()");
            var book = api.GetBook(listOfBooks[userChoice - 1].Id);
            Console.WriteLine($"I got the book for you!");

            Console.WriteLine($"{book.Title} written by {book.Author}\n" +
                $"Has the price {book.Price}\n" +
                $"Availible quantity: {book.Amount}");
            PrintOut.DarkRed("Press enter()");
            Console.ReadKey();

            /**************************************************************
                             Buy book()
             **************************************************************/
            PrintOut.Red("BuyBook()");
            Console.WriteLine($"Was it successful? " +
                $"{api.BuyBook(loggedInUser.Id, listOfBooks[userChoice - 1].Id)}");

            PrintOut.DarkRed("Press enter()");
            Console.ReadKey();
            /**************************************************************
                             Sold items()
             **************************************************************/
            PrintOut.Red($"SoldItems()");
            var list = api.SoldItems(loggedInUser.Id);
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Title} from author {item.Author} " +
                    $"was bought {item.PurchaseDate.ToShortDateString()} " +
                    $"by user with userID {item.UserId} ");
            }
            if (list.Count == 0)
            {
                Console.WriteLine("No access to see sold books or there are no sold books in database.");
            }
            PrintOut.DarkRed("Press enter()");
            Console.ReadKey();

            /**************************************************************
                             Ping()
             **************************************************************/
            PrintOut.Red($"Ping()");
            Console.WriteLine(api.Ping(loggedInUser.Id));
            PrintOut.DarkRed("Check database for session renewal then press enter()");
            Console.ReadKey();

            /**************************************************************
                             SetAmount()
             **************************************************************/
            PrintOut.Red($"SetAmount()");
            Console.WriteLine("Adding 10 books to database (the book you bought)");
            Console.WriteLine($"Successful change: { api.SetAmount(loggedInUser.Id, listOfBooks[userChoice - 1].Id, 10)}");
            book = api.GetBook(listOfBooks[userChoice - 1].Id);
            Console.WriteLine($"Here is the new status of the book!");

            Console.WriteLine($"{book.Title} Availible quantity: {book.Amount}");
            PrintOut.DarkRed("Press enter");
            Console.ReadKey();

            Console.WriteLine("Reducing number of books with 4 to database (the book you bought)");
            Console.WriteLine($"Successful change: { api.SetAmount(loggedInUser.Id, listOfBooks[userChoice - 1].Id, -4)}");
            book = api.GetBook(listOfBooks[userChoice - 1].Id);
            Console.WriteLine($"Here is the new status of the book!");

            Console.WriteLine($"{book.Title} Availible quantity: {book.Amount}");
            PrintOut.DarkRed("Press enter");
            Console.ReadKey();

            /**************************************************************
                             DeleteBook()
             **************************************************************/
            PrintOut.Red($"DeleteBook()");
            Console.WriteLine("Deleting 6 books from database (the book you bought)");
            Console.WriteLine($"Successful change: { api.DeleteBook(loggedInUser.Id, listOfBooks[userChoice - 1].Id, 6)}");
            Console.ReadKey();

            /**************************************************************
                             DeleteCategory()
             **************************************************************/
            PrintOut.Red($"DeleteCategory()");
            Console.WriteLine("Deleting category from database (Thriller)");
            Console.WriteLine($"Successful change: { api.DeleteCategory(loggedInUser.Id, 5)}");
            Console.ReadKey();

            /**************************************************************
                             MoneyEarned()
             **************************************************************/
            PrintOut.Red("MoneyEarned()");
            Console.WriteLine($"Money earned: {api.MoneyEarned(loggedInUser.Id)}");

            /**************************************************************
                             BestCustomer()
             **************************************************************/
            PrintOut.Red("BestCustomer()");
            var bestCustomer = api.BestCustomer(loggedInUser.Id);
            if (bestCustomer != (null, 0))
            {
                Console.WriteLine($"Best Customer: {bestCustomer.Item1.Name} has bought {bestCustomer.Item2} books");
            }
            else
            {
                Console.WriteLine("You don´t have the user rights to see this.");
            }

            /**************************************************************
                             LogOut()
             **************************************************************/
            PrintOut.Red($"LogOut()");
            Console.WriteLine("Logging out the user...Press enter to quit the program");
            api.Logout(loggedInUser.Id);
            Console.ReadKey();
        }
    }
}