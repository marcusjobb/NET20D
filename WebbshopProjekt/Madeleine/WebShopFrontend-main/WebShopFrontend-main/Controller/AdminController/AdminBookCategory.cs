using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WebShopAssignment;
using WebShopFrontend.Helpers;
using WebShopFrontend.View;

namespace WebShopFrontend.Controller.AdminController
{
    public class AdminBookCategory
    {
        public static WebShopAPI api = new WebShopAPI();

        /// <summary>
        /// Lägger till en ny kategori i databasen
        /// </summary>
        /// <param name="adminId"></param>
        public static void AddsCategory(int adminId)
        {
            UserHelpers.IsUserActice(adminId);

            Console.WriteLine("Vad är namnet på kategorin?: ");
            string categoryName = Console.ReadLine();

            var added = api.AddCategory(adminId, categoryName);
            if (added)
            {
                Console.WriteLine("Tillagd");
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
        /// <summary>
        /// Uppdaterar namnet på en kategori
        /// </summary>
        /// <param name="adminId"></param>
        public static void UpdateCategory(int adminId)
        {
            UserHelpers.IsUserActice(adminId);

            Console.WriteLine("Vilken kategori vill du uppdatera?");
            var listCategories = api.GetCategories();
            foreach(var l in listCategories)
            {
                Console.WriteLine($"{l.Id}: {l.Name}");
            }
            int categoryId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Vad ska kategorin heta?");
            string name = Console.ReadLine();

            var updated = api.UpdateCategory(adminId, categoryId, name);
            if(updated == true)
            {
                Console.WriteLine("Uppdaterad.");
                Thread.Sleep(2000);
                Console.Clear();
            }
            else
            {
                Messages.WrongInput();
                Console.Clear();
            }

        }

        /// <summary>
        /// Tar bort en kategori som saknar böcker
        /// </summary>
        /// <param name="adminId"></param>
        public static void DeleteCategory(int adminId)
        {
            UserHelpers.IsUserActice(adminId);

            Console.WriteLine("Vilken kategori vill du ta bort?");
            var list = api.GetCategories();
            foreach(var l in list)
            {
                Console.WriteLine($"{l.Id}: {l.Name}");
            }
            int categoryId = Convert.ToInt32(Console.ReadLine());
            var del = api.DeleteCategory(adminId, categoryId);
            if(del == false)
            {
                Console.WriteLine("Denna kunde inte tas bort");
                Console.WriteLine("Antingen finns inte kategorin");
                Console.WriteLine("eller så det böcker kopplade till den");
                Thread.Sleep(2000);
                Console.Clear();

            }
            else
            {
                Console.WriteLine("Kategori borttagen");
                Thread.Sleep(2000);
                Console.Clear();

            }
        }

    }
}
