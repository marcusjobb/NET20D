using System;

namespace Webbshop.Views
{
    internal class UserView
    {
        /// <summary>
        /// Print the first menu the standard user sees after login
        /// </summary>
        public static void PrintBuyMenuOptions()
        {
            Console.Clear();
            SharedView.PrintWithGreenText($"\tVälkommen till bokshoppen");
            Console.WriteLine("\t1. Köp böcker");
            Console.WriteLine("\tX. Logga ut");
        }

        /// <summary>
        /// Prints the register page and takes a input and returns this
        /// </summary>
        /// <returns>returns information for registering a user</returns>
        public static (string username, string password, string verifyPassword) Register()
        {
            Console.Clear();
            SharedView.PrintWithDarkGreyText("Registrera ett konto");
            Console.Write("\tAnge användarnamn> ");
            var username = Console.ReadLine();
            Console.Write("\tAnge lösenord> ");
            var password = Console.ReadLine();
            Console.Write("\tVerifiera lösenord> ");
            var verifiedPassword = Console.ReadLine();

            return (username, password, verifiedPassword);
        }
    }
}