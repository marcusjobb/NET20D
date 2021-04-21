using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopAPI.Utils
{
    public static class Txt
    {
        /// <summary>
        /// Weocome Text
        /// </summary>
        public static string Welcome { get; } = "Wellcome to Lees Webbshop\n";
        /// <summary>
        /// Test run message
        /// </summary>
        public static string TestRun { get; } = "1. Test run of all the funktions\n";
        /// <summary>
        /// Wrong input message
        /// </summary>
        public static string WrongInput { get; } = "Wrong input. B/b exits this menu\n";
        /// <summary>
        /// Test Done message
        /// </summary>

        public static string TestDone { get; } = "Database test is done\n";
        /// <summary>
        /// Exit message
        /// </summary>
        public static string Exit { get; } = "\nExit...\n";
        /// <summary>
        /// Log in message
        /// </summary>
        public static string LogIn { get; } = "Log in\n";
        /// <summary>
        /// Name masage
        /// </summary>
        public static string Name { get; } = "Name: ";
        /// <summary>
        /// Password message
        /// </summary>
        public static string Password { get; } = "Password: ";
        /// <summary>
        /// Menu options message
        /// </summary>
        //Menu two
        public static string MenuTwoUser { get; } = @"
1. List categories
2. Find category
3. List books in a category
4. List available books
5. Get info about a book
6. Find books
7. Find books by author
8. Buy a book
9. Ping a user
10. Register a user (Verified option for the course). Not recomended if you are not an admin
11. LOG OUT";
        /// <summary>
        /// Category message
        /// </summary>
        public static string ListCategories { get; } = "Listing all categories";
        /// <summary>
        /// Category search message
        /// </summary>
        public static string SearchingCategory { get; } = "Searching category";
        /// <summary>
        /// Listing available books message 
        /// </summary>
        public static string ShowAvailableBooks { get; } = "Showing available books";
        /// <summary>
        /// Geting information about a book message
        /// </summary>
        public static string GetInformationAboutBook { get; } = "Getting information about this book";
        /// <summary>
        /// Finding author message
        /// </summary>
        public static string ListingAuthor { get; } = "Find author matching keyword";
        /// <summary>
        /// Buying book maessage book
        /// </summary>
        public static string BuyBook { get; } = "Buying book";
        /// <summary>
        /// Ping message
        /// </summary>
        public static string Ping { get; } = "Pinging user...";
        /// <summary>
        /// Register usermessage
        /// </summary>
        public static string RegisteringUser { get; } = "Registering new user";
        /// <summary>
        /// Press any key message
        /// </summary>

        public static string PressAnyKey { get; } = "Press any key...";
        /// <summary>
        /// Keyword message
        /// </summary>

        public static string Keyword { get; } = "Type a keyword: ";
        /// <summary>
        /// Choose category message
        /// </summary>
        public static string ChooseCategory { get; } = "Wich category:";



    }
}
