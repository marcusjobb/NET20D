using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopUI.Views
{
    class Register
    {
        public List<string> NewUser()
        {
            List<string> userInfo = new List<string>();

            Console.WriteLine("Please fill in the required information below.");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            userInfo.Add(username);

            Console.Write("Password: ");
            string password = Console.ReadLine();
            userInfo.Add(password);

            Console.Write("Please verify password again: ");
            string verifyPassword = Console.ReadLine();
            userInfo.Add(verifyPassword);

            return userInfo;

        }

    }
}
