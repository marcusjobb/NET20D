using Inlämning_API.Models;
using System;
using System.Collections.Generic;

namespace Inlämning_3Front.Views
{
    internal class AdminView
    {
        /// <summary>
        /// Views to the admincontroller
        /// </summary>
        /// <param name="user"></param>
        public void AdminMenu(User user)
        {
            Console.Clear();
            Console.WriteLine($"Welcome {user.Name}");
            Console.WriteLine("1.  Add book");
            Console.WriteLine("2.  Set amount");
            Console.WriteLine("3.  List users");
            Console.WriteLine("4.  Search user");
            Console.WriteLine("5.  Update book");
            Console.WriteLine("6.  Delete book");
            Console.WriteLine("7.  Add category");
            Console.WriteLine("8.  Add book to category");
            Console.WriteLine("9.  Update Category");
            Console.WriteLine("10. Delete Category");
            Console.WriteLine("11. Add User");
            Console.WriteLine("12. Show sold items");
            Console.WriteLine("13. Money earned");
            Console.WriteLine("14. Show best customer");
            Console.WriteLine("15. Promote user");
            Console.WriteLine("16. Demote user");
            Console.WriteLine("17. Activate user");
            Console.WriteLine("18. Deactivate user");
            Console.WriteLine("[E. to go back]");
        }

        public void ShowBooks(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                Console.Write($"{book.Id}. " +
                      $"[Title: {book.Title}] " +
                      $"[Author: {book.Author}] " +
                      $"[Amount: {book.Amount}] ");
                if (book.Category != null) Console.WriteLine($"[Category: {book.Category.Name}]");
            }
            Console.WriteLine();
        }

        public void ShowUsers(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine($"{user.ID}. " +
                    $"[Name: {user.Name}] " +
                    $"[Active: {user.IsActive}] " +
                    $"[Admin: {user.IsAdmin}]");
            }
        }

        public void ShowCategory(IEnumerable<BookCategories> categories)
        {
            foreach (var cat in categories)
            {
                Console.WriteLine($"{cat.Id}. {cat.Name}");
            }
        }

        public void ShowSoldItems(IEnumerable<SoldBooks> solditems)
        {
            foreach (var sold in solditems)
            {
                Console.WriteLine($"{sold.Title}");
            }
        }

        public void DisplayInt(int number) => Console.WriteLine($"{number}");

        public void DisplayUser(User user) => Console.WriteLine($"[Name: {user.Name}]");

        public void InputChoice() => Console.Write("Enter choice: ");

        public void AskForTitle() => Console.Write("Enter title: ");

        public void AskForPassword() => Console.Write("Enter password: ");

        public void AskForAuthor() => Console.Write("Enter author: ");

        public void AskForPrice() => Console.Write("Enter price: ");

        public void AskForAmount() => Console.Write("Enter Amount: ");

        public void AskForBookId() => Console.Write("Enter book Id: ");

        public void EnterKeyword() => Console.Write("Enter keyword: ");

        public void AskForName() => Console.WriteLine("Enter name: ");
    }
}