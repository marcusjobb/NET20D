using System;
using System.Collections.Generic;
using System.Text;
using WebbShopAPI;

namespace BookWebbshop.Controller
{
    class StoreController
    {

        public void ListCategories(int userID)
        {
            var api = new WebbshopAPI();
            api.CheckUser(userID);
            Console.WriteLine("Här är lista med alla kategorier:");
            api.GetCategories();

        }

        public void SearchCategories(int userID)
        {
            var api = new WebbshopAPI();
            api.CheckUser(userID);

            Console.Write("Sök efter kategori: ");
            string keyword = Console.ReadLine();

            Console.WriteLine($"" +
                $"\nHär är lista med alla kategorier som innehåller {keyword}:");
            api.GetCategories(keyword);

        }

        public void SearchBooksByAuthor(int userID)
        {
            var api = new WebbshopAPI();
            api.CheckUser(userID);

            Console.Write("Sök efter författare: ");
            string keyword = Console.ReadLine();

            Console.WriteLine($"" +
                $"\nHär är lista med alla böcker av {keyword}:");
            api.GetAuthors(keyword);

        }

        public void BookPurchase(int userID)
        {
            var api = new WebbshopAPI();
            api.CheckUser(userID);

            Console.Write("Sök efter titel på boken som du vill köpa: ");
            string keyword = Console.ReadLine();
            
            int bookId = api.GetBookId(keyword);

            if (bookId != 0)
            {
                Console.WriteLine($"Bokens information:");
                api.GetBook(bookId);
                api.GetAuthors(keyword);

                Console.WriteLine("------------------------------" +
                    $"\nVill du köpa boken? y/n");
                string input = Console.ReadLine();

                if (input == "y" && userID != 0)
                {
                    api.BuyBook(userID, bookId);
                    Console.WriteLine("------------------------------" +
                        "\nDitt köp gick igenom!");
                }
                else if (input == "y" && userID == 0)
                {
                    Console.WriteLine("------------------------------" +
                        "\nDu måste vara inloggad för att handla");
                }
            }
            
        }

        public void RegisterUser()
        {
            var api = new WebbshopAPI();

            Console.Write("Fyll i uppgifter:");
            Console.Write("Namn: ");
            string name = Console.ReadLine();
            Console.Write("Lösenord: ");
            string password = Console.ReadLine();
            Console.Write("Verifiera lösenord: ");
            string verPassword = Console.ReadLine();

            if (api.Register(name, password, verPassword) == true)
                Console.WriteLine("" +
                    "\nDu är nu registrerad, nu kan du logga in");
            else
                Console.WriteLine("" +
                    "\nNågot gick fel, testa igen!");
        }

        public int LogInUser()
        {
            var api = new WebbshopAPI();

            Console.Write("Namn: ");
            string name = Console.ReadLine();
            Console.Write("Lösenord: ");
            string password = Console.ReadLine();

            int userID = api.Login(name, password);

            if (userID > 0)
            {
                Console.WriteLine("" +
                    "\nDu är inloggad");
                return userID;
            }
            else
            {
                Console.WriteLine("" +
                    "\nNågot gick fel, testa igen");
                return 0;
            }

        }

        public int LogOutUser(int userID)
        {
            var api = new WebbshopAPI();

            api.Logout(userID);
            Console.WriteLine("Du är utloggad");
            return 0;
        }
    }
}
