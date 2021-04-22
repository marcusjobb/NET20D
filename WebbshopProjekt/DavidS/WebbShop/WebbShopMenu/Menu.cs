using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WebbShop;
using WebbShop.Models;
using static WebbShop.Helpers.HelperMethods;

namespace WebbShopMenu
{
    internal static class Menu
    {
        /// <summary>
        /// The color used to color the banners and input from the user.
        /// </summary>
        private const ConsoleColor Color = ConsoleColor.DarkMagenta;

        /// <summary>
        /// The time to pause the thread.
        /// </summary>
        private const int SleepTime = 2000;

        /// <summary>
        /// The title of the webb shop.
        /// </summary>
        private const string Title = "Webb Shop";

        /// <summary>
        /// The connection to the API.
        /// </summary>
        private static readonly WebbShopAPI API = new WebbShopAPI();

        /// <summary>
        /// Shows the main menu and lets the user choose what to do
        /// until he or she chooses to exit the program.
        /// </summary>
        public static void MainMenu()
        {
            Console.Title = Title;
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = Color;
                Console.WriteLine("\t _      __    __   __     ______");
                Console.WriteLine("\t| | /| / /__ / /  / /    / __/ /  ___  ___");
                Console.WriteLine("\t| |/ |/ / -_) _ \\/ _ \\  _\\ \\/ _ \\/ _ \\/ _ \\");
                Console.WriteLine("\t|__/|__/\\__/_.__/_.__/ /___/_//_/\\___/ .__/");
                Console.WriteLine("\t                                    /_/");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\tMake a choice:");
                Console.WriteLine("\t1. Register as a new user");
                Console.WriteLine("\t2. Login");
                Console.WriteLine("\t3. Search books");
                Console.WriteLine("\t4. Exit program");
                bool exit;
                do
                {
                    exit = true;
                    switch (GetChoice())
                    {
                        case 1:
                            Register();
                            break;

                        case 2:
                            Login();
                            break;

                        case 3:
                            SearchBooksMenu();
                            break;

                        case 4:
                            return;

                        default:
                            ErrorMessage();
                            exit = false;
                            break;
                    }
                } while (!exit);
            }
        }

        /// <summary>
        /// Lets the <paramref name="admin"/> input the information
        /// required to add a <see cref="Book"/>. If the book exists the amount
        /// is increased, otherwise a new book is created.
        /// </summary>
        /// <param name="admin"></param>
        private static void AddBook(User admin)
        {
            Console.Clear();
            Console.ForegroundColor = Color;
            Console.WriteLine("\n\t   ___     __   __  ___            __");
            Console.WriteLine("\t  / _ |___/ /__/ / / _ )___  ___  / /__");
            Console.WriteLine("\t / __ / _  / _  / / _  / _ \\/ _ \\/  '_/");
            Console.WriteLine("\t/_/ |_\\_,_/\\_,_/ /____/\\___/\\___/_/\\_\\\n");
            Console.ForegroundColor = ConsoleColor.White;
            string title = GetText("title");
            if (title.Length != 0)
            {
                var books = API.GetBooks(title);
                if (books.Count > 0)
                {
                    var ctr = ListBooks(books);
                    bool exit;
                    do
                    {
                        exit = true;
                        var choice = GetChoice();
                        if (choice > 0 && choice < ctr)
                        {
                            var book = books[choice - 1];
                            do
                            {
                                exit = true;
                                Console.WriteLine();
                                var amount = GetNumber("amount");
                                if (amount > 0)
                                {
                                    if (API.AddBook(admin.Id, book.Id, book.Title, book.Author, book.Price, amount))
                                    {
                                        SuccessMessage($"{amount} of the book {book.Title} was successfully added!");
                                    }
                                    else
                                    {
                                        ErrorMessage("Something went wrong.");
                                    }
                                    break;
                                }
                                else
                                {
                                    ErrorMessage();
                                    exit = false;
                                }
                            } while (!exit);
                        }
                        else if (choice == ctr)
                        {
                            if (DoYouWantTo($"add {title} as a new book? (y/n)"))
                            {
                                AddNewBook(admin, title);
                            }
                        }
                        else
                        {
                            ErrorMessage();
                            exit = false;
                        }
                    } while (!exit);
                }
                else
                {
                    AddNewBook(admin, title);
                }
            }
        }

        /// <summary>
        /// Lets the <paramref name="admin"/> add a <see cref="Book"/>
        /// to the specified <paramref name="category"/>.
        /// </summary>
        /// <param name="admin"></param>
        /// <param name="category"></param>
        private static void AddBookToCategory(User admin, BookCategory category)
        {
            Console.WriteLine();
            var title = GetText("title");
            var books = API.GetBooks(title);
            if (books.Count > 0)
            {
                var ctr = ListBooks(books);
                bool exit;
                do
                {
                    exit = true;
                    var choice = GetChoice();
                    if (choice > 0 && choice < ctr)
                    {
                        var book = books[choice - 1];
                        if (API.AddBookToCategory(admin.Id, book.Id, category.Id))
                        {
                            SuccessMessage($"{book.Title} was added to {category.Name}!");
                        }
                        else
                        {
                            ErrorMessage("Something went wrong.");
                        }
                    }
                    else if (choice != ctr)
                    {
                        ErrorMessage();
                        exit = false;
                    }

                } while (!exit);
            }
            else
            {
                ErrorMessage("There are no books available that match your search.");
            }
        }

        /// <summary>
        /// Lets the <paramref name="admin"/> add the specified
        /// <paramref name="book"/> to a <see cref="BookCategory"/>.
        /// </summary>
        /// <param name="admin"></param>
        /// <param name="book"></param>
        private static void AddBookToCategory(User admin, Book book)
        {
            bool exit;
            var categories = API.GetCategories();
            if (categories.Count > 0)
            {
                var ctr = ListCategories(categories);
                do
                {
                    exit = true;
                    var choice = GetChoice();
                    if (choice > 0 && choice < ctr)
                    {
                        var category = categories[choice - 1];
                        if (API.AddBookToCategory(admin.Id, book.Id, category.Id))
                        {
                            SuccessMessage($"{book.Title} was added to {category.Name}!");
                        }
                        else
                        {
                            ErrorMessage("Something went wrong.");
                        }
                    }
                    else if (choice != ctr)
                    {
                        ErrorMessage();
                        exit = false;
                    }
                } while (!exit);
            }
            else
            {
                ErrorMessage("There are no categories available!");
            }
        }

        /// <summary>
        /// Lets the <paramref name="admin"/> add a new
        /// <see cref="BookCategory"/> to the database.
        /// </summary>
        /// <param name="admin"></param>
        private static void AddCategory(User admin)
        {
            Console.WriteLine();
            var categoryName = GetText("name of category");
            if (categoryName.Length != 0)
            {
                if (CategoryExists(categoryName))
                {
                    ErrorMessage($"{categoryName} already exists!");
                }
                else if (API.AddCategory(admin.Id, categoryName))
                {
                    SuccessMessage($"{categoryName} was successfully added!");
                }
                else
                {
                    ErrorMessage("Something went wrong.");
                }
            }
        }

        /// <summary>
        /// Lets the <paramref name="admin"/> add a new
        /// <see cref="Book"/> to the database.
        /// </summary>
        /// <param name="admin"></param>
        /// <param name="title"></param>
        private static void AddNewBook(User admin, string title)
        {
            var author = GetText("author");
            if (author.Length != 0)
            {
                var price = GetNumber("price");
                var amount = GetNumber("amount");
                if (API.AddBook(admin.Id, 0, title, author, price, amount))
                {
                    SuccessMessage($"{title} was successfully added!");
                }
                else
                {
                    ErrorMessage("Something went wrong.");
                }
            }
        }

        /// <summary>
        /// Lets the <paramref name="admin"/> add a new
        /// <see cref="User"/> to the database.
        /// </summary>
        /// <param name="admin"></param>
        private static void AddUser(User admin)
        {
            Console.Clear();
            Console.ForegroundColor = Color;
            Console.WriteLine("\t   ___     __   __  __  __");
            Console.WriteLine("\t  / _ |___/ /__/ / / / / /__ ___ ____");
            Console.WriteLine("\t / __ / _  / _  / / /_/ (_-</ -_) __/");
            Console.WriteLine("\t/_/ |_\\_,_/\\_,_/  \\____/___/\\__/_/\n");
            Console.ForegroundColor = ConsoleColor.White;
            var username = GetText("username");
            if (username.Length != 0)
            {
                if (UserExists(username))
                {
                    ErrorMessage("There already exists a user with that name and password!");
                }
                else
                {
                    var password = GetText("password");
                    if (API.AddUser(admin.Id, username, password))
                    {
                        SuccessMessage($"{username} was successfully added!");
                    }
                    else
                    {
                        ErrorMessage("Something went wrong.");
                    }
                }
            }
            else
            {
                ErrorMessage("You have to enter a name.");
            }
        }

        /// <summary>
        /// Shows a special admin menu to the <paramref name="admin"/>.
        /// </summary>
        /// <param name="admin"></param>
        private static void AdminMenu(User admin)
        {
            while (true)
            {
                Console.Clear();
                Ping(admin.Id);
                Console.ForegroundColor = Color;
                Console.WriteLine("\t   ___     __      _        __  ___");
                Console.WriteLine("\t  / _ |___/ /_ _  (_)__    /  |/  /__ ___  __ __");
                Console.WriteLine("\t / __ / _  /  ' \\/ / _ \\  / /|_/ / -_) _ \\/ // /");
                Console.WriteLine("\t/_/ |_\\_,_/_/_/_/_/_//_/ /_/  /_/\\__/_//_/\\_,_/\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\tMake a choice:");
                Console.WriteLine("\t1. Book menu");
                Console.WriteLine("\t2. Category menu");
                Console.WriteLine("\t3. User menu");
                Console.WriteLine("\t4. Sold books menu");
                Console.WriteLine("\t5. Logout");
                bool exit;
                do
                {
                    exit = true;
                    switch (GetChoice())
                    {
                        case 1:
                            BookMenu(admin);
                            break;

                        case 2:
                            CategoryMenu(admin);
                            break;

                        case 3:
                            UserMenu(admin);
                            break;

                        case 4:
                            SoldBooksMenu(admin);
                            break;

                        case 5:
                            Logout(admin.Id);
                            return;

                        default:
                            ErrorMessage();
                            exit = false;
                            break;
                    }
                } while (!exit);
            }
        }

        /// <summary>
        /// Lets the <paramref name="admin"/> see the customer
        /// that has bought the most books.
        /// </summary>
        /// <param name="admin"></param>
        private static void BestCustomer(User admin)
        {
            var (customer, books) = API.BestCustomer(admin.Id);
            if (customer != null)
            {
                Console.WriteLine($"\n\tBest customer: {customer.Name}" +
                    $" with {books} books bought!");
                Console.ReadKey(true);
            }
            else
            {
                ErrorMessage("There are no customers.");
            }
        }

        /// <summary>
        /// Shows a special <see cref="Book"/>
        /// menu for the <paramref name="admin"/>.
        /// </summary>
        /// <param name="admin"></param>
        private static void BookMenu(User admin)
        {
            while (true)
            {
                Console.Clear();
                Ping(admin.Id);
                Console.ForegroundColor = Color;
                Console.WriteLine("\t   ___            __     __  ___");
                Console.WriteLine("\t  / _ )___  ___  / /__  /  |/  /__ ___  __ __");
                Console.WriteLine("\t / _  / _ \\/ _ \\/  '_/ / /|_/ / -_) _ \\/ // /");
                Console.WriteLine("\t/____/\\___/\\___/_/\\_\\ /_/  /_/\\__/_//_/\\_,_/\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\tMake a choice:");
                Console.WriteLine("\t1. Add a book");
                Console.WriteLine("\t2. Search for a book");
                Console.WriteLine("\t3. Go back");
                bool exit;
                do
                {
                    exit = true;
                    switch (GetChoice())
                    {
                        case 1:
                            AddBook(admin);
                            break;

                        case 2:
                            SearchBooksMenu(admin.Id);
                            break;

                        case 3:
                            return;

                        default:
                            ErrorMessage();
                            exit = false;
                            break;
                    }
                } while (!exit);
            }
        }

        /// <summary>
        /// Lets a user buy a specified <see cref="Book"/>
        /// based on the <paramref name="bookId"/>.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        private static void BuyBook(int userId, int bookId)
        {
            if (API.BuyBook(userId, bookId))
            {
                var book = API.GetBook(bookId);
                SuccessMessage($"{book.Title} was successfully purchased.");
            }
            else if (!UserExists(userId))
            {
                ErrorMessage("You have to be logged in to buy a book.");
            }
            else
            {
                ErrorMessage("Something went wrong.");
            }
        }

        /// <summary>
        /// Shows a special <see cref="BookCategory"/>
        /// menu for the <paramref name="admin"/>.
        /// </summary>
        /// <param name="admin"></param>
        private static void CategoryMenu(User admin)
        {
            while (true)
            {
                Console.Clear();
                Ping(admin.Id);
                Console.ForegroundColor = Color;
                Console.WriteLine("\t  _____     __                           __  ___");
                Console.WriteLine("\t / ___/__ _/ /____ ___ ____  ______ __  /  |/  /__ ___  __ __");
                Console.WriteLine("\t/ /__/ _ `/ __/ -_) _ `/ _ \\/ __/ // / / /|_/ / -_) _ \\/ // /");
                Console.WriteLine("\t\\___/\\_,_/\\__/\\__/\\_, /\\___/_/  \\_, / /_/  /_/\\__/_//_/\\_,_/");
                Console.WriteLine("\t                 /___/         /___/\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\tMake a choice:");
                Console.WriteLine("\t1. Add a book category");
                Console.WriteLine("\t2. Search a category");
                Console.WriteLine("\t3. List all categories");
                Console.WriteLine("\t4. Go back");
                bool exit;
                do
                {
                    exit = true;
                    switch (GetChoice())
                    {
                        case 1:
                            AddCategory(admin);
                            break;

                        case 2:
                            SearchCategory(admin);
                            break;

                        case 3:
                            ListAllCategories(admin);
                            break;

                        case 4:
                            return;

                        default:
                            ErrorMessage();
                            exit = false;
                            break;
                    }
                } while (!exit);
            }
        }

        /// <summary>
        /// Shows a menu to a customer.
        /// </summary>
        /// <param name="user"></param>
        private static void CustomerMenu(User user)
        {
            while (true)
            {
                Console.Clear();
                Ping(user.Id);
                Console.ForegroundColor = Color;
                Console.WriteLine("\n\t  _____         __                       __  ___");
                Console.WriteLine("\t / ___/_ _____ / /____  __ _  ___ ____  /  |/  /__ ___  __ __");
                Console.WriteLine("\t/ /__/ // (_-</ __/ _ \\/  ' \\/ -_) __/ / /|_/ / -_) _ \\/ // /");
                Console.WriteLine("\t\\___/\\_,_/___/\\__/\\___/_/_/_/\\__/_/   /_/  /_/\\__/_//_/\\_,_/");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\tMake a choice:");
                Console.WriteLine("\t1. Search a book");
                Console.WriteLine("\t2. Logout");
                bool exit;
                do
                {
                    exit = true;
                    switch (GetChoice())
                    {
                        case 1:
                            SearchBooksMenu(user.Id);
                            break;

                        case 2:
                            Logout(user.Id);
                            return;

                        default:
                            ErrorMessage();
                            exit = false;
                            break;
                    }
                } while (!exit);
            }
        }

        /// <summary>
        /// Lets the <paramref name="admin"/> delete
        /// the specified <paramref name="book"/>.
        /// </summary>
        /// <param name="admin"></param>
        /// <param name="book"></param>
        private static bool DeleteBook(User admin, Book book)
        {
            if (API.DeleteBook(admin.Id, book.Id))
            {
                SuccessMessage($"{book.Title} was successfully deleted!");
                return true;
            }
            else
            {
                ErrorMessage($"{book.Title} was only reduced by 1.");
                return false;
            }
        }

        /// <summary>
        /// Lets the <paramref name="admin"/> remove a
        /// <paramref name="category"/> from the database.
        /// The <paramref name="category"/> will only be
        /// removed if there are no books connected to it.
        /// </summary>
        /// <param name="admin"></param>
        /// <param name="category"></param>
        private static bool DeleteCategory(User admin, BookCategory category)
        {
            var books = API.GetCategory(category.Id);
            if (API.DeleteCategory(admin.Id, category.Id))
            {
                SuccessMessage($"{category.Name} was successfully deleted!");
                return true;
            }
            else if (books.Count > 0)
            {
                ErrorMessage($"{category.Name} cannot be deleted since there" +
                    $" are {books.Count} connected to the category.");
            }
            else
            {
                ErrorMessage("Something went wrong.");
            }

            return false;
        }

        /// <summary>
        /// Asks the user a <paramref name="question"/>
        /// and gets the users answer.
        /// </summary>
        /// <param name="question"></param>
        /// <returns><see langword="true"/> if the user answers y,
        /// otherwise <see langword="false"/>.</returns>
        private static bool DoYouWantTo(string question)
        {
            Console.Write($"\n\tDo you want to {question}: ");
            return string.Equals(ReadInColor(), "y",
                StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Shows a colored error <paramref name="message"/> on
        /// the screen, then removes the message and also the
        /// user input that was incorrect.
        /// </summary>
        /// <param name="message"></param>
        private static void ErrorMessage(string message = "Invalid choice! Try again.")
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\t" + message);
            Thread.Sleep(SleepTime);
            for (int i = 0; i < 2; i++)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                for (int j = 0; j < 80; j++)
                {
                    Console.Write(" ");
                }
            }

            Console.SetCursorPosition(0, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Lets the user search for books that match a keyword.
        /// The search will look for matches in titles, authors,
        /// and categories and then show the books that match.
        /// </summary>
        /// <param name="userId"></param>
        private static void FreeSearch(int userId)
        {
            Console.WriteLine();
            var keyword = GetText("keyword");
            var books = new List<Book>();
            foreach (var category in API.GetCategories(keyword))
            {
                foreach (var book in API.GetCategory(category.Id))
                {
                    books.Add(book);
                }
            }

            foreach (var book in API.GetBooks(keyword))
            {
                books.Add(book);
            }

            foreach (var book in API.GetAuthors(keyword))
            {
                books.Add(book);
            }

            books = books.Distinct().ToList();
            ShowBooks(userId, books);
        }

        /// <summary>
        /// Gets an input from the user and tries to
        /// parse it into an <see langword="int"/>.
        /// </summary>
        /// <returns>The parsed <see langword="int"/> or
        /// 0 if the parse failed.</returns>
        private static int GetChoice()
        {
            Console.Write("\t> ");
            int.TryParse(ReadInColor(), out var choice);
            return choice;
        }

        /// <summary>
        /// Gets a number from the user.
        /// </summary>
        /// <param name="type"></param>
        /// <returns>The number.</returns>
        private static int GetNumber(string type)
        {
            bool exit;
            int number;
            do
            {
                exit = true;
                Console.Write($"\tEnter {type}: ");
                if (!int.TryParse(ReadInColor(), out number))
                {
                    ErrorMessage();
                    exit = false;
                }
                else if (number < 1)
                {
                    ErrorMessage("You have to enter a number greater than 0.");
                    exit = false;
                }
            } while (!exit);

            return number;
        }

        /// <summary>
        /// Gets a text input from the user.
        /// </summary>
        /// <param name="type"></param>
        /// <returns>The text input.</returns>
        private static string GetText(string type)
        {
            Console.Write($"\tEnter {type}: ");
            return ReadInColor();
        }

        /// <summary>
        /// Lets the <paramref name="admin"/> list all book
        /// categories in the database and select a specific one.
        /// </summary>
        /// <param name="admin"></param>
        private static void ListAllCategories(User admin)
        {
            var categories = API.GetCategories();
            if (categories.Count > 0)
            {
                var ctr = ListCategories(categories);
                bool exit;
                do
                {
                    exit = true;
                    var choice = GetChoice();
                    if (choice > 0 && choice < ctr)
                    {
                        var category = categories[choice - 1];
                        SelectCategory(admin, category);
                    }
                    else if (choice != ctr)
                    {
                        ErrorMessage();
                        exit = false;
                    }
                } while (!exit);
            }
            else
            {
                ErrorMessage("There are no categories available!");
            }
        }

        /// <summary>
        /// Lets an <paramref name="admin"/> list all users
        /// in the database and select a specific one.
        /// </summary>
        /// <param name="admin"></param>
        private static void ListAllUsers(User admin)
        {
            var users = API.ListUsers(admin.Id);
            var ctr = ListUsers(users);
            bool exit;
            do
            {
                exit = true;
                var choice = GetChoice();
                if (choice > 0 && choice < ctr)
                {
                    var user = users[choice - 1];
                    SelectedUser(admin, user);
                }
                else if (choice != ctr)
                {
                    ErrorMessage();
                    exit = false;
                }
            } while (!exit);
        }

        /// <summary>
        /// Shows all the books in <paramref name="books"/>
        /// in a menu like manner.
        /// </summary>
        /// <param name="books"></param>
        /// <returns>The highest choice available
        /// to make from the menu.</returns>
        private static int ListBooks(List<Book> books)
        {
            Console.WriteLine("\n\tChoose a book:");
            var ctr = 1;
            foreach (var book in books)
            {
                Console.Write($"\t{ctr++}. ");
                ShowBookDetails(book);
            }

            Console.WriteLine($"\t{ctr}. None of the above");
            return ctr;
        }

        /// <summary>
        /// Shows all the categories in <paramref name="categories"/>
        /// in a menu like manner.
        /// </summary>
        /// <param name="categories"></param>
        /// <returns>The highest choice available
        /// to make from the menu.</returns>
        private static int ListCategories(List<BookCategory> categories)
        {
            Console.WriteLine("\n\tChoose a category:");
            var ctr = 1;
            foreach (var category in categories)
            {
                Console.WriteLine($"\t{ctr++}. {category.Name}");
            }

            Console.WriteLine($"\t{ctr}. None of the above");
            return ctr;
        }

        /// <summary>
        /// Shows all the users in <paramref name="users"/>
        /// in a menu like manner.
        /// </summary>
        /// <param name="users"></param>
        /// <returns>The highest choice available
        /// to make from the menu.</returns>
        private static int ListUsers(List<User> users)
        {
            Console.WriteLine("\n\tChoose a user:");
            var ctr = 1;
            foreach (var user in users)
            {
                Console.Write($"\t{ctr++}. ");
                ShowUserDetails(user);
            }

            Console.WriteLine($"\t{ctr}. None of the above");
            return ctr;
        }

        /// <summary>
        /// Lets a user login.
        /// </summary>
        /// <returns>The users id if the username
        /// and password match a user in the database,
        /// otherwise 0.</returns>
        private static int Login()
        {
            int userId;
            bool exit;
            do
            {
                exit = true;
                Console.Clear();
                Console.ForegroundColor = Color;
                Console.WriteLine("\t   __             _");
                Console.WriteLine("\t  / /  ___  ___ _(_)__");
                Console.WriteLine("\t / /__/ _ \\/ _ `/ / _ \\");
                Console.WriteLine("\t/____/\\___/\\_, /_/_//_/");
                Console.WriteLine("\t          /___/\n");
                Console.ForegroundColor = ConsoleColor.White;
                var username = GetText("username");
                var password = GetText("password");
                userId = API.Login(username, password);
                if (UserExists(userId, out var user))
                {
                    if (user.IsActive)
                    {
                        SuccessMessage("You are now logged in!");
                        if (user.IsAdmin)
                        {
                            AdminMenu(user);
                        }
                        else
                        {
                            CustomerMenu(user);
                        }
                    }
                    else
                    {
                        ErrorMessage("Sorry, you are not active.");
                    }
                }
                else if (TryAgain("Username or password was incorrect."))
                {
                    exit = false;
                }
            } while (!exit);

            return userId;
        }

        /// <summary>
        /// Logs out a logged in user.
        /// </summary>
        /// <param name="userId"></param>
        private static void Logout(int userId)
        {
            if (UserExists(userId, out var user) && user.IsLoggedIn())
            {
                API.Logout(userId);
                SuccessMessage("You are now logged out.");
            }
            else
            {
                ErrorMessage("You have to be logged in to be able to log out.");
            }
        }

        /// <summary>
        /// Shows the <paramref name="admin"/> the total sum
        /// of all the earnings from sold books.
        /// </summary>
        /// <param name="admin"></param>
        private static void MoneyEarned(User admin)
        {
            Console.WriteLine($"\n\tMoney earned: {API.MoneyEarned(admin.Id)} kr.");
            Console.ReadKey(true);
        }

        /// <summary>
        /// Pings the user and writes Pong in dark grey to the screen
        /// if the user still was logged in when pinged.
        /// </summary>
        /// <param name="userId"></param>
        private static void Ping(int userId)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(API.Ping(userId));
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Reads input from the user in color.
        /// </summary>
        /// <returns>The user input.</returns>
        private static string ReadInColor()
        {
            Console.ForegroundColor = Color;
            var input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            return input;
        }

        /// <summary>
        /// Lets a user register to the database.
        /// </summary>
        private static void Register()
        {
            bool exit;
            do
            {
                exit = true;
                Console.Clear();
                Console.ForegroundColor = Color;
                Console.WriteLine("\n\t   ___           _     __");
                Console.WriteLine("\t  / _ \\___ ___ _(_)__ / /____ ____");
                Console.WriteLine("\t / , _/ -_) _ `/ (_-</ __/ -_) __/");
                Console.WriteLine("\t/_/|_|\\__/\\_, /_/___/\\__/\\__/_/");
                Console.WriteLine("\t         /___/\n");
                Console.ForegroundColor = ConsoleColor.White;
                var username = GetText("username");
                if (username.Length != 0)
                {
                    var password = GetText("password");
                    var passwordVerify = GetText("password again");
                    if (password.Equals(passwordVerify))
                    {
                        if (API.Register(username, password, passwordVerify))
                        {
                            SuccessMessage($"{username} was successfully registered!");
                        }
                        else
                        {
                            ErrorMessage($"{username} already exists.");
                        }
                    }
                    else if (TryAgain("The passwords doesn't match."))
                    {
                        exit = false;
                    }
                }
                else
                {
                    ErrorMessage("You have to enter a name.");
                }
            } while (!exit);
        }

        /// <summary>
        /// Lets the user search for books in different ways.
        /// </summary>
        /// <param name="userId"></param>
        private static void SearchBooksMenu(int userId = 0)
        {
            while (true)
            {
                Console.Clear();
                Ping(userId);
                Console.ForegroundColor = Color;
                Console.WriteLine("\t   ____                 __     ___            __");
                Console.WriteLine("\t  / __/__ ___ _________/ /    / _ )___  ___  / /__ ___");
                Console.WriteLine("\t _\\ \\/ -_) _ `/ __/ __/ _ \\  / _  / _ \\/ _ \\/  '_/(_-<");
                Console.WriteLine("\t/___/\\__/\\_,_/_/  \\__/_//_/ /____/\\___/\\___/_/\\_\\/___/\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\tMake a choice:");
                Console.WriteLine("\t1. Search by title");
                Console.WriteLine("\t2. Search by author");
                Console.WriteLine("\t3. Search by category");
                Console.WriteLine("\t4. Free search");
                Console.WriteLine("\t5. Go back");
                bool exit;
                do
                {
                    exit = true;
                    switch (GetChoice())
                    {
                        case 1:
                            SearchByTitle(userId);
                            break;

                        case 2:
                            SearchByAuthor(userId);
                            break;

                        case 3:
                            SearchByCategory(userId);
                            break;

                        case 4:
                            FreeSearch(userId);
                            break;

                        case 5:
                            return;

                        default:
                            ErrorMessage();
                            exit = false;
                            break;
                    }
                } while (!exit);
            }
        }

        /// <summary>
        /// Lets the user search for books through authors.
        /// </summary>
        /// <param name="userId"></param>
        private static void SearchByAuthor(int userId)
        {
            Console.WriteLine();
            var author = GetText("author");
            var books = API.GetAuthors(author);
            ShowBooks(userId, books);
        }

        /// <summary>
        /// Lets the user search for books through categories.
        /// </summary>
        /// <param name="userId"></param>
        private static void SearchByCategory(int userId)
        {
            var categories = API.GetCategories();
            if (categories.Count > 0)
            {
                var ctr = ListCategories(categories);
                bool exit;
                do
                {
                    exit = true;
                    var choice = GetChoice();
                    if (choice > 0 && choice < ctr)
                    {
                        var category = categories[choice - 1];
                        var books = API.GetAvailableBooks(category.Id);
                        if (UserIsAdminAndLoggedIn(userId))
                        {
                            books = API.GetCategory(category.Id);
                        }
                        ShowBooks(userId, books);
                    }
                    else if (choice != ctr)
                    {
                        ErrorMessage();
                        exit = false;
                    }
                } while (!exit);
            }
            else
            {
                ErrorMessage("There are no categories available!");
            }
        }

        /// <summary>
        /// Lets the user search for books through titles.
        /// </summary>
        /// <param name="userId"></param>
        private static void SearchByTitle(int userId)
        {
            Console.WriteLine();
            var title = GetText("title");
            var books = API.GetBooks(title);
            ShowBooks(userId, books);
        }

        /// <summary>
        /// Lets the admin search for categories based on a name
        /// and then select a specific category.
        /// </summary>
        /// <param name="admin"></param>
        private static void SearchCategory(User admin)
        {
            Console.WriteLine();
            var categoryName = GetText("category name");
            var categories = API.GetCategories(categoryName);
            if (categories.Count > 0)
            {
                var ctr = ListCategories(categories);
                bool exit;
                do
                {
                    exit = true;
                    var choice = GetChoice();
                    if (choice > 0 && choice < ctr)
                    {
                        var category = categories[choice - 1];
                        SelectCategory(admin, category);
                    }
                    else if (choice != ctr)
                    {
                        ErrorMessage();
                        exit = false;
                    }

                } while (!exit);
            }
            else
            {
                ErrorMessage("There are no categories available that match your search.");
            }
        }

        /// <summary>
        /// Lets the <paramref name="admin"/> search for a
        /// <see cref="User"/> base on the username then lists
        /// all the users that match. The admin are then able to
        /// select a specific user to modify.
        /// </summary>
        /// <param name="admin"></param>
        private static void SearchUser(User admin)
        {
            Console.WriteLine();
            var username = GetText("username");
            var users = API.FindUser(admin.Id, username);
            if (users.Count > 0)
            {
                var ctr = ListUsers(users);
                bool exit;
                do
                {
                    exit = true;
                    var choice = GetChoice();
                    if (choice > 0 && choice < ctr)
                    {
                        var user = users[choice - 1];
                        SelectedUser(admin, user);
                    }
                    else if (choice != ctr)
                    {
                        ErrorMessage();
                        exit = false;
                    }
                } while (!exit);
            }
            else
            {
                ErrorMessage("There are no users available that match your search.");
            }
        }

        /// <summary>
        /// Shows a menu for the <paramref name="admin"/> and lets him or her
        /// choose different things to do with the specified
        /// <paramref name="book"/>.
        /// </summary>
        /// <param name="admin"></param>
        /// <param name="book"></param>
        private static void SelectBook(User admin, Book book)
        {
            bool outerExit = false;
            while (!outerExit)
            {
                Console.Clear();
                Ping(admin.Id);
                Console.ForegroundColor = Color;
                Console.WriteLine("\t   ___            __");
                Console.WriteLine("\t  / _ )___  ___  / /__");
                Console.WriteLine("\t / _  / _ \\/ _ \\/  '_/");
                Console.WriteLine("\t/____/\\___/\\___/_/\\_\\");
                Console.ForegroundColor = ConsoleColor.White;
                ShowAllBookDetails(book);
                Console.WriteLine("\n\tWhat do you want to do?");
                Console.WriteLine("\t1. Set the amount");
                Console.WriteLine("\t2. Add book to a category");
                Console.WriteLine("\t3. Update book");
                Console.WriteLine("\t4. Delete book");
                Console.WriteLine("\t5. Go back");
                bool innerExit;
                do
                {
                    innerExit = true;
                    switch (GetChoice())
                    {
                        case 1:
                            SetAmount(admin, book);
                            break;

                        case 2:
                            AddBookToCategory(admin, book);
                            break;

                        case 3:
                            UpdateBook(admin, book);
                            break;

                        case 4:
                            outerExit = DeleteBook(admin, book);
                            break;

                        case 5:
                            outerExit = true;
                            break;

                        default:
                            ErrorMessage();
                            innerExit = false;
                            break;
                    }
                } while (!innerExit);
            }
        }
        /// <summary>
        /// Shows a menu for the <paramref name="admin"/> and
        /// lets him or her choose different things to do with
        /// the specified <paramref name="category"/>.
        /// </summary>
        /// <param name="admin"></param>
        /// <param name="category"></param>
        private static void SelectCategory(User admin, BookCategory category)
        {
            var outerExit = false;
            while (!outerExit)
            {
                Console.Clear();
                Ping(admin.Id);
                Console.ForegroundColor = Color;
                Console.WriteLine("\t  _____     __");
                Console.WriteLine("\t / ___/__ _/ /____ ___ ____  ______ __");
                Console.WriteLine("\t/ /__/ _ `/ __/ -_) _ `/ _ \\/ __/ // /");
                Console.WriteLine("\t\\___/\\_,_/\\__/\\__/\\_, /\\___/_/  \\_, /");
                Console.WriteLine("\t                 /___/         /___/\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\t{category.Name}");
                Console.WriteLine("\n\tWhat do you want to do?");
                Console.WriteLine("\t1. Add a book to the category");
                Console.WriteLine("\t2. Update category");
                Console.WriteLine("\t3. Delete category");
                Console.WriteLine("\t4. Go back");
                bool innerExit;
                do
                {
                    innerExit = true;
                    switch (GetChoice())
                    {
                        case 1:
                            AddBookToCategory(admin, category);
                            break;

                        case 2:
                            UpdateCategory(admin, category);
                            break;

                        case 3:
                            outerExit = DeleteCategory(admin, category);
                            break;

                        case 4:
                            outerExit = true;
                            break;

                        default:
                            ErrorMessage();
                            innerExit = false;
                            break;
                    }
                } while (!innerExit);
            }
        }

        /// <summary>
        /// Shows a special menu for the <paramref name="admin"/> with
        /// choices regarding the specified <paramref name="user"/>
        /// </summary>
        /// <param name="admin"></param>
        /// <param name="user"></param>
        private static void SelectedUser(User admin, User user)
        {
            while (true)
            {
                Console.Clear();
                Ping(admin.Id);
                Console.ForegroundColor = Color;
                Console.WriteLine("\t  __  __");
                Console.WriteLine("\t / / / /__ ___ ____");
                Console.WriteLine("\t/ /_/ (_-</ -_) __/");
                Console.Write("\t\\____/___/\\__/_/\n\n\t");
                Console.ForegroundColor = ConsoleColor.White;
                ShowUserDetails(user);
                Console.WriteLine("\n\tWhat do you want to do?");
                Console.WriteLine("\t1. Promote user");
                Console.WriteLine("\t2. Demote user");
                Console.WriteLine("\t3. Activate user");
                Console.WriteLine("\t4. Inactivate user");
                Console.WriteLine("\t5. Go back");
                bool exit;
                do
                {
                    exit = true;
                    switch (GetChoice())
                    {
                        case 1:
                            if (API.Promote(admin.Id, user.Id))
                            {
                                SuccessMessage($"{user.Name} was successfully promoted!");
                            }
                            else
                            {
                                ErrorMessage("Something went wrong.");
                            }
                            break;

                        case 2:
                            if (API.Demote(admin.Id, user.Id))
                            {
                                SuccessMessage($"{user.Name} was successfully demoted!");
                            }
                            else
                            {
                                ErrorMessage("Something went wrong.");
                            }
                            break;

                        case 3:
                            if (API.ActivateUser(admin.Id, user.Id))
                            {
                                SuccessMessage($"{user.Name} was successfully activated!");
                            }
                            else
                            {
                                ErrorMessage("Something went wrong.");
                            }
                            break;

                        case 4:
                            if (API.InactivateUser(admin.Id, user.Id))
                            {
                                SuccessMessage($"{user.Name} was successfully inactivated!");
                            }
                            else
                            {
                                ErrorMessage("Something went wrong.");
                            }
                            break;

                        case 5:
                            return;

                        default:
                            ErrorMessage();
                            exit = false;
                            break;
                    }
                } while (!exit);
            }
        }

        /// <summary>
        /// Lets the <paramref name="admin"/> set the amount
        /// for the specified <paramref name="book"/>.
        /// </summary>
        /// <param name="admin"></param>
        /// <param name="book"></param>
        private static void SetAmount(User admin, Book book)
        {
            bool exit;
            do
            {
                exit = true;
                int amount = GetNumber("amount");
                if (amount > 0)
                {
                    API.SetAmount(admin.Id, book.Id, amount);
                    SuccessMessage($"The amount for {book.Title} was set to {amount}!");
                }
                else
                {
                    ErrorMessage();
                    exit = false;
                }
            } while (!exit);
        }

        /// <summary>
        /// Shows all the details about a specified <paramref name="book"/>
        /// including the available amount.
        /// </summary>
        /// <param name="book"></param>
        private static void ShowAllBookDetails(Book book)
        {
            Console.Write($"\n\t{book.Title}, {book.Author}, ");
            if (book.Category != null)
            {
                Console.Write($"{book.Category.Name}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("unknown");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine($", {book.Amount} st, {book.Price} kr");
        }

        /// <summary>
        /// Shows details about specified <paramref name="book"/>
        /// except for the available amount.
        /// </summary>
        /// <param name="book"></param>
        private static void ShowBookDetails(Book book)
        {
            Console.Write($"{book.Title}, {book.Author}, ");
            if (book.Category != null)
            {
                Console.Write($"{book.Category.Name}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("unknown");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine($", {book.Price} kr");
        }

        /// <summary>
        /// Lists all the books in <paramref name="books"/> in a
        /// menu like manner and lets the user choose a book to buy.
        /// If the user is an admin a special menu will open for
        /// the book instead of the book being purchased.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="books"></param>
        private static void ShowBooks(int userId, List<Book> books)
        {
            if (UserExists(userId, out var user) && !user.IsAdmin)
            {
                books = books.Where(b => b.Amount > 0).ToList();
            }

            if (books.Count > 0)
            {
                var ctr = ListBooks(books);
                bool exit;
                do
                {
                    exit = true;
                    var choice = GetChoice();
                    if (choice > 0 && choice < ctr)
                    {
                        var book = books[choice - 1];
                        if (user?.IsAdmin == true)
                        {
                            SelectBook(user, book);
                        }
                        else
                        {
                            BuyBook(userId, book.Id);
                        }
                    }
                    else if (choice != ctr)
                    {
                        ErrorMessage();
                        exit = false;
                    }
                } while (!exit);
            }
            else
            {
                ErrorMessage("There are no books available that match your search.");
            }
        }

        /// <summary>
        /// Shows all the sold books to the <paramref name="admin"/>.
        /// </summary>
        /// <param name="admin"></param>
        private static void ShowSoldBooks(User admin)
        {
            var books = API.SoldItems(admin.Id);
            if (books != null)
            {
                Console.WriteLine();
                var ctr = 1;
                foreach (var book in books)
                {
                    Console.Write($"\t{ctr++}. {book.Title}, {book.Author}, ");
                    if (book.Category != null)
                    {
                        Console.Write(book.Category.Name);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("unknown");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine($", {book.Price} kr. " +
                        $"Purchased by: {book.User.Name}");
                }
            }
            else
            {
                ErrorMessage("There are no sold books.");
            }

            Console.ReadKey(true);
        }

        /// <summary>
        /// Shows the details of the specified <paramref name="user"/>.
        /// </summary>
        /// <param name="user"></param>
        private static void ShowUserDetails(User user)
        {
            Console.WriteLine($"{user.Name}, " +
                    $"{user.Password}, " +
                    $"Active: {user.IsActive}, " +
                    $"Admin: {user.IsAdmin}");
        }

        /// <summary>
        /// Shows a colored error <paramref name="message"/>
        /// on the screen and then removes it.
        /// </summary>
        /// <param name="message"></param>
        private static void SmallErrorMessage(string message = "Invalid choice! Try again.")
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\t" + message);
            Thread.Sleep(SleepTime);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            for (int j = 0; j < 80; j++)
            {
                Console.Write(" ");
            }

            Console.SetCursorPosition(0, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Shows a sold books menu to the <paramref name="admin"/>.
        /// </summary>
        /// <param name="admin"></param>
        private static void SoldBooksMenu(User admin)
        {
            while (true)
            {
                Console.Clear();
                Ping(admin.Id);
                Console.ForegroundColor = Color;
                Console.WriteLine("\t   ____     __   __  ___            __          __  ___");
                Console.WriteLine("\t  / __/__  / /__/ / / _ )___  ___  / /__ ___   /  |/  /__ ___  __ __");
                Console.WriteLine("\t _\\ \\/ _ \\/ / _  / / _  / _ \\/ _ \\/  '_/(_-<  / /|_/ / -_) _ \\/ // /");
                Console.WriteLine("\t/___/\\___/_/\\_,_/ /____/\\___/\\___/_/\\_\\/___/ /_/  /_/\\__/_//_/\\_,_/\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\tMake a choice:");
                Console.WriteLine("\t1. See all the sold books");
                Console.WriteLine("\t2. See money earned");
                Console.WriteLine("\t3. See who is the best customer");
                Console.WriteLine("\t4. Go back");
                bool exit;
                do
                {
                    exit = true;
                    switch (GetChoice())
                    {
                        case 1:
                            ShowSoldBooks(admin);
                            break;

                        case 2:
                            MoneyEarned(admin);
                            break;

                        case 3:
                            BestCustomer(admin);
                            break;

                        case 4:
                            return;

                        default:
                            ErrorMessage();
                            exit = false;
                            break;
                    }
                } while (!exit);
            }
        }

        /// <summary>
        /// Shows a colored success <paramref name="message"/> on the screen.
        /// </summary>
        /// <param name="message"></param>
        private static void SuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\t" + message);
            Thread.Sleep(SleepTime);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }

        /// <summary>
        /// Shows a colored error <paramref name="message"/> on the
        /// screen and asks the user if he or she wants to try again.
        /// </summary>
        /// <param name="message"></param>
        /// <returns><see langword="true"/> if the user wants to try again,
        /// otherwise <see langword="false"/>.</returns>
        private static bool TryAgain(string message)
        {
            SmallErrorMessage(message);
            return DoYouWantTo("try again? (y/n)");
        }

        /// <summary>
        /// Shows an update menu for the <paramref name="admin"/> and lets
        /// him or her make changes to the specified <paramref name="book"/>.
        /// </summary>
        /// <param name="admin"></param>
        /// <param name="book"></param>
        private static void UpdateBook(User admin, Book book)
        {
            while (true)
            {
                Console.Clear();
                Ping(admin.Id);
                Console.ForegroundColor = Color;
                Console.WriteLine("\t  __  __        __     __        ___            __");
                Console.WriteLine("\t / / / /__  ___/ /__ _/ /____   / _ )___  ___  / /__");
                Console.WriteLine("\t/ /_/ / _ \\/ _  / _ `/ __/ -_) / _  / _ \\/ _ \\/  '_/");
                Console.WriteLine("\t\\____/ .__/\\_,_/\\_,_/\\__/\\__/ /____/\\___/\\___/_/\\_\\");
                Console.WriteLine("\t    /_/");
                Console.ForegroundColor = ConsoleColor.White;
                ShowAllBookDetails(book);
                Console.WriteLine("\n\tWhat do you want to change?");
                Console.WriteLine("\t1. The title");
                Console.WriteLine("\t2. The author");
                Console.WriteLine("\t3. The price");
                Console.WriteLine("\t4. Go back");
                bool exit;
                do
                {
                    exit = true;
                    switch (GetChoice())
                    {
                        case 1:
                            Console.WriteLine();
                            book.Title = GetText("title");
                            break;

                        case 2:
                            Console.WriteLine();
                            book.Author = GetText("author");
                            break;

                        case 3:
                            Console.WriteLine();
                            book.Price = GetNumber("price");
                            break;

                        case 4:
                            return;

                        default:
                            ErrorMessage();
                            exit = false;
                            break;
                    }
                } while (!exit);

                if (API.UpdateBook(admin.Id, book.Id, book.Title, book.Author, book.Price))
                {
                    SuccessMessage($"{book.Title} was successfully updated!");
                }
                else
                {
                    ErrorMessage("Something went wrong.");
                }
            }
        }

        /// <summary>
        /// Lets the <paramref name="admin"/> update the name
        /// of the specified <paramref name="category"/>.
        /// </summary>
        /// <param name="admin"></param>
        /// <param name="category"></param>
        private static void UpdateCategory(User admin, BookCategory category)
        {
            var oldName = category.Name;
            var newName = GetText($"new name for {category.Name}");
            if (CategoryExists(newName))
            {
                ErrorMessage($"{newName} does already exixt!");
            }
            else if (API.UpdateCategory(admin.Id, category.Id, newName))
            {
                SuccessMessage($"{oldName} was successfully updated into {newName}!");
            }
            else
            {
                ErrorMessage("Something went wrong.");
            }
        }

        /// <summary>
        /// Shows a special user menu to the <paramref name="admin"/>.
        /// </summary>
        /// <param name="admin"></param>
        private static void UserMenu(User admin)
        {
            while (true)
            {
                Console.Clear();
                Ping(admin.Id);
                Console.ForegroundColor = Color;
                Console.WriteLine("\t  __  __              __  ___");
                Console.WriteLine("\t / / / /__ ___ ____  /  |/  /__ ___  __ __");
                Console.WriteLine("\t/ /_/ (_-</ -_) __/ / /|_/ / -_) _ \\/ // /");
                Console.WriteLine("\t\\____/___/\\__/_/   /_/  /_/\\__/_//_/\\_,_/\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\tMake a choice:");
                Console.WriteLine("\t1. Add a user");
                Console.WriteLine("\t2. Find a user");
                Console.WriteLine("\t3. List all users");
                Console.WriteLine("\t4. Go back");
                bool exit;
                do
                {
                    exit = true;
                    switch (GetChoice())
                    {
                        case 1:
                            AddUser(admin);
                            break;

                        case 2:
                            SearchUser(admin);
                            break;

                        case 3:
                            ListAllUsers(admin);
                            break;

                        case 4:
                            return;

                        default:
                            ErrorMessage();
                            exit = false;
                            break;
                    }
                } while (!exit);
            }
        }
    }
}