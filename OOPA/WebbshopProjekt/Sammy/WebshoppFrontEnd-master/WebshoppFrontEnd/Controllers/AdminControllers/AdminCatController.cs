using Inlämning2;
using System;
using WebbshopFrontEnd.Views;
using WebbshopFrontEnd.Views.Admin;

namespace WebbshopFrontEnd.Controllers.AdminControllers
{
    public static class AdminCatController
    {
        public static WebbShopAPI api = new WebbShopAPI();
        
        /// <summary>
        /// Metod för att lägga till en kategori.
        /// </summary>
        /// <param name="adminId"></param>
        public static void AddCat(int adminId)
        {
            api.Ping(adminId);
            var bookTitle = AdminCatMenu.AddCatMenu();
            var added = api.AddCategory(adminId, bookTitle);
            if (added) { Console.WriteLine("Tillagd"); }
            else { Message.ErrorInput(); }
        }

        public static void AddCatToBook(int adminId)
        {
            api.Ping(adminId);
            (int bookId, string catName) = AdminCatMenu.ShowAddCatToBook();

        }
    }
}
