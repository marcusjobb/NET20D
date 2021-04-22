using System;

namespace BookShopIvoNazlic.Views
{
    /// <remarks>
    /// Handles the layout and menus and messages
    /// </remarks>
    static class Layout
    {

        /// <summary>
        /// Changes the layout of the program.
        /// </summary>
        public static void ProgramLayout()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            Console.Title = "Bookstore from hell";
        }

        /// <summary>
        /// Changes layout of the program if logged in 
        /// user is administrator
        /// </summary>
        public static void AdminLayout()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.Title = "Bookstore from hell - Admin";
        }

        public static void Welcome()
        {
            Console.WriteLine("\n      *********************************************************************");
            Console.WriteLine("      *   W E L C O M E  T O  T H E  B O O K S T O R E  F R O M  H E L L  *");
            Console.WriteLine("      *********************************************************************\n");
        }

        public static void LoginSuccesfull()
        {
            Console.WriteLine("\n      ***********************");
            Console.WriteLine("      *  L O G G E D   I N  *");
            Console.WriteLine("      ***********************\n");
        }

        public static void AdminLoggedIn()
        {
            Console.WriteLine("\n      ****************************************");
            Console.WriteLine("      *  L O G G E D   I N   A S   A D M I N *");
            Console.WriteLine("      ****************************************\n");
        }

        public static void PurchaseSuccesfull(object Book)
        {
            Console.WriteLine($"You have bought a book:\n\n{Book}\n");
        }

        public static void PurchaseFail()
        {
            Console.Clear();
            Console.WriteLine($"You have either entered a wrong book id or the book is out of stock.\n");
            ClearScreen();
        }

        /// <summary>
        /// Displays error message if user made non numerical 
        /// choice in the menu
        /// </summary>
        public static void NotNumber()
        {
            Console.WriteLine("You have not entered a number. Please try again.\n");
            ClearScreen();
        }

        /// <summary>
        /// Clears screen and asks user action to move further in the program
        /// </summary>
        public static void ClearScreen()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }


    }
}
