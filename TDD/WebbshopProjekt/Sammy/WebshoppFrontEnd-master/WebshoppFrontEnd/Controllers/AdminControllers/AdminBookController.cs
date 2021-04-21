using Inlämning2;
using System;
using WebbshopFrontEnd.Views;
using WebbshopFrontEnd.Views.Admin;

namespace WebbshopFrontEnd.Controllers.AdminControllers
{
    public static class AdminBookController
    {
        public static WebbShopAPI api = new WebbShopAPI();

        /// <summary>
        /// Metod för att lägga till en bok.
        /// </summary>
        /// <param name="adminId"></param>
        public static void AddBook(int adminId)
        {
            api.Ping(adminId);
            (string title, string author, int price, int amount) = AdminBookMenu.AddBookMenu(); 
            var newBook = api.AddBook(adminId, title, author, price, amount);
            if (!newBook) { Message.ErrorInput(); }
            Console.Clear();
        }

        /// <summary>
        /// Metod för att ta bort en bok.
        /// </summary>
        /// <param name="adminId"></param>
        public static void DeleteBook(int adminId)
        {
            api.Ping(adminId);
            int bookId = AdminBookMenu.DeleteBookMenu();
            api.DeleteBook(adminId, bookId);
        }

        /// <summary>
        /// Metod för att sätta antalet på en bok i lagret.
        /// </summary>
        /// <param name="adminId"></param>
        public static void SetAmountBooks(int adminId)
        {
            api.Ping(adminId);
            (int bookId, int amount) = AdminBookMenu.AmountInput();
            api.SetAmount(adminId, bookId, amount);
        }

        /// <summary>
        /// Metod för att uppdatera en bok.
        /// </summary>
        /// <param name="adminId"></param>
        public static void UpdateBook(int adminId)
        {
            api.Ping(adminId);
            (int bookId, string title, string author, int price) = AdminBookMenu.UpdateBookInput();
            api.UpdateBook(adminId, bookId, title, author, price);
        }
    }
}
