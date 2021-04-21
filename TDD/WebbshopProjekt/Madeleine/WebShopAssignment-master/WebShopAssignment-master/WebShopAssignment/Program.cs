using System;
using WebShopAssignment.Helpers;
using WebShopAssignment.Models;

namespace WebShopAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            var webShop = new WebShopAPI();

            //Kör Seeders först
            /*
            Seeder.SeedUsers();
            Seeder.SeedCategories();
            Seeder.SeedBookTitles();
            */
            
            /*
            // Test 1 - logga in, sök på kategorier och köp en bok           
            var id = webShop.Login("Administrator", "CodicRulez");
            Console.WriteLine(id);                   
            var check = webShop.Ping(1);
            Console.WriteLine(check);
           

            // Lista på alla kategorier som finns
            var cats = webShop.GetCategories();
            foreach(var cat in cats)
            {
                Console.WriteLine($"Kategorier som finns: ID {cat.Id} Namn: { cat.Name }");
            }
            
            //kolla vilka kategorier som finns, baserat på sökord           
            var category = webShop.GetCategories("Horror");
            foreach(var b in category)
            {
                Console.WriteLine($"Katergorier som matchar sökordet: {b.Name}");
            }
            //Skriver ut namn på böckerna med en specifik kategori
            var booksWithCategory = webShop.GetCategory(1);
            foreach( var b in booksWithCategory)
            {
                Console.WriteLine($"Katergori med bok i lager: {b.Title}");
            }

            //Skriv ut info om bok
            var bookInfo = webShop.GetBook(2);
            foreach (var info in bookInfo)
            {
                UserHelper.PrintAllInformation(info);
            }
            //köp en bok
            webShop.BuyBook(1, 2);
        
            //kolla hur många av varje bok som finns i lager
            var available = webShop.GetAvailableBooks();
            foreach (var a in available)
            {
                Console.WriteLine($"Bok i lager: {a.Title}. Antal: {a.Amount}");
            }
            */

            /*
            //Test 2 - Logga in som admin, skapa en kategori
            webShop.Login("Administrator", "CodicRulez");
            webShop.AddCategory(1, "Kids");
            webShop.AddBook(1, "Horton Hears A Who", "Dr Seuss", 100, 2);
            webShop.AddBookToCategory(1, 5, 5);
            */

            /*
            // Test 3 - skapa en användare
            webShop.Login("Administrator", "CodicRulez");
            webShop.AddUser(1, "maja", "Codic2021");
            */

        }
    }
}
