using Bookshop.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Views.AdminUsers
{
    public static class UserInfo
    {
        /// <summary>
        /// The menu options.
        /// </summary>
        public static List<string> menuOptions = new List<string>() { "Activate user",
            "Inactivate user", "Promote user", "Demote user", "Back"};

        /// <summary>
        /// Prints the information about a user.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <param name="users">A list with users.</param>
        public static void PrintUserInfo(int userId, List<Webbutik.Models.User> users)
        {
            Webbutik.Models.User user = new Webbutik.Models.User();
            
            foreach (var item in users)
            {
                if (item.Id == userId)
                {
                    user = item;
                }
            }

            Console.SetCursorPosition(25, 9);
            Console.Write("Id:");
            Console.CursorLeft = 40;
            Console.WriteLine(user.Id);

            Console.CursorLeft = 25;
            Console.Write("Name:");
            Console.CursorLeft = 40;
            Console.WriteLine(user.Name);

            Console.CursorLeft = 25;
            Console.Write("Last login: ");
            Console.CursorLeft = 40;
            Console.WriteLine(user.LastLogin);

            Console.CursorLeft = 25;
            Console.Write("Is admin:");
            Console.CursorLeft = 40;
            Console.WriteLine(user.IsAdmin);

            Console.CursorLeft = 25;
            Console.Write("Is active:");
            Console.CursorLeft = 40;
            Console.WriteLine(user.IsActive);
        }
    }
}
