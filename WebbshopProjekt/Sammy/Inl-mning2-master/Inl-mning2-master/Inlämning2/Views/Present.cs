using Inlämning2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämning2.Views
{
    public static class Present
    {
        public static void DrawALine()
        {
            Console.WriteLine("---------");
        }
        
        public static void ListBooks(Book book)
        {
            foreach (var cat in book.Categories)
            {
                Console.WriteLine($"Category: {cat.Name}");

            }
            DrawALine();
        }

        public static void ListBooks(List<Book> bookList)
        {
            foreach (var book in bookList)
            {
                Console.WriteLine(book.Title);
            }
            DrawALine();
        }

        public static void ListCategory(List<Book> books)
        {
            foreach (var book in books)
            {
                foreach (var cat in book.Categories)
                {
                    Console.WriteLine($"{cat.Name}: {book.Title}");

                }
            }
        }

        public static void ListCategories(List<Category> categories)
        {
            foreach (var cat in categories)
            {
                Console.WriteLine(cat.Name);
            }
            DrawALine();
        }

        public static void ListUsers(List<User> Users)
        {
            foreach (var u in Users)
            {
                Console.WriteLine(u.Name);
            }
        }
    }
}
