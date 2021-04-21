
using Microsoft.Extensions.Caching.Memory;
using MyFirstEntityframProject.Database;
using System;

namespace MyFirstEntityframProject
{
    class Program
    {

        internal static void Main(string[] args)
        {
            Seeder.Seed();

            var api = new WebShopAPI();

            //var id = api.Login("Administrator", "CodicRulez");
            //Console.WriteLine(id); //klar

            //var id = api.Login("Yulia", "Lucia2011");
            // Console.WriteLine(id); //klar

            //api.Logout(2); //klar

            //api.GetCategories(); //klar
          
            //api.GetCategories("Rom"); // klar

            //api.GetCategory(3); // //klar

            //api.GetAvailableBooks(); //klar

            //api.GetBook(3); //klar

            //api.GetBooks("b"); //klar

            //api.GetAuthors("St"); //klar

            //api.BuyBook(3, 4); //klar

            //api.Ping(3); //klar

            //api.Register("Yulia","Lucia2011","Lucia2011"); //klar


            //============ functions available to admin ============

            //api.AddBook(1,5,"Peace and War", "Leo Tolstoy", 185, 3); //klar

            //api.SetAmount(1,9); //klar

            //api.ListUsers(2);// klar

            //api.FindUser(2,"Lu");klar

            //api.UpdateBook(1,3,"Masha and the Bear", "Oleg Kusuvkov", 150, 2); klar

            //api.DeleteBook(1,3);//klar

            //api.AddCategory(1, "Poesi"); //klar

            //api.AddBookToCategory(1,3,1); //klar

            //api.UpdateCategory(1, 5, "History"); klar

            //api.DeleteCategory(1, 4); //klar

            //api.AddUser(1, "Yulia", "Lucia2011); /klar
        }
    }
}



