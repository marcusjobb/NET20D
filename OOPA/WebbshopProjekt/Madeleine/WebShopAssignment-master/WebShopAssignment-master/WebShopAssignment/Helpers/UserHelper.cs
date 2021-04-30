using System;
using System.Collections.Generic;
using System.Text;
using WebShopAssignment.Models;

namespace WebShopAssignment.Helpers
{
    public class UserHelper
    {
        public static bool IsUserAdmin(User user)
        {
            if (user == null || !user.IsAdmin)
            {
                return false;
            }
            if (user.SessionTimer < DateTime.Now.AddMinutes(-15))
            {
                return false;
            }
            return true;

        }

        public static void PrintAllInformation(Book book)
        {
            Console.WriteLine($"ID: {book.Id }, Titel: {book.Title}, Författare: {book.Author}, Pris: {book.Price}, Antal i lager: {book.Amount} Kategori: {book.CategoryId}");
        }

    }
}
