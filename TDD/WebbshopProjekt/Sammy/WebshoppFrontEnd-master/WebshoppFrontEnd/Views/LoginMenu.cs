
namespace WebbshopFrontEnd.Views
{
    using System;

    public static class LoginMenu
    {
        /// <summary>
        /// Vyn för inloggning
        /// </summary>
        /// <returns></returns>
        public static (string, string) ShowLogInMenu()
        {
            Console.Clear();
            Console.WriteLine("********************");
            Console.WriteLine("*     Inloggning   *");
            Console.WriteLine("********************\n");
            Console.Write("Ditt användarnamn: ");
            string username = Console.ReadLine();
            Console.Write("Ditt lösenord: ");
            string password = Console.ReadLine();
            var user = (username, password);
            return user;
        }
    }
}
