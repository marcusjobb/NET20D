using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WebShopAssignment;
using WebShopFrontend.View;

namespace WebShopFrontend.Controller.UserController
{
    public class UserBookCategory
    {
        public static WebShopAPI api = new WebShopAPI();
        /// <summary>
        /// Skriver ut alla kategorier i databasen
        /// </summary>
        /// <param name="userId"></param>
        public static void PrintAllCategories(int userId)
        {
            api.Ping(userId);

            var cat = api.GetCategories();
            foreach (var c in cat)
            {
                Console.WriteLine($"Kategori: {c.Id}, {c.Name}");
            }
            Console.WriteLine("Vilken kategori vill du välja?");
            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                UserBook.GetBooksInCategory(choice, userId);
            }
            catch
            {
                Messages.WrongInput();
                Console.Clear();
                return;
            }

        }
        /// <summary>
        /// Sök efter kategorier
        /// </summary>
        /// <param name="userId"></param>
        public static void SearchForCategories(int userId)
        {
            api.Ping(userId);

            Console.WriteLine("Sök efter: ");
            string keyword = Console.ReadLine();
            var cat = api.GetCategories(keyword);
            foreach (var c in cat)
            {
                Console.WriteLine($"Resultat:{c.Id} {c.Name}");
            }
            if (cat.Count == 0)
            {
                Messages.DoesNotExist();
                Console.Clear();
                return;
            }
            Console.WriteLine("Vilken vill du välja?");
            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                UserBook.GetBooksInCategory(choice, userId);
            }
            catch
            {
                Messages.WrongInput();
                Console.Clear();
                return;
            }
        }
    }
}
