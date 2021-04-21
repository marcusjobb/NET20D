using System;

namespace FrontEnd.Helper
{
    static public class Inputs
    {
        public static int InputMainMenuSwitch()
        {
            //https://stackoverflow.com/questions/24443827/reading-an-integer-from-user-input

            var input = Console.ReadLine();
            if (int.TryParse(input, out int number1))
            {
                return number1;
            }
            else
            {
                return 4;
            }
        }

        public static int InputAdminMenuSwitch()
        {
            //https://stackoverflow.com/questions/24443827/reading-an-integer-from-user-input

            var input = Console.ReadLine();
            if (int.TryParse(input, out int number1))
            {
                return number1;
            }
            else
            {
                return default;
            }
        }

        internal static (string userName, string password) InputLogin()
        {
            Console.WriteLine("Enter user name");
            Console.WriteLine("( admin  Name: Administrator Password: CodicRulez)");
            Console.WriteLine("( User  Name: TestCustomer  Password: Codic2021");
            var userName = Console.ReadLine();
            Console.WriteLine("Enter Password");
            var password = Console.ReadLine();
            var nameAndPassword = (userName, password);
            return nameAndPassword;
        }

        internal static (string userName, string password, string passwordVerify) InputRegister()
        {
            Console.WriteLine("Enter username");
            var userName = Console.ReadLine();
            Console.WriteLine("Enter password");
            var password = Console.ReadLine();
            Console.WriteLine("Verify password");
            var passwordVerify = Console.ReadLine();
            return (userName, password, passwordVerify);
        }
    }
}