using Inlm3.Controllers;
using System;

namespace Inlm3.Views
{
    /// <summary>
    /// Main Meny för front-end.
    /// </summary>
    internal class MainMeny
    {
        private Controller controll = new Controller();
        private SubMenyBuyBook subMeny1 = new SubMenyBuyBook();
        private SubMenyBooksCRUD subMeny2 = new SubMenyBooksCRUD();
        private SubMenyUsersCRUD subMeny3 = new SubMenyUsersCRUD();

        /// <summary>
        /// Index för frontEnd. Index visas enbort om användaren loggar in med giltigt lösenord och användarnamn.
        /// Alla funktioner är synliga för användare oavsett om de är admin eller inte, däremot kan vanliga users inte använda
        /// Admin metoderna.
        /// </summary>
        public void Index()
        {
            int userID = 0;
            bool keepGoing = true;

            Console.WriteLine("Welcome to Davids Bokhandel");
            do
            {
                userID = LoginUser();
            } while (userID == 0);

            while (keepGoing)
            {
                Console.WriteLine("1. Buy books");
                Console.WriteLine("2. Books CRUD");
                Console.WriteLine("3. Users CRUD");
                Console.WriteLine("4. Ping");
                Console.WriteLine("5. Exit bookstore");
                Console.Write("> ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        subMeny1.Index(userID);
                        break;

                    case "2":
                        subMeny2.Index(userID);
                        break;

                    case "3":
                        subMeny3.Index(userID);
                        break;

                    case "4":
                        Ping(userID);
                        break;

                    case "5":
                        LogoutUser(userID);
                        keepGoing = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Validerar att användaren är inloggad.
        /// </summary>
        public void LoginValidate(int userID, string username)
        {
            if (userID != 0)
            {
                Console.WriteLine($"User: {username} is logged in");
            }
            else
            {
                Console.WriteLine("Could not login user, please try again");
            }
        }

        /// <summary>
        /// Loggar in användaren genom controller
        /// </summary>
        public int LoginUser()
        {
            (string, string) account;

            Console.WriteLine("Please login");
            Console.Write("Username: ");
            account.Item1 = Console.ReadLine();

            Console.Write("Password: ");
            account.Item2 = Console.ReadLine();

            int userID = controll.Login(account);
            LoginValidate(userID, account.Item1);

            return userID;
        }

        /// <summary>
        /// Loggar ut användaren genom controller
        /// </summary>
        public void LogoutUser(int userID)
        {
            if (controll.Logout(userID))
            {
                Console.WriteLine("You are logged out");
            }
            else
            {
                Console.WriteLine("You are not logged in, and can therefor not log out");
            }
        }

        /// <summary>
        /// Pingar om användarens session timer inte gått ut.
        /// </summary>
        public void Ping(int userID)
        {
            Console.WriteLine(controll.Ping(userID));
        }
    }
}