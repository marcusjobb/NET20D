using Inlämning3.Helpers;
using System;

namespace Inlämning3.Views.Home
{
    public class RegisterView
    {
        /// <summary>
        /// Lets the user register by enter username, password and passwordverify
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="passwordVerify"></param>
        public static void Display(out string username, out string password, out string passwordVerify)
        {
            Console.WriteLine(@".______       _______   _______  __       _______.___________. _______ .______      ");
            Console.WriteLine(@"|   _  \     |   ____| /  _____||  |     /       |           ||   ____||   _  \     ");
            Console.WriteLine(@"|  |_)  |    |  |__   |  |  __  |  |    |   (----`---|  |----`|  |__   |  |_)  |    ");
            Console.WriteLine(@"|      /     |   __|  |  | |_ | |  |     \   \       |  |     |   __|  |      /     ");
            Console.WriteLine(@"|  |\  \----.|  |____ |  |__| | |  | .----)   |      |  |     |  |____ |  |\  \----.");
            Console.WriteLine(@"| _| `._____||_______| \______| |__| |_______/       |__|     |_______|| _| `._____|");
            Console.WriteLine();
            Console.Write("Enter your username: ");
            username = Helper.GetUserChoiceText();
            Console.Write("Enter your password: ");
            password = Helper.GetUserChoiceText();
            Console.Write("Enter your password again to verify: ");
            passwordVerify = Helper.GetUserChoiceText();
        }
    }
}