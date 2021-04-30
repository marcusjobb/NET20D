using System;
using WebbShopFE.Helper;

namespace WebbShopFE.Views
{
    /// <summary>
    /// Methods that prints diffrent messages depending
    /// what happens in the program ex error message, sucess message.
    /// </summary>
    public static class MessageView
    {
        public static void EnterkeyToContinue()
        {
            Console.WriteLine("Enter to contuine!");
        }

        public static void ErrorMessage()
        {
            HelpMethods.RedTextWL("\nSomething went wrong!");
        }

        public static void ItemNotFound()
        {
            HelpMethods.RedTextWL("The item was not found!");
        }

        public static void LoginToBuyBooks()
        {
            HelpMethods.RedTextWL("You need to login to buy books.....");
        }

        public static void NoSearchMatch()
        {
            HelpMethods.RedTextWL("No result found!");
        }

        public static void SuccesMessage()
        {
            HelpMethods.GreenTextWL("Success!");
        }

        public static void TryAgain()
        {
            HelpMethods.RedTextWL("\nWrong input, try again...");
        }

        public static void WrongInput()
        {
            HelpMethods.RedTextWL("\nWrong input!");
        }
    }
}