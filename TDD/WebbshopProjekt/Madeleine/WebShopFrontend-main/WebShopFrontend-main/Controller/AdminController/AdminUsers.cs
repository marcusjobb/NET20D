using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WebShopAssignment;
using WebShopFrontend.Helpers;
using WebShopFrontend.View;

namespace WebShopFrontend.Controller.AdminController
{
    public class AdminUsers
    {
        public static WebShopAPI api = new WebShopAPI();
        /// <summary>
        /// Skriver ut användarnamnet på alla användare
        /// </summary>
        /// <param name="adminId"></param>
        public static void PrintUsers(int adminId)
        {           
            UserHelpers.IsUserActice(adminId);

            var users = api.ListUser(adminId);
            Console.WriteLine("Användare: ");
            foreach (var u in users)
            {
                Console.WriteLine(u.Name);

            }
            Console.WriteLine("");
            Thread.Sleep(2000);
            Console.Clear();
        }
        /// <summary>
        /// Sök efter användare
        /// </summary>
        /// <param name="adminId"></param>
        public static void SearchForUser(int adminId)
        {
            UserHelpers.IsUserActice(adminId);

            Console.WriteLine("Sök efter: ");
            string keyword = Console.ReadLine();
            var match = api.FindUser(adminId, keyword);
            Console.WriteLine("Resultat: ");
            foreach (var m in match)
            {
                Console.WriteLine(m.Name);                
            }
            
            if (match.Count == 0)
            {
                Messages.DoesNotExist();
                Console.Clear();
                return;
            }
            Thread.Sleep(2000);
            Console.Clear();

        }
        /// <summary>
        /// Lägg till användare
        /// </summary>
        /// <param name="adminId"></param>
        public static void AddingUser(int adminId)
        {
            UserHelpers.IsUserActice(adminId);

            Console.WriteLine("Vilken användare vill du lägga till?");
            Console.WriteLine("Användarnamn: ");
            string name = Console.ReadLine();
            Console.WriteLine("Lösenord: ");
            string password = Console.ReadLine();

            var added = api.AddUser(adminId, name, password);
            if (added)
            {
                Console.WriteLine("Användaren är tillagd");
                Thread.Sleep(2000);
                Console.Clear();

            }
            else
            {
                Messages.WrongInput();
                Console.Clear();
                return;
            }
        }

    }
}
