using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopAPI.Models;

namespace WebbShopUI.Views.AdminViews
{
    class AdminUsers
    {
        public int AdminUsersMenu()
        {
            Console.Clear();
            Console.WriteLine("Users options!");
            Console.WriteLine("");
            Console.WriteLine("1. List users");
            Console.WriteLine("2. Find a user");
            Console.WriteLine("3. Add a new user");
            int.TryParse(Console.ReadLine(), out int choice);

            return choice;
        }

        public void ListUsers(IEnumerable<User> listOfUsers)
        {
            var users = listOfUsers;
            if (users != null)
            {
                Console.Clear();
                foreach (var u in users)
                {
                    Console.WriteLine($"{u.Id} - {u.Name}");
                }
                Console.ReadKey();
            }
            if(users == null)
            {
                Console.WriteLine("No users found!");
                Console.ReadKey();
            }
        }

        public string FindUserKeyword()
        {
            Console.Write("Type in the keyword or name of the user you are searching for: ");
            string keyword = Console.ReadLine();

            return keyword;
        }


        public List<string> NewUser()
        {
            List<string> userInfo = new List<string>();
            Console.Write("Name of the user: ");
            string username = Console.ReadLine();
            userInfo.Add(username);

            Console.WriteLine("");
            Console.Write("Password of the user: ");
            string password = Console.ReadLine();
            userInfo.Add(password);

            return userInfo;
        }


    }
}
