using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopUI.Views
{
    public class Login
    {
        public List<string> LoginView()
        {
            List<string> userInfo = new List<string>();
            Console.WriteLine("Please type in your user information.");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            userInfo.Add(username);

            Console.Write("Password: ");
            string password = Console.ReadLine();
            userInfo.Add(password);

            return userInfo;
        }

        



    }
}
