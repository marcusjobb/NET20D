namespace WebbShop_MikaelLarsson.Views
{
    using System;
    using WebbShop_MikaelLarsson.Controllers;

    /// <summary>
    /// Klass för att skriva ut menyerna.
    /// </summary>
    internal static class MenuView
    {
        /// <summary>
        /// bool för att loopa bookmeny.
        /// </summary>
        public static bool bookMenu = true;

        /// <summary>
        /// bool för att loopa Category-menyn.
        /// </summary>
        public static bool categoryMenu = true;

        /// <summary>
        /// bool för att loopa huvudmeny.
        /// </summary>
        public static bool mainMenu;
        /// <summary>
        /// Text för Book-menyn
        /// </summary>
        public static void BookMenu()
        {
            while (bookMenu)
            {
                Console.Title = "Book Menu";
                Console.WriteLine("\nBOOKS");
                Console.WriteLine("1 - Back to main menu\n2 - Search for a special book\n3 - Search for an author");
                UserBookController.BookMenu();
            }
        }

        /// <summary>
        /// Text för Category-menyn
        /// </summary>
        public static void CategoryMenu()
        {
            while (categoryMenu)
            {
                Console.Title = "Category Menu";
                Console.WriteLine("\nCATEGORIES");
                Console.WriteLine("1 - Back to main menu\n2 - See all categories\n3 - Search for a special category\n4 - See all books in a category\n5 - See all available books in a category");
                UserCategoryController.CategoryMenu();
            }
        }

        /// <summary>
        /// Text för huvudmenyn
        /// </summary>
        public static void MainMenu()
        {
            mainMenu = true;
            while (mainMenu)
            {
                Console.Title = "Main Menu";
                Console.Clear();
                categoryMenu = true;
                bookMenu = true;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(@"   
            * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
            *                 _                             __       _  *
            * | | _  _  _|   |_) _  _  |  _    | | _ |_ |_ (_ |_  _ |_) *
            * |_|_> (/_(_|   |_)(_)(_) |<_>    |^|(/_|_)|_)__)| |(_)|   *
            *                                                           *
            * * * * * * * * * * * * * * WELCOME * * * * * * * * * * * * * 
");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Please enter your number of choice");
                Console.WriteLine("1 - Exit program\n2 - Login\n3 - Logout\n4 - Register new user\n\n5 - See categories\n6 - See books\n7 - For admins");
                MenuController.MainMenu();
            }
        }
    }
}
