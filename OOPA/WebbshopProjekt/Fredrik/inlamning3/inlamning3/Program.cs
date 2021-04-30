using System;
using System.Collections.Generic;
using WebbShopAPI;
using WebbShopAPI.Models;

namespace inlamning3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] userOpts = { 
                "Login", "Logout", "GetCategories", "GetCategrories", "GetCategory", 
                "GetAvailableBooks", "GetBook", "GetBooks", "GetAuthors", 
                "BuyBooks", "Ping", "Register"    
            };
            string[] adminOpts = {
                "AddBook", "SetAmount", "ListUsers", "FindUser", "UpdateBook", "DeleteBook", "AddCategory", "AddBookToCategory", "UpdateCategory",
                "DeleteCategory", "AddUser"
            };
            var api = new WebbShopApi();
            string state = "";
            int id = Dev(api);
            Users signedIn = api.FindUser(id, "Administrator"); //en vanlig användare kan inte hämta en användare, används som identifierare för om användaren är admin
            
            do
            {
                if (state.Length > 0)
                    MenuHelper.PrintState(state);
                int opt = -1;
                if(signedIn == null)
                    opt = InputHelper.GetObligatoryInput(MenuHelper.PrintMenu(userOpts));
                else
                    opt = InputHelper.GetObligatoryInput(MenuHelper.PrintMenu(adminOpts));

                if (signedIn == null)
                    state = UserMenu(opt, id, api);
                else
                    state = AdminMenu(opt, id, api);
                Console.Clear();
            } while (true);
        }

        /// <summary>
        /// The same as UserMenu, it's just for administrators. Functions made here authenticate the signed in user to be an administrator and such 
        /// all things wont work if you're simply a user. <see cref="UserMenu(int, int, WebbShopApi)"/>
        /// </summary>
        /// <param name="opt">What menu option was made</param>
        /// <param name="id">What user is using the system</param>
        /// <param name="api">The api object</param>
        /// <returns>The results of what you just did.</returns>
        static string AdminMenu(int opt, int id, WebbShopApi api)
        {
            string retval = "";

            switch (opt)
            {
                case 0:
                    Console.WriteLine("Adding new book");
                    var categories = api.GetCategories();
                    OutputHelper.PrintArray(categories);
                    int category = -1;
                    do
                    {
                        category = InputHelper.TakeObligatoryIntInput("Enter a category from above");
                    } while (category > categories.Count || category < 1);

                    string title    = InputHelper.TakeObligatoryStringInput("Enter the name of this book");
                    string author   = InputHelper.TakeObligatoryStringInput($"Enter the author of {title}");
                    double cost     = InputHelper.TakeObligatoryDoubleInput($"Enter a price for {title}");
                    int amount      = InputHelper.TakeObligatoryIntInput($"Enter the amount of books you have of {title}");

                    if(api.AddBook(id, category, title, author, cost, amount))
                    {
                        retval = "Added book successfully";
                    }
                    else
                    {
                        retval = "Failed to add book.";
                    }
                    break;
                case 1:
                    Console.WriteLine("Set amount of books");
                    title = InputHelper.TakeObligatoryStringInput("Enter the name of the book you want to change amount for, you can use free search");
                    var books = api.GetBooks(title);
                    int bookId = -1;

                    if (books != null) {
                        if (books.Count > 1)
                        {
                            OutputHelper.PrintArray(books);
                            do
                            {
                                bookId = InputHelper.TakeObligatoryIntInput("Enter the id of a book from above");
                            } while (bookId > books.Count || bookId < 1);
                            var book = api.GetBook(bookId);
                            Console.WriteLine($"Found one book: {book.Title}");
                            amount = InputHelper.TakeObligatoryIntInput("Enter the new amount");
                            retval = api.SetAmount(id, bookId, amount) == true ? $"Set amount to {amount} for book {book.Title}" : $"Unable to change amount for book {book.Title}";
                        }
                        else
                        {
                            Console.WriteLine($"Found one book: {books[0].Title}");
                            amount = InputHelper.TakeObligatoryIntInput("Enter the new amount");
                            retval = api.SetAmount(id, books[0].Id, amount) == true ? $"Set amount to {amount} for book {books[0].Title}" : $"Unable to change amount for book {books[0].Title}";
                        }
                    }                    
                    break;
                case 2:
                    Console.WriteLine("List users");
                    OutputHelper.PrintArray(api.ListUsers(id));
                    MenuHelper.Interrupt();
                    break;
                case 3:
                    Console.WriteLine("Find users");
                    string name = InputHelper.TakeObligatoryStringInput("Enter the name of the person you'd like to find");
                    var result = api.FindUser(id, name);

                    if(result != null)
                    {
                        retval = $"User found\nId: {result.Id}\nName: {result.Name}\nLast login: {result.LastLogin}\nEnabled: {result.IsActive}\nIs administrator: {result.IsAdmin}";
                    }
                    else
                    {
                        retval = "No user found.";
                    }
                    break;
                case 4:
                    Console.WriteLine("Updating existing book");

                    Console.WriteLine("Please select which book to update");
                    title = InputHelper.TakeObligatoryStringInput("Enter the name of the book you want to change amount for, you can use free search");
                    books = api.GetBooks(title);
                    bookId = -1;
                    do
                    {
                        bookId = InputHelper.TakeObligatoryIntInput("Enter the id of a book from above");
                    } while (bookId > books.Count || bookId < 1);

                    Console.WriteLine($"Selected {books[bookId].Title}");

                    categories = api.GetCategories();
                    OutputHelper.PrintArray(categories);
                    category = -1;
                    do
                    {
                        category = InputHelper.TakeObligatoryIntInput("Enter a category from above");
                    } while (category > categories.Count || category < 1);

                    title   = InputHelper.TakeObligatoryStringInput("Enter the new name of this book");
                    author  = InputHelper.TakeObligatoryStringInput($"Enter the new author of {title}");
                    cost    = InputHelper.TakeObligatoryDoubleInput($"Enter the new price for {title}");

                    if (api.UpdateBook(id, bookId, title, author, cost))
                    {
                        retval = "Added book successfully";
                    }
                    else
                    {
                        retval = "Failed to add book.";
                    }
                    break;
                case 5:
                    Console.WriteLine("Delete existing book");

                    Console.WriteLine("Please select which book to delete");
                    title   = InputHelper.TakeObligatoryStringInput("Enter the name of the book you want to change amount for, you can use free search");
                    books   = api.GetBooks(title);
                    bookId  = -1;
                    do
                    {
                        bookId = InputHelper.TakeObligatoryIntInput("Enter the id of a book from above");
                    } while (bookId > books.Count || bookId < 1);

                    if(api.DeleteBook(id, bookId))
                    {
                        retval = $"Successfully deleted {books[bookId].Title}";
                    }
                    else
                    {
                        retval = $"Failed to delete {books[bookId].Title}";
                    }
                    break;
                case 6:
                    Console.WriteLine("Add category");
                    OutputHelper.PrintArray(api.GetCategories());
                    title = InputHelper.TakeObligatoryStringInput("Enter a new name for a category, the names above cannot be used");

                    if(api.AddCategory(id, title))
                    {
                        retval = $"Successfully created category {title}";
                    }
                    else
                    {
                        retval = $"Failed to create category {title}";
                    }
                    break;
                case 7:
                    Console.WriteLine("Please select which book to change category for");
                    title = InputHelper.TakeObligatoryStringInput("Enter the name of the book you want to change category for, you can use free search");
                    books = api.GetBooks(title);
                    bookId = -1;
                    do
                    {
                        bookId = InputHelper.TakeObligatoryIntInput("Enter the id of a book from above");
                    } while (bookId > books.Count || bookId < 1);

                    Console.WriteLine($"Selected {books[bookId].Title}");


                    categories = api.GetCategories();
                    OutputHelper.PrintArray(categories);
                    category = -1;
                    do
                    {
                        category = InputHelper.TakeObligatoryIntInput($"Enter a category from above to set for the book {books[bookId].Title}");
                    } while (category > categories.Count || category < 1);

                    if(api.AddBookToCategory(id, bookId, category))
                    {
                        retval = $"Successfully moved {books[bookId].Title} to category {categories[category].Name}";
                    }
                    else
                    {
                        retval = $"Failed to set book category for book {books[bookId].Title}";
                    }
                    break;
                case 8:
                    Console.WriteLine("Please select which category to update");
                    categories = api.GetCategories();
                    OutputHelper.PrintArray(categories);
                    category = -1;
                    do
                    {
                        category = InputHelper.TakeObligatoryIntInput($"Enter a category id from above");
                    } while (category > categories.Count || category < 1);

                    Console.WriteLine($"Selected {categories[category].Name}");
                    string was = categories[category].Name;
                    title = InputHelper.TakeObligatoryStringInput($"Enter a new name for {was}, you can't reuse any existing names");

                    if (api.UpdateCategory(id, category, title))
                    {
                        retval = $"Successfully renamed category {was} to {title}";
                    }
                    else
                    {
                        retval = $"Failed to rename category {was} to {title}";
                    }
                    break;
                case 9:
                    Console.WriteLine("Please select which category to delete");
                    categories = api.GetCategories();
                    OutputHelper.PrintArray(categories);
                    category = -1;
                    do
                    {
                        category = InputHelper.TakeObligatoryIntInput($"Enter a category id from above");
                    } while (category > categories.Count || category < 1);
                    was = categories[category].Name;
                    books = api.GetAvailableBooks(category);
                    if(books == null)
                    {
                        if(api.DeleteCategory(id, category)){
                            retval = $"Successfully deleted category {was}";
                        }
                    }
                    else
                    {
                        retval = $"You have books assigned to {categories[category].Name}, you can't remove it until they are moved to another category.";
                    }
                    break;
                case 10:
                    Console.WriteLine("Add a new user");

                    name = InputHelper.TakeObligatoryStringInput($"Enter a username for the new user, it may not exist previously");
                    var password = InputHelper.TakeObligatoryStringInput($"Enter a password for the new user");
                    var password2 = InputHelper.TakeObligatoryStringInput($"Enter the password once more, it must match what you just wrote");

                    if(password == password2)
                    {
                        if(api.AddUser(id, name, password))
                        {
                            retval = $"Added user {name}";
                        }
                    }
                    else
                    {
                        retval = "Passwords didn't match.";
                    }
                    break;
                case 11:
                    Console.WriteLine("Sold items");
                    OutputHelper.PrintArray(api.SoldItems(id));
                    break;
                case 12:
                    Console.WriteLine($"Money earned: {api.MoneyEarned(id)}");
                    break;
                case 13:
                    Console.WriteLine($"Best customer: {api.BestCustomer(id)}");
                    break;
                case 14:
                    Console.WriteLine("Promote user");
                    var users = api.ListUsers(id);
                    OutputHelper.PrintArray(users);
                    Console.WriteLine("Please select a user from the list above");
                    var uid = -1;
                    do
                    {
                        uid = InputHelper.TakeObligatoryIntInput($"Enter a user id from above");
                    } while (uid > users.Count || uid < 1);

                    if(api.Promote(id, uid))
                    {
                        retval = $"Promoted user {uid}";
                    }
                    else
                    {
                        retval = $"Could not promote {uid}";
                    }
                    break;
                case 15:
                    Console.WriteLine("Demote user");
                    users = api.ListUsers(id);
                    OutputHelper.PrintArray(users);
                    Console.WriteLine("Please select a user from the list above");
                    uid = -1;
                    do
                    {
                        uid = InputHelper.TakeObligatoryIntInput($"Enter a user id from above");
                    } while (uid > users.Count || uid < 1);

                    if (api.Promote(id, uid))
                    {
                        retval = $"Demoted user {uid}";
                    }
                    else
                    {
                        retval = $"Could not demote {uid}";
                    }
                    break;
                case 16:
                    Console.WriteLine("Activate user");
                    users = api.ListUsers(id);
                    OutputHelper.PrintArray(users);
                    Console.WriteLine("Please select a user from the list above");
                    uid = -1;
                    do
                    {
                        uid = InputHelper.TakeObligatoryIntInput($"Enter a user id from above");
                    } while (uid > users.Count || uid < 1);

                    if (api.Promote(id, uid))
                    {
                        retval = $"Activated user {uid}";
                    }
                    else
                    {
                        retval = $"Could not activate {uid}";
                    }
                    break;
                case 17:
                    Console.WriteLine("Deactivate user");
                    users = api.ListUsers(id);
                    OutputHelper.PrintArray(users);
                    Console.WriteLine("Please select a user from the list above");
                    uid = -1;
                    do
                    {
                        uid = InputHelper.TakeObligatoryIntInput($"Enter a user id from above");
                    } while (uid > users.Count || uid < 1);

                    if (api.Promote(id, uid))
                    {
                        retval = $"Deactivated user {uid}";
                    }
                    else
                    {
                        retval = $"Could not deactivate {uid}";
                    }
                    break;
                default:
                    retval = "Option unknown.";
                    break;
            }

            return retval;
        }

        /// <summary>
        /// Output the user menu, a user is not an administrator and more seen as an employee.
        /// </summary>
        /// <param name="opt">What menu option was made</param>
        /// <param name="id">What user is using the system</param>
        /// <param name="api">The api object</param>
        /// <returns>The results of what you just did.</returns>
        static string UserMenu(int opt, int id, WebbShopApi api)
        {
            string[] messages = { 
                "Enter a search-word or phrase",
                "Enter a category id",
                "Enter the book id"
            };
            string retval = "";
            switch (opt)
            {
                case 0:
                    id = api.Login(
                        InputHelper.TakeObligatoryStringInput("Enter your username"),
                        InputHelper.TakeObligatoryStringInput("Enter your password")
                    );

                    if (id > 0)
                    {
                        retval = "Login successfull.";
                    }
                    else
                    {
                        if (id == -1)
                        {
                            retval = "The username was not found.";
                        }
                        else
                        {
                            retval = "This account is disabled.";
                        }
                    }
                    break;
                case 1:
                    if (api.Logout(id))
                    {
                        id = -1;
                        retval = "Account was signed out.";
                    }
                    else
                    {
                        retval = "No account to sign out.";
                    }
                    break;
                case 2:
                    OutputHelper.PrintArray(api.GetCategories());
                    MenuHelper.Interrupt();
                    break;
                case 3:
                    OutputHelper.PrintArray(api.GetCategories(InputHelper.TakeObligatoryStringInput(messages[0])));
                    MenuHelper.Interrupt();
                    break;
                case 4:
                    OutputHelper.PrintArray(api.GetCategory(InputHelper.TakeObligatoryIntInput(messages[1])));
                    MenuHelper.Interrupt();
                    break;
                case 5:
                    OutputHelper.PrintArray(api.GetAvailableBooks(InputHelper.TakeObligatoryIntInput(messages[1])));
                    MenuHelper.Interrupt();
                    break;
                case 6:
                    OutputHelper.Print(api.GetBook(InputHelper.TakeObligatoryIntInput(messages[2])));
                    MenuHelper.Interrupt();
                    break;
                case 7:
                    OutputHelper.Print(api.GetBooks(InputHelper.TakeObligatoryStringInput(messages[0])));
                    MenuHelper.Interrupt();
                    break;
                case 8:
                    OutputHelper.Print(api.GetAuthors(InputHelper.TakeObligatoryStringInput(messages[0])));
                    MenuHelper.Interrupt();
                    break;
                case 9:
                    if(api.BuyBook(InputHelper.TakeObligatoryIntInput("Enter the user id (buyer)"), InputHelper.TakeObligatoryIntInput(messages[2])))
                    {
                        retval = "The book was bought successfully.";
                    }
                    else
                    {
                        retval = "The book couldn't be sold.";
                    }
                    MenuHelper.Interrupt();
                    break;
                case 10:
                    if (api.Ping(id) == "pong")
                    {
                        retval = "Your session was extended";
                    }
                    else
                    {
                        retval = "Failed to extend session";
                    }
                    MenuHelper.Interrupt();
                    break;
                case 11:
                    if(api.Register(InputHelper.TakeObligatoryStringInput("The customers username"), InputHelper.TakeObligatoryStringInput("The customers desired password"), InputHelper.TakeObligatoryStringInput("The password again")))
                    {
                        retval = "The customer was registered successfully.";
                    }
                    else
                    {
                        retval = "The customer couldn't be registered at this time. Either:\n\t- The username is taken\n\t- The passwords doesn't match\n\t- The username was filled in blank\n\t- The password is too short";
                    }
                    MenuHelper.Interrupt();
                    break;
                default:
                    retval = "Option unknown.";
                    break;
            }
            return retval;
        }

        /// <summary>
        /// Just skip that thing called authentication. You get signed in as an admin.
        /// </summary>
        /// <param name="api">The api object</param>
        /// <returns>The administrator account id</returns>
        static int Dev(WebbShopApi api)
        {
            return api.Login(
                "Administrator",
                "CodicRulez"
            );
        }
    }
}
