using FrontEnd.Controllers;
using System;

namespace FrontEnd
{
    class Program
    {
        //ToDo: Menyer i views
        // TODO: menyer för Admin
        // TODO: Menyer för icke admin
        // TODO: 
        static void Main(string[] args)
        {
            WebbShop.Database.Seeder.Seed();
            var home = new Home();
            home.Start();
            //var myBook = WebbShopAPI.WebbShopApi.GetBook(1);
            //Console.WriteLine(myBook);

            //var myUser = WebbShopAPI.WebbShopApi.FindUsers(2, "Glen");
            //foreach (var user in myUser)
            //{
            //    Console.WriteLine("Din användare");
            //    Console.WriteLine("Name: " + user.Name + "Password: " + user.Password);
            //}

            //var allUsers = WebbShopAPI.WebbShopApi.ListUsers(2);
            //foreach (var user in allUsers)
            //{
            //    Console.WriteLine(user.Name);
            //}
        }
    }
}
