using System;
using System.Collections.Generic;
using System.Threading;
using Webbutik.Database;

namespace Webbutik
{
    class Program
    {
        static void Main(string[] args)
        {
            string username;
            string password;
            int userId;

            Seeder.Seed();
            WebbShopAPI webbShopAPI = new WebbShopAPI();

            username = "TestCustomer";
            password = "Codic2021";

            //webbShopAPI.Logout(2);
            userId = webbShopAPI.Login(username, password).Id;

            List<int> categoryId = new List<int>();

            Console.WriteLine("Välje en kategori: ");
            foreach (var item in webbShopAPI.GetCategories())
            {
                Console.WriteLine(item.Name);
                categoryId.Add(item.Id);
            }

            Console.WriteLine();
            Console.WriteLine("Horror");
            Console.WriteLine();

            List<int> bookId = new List<int>();
            foreach (var item in webbShopAPI.GetCategory(categoryId[0]))
            {
                Console.WriteLine(item.Title);
                bookId.Add(item.Id);
            }

            Console.WriteLine();
            Console.WriteLine("DrSleep");
            Console.WriteLine();

            Console.WriteLine("Amount: " + webbShopAPI.GetBook(bookId[0]).Amount);
            Console.WriteLine();

            webbShopAPI.BuyBook(userId, bookId[0]);
            Console.WriteLine("Amount: " + webbShopAPI.GetBook(bookId[0]).Amount);

            webbShopAPI.Logout(userId);

            username = "Administrator";
            password = "CodicRulez";

            userId = webbShopAPI.Login(username, password).Id;
            webbShopAPI.AddCategory(userId, "Adventure");

            foreach (var item in webbShopAPI.GetCategories("Adventure"))
            {
                Console.WriteLine(item.Name);
                categoryId.Add(item.Id);
            }

            webbShopAPI.AddBookToCategory(userId, 1, categoryId[5]);
            Console.WriteLine(webbShopAPI.GetBook(1).Title);
            Console.WriteLine(webbShopAPI.GetBook(1).Category.Name);

            webbShopAPI.Logout(userId);
        }
    }
}
