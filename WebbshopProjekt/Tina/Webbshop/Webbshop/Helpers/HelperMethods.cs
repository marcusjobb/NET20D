using System;
using System.Linq;
using Webbshop.Views;
using WebbshopProject.Database;
using WebbshopProject;
namespace Webbshop.Helpers
{
    class HelperMethods
    {
        public static WebbshopDatabase db = new WebbshopDatabase();
        public static WebbshopAPI api = new WebbshopAPI();

        /// <summary>
        /// Checks if user is admin and logged-in.
        /// </summary>
        /// <param name="userId">Id of the user using program</param>
        /// <returns>true or false</returns>
        public static bool IsUserAdminAndLoggedIn(int userId)
        {
            var admin = db.Users.FirstOrDefault(u => u.Id == userId &&
            u.SessionTimer > DateTime.Now.AddMinutes(-15) &&
            u.IsActive && u.IsAdmin);
            return admin != null;
        }

        /// <summary>
        /// Checks if user is active and logged in
        /// </summary>
        /// <param name="userId">Id of the user using program</param>
        /// <returns>true or false</returns>
        public static bool IsUserActiveAndLoggedIn(int userId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == userId &&
            u.SessionTimer > DateTime.Now.AddMinutes(-15) && u.IsActive);
            return user != null;
        }

        /// <summary>
        /// The user can choose a book, from a
        /// numbered list.
        /// </summary>
        /// <returns>Choice as int</returns>
        public static int ChooseBook()
        {
            Console.Clear();
            int choice = 0;
            int count = 1;
            var books = api.GetBooks("");
            if (books.Count != 0)
            {
                foreach (var book in books)
                {
                    Console.WriteLine($"{count}. {book.Title}");
                    count++;
                }

                Messages.ColorText("If non of above, press 0",
                    ConsoleColor.Cyan);
                Console.Write("Enter choice: ");
                var input = Console.ReadLine();
                if (input != "null")
                {
                    bool answer = int.TryParse(input, out choice);
                    return choice;
                }

                else
                {
                    return 0;
                }
            }

            else
            {
                Messages.ErrorMessage("There is no books.");
                return 0;
            }
        }

        /// <summary>
        /// The user can choose a category, from a 
        /// numbered list.
        /// </summary>
        /// <returns>Choice as int</returns>
        public static int ChooseCategory()
        {
            int choice;
            int count = 1;
            var categories = api.GetCategories();
            foreach (var cat in categories)
            {
                Console.WriteLine($"{count}. {cat.Name}");
                count++;
            }

            Console.Write("Enter choice: ");
            var input = Console.ReadLine();
            bool answer = int.TryParse(input, out choice);
            return choice;
        }

        /// <summary>
        /// The user can choose a user, from a 
        /// numbered list.
        /// </summary>
        /// <param name="userId">Id of the user using program</param>
        /// <returns>Choice as int</returns>
        public static int ChooseUser(int userId)
        {
            int userChoice;
            int count = 1;
            var listOfUsers = api.ListUsers(userId);
            if (listOfUsers != null)
            {
                foreach (var user in listOfUsers)
                {
                    Console.WriteLine($"{count}. {user.Name}");
                    count++;
                }
            }

            Messages.ColorText("If non of above, enter 0",
                ConsoleColor.Cyan);
            Console.Write("Enter choice: ");
            var input = Console.ReadLine();
            if (input == null)
            {
                userChoice = 0;
            }

            bool answer = int.TryParse(input, out userChoice);
            return userChoice;
        }
    }
}
