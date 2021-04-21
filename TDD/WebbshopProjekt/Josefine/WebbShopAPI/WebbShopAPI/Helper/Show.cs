using System;
using System.Collections.Generic;
using WebbShopAPI.Models;

namespace WebbShopJoR.Helper
{/// <summary>
/// Class to print stuff when testing methods
/// </summary>
    public class Show
    {
        public static void ShowCathegorys(List<BookCategory> categories)
        {
            foreach (var category in categories)
            {
                Console.WriteLine(category.Name);
            }
        }
        public static void ShowBooks(List<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title} \nAuthor: {book.Author}\nAvaliable ex: {book.Amount}\n");
            }
        }
        public static void ShowBook(Book book)
        {
            if (book != null)
            {
                Console.WriteLine($"Title: {book.Title}\nAuthor: {book.Author}");
                if (book.BookCategories != null)
                {
                    Console.WriteLine($"Category: {book.BookCategories.Name}");
                }
                Console.WriteLine($"Price: {book.Price}\nAvailable ex: {book.Amount}");
            }
        }
        public static void ShowUsers(List<User> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
            }
        }
    }
}
