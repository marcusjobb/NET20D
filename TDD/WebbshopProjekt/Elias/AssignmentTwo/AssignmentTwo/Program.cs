using AssignmentTwo.Database;
using System;

namespace AssignmentTwo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WebbShopAPI API = new WebbShopAPI();

            Seeder.Seed();

            API.Login("TestCustomer", "Codic2021");

            foreach (var item in API.GetCategories())
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("------------------------------");

            foreach (var item in API.GetCategory(2))
            {
                Console.WriteLine(item.Title);
            }

            Console.WriteLine("------------------------------");

            foreach (var item in API.GetBook(3))
            {
                Console.WriteLine(item.Title + ", " + item.Author + ", " + item.Amount + " copies available");
            }

            Console.WriteLine("------------------------------");

            API.BuyBook(2, 3);

            API.Login("Administrator", "CodicRulez");

            API.AddCategory(1, "Fantasy");

            foreach (var item in API.GetCategories())
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("------------------------------");

            API.AddBookToCategory(1, 4, 5);

            API.AddUser(1, "Elias", "LösenÄrBra");
        }
    }
}