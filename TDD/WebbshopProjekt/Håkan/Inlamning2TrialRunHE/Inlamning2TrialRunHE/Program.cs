using Inlamning2TrialRunHE.Db;
using System;

namespace Inlamning2TrialRunHE
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Seeder.Seed();
            WebbShopAPI shop = new WebbShopAPI();
            int amount = 3;
            shop.AddUser(1, "Add", "User");
            var userId = shop.Login(
                "Administrator", "CodicRulez");
            Console.WriteLine("AddCategory: " + shop.AddCategory(
                userId.Id, "TestCategory"));
            Console.WriteLine("Addbook: " + shop.Addbook(
                userId.Id, 5, "C#", "Jan Skansholm", 5, 8));
            Console.WriteLine("AddBookToCategory: " + shop.AddBookToCategory(
                1, 5, 3));
            Console.WriteLine("AddUser: " + shop.AddUser(
                userId.Id, "Kevin", "Mitnick"));
            Console.WriteLine("BuyBook: " + shop.BuyBook(
                userId.Id, 5));
            Console.WriteLine("DeleteBook: " + shop.DeleteBook(
                userId.Id, 3));
            shop.SetAmount(userId.Id, 1, amount);
            Console.WriteLine("DeleteCategory: " + shop.DeleteCategory(
                userId.Id, 2));
            foreach (var user in shop.FindUser(userId.Id, "itni"))
            {
                Console.WriteLine("FindUser: " + user.Name);
            }
            foreach (var book in shop.GetAuthors("simo"))
            {
                Console.WriteLine("GetAuthor: " + book.Author);
            }
            foreach (var book in shop.GetAvailableBooks(1))
            {
                Console.WriteLine("GetAvailableBooks: " + book.Title);
            }
            Console.WriteLine("GetBook: " + shop.GetBook(2).Category.Name);
            foreach (var book in shop.GetBooks("Sh"))
            {
                Console.WriteLine("GetBooks: " + book.Title);
            }
            foreach (var category in shop.GetCategories())
            {
                Console.WriteLine("GetCategories1: " + category.Name);
            }
            foreach (var category in shop.GetCategories("Hum"))
            {
                Console.WriteLine("GetCategories2: " + category.Name);
            }
            foreach (var book in shop.GetCategory(2))
            {
                Console.WriteLine("GetCategory: " + book.Title);
            }
            foreach (var user in shop.ListUsers(userId.Id))
            {
                Console.WriteLine("Listusers: " + user.Name);
            }
            Console.WriteLine("Logout: Utloggad!");
            Console.WriteLine("Ping: " + shop.Ping(
                userId.Id));
            Console.WriteLine("Register: " + shop.Register(
                "Rutger", "Jönåker", "Jönåker"));

            Console.WriteLine("UpdateBook: " + shop.UpdateBook(
                userId.Id, 5, "Marcus", "Medina", 133));

            Console.WriteLine("UpdateCategory: " + shop.UpdateCategory(
                userId.Id, 4, "UpdatedCategory"));

            Console.ReadLine();
        }
    }
}
