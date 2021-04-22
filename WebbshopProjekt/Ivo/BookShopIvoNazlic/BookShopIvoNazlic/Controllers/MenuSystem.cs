using BookShopIvoNazlic.Views;
using System;

namespace BookShopIvoNazlic.Controllers
{
    /// <remarks>
    /// Contains all the logic of the menu system
    /// Contains methods that call the API-methods
    /// </remarks>
    static class MenuSystem
    {

        private static int loggedInUserId;

        /// <summary>
        /// Handles all the API-actions available to a user. 
        /// Logic based on switch functionality.
        /// <param name="userMenuChoice">Array containing chosen menu option</param>
        /// </summary>
        public static void ProgramActions(object[] userMenuChoice)
        {
            Console.WriteLine($"You've chosen {userMenuChoice[1]}\n");
            switch (userMenuChoice[0])
            {

                case 1: //User login

                    loggedInUserId = WebbShopIvoNazlic.WebbShopAPI.Login(MenuTools.UsernameInput(), MenuTools.PasswordInput());
                    if (loggedInUserId != 0)
                    {
                        if (WebbShopIvoNazlic.WebbShopAPI.IsAdmin(loggedInUserId))
                        {
                            Layout.AdminLayout();
                            Layout.AdminLoggedIn();
                            Start.IsAdmin = true;
                            Layout.ClearScreen();
                        }

                        else
                        {
                            Layout.LoginSuccesfull();
                            Layout.ClearScreen();
                        }
                    }

                    else
                    {
                        Console.WriteLine("Wrong username and/or password.\nPlease try again");
                        Layout.ClearScreen();
                    }

                    break;


                case 2: //User logout.

                    WebbShopIvoNazlic.WebbShopAPI.Logout(loggedInUserId);
                    Layout.ClearScreen();
                    break;


                case 3: //List all categories

                    foreach (var item in WebbShopIvoNazlic.WebbShopAPI.GetCategories(loggedInUserId))
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("");
                    Layout.ClearScreen();
                    break;


                case 4: //List all books in a category (by matching keyword)

                    string keyword = MenuTools.KeywordInput();
                    foreach (var item in WebbShopIvoNazlic.WebbShopAPI.GetCategories(loggedInUserId, keyword))
                    {
                        Console.WriteLine(item);
                    }

                    Console.WriteLine("");
                    Layout.ClearScreen();
                    break;


                case 5: //List of all books in a category

                    if (int.TryParse(MenuTools.CategoryIdInput(), out int categoryId))
                    {
                        foreach (var item in WebbShopIvoNazlic.WebbShopAPI.GetCategory(loggedInUserId, categoryId))
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("");
                        Layout.ClearScreen();
                    }

                    else
                    {
                        Layout.NotNumber();
                    }

                    break;


                case 6: //List all books with amount > 0

                    if (int.TryParse(MenuTools.CategoryIdInput(), out categoryId))
                    {
                        foreach (var item in WebbShopIvoNazlic.WebbShopAPI.GetAvailableBooks(loggedInUserId, categoryId))
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("");
                        Layout.ClearScreen();
                    }

                    else
                    {
                        Layout.NotNumber();
                    }

                    break;


                case 7: //Get info about a book

                    if (int.TryParse(MenuTools.BookIdInput(), out int bookId))
                    {
                        Console.WriteLine($"{WebbShopIvoNazlic.WebbShopAPI.GetBook(loggedInUserId, bookId)}\n");
                        Layout.ClearScreen();
                    }

                    else
                    {
                        Layout.NotNumber();
                    }

                    break;


                case 8: //List all books (by matching keyword)

                    keyword = MenuTools.KeywordInput();
                    foreach (var item in WebbShopIvoNazlic.WebbShopAPI.GetBooks(loggedInUserId, keyword))
                    {
                        Console.WriteLine(item);
                    }

                    Console.WriteLine("");
                    Layout.ClearScreen();

                    break;


                case 9: //List all books by matching author

                    keyword = MenuTools.KeywordInput();
                    foreach (var item in WebbShopIvoNazlic.WebbShopAPI.GetAuthors(loggedInUserId, keyword))
                    {
                        Console.WriteLine(item);
                    }

                    Console.WriteLine("");
                    Layout.ClearScreen();

                    break;


                case 10: //Buy book

                    if (int.TryParse(MenuTools.BookIdInput(), out bookId))
                    {
                        if (WebbShopIvoNazlic.WebbShopAPI.BuyBook(loggedInUserId, bookId))
                        {
                            Layout.PurchaseSuccesfull(WebbShopIvoNazlic.WebbShopAPI.GetBook(loggedInUserId, bookId));
                            Layout.ClearScreen();
                        }

                        else
                        {
                            Layout.PurchaseFail();
                        }
                    }

                    else
                    {
                        Layout.NotNumber();
                    }

                    break;


                case 11: //Ping

                    Console.Clear();
                    Console.WriteLine(WebbShopIvoNazlic.WebbShopAPI.Ping(loggedInUserId));
                    Layout.ClearScreen();
                    break;


                case 12: //Register user

                    if (WebbShopIvoNazlic.WebbShopAPI.Register(MenuTools.UsernameInput(), MenuTools.PasswordInput()))
                    {
                        Console.WriteLine("User created");
                        Layout.ClearScreen();
                    }

                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Registration failed\n");
                        Layout.ClearScreen();
                    }

                    break;


                case 13: //Exit program

                    Start.keepPlaying = false;
                    break;

                default:

                    Layout.ClearScreen();
                    break;

            }
        }


        /// <summary>
        /// Handels all the API-actions available to a administrator. 
        /// Logic based on switch functionality.
        /// <param name="userMenuChoice">Array containing chosen menu option</param>
        /// </summary>
        public static void AdminActions(object[] userMenuChoice)
        {
            Console.WriteLine($"You've chosen {userMenuChoice[1]}\n");
            switch (userMenuChoice[0])
            {

                case 1: //Add book

                    string bookTitle = MenuTools.BookTitleInput();
                    string author = MenuTools.AuthorInput();
                    if (int.TryParse(MenuTools.PriceInput(), out int price))
                    {
                        Console.Clear();
                        if (int.TryParse(MenuTools.AmmountInput(), out int ammount))
                        {
                            Console.Clear();
                            if (WebbShopIvoNazlic.WebbShopAPI.AddBook(loggedInUserId, bookTitle, author, price, ammount))
                            {
                                Console.WriteLine("Book added.\n");
                                Layout.ClearScreen();
                            }
                            else
                            {
                                Console.WriteLine("Adding book failed.\n");
                                Layout.ClearScreen();
                            }
                        }

                        else
                        {
                            Layout.NotNumber();
                        }

                    }

                    else
                    {
                        Layout.NotNumber();
                    }

                    break;


                case 2: //Set ammount of books

                    if (int.TryParse(MenuTools.BookIdInput(), out int bookId))
                    {
                        Console.Clear();
                        if (WebbShopIvoNazlic.WebbShopAPI.SetAmount(loggedInUserId, bookId))
                        {
                            Console.WriteLine("Ammount of books set.\n");
                            Layout.ClearScreen();
                        }

                        else
                        {
                            Console.WriteLine("Updating ammount of books failed.\n");
                            Layout.ClearScreen();
                        }
                    }

                    else
                    {
                        Layout.NotNumber();
                    }

                    break;


                case 3: //List all users

                    foreach (var item in WebbShopIvoNazlic.WebbShopAPI.ListUsers(loggedInUserId))
                    {
                        Console.WriteLine(item);
                    }

                    Console.WriteLine("");
                    Layout.ClearScreen();
                    break;


                case 4: //List all users by matching keyword

                    string keyword = MenuTools.KeywordInput();
                    foreach (var item in WebbShopIvoNazlic.WebbShopAPI.FindUser(loggedInUserId, keyword))
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("");
                    Layout.ClearScreen();
                    break;


                case 5: //Update book data

                    if (int.TryParse(MenuTools.BookIdInput(), out bookId))
                    {
                        Console.Clear();
                        bookTitle = MenuTools.BookTitleInput();
                        author = MenuTools.AuthorInput();
                        if (int.TryParse(MenuTools.PriceInput(), out price))
                        {
                            Console.Clear();
                            if (WebbShopIvoNazlic.WebbShopAPI.UpdateBook(loggedInUserId, bookId, bookTitle, author, price))
                            {
                                Console.WriteLine("Book info updated.\n");
                                Layout.ClearScreen();
                            }
                            else
                            {
                                Console.WriteLine("Updating book data failed.\n");
                                Layout.ClearScreen();
                            }
                        }
                        else
                        {
                            Layout.NotNumber();
                        }
                    }

                    else
                    {
                        Layout.NotNumber();
                    }

                    break;


                case 6: //Delete book

                    if (int.TryParse(MenuTools.BookIdInput(), out bookId))
                    {
                        Console.Clear();
                        if (WebbShopIvoNazlic.WebbShopAPI.DeleteBook(loggedInUserId, bookId))
                        {
                            Console.WriteLine("Book deleted.\n");
                            Layout.ClearScreen();
                        }

                        else
                        {
                            Console.WriteLine("Deleting the book failed.\n");
                            Layout.ClearScreen();
                        }
                    }

                    else
                    {
                        Layout.NotNumber();
                    }

                    break;


                case 7: //Add a category

                    string categoryName = MenuTools.CategoryNameInput();
                    if (WebbShopIvoNazlic.WebbShopAPI.AddCategory(loggedInUserId, categoryName))
                    {
                        Console.WriteLine($"Category {categoryName} added.\n");
                        Layout.ClearScreen();
                    }

                    else
                    {
                        Console.WriteLine("Adding the category failed.\n");
                        Layout.ClearScreen();
                    }

                    break;


                case 8: //Add book to a category

                    if (int.TryParse(MenuTools.BookIdInput(), out bookId))
                    {
                        Console.Clear();
                        Console.Write("Enter category id: ");
                        if (int.TryParse(MenuTools.CategoryIdInput(), out int categoryNr))
                        {
                            Console.Clear();
                            if (WebbShopIvoNazlic.WebbShopAPI.AddBookToCategory(loggedInUserId, bookId, categoryNr))
                            {
                                Console.WriteLine("Book added successfully.");
                                Layout.ClearScreen();
                            }

                            else
                            {
                                Console.WriteLine("Adding the book failed.\n");
                                Layout.ClearScreen();
                            }
                        }

                        else
                        {
                            Layout.NotNumber();
                        }
                    }

                    else
                    {
                        Layout.NotNumber();
                    }

                    break;


                case 9: //Update Category info

                    if (int.TryParse(MenuTools.CategoryIdInput(), out int categoryId))
                    {
                        Console.Clear();
                        string category = MenuTools.CategoryNameInput();
                        if (WebbShopIvoNazlic.WebbShopAPI.UpdateCategory(loggedInUserId, categoryId, category))
                        {
                            Console.Clear();
                            Console.WriteLine($"Category info updatet successfully.\n");
                            Layout.ClearScreen();
                        }

                        else
                        {
                            Console.WriteLine("Adding the category failed.\n");
                            Layout.ClearScreen();
                        }
                    }

                    else
                    {
                        Layout.NotNumber();
                    }

                    break;


                case 10: //Delete category

                    if (int.TryParse(MenuTools.CategoryIdInput(), out categoryId))
                    {
                        Console.Clear();
                        if (WebbShopIvoNazlic.WebbShopAPI.DeleteCategory(loggedInUserId, categoryId))
                        {
                            Console.WriteLine("Category deleted.\n");
                            Layout.ClearScreen();
                        }

                        else
                        {
                            Console.WriteLine("Deleting the book failed.\n");
                            Layout.ClearScreen();
                        }
                    }

                    else
                    {
                        Layout.NotNumber();
                    }

                    break;


                case 11: //Add user

                    if (WebbShopIvoNazlic.WebbShopAPI.AddUser(loggedInUserId, MenuTools.UsernameInput(), MenuTools.PasswordInput()))
                    {
                        Console.WriteLine("User created");
                        Layout.ClearScreen();
                    }

                    else
                    {
                        Console.WriteLine("Adding user failed\n");
                        Layout.ClearScreen();
                    }

                    break;


                case 12: //List of all sold items

                    foreach (var item in WebbShopIvoNazlic.WebbShopAPI.SoldItems(loggedInUserId))
                    {
                        Console.WriteLine(item);
                    }

                    Console.WriteLine("");
                    Layout.ClearScreen();
                    break;


                case 13: //Show how much the books have sold for

                    Console.WriteLine($"The store has sold books for: {WebbShopIvoNazlic.WebbShopAPI.MoneyEarned(loggedInUserId)}");
                    Console.WriteLine("");
                    Layout.ClearScreen();
                    break;


                case 14: //Show the id of the best customer - based on books bought

                    Console.WriteLine($"The best customer is (Id: ){WebbShopIvoNazlic.WebbShopAPI.BestCustomer(loggedInUserId)}");
                    Console.WriteLine("");
                    Layout.ClearScreen();
                    break;


                case 15: //Promote user to admin

                    if (int.TryParse(MenuTools.UserIdInput(), out int userId))
                    {
                        Console.Clear();
                        if (WebbShopIvoNazlic.WebbShopAPI.Promote(loggedInUserId, userId))
                        {
                            Console.WriteLine("User promoted to admin.\n");
                            Layout.ClearScreen();
                        }

                        else
                        {
                            Console.WriteLine("Promotion failed.\n");
                            Layout.ClearScreen();
                        }
                    }

                    else
                    {
                        Layout.NotNumber();
                    }

                    break;


                case 16: //Demote user


                    if (int.TryParse(MenuTools.UserIdInput(), out userId))
                    {
                        Console.Clear();
                        if (WebbShopIvoNazlic.WebbShopAPI.Demote(loggedInUserId, userId))
                        {
                            Console.WriteLine("User demoted.\n");
                            Layout.ClearScreen();
                        }

                        else
                        {
                            Console.WriteLine("Demoting user failed.\n");
                            Layout.ClearScreen();
                        }
                    }

                    else
                    {
                        Layout.NotNumber();
                    }

                    break;


                case 17: //Activate user

                    if (int.TryParse(MenuTools.UserIdInput(), out userId))
                    {
                        Console.Clear();
                        if (WebbShopIvoNazlic.WebbShopAPI.ActivateUser(loggedInUserId, userId))
                        {
                            Console.WriteLine("User activated.\n");
                            Layout.ClearScreen();
                        }

                        else
                        {
                            Console.WriteLine("Activation failed.\n");
                            Layout.ClearScreen();
                        }
                    }

                    else
                    {
                        Layout.NotNumber();
                    }

                    break;


                case 18: //Demote user

                    if (int.TryParse(MenuTools.UserIdInput(), out userId))
                    {
                        Console.Clear();
                        if (WebbShopIvoNazlic.WebbShopAPI.InactivateUser(loggedInUserId, userId))
                        {
                            Console.WriteLine("User deactivated.\n");
                            Layout.ClearScreen();
                        }

                        else
                        {
                            Console.WriteLine("Deactivation failed.\n");
                            Layout.ClearScreen();
                        }
                    }

                    else
                    {
                        Layout.NotNumber();
                    }

                    break;

                case 19: //Exit program

                    Start.keepPlaying = false;
                    break;

                default:

                    Layout.ClearScreen();
                    break;

            }
        }
    }
}
