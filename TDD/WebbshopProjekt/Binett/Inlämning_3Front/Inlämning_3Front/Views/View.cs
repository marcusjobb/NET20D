using System;

namespace Inlämning_3Front.Views
{
    public class View
    {
        /// <summary>
        /// Views for the menu
        /// </summary>
        public void StartMenu()
        {
            Console.Clear();
            Console.WriteLine("Make a choice");
            Console.WriteLine("1. Take a look at our assortment");
            Console.WriteLine("2. Register a new account");
            Console.WriteLine("3. Login on a existing account");
            Console.WriteLine("[E. To exit]");
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("1. Books");
            Console.WriteLine("2. Logout");
            Console.Write("Enter choice: ");
        }

        public void AdminMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Books");
            Console.WriteLine("2. Admin menu");
            Console.WriteLine("3. Logout");
            Console.Write("Enter choice: ");
        }

        public void AskForName() => Console.Write("Enter name: ");

        public void AskforPassWord() => Console.Write("Enter password: ");

        public void VerifyPassWord() => Console.Write("Verify password: ");
    }
}