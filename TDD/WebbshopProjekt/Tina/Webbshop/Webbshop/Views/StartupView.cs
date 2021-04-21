using System;
using Webbshop.Helpers;

namespace Webbshop.Views
{
    class StartupView
    {
        /// <summary>
        /// Prints the startup Menu.
        /// </summary>
        public static void WelcomeView()
        {
            Console.Clear();
            Messages.ColorText(@"  _              __             
 |_)  _   _  |  (_  |_   _  ._  
 |_) (_) (_) |< __) | | (_) |_) 
                            | ", ConsoleColor.Cyan);
            Messages.ColorText("What do you want to do?",
                ConsoleColor.Cyan);
            Messages.ColorText("[1] Login\n[2] Register\n" +
                "[3] Browse menu",
                ConsoleColor.Yellow);
            Console.Write("Enter choice: ");
        }
        /// <summary>
        /// Prints the login to the user.
        /// </summary>
        /// <returns></returns>
        public static (string username, string password) LoginView()
        {
            Console.Clear();
            Messages.ColorText(@"                  
 |   _   _  o ._  
 |_ (_) (_| | | | 
         _|    ", ConsoleColor.Cyan);
            Messages.ColorText("Please enter username and password.",
                ConsoleColor.Cyan);
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            return (username, password);
        }
        /// <summary>
        /// Prints the Register to the user.
        /// </summary>
        /// <returns></returns>

        public static (string username, string password,
            string passwordVerify) RegisterView()
        {
            Console.Clear();
            Messages.ColorText(@"  _                          
 |_)  _   _  o  _ _|_  _  ._ 
 | \ (/_ (_| | _>  |_ (/_ |  
          _|  ", ConsoleColor.Cyan);
            Messages.ColorText("Please enter information," +
                " for registration.", ConsoleColor.Cyan);
            Console.Write($"Username: ");
            string username = Console.ReadLine();
            Console.Write($"Password: ");
            string password = Console.ReadLine();
            Console.Write("Verify password: ");
            string passwordVerify = Console.ReadLine();
            return (username, password, passwordVerify);
        }
        /// <summary>
        /// Prints the mainMenu, depending on if the user is admin or not, 
        /// the menu will show different alternatives.
        /// </summary>
        /// <param name="userId"></param>
        public static void PrintMenu(int userId)
        {
            Messages.ColorText(@"                  
 |\/|  _  ._      
 |  | (/_ | | |_| 
                  ", ConsoleColor.Cyan);

            if (!HelperMethods.IsUserAdminAndLoggedIn(userId))
            {
                Console.Clear();
                Messages.ColorText("[1] Book\n[2] Categories\n" +
                    "[3] Back", ConsoleColor.Yellow);
            }
            else
            {
                Console.Clear();
                Messages.ColorText("[1] Book\n[2] Categories\n" +
                    "[3] User choices\n[E] Logout", ConsoleColor.Yellow);
            }
        }
    }
}
