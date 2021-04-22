using System;

namespace WebshopApiFrontend.Utility
{
    static class Shop
    {
        /// <summary>
        /// Menu for purchasing books, it contains a list option to ease the way buying works, with book Id
        /// </summary>
        /// <param name="loggedInUser"></param>
        public static void PurchaceBooks(int loggedInUser)
        {
            bool activeSeassion = true;
            do
            {
                Console.WriteLine("\n**************************************\n" +
                                    "* 1. List Books\n" +
                                    "* 2. Buy Book\n" +
                                    "* 0. Return\n" +
                                    "**************************************\n");
                Console.Write(">> ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string menuChoice = Console.ReadLine();
                Console.ResetColor();

                switch (menuChoice)
                {
                    case "1":
                        Methods.ListBooksInDatabase();
                        break;
                    case "2":
                        Methods.BuyBookInDatabase(loggedInUser);
                        break;
                    case "0":
                        activeSeassion = false;
                        break;
                }
            } while (activeSeassion);
        }
    }
}
