using System;
using WebbShopAPI.Models;

namespace WebbShopFront
{
    public class Menu
    {
        /// <summary>
        /// Dessa två strängar har jag skapat för att göra det smidigare med att designa menyerna.
        /// </summary>
        public string spacing = "                                            ";
        public string spacing2 = "           ";
        
        /// <summary>
        /// Denna metod körs när programmet startas, metoden returnerar true eller false beroende på vad IsAdmin är satt till.
        /// </summary>
        /// <returns></returns>
        public bool Intro()
        {
            bool adminUser = false;

            var API = new WebbShopAPI.WebbShopAPI();
            Console.WindowHeight = 30;
            Console.WindowWidth = 120;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine(@"
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                   _      __    __   __   ______
                                  | | /| / /__ / /  / /  / __/ /  ___  ___
                                  | |/ |/ / -_) _ \/ _ \_\ \/ _ \/ _ \/ _ \
                                  |__/|__/\__/_.__/_.__/___/_//_/\___/ .__/
                                                                    /_/
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

                                            (1) Log in
                                            (2) Register
                                            (3) Exit

                                  ");
                Console.Write(spacing + "    ");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.Write(spacing + "Username: ");
                    string username = Console.ReadLine();
                    Console.Write(spacing + "Password: ");
                    string password = Console.ReadLine();
                    var loginID = API.Login(username, password);
                    var userIsAdmin = API.IsAdmin(username);

                    if (loginID > 0)
                    {
                        if (userIsAdmin == true)
                        {
                            adminUser = true;
                        }
                        loop = false;
                    }
                    else
                    {
                        Console.WriteLine(spacing + "Incorrect username or password.");
                        Console.ReadKey();
                    }
                }
                else if (input == "2")
                {
                    Console.Write(spacing + "Username: ");
                    string username = Console.ReadLine();
                    Console.Write(spacing + "Password: ");
                    string password = Console.ReadLine();
                    Console.Write(spacing + "Verify password: ");
                    string passwordverify = Console.ReadLine();

                    var register = API.Register(username, password, passwordverify);
                    if (register == true)
                    {
                        Console.WriteLine(spacing + "Created new account.");
                    }
                    else if (register == false)
                    {
                        Console.WriteLine(spacing + "Failed to create an account.");
                    }
                    Console.ReadLine();
                }
                else if (input == "3")
                {
                    System.Environment.Exit(1);
                }
            }
                return adminUser;
        }

        /// <summary>
        /// Meny för användare som har IsAdmin = true.
        /// </summary>
        public void AdminMenu()
        {
            bool adminMenu = true;
            var API = new WebbShopAPI.WebbShopAPI();
            var admin = new Controllers.AdminMethods();
            var user = new Controllers.UserMethods();

            while (adminMenu)
            {
                Console.Clear();
                Console.WriteLine(@"
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                     ___     __      _
                                    / _ |___/ /_ _  (_)__  __ _  ___ ___  __ __
                                   / __ / _  /  ' \/ / _ \/  ' \/ -_) _ \/ // /
                                  /_/ |_\_,_/_/_/_/_/_//_/_/_/_/\__/_//_/\_,_/

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

                              ");
                Console.WriteLine(spacing2 + "(1) Add a book\t\t(8) Add a book to category\t(15) Demote a user");
                Console.WriteLine(spacing2 + "(2) Add amount of books\t(9) Delete a category\t\t(16) Activate a user");
                Console.WriteLine(spacing2 + "(3) List all users\t\t(10) Add a user\t\t\t(17) Inactivate a user");
                Console.WriteLine(spacing2 + "(4) Search for a user\t(11) View all sold items\t(18) Logout");
                Console.WriteLine(spacing2 + "(5) Update a book\t\t(12) Show all money earned");
                Console.WriteLine(spacing2 + "(6) Delete a book\t\t(13) Display the best customer");
                Console.WriteLine(spacing2 + "(7) Add a category\t\t(14) Promote a user\n");
                Console.Write(spacing + "      ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        admin.AddBook();
                        break;
                    case "2":
                        admin.SetAmount();
                        break;
                    case "3":
                        admin.ListAllUsers();
                        break;
                    case "4":
                        admin.SearchUser();
                        break;
                    case "5":
                        admin.UpdateBook();
                        break;
                    case "6":
                        admin.DeleteBook();
                        break;
                    case "7":
                        admin.AddCategory();
                        break;
                    case "8":
                        admin.AddBookToCategory();
                        break;
                    case "9":
                        admin.DeleteCategory();
                        break;
                    case "10":
                        admin.AddUser();
                        break;
                    case "11":
                        admin.SoldItems();
                        break;
                    case "12":
                        admin.MoneyEarned();
                        break;
                    case "13":
                        admin.BestCustomer();
                        break;
                    case "14":
                        admin.Promote();
                        break;
                    case "15":
                        admin.Demote();
                        break;
                    case "16":
                        admin.ActivateUser();
                        break;
                    case "17":
                        admin.InactivateUser();
                        break;
                    case "18":
                        user.Logout();
                        break;
                }
            }
        }

        /// <summary>
        /// Meny för alla användare som har IsAdmin = false (defaultvärdet)
        /// </summary>
        public void UserMenu()
        {
            bool adminMenu = true;
            var API = new WebbShopAPI.WebbShopAPI();
            var user = new Controllers.UserMethods();
            while (adminMenu)
            {
                Console.Clear();
                Console.WriteLine(@"
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                    __  __                                         
                                   / / / /_______  _________ ___  ___  ____  __  __
                                  / / / / ___/ _ \/ ___/ __ `__ \/ _ \/ __ \/ / / /
                                 / /_/ (__  )  __/ /  / / / / / /  __/ / / / /_/ / 
                                 \____/____/\___/_/  /_/ /_/ /_/\___/_/ /_/\__,_/  

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                    ");
                Console.WriteLine(spacing2 + "(1) List all categories\t\t\t(6) Search for book by name");
                Console.WriteLine(spacing2 + "(2) Search for category by name\t\t(7) Search for author by name");
                Console.WriteLine(spacing2 + "(3) Search books that match category ID\t(8) Buy a book");
                Console.WriteLine(spacing2 + "(4) Get available books\t\t\t(9) Logout");
                Console.WriteLine(spacing2 + "(5) Search for a book with ID");
                Console.Write(spacing + "      ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        user.ListCategories();
                        break;
                    case "2":
                        user.ListCategoryKeyword();
                        break;
                    case "3":
                        user.ListCategoryID();
                        break;
                    case "4":
                        user.GetAvaibleBooks();
                        break;
                    case "5":
                        user.GetBook();
                        break;
                    case "6":
                        user.GetBooks();
                        break;
                    case "7":
                        user.GetAuthors();
                        break;
                    case "8":
                        user.BuyBook();
                        break;
                    case "9":
                        user.Logout();
                        break;

                }
            }
        }
    }
}