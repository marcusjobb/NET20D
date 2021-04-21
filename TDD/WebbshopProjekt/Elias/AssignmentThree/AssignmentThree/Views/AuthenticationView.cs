using System;

namespace AssignmentThree.Views
{
    public static class AuthenticationView
    {
        public static void PrintAuthMenu()
        {
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Logout");
            Console.WriteLine("0. Return to main menu");
        }

        public static void PrintInvalidInput()
        {
            Console.WriteLine("Invalid input, please try again");
        }

        public static (string username, string userPassword) PrintLogin()
        {
            Console.WriteLine("Enter your username");
            var username = Console.ReadLine();

            Console.WriteLine("Enter your password");
            var userPassword = Console.ReadLine();

            return (username, userPassword);
        }

        public static void PrintLogInBefore()
        {
            Console.WriteLine("You need to log in before being able to log out");
        }

        public static (string username, string password, string passwordVerify) PrintRegister()
        {
            Console.WriteLine("Enter your username");
            var username = Console.ReadLine();

            Console.WriteLine("Enter your password");
            var password = Console.ReadLine();

            Console.WriteLine("Verify your password");
            var passwordVerify = Console.ReadLine();

            return (username, password, passwordVerify);
        }

        public static void PrintSuccessful()
        {
            Console.WriteLine("Action was successful");
        }

        public static void PrintWentWrong()
        {
            Console.WriteLine("Something went wrong, try again");
        }
    }
}