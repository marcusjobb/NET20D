using Inlämning_API.Models;
using System;

namespace Inlämning_3Front.Views
{
    /// <summary>
    /// Prints general 
    /// </summary>
    public static class MessageView
    {
        public static void EnterkeyToContinue() => Console.WriteLine("[Enter a key to continue]");

        public static void SomethingWentWrong() => Console.WriteLine("Something went wrong");

        public static void WrongInput() => Console.WriteLine("Wrong input");

        public static void EmptyList() => Console.WriteLine("The item was not found :( ");

        public static void SuccessMessage() => Console.WriteLine("Success");

        public static void RegisterMessage() => Console.WriteLine("You need to register at the main page");

        public static void LoggedinAs(User user) => Console.WriteLine($"{user.Name} Successfully logged in");

        public static void NoUserMatch() => Console.WriteLine("No user match with that credentials");
    }
}