using Inlämning2.Database;
using Inlämning2.Models;
using System.Linq;
using System;

namespace Inlämning2
{
    class Program
    {
        public static void Main(string[] args)
        {
            ////Grunddata införs i databasen.
            //Seeder.Seed();

            //var webbShop = new WebbShopAPI();

            ////Kunden loggar in
            //var id = webbShop.LogIn("TestCustomer", "Codic2021");
            //Console.WriteLine(id);
            //Views.Present.DrawALine();

            //Logga ut
            //webbShop.LogOut(1);

            ////Lista alla katergorier
            //var list = webbShop.GetCategories();
            //Views.Present.ListCategories(list);

            ////Lista alla kategorier med keyword "or"
            //var list = webbShop.GetCategories("or");
            //Views.Present.ListCategories(list);

            ////GetCategory med Horror
            //var list = webbShop.GetCategory(2);
            //Views.Present.ListCategory(list);

            ////Lista böcker med antal > 0 
            //var list = webbShop.GetAvaliableBooks(2);
            //Views.Present.ListBooks(list);

            ////Visa detaljer av en bok
            //var book = webbShop.GetBook(3);
            //Console.WriteLine(book.ToString());

            ////Lista böcker som har matchat sökordet
            //var list = webbShop.GetBooks("or");
            //Views.Present.ListBooks(list);

            ////Visa alla böcker av den sökad författare
            //var list = webbShop.GetAuthor("King");
            //Views.Present.ListBooks(list);

            //webbShop.BuyBook(2, 2);

            ////Skicka Ping 
            //Console.WriteLine(webbShop.Ping(2));

            ////Kunden registerar sig.
            //webbShop.Register("Sammy Wong", "NoMorePain", "NoMorePain");

            ////Logga in admin
            //var id = webbShop.LogIn("Adminstrator", "CodicRulez");
            //Console.WriteLine(id);
            //Views.Present.DrawALine();

            ////Läger in några böcker
            //webbShop.AddBook(1, "Principle of Angels", "Jaine Fenn", 200, 4);
            //webbShop.AddBook(1, "Frankenstein", "Mary Wollencrasft Shelly", 300, 2);

            ////Sätt antal utökas med 2
            //webbShop.SetAmount(1, 3, 2);

            ////Lista alla användare
            //var list = webbShop.ListUsers(1);
            //Views.Present.ListUsers(list);

            //// Hitta användare med sökord
            //var list = webbShop.FindUser(1, "Wong");
            //Views.Present.ListUsers(list);

            ////Uppdatera "I Robot" med pris 100
            //webbShop.UpdateBook(1, 4, "I Robot", "Issac Asimov", 100);

            ////Ta bort en bok
            //webbShop.DeleteBook(1, 1);

            ////Lägger till Thriller i kategori
            //webbShop.AddCategory(1, "Children");

            ////Uppdatera bokens kategori
            //webbShop.AddBookToCategory(1, 5, 3);

            ////Ta bort en kategori
            //webbShop.DeleteCategory(1, 6);

            ////Lägger till en nya användare
            //webbShop.AddUser(1, "Mary Karlsson");
            //webbShop.AddUser(1, "Sammy Wong");

        }
    }
}
