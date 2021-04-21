
namespace WebbshopFrontEnd.Views
{
    using Inlämning2;
    using Inlämning2.Models;
    using System;
    using System.Collections.Generic;
    using WebbshopFrontEnd.Controllers.UserControllers;

    public static class UserView
    {
        public static WebbShopAPI api = new WebbShopAPI();

        /// <summary>
        /// Vyn för att registera en ny kund.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public static void RegisterUser(string username, string password)
        {
            Console.WriteLine("Du är inte kund hos oss, var vänligen och registera dig.");
            Console.WriteLine($"Du har angett {username} som användarnamn och {password} som lösenord.");
            Console.Write("Skriv lösenord igen för att verifiera: ");
            string pwVerify = Console.ReadLine();
            api.Register(username, password, pwVerify);
        }

        /// <summary>
        /// Vyn för inmatning av sökord för att hitta kategori.
        /// </summary>
        /// <returns></returns>
        public static string ShowSearchCat()
        {
            Console.Clear();
            Console.Write("Ange ett sökord för kategori som du söker: ");
            return Console.ReadLine();
        }
        
        /// <summary>
        /// Vyn för att lista alla kategorier.
        /// </summary>
        /// <param name="cat"></param>
        public static void ShowAllCategory(List<Category> cat)
        {
            Console.Clear();
            foreach (var c in cat) { Console.WriteLine($"Kategori: [{c.Id}] -- {c.Name}"); }
            if ( cat.Count == 0) { Message.CatNotExisted(); }
        }

        /// <summary>
        /// Lista alla böcker
        /// </summary>
        /// <param name="books"></param>
        public static void ShowBooks(List<Book> books)
        {
            Console.Clear();
            Console.WriteLine("Vi har hittat följande böcker:");
            foreach (var b in books)
            {
                Console.WriteLine($"BokId: [{b.BookId}] -- Title: {b.Title}");
            }
            if (books.Count == 0) { Message.BookNotExisted(); }
        }

        public static string ShowSearchAuthor()
        {
            Console.Clear();
            Console.Write("Var god och ange namnet på författare: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Vyn för användarmenyn.
        /// </summary>
        /// <param name="userId"></param>
        public static void UserMenu(int userId)
        {
            bool loop = true;

            while (loop)
            {
                Console.WriteLine("************************");
                Console.WriteLine("*    Användarmeny      *");
                Console.WriteLine("************************\n");
                Console.WriteLine("Du har följande val ");
                Console.WriteLine("[1] Lista alla kategorier");
                Console.WriteLine("[2] Söka efter kategori med sökord");
                Console.WriteLine("[3] Lista alla böcker i en kategori");
                Console.WriteLine("[4] Lista alla böcker som vi har i lagret i en kategori");
                Console.WriteLine("[5] Söka efter en bok med sökord");
                Console.WriteLine("[6] Söka efter böcker av en författare");
                Console.WriteLine("[7] Logga ut");

                try
                {
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 7)
                    {
                        Message.SignOut();
                        api.LogOut(userId);
                    loop = false;
                    //return;
                    }
                    else { UserChoiceController.UserChoice(userId, choice); }
                }
                catch { Message.ErrorInput(); }

            }
        }
    }
}
