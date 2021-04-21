using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inlamn2WebbShop_MLarsson.Database;
using Inlamn2WebbShop_MLarsson.Models;
using Microsoft.EntityFrameworkCore;

namespace Inlamn2WebbShop_MLarsson.Views
{
    public static class View
    {
        /// <summary>
        /// Öpnnar en koppling till databasen, för att kunna använda i hela klassen.
        /// </summary>
        private static WebbShopContext db = new WebbShopContext();

        /// <summary>
        /// Visar om användare är active eller inactive
        /// </summary>
        /// <param name="actInact"></param>
        /// <param name="name"></param>
        /// <returns>true</returns>
        public static bool ActiveInactive(string actInact, string name)
        {
            if (actInact == "active")
            {
                Console.WriteLine($"\n{name} is now an active user.");
            }
            else
            {
                Console.WriteLine($"\n{name} is now an inactivated user.");
            }
            return true;
        }

        /// <summary>
        /// Visa text för att visa att boken är tillagd i butiken.
        /// </summary>
        /// <param name="title"></param>
        /// <returns>true</returns>
        public static bool AddBook(string title)
        {
            Console.WriteLine($"The book {title} is added to the store.");
            return true;
        }

        /// <summary>
        /// Visa text för att lägga till bok i kategori.
        /// </summary>
        /// <param name="cat"></param>
        /// <returns>true</returns>
        public static bool AddBookToCategory(Category cat)
        {
            Console.WriteLine($"Book added to category {cat.Name}. ");
            return true;
        }

        /// <summary>
        /// Visa text för att lägga till kategori
        /// </summary>
        /// <param name="name"></param>
        /// <returns>true</returns>
        public static bool AddCategory(string name)
        {
            Console.WriteLine($"You have added {name} as a category.");
            return true;
        }

        /// <summary>
        /// Visa text för att lägga till användare.
        /// </summary>
        /// <param name="choice"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns>true om ny användare är tillagd, annars false</returns>
        public static bool AddUser(string choice, string name, string password)
        {
            if (choice == "user")
            {
                Console.WriteLine("User already exists! Try another name.");
            }
            if (choice == "add")
            {
                Console.WriteLine($"You have added a new user: {name.Trim()} - {password}");
                return true;
            }
            return false;
        }

        /// <summary>
        /// Visar bästa kunden.
        /// </summary>
        /// <param name="amount"></param>
        public static void BestCustomer(int amount)
        {
            Console.WriteLine($"\nBEST CUSTOMER:\nAmount of books bought: {amount}");
        }

        /// <summary>
        /// Visa text vilken bok som är köpt.
        /// </summary>
        /// <param name="title"></param>
        public static void BuyBook(string title)
        {
            Console.WriteLine($"\nYou have bought {title}\n");
        }

        /// <summary>
        /// Visa text om bok är raderad.
        /// </summary>
        /// <param name="title"></param>
        /// <returns>true</returns>
        public static bool DeleteBook(string title)
        {
            Console.WriteLine($"You have deleted book {title}");
            return true;
        }

        /// <summary>
        /// Visar om användaren är demote eller promote.
        /// </summary>
        /// <param name="dePro"></param>
        /// <param name="name"></param>
        /// <returns>true</returns>
        public static bool DemotePromote(string dePro, string name)
        {
            if (dePro == "demote")
            {
                Console.WriteLine($"\n{name} is now demoted to normal user.");
            }
            else
            {
                Console.WriteLine($"\n{name} is now promoted to administrator.");
            }
            return true;
        }
        /// <summary>
        /// Listar alla böcker i en boklista
        /// </summary>
        /// <param name="bookList"></param>
        public static void ListBooks(List<Book> bookList)
        {
            foreach (var book in bookList)
            {
                ListBooks(book);
            }
        }

        /// <summary>
        /// Presenterar en vald bok och dess kategori.
        /// </summary>
        /// <param name="book"></param>
        public static void ListBooks(Book book)
        {
            foreach (var cat in book.Categories)
            {
                Console.Write("Category: ");
                Console.WriteLine($"{cat.Name} ");
            }
            Console.WriteLine(book);
        }

        /// <summary>
        /// Listar alla kategorier i en kategorilista
        /// </summary>
        /// <param name="categories"></param>
        public static void ListCategories(List<Category> categories)
        {
            Console.WriteLine("\nCATEGORIES: ");
            try
            {
                foreach (var cat in categories)
                {
                    Console.WriteLine(cat.Name);
                }
            }
            catch
            {
                Console.WriteLine("No categories found...");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Listar alla böcker i en kategori.
        /// </summary>
        /// <param name="books"></param>
        public static void ListCategory(List<Book> books)
        {
            Console.WriteLine($"\nBOOKS IN CATEGORY: ");
            try
            {
                foreach (var book in books)
                {

                    foreach (var cat in book.Categories)
                    {
                        Console.WriteLine($"{cat.Name} - {book.Title}");
                    }
                }
            }
            catch
            {
                Console.WriteLine("No books found...");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Visar information om en användare.
        /// </summary>
        /// <param name="user"></param>
        public static void ListUser(User user)
        {
            Console.WriteLine("USER: ");

            try
            {
                Console.WriteLine($"ID: {user.Id} - {user.Name}");
                if (user.SoldBooks != null)
                {
                    Console.Write($"Books bought: ");
                    foreach (var soldBook in user.SoldBooks)
                    {
                        Console.Write($"{soldBook.Title}, ");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("No user found...");
            }

        }
        /// <summary>
        /// Listar alla användare i en användarlista, inklusive admin.
        /// </summary>
        /// <param name="userList"></param>
        public static void ListUsers(List<User> userList)
        {
            Console.WriteLine();
            try
            {
                foreach (var user in userList)
                {
                    Console.WriteLine("\nUSER: ");
                    Console.WriteLine(user);
                    if (user.SoldBooks != null)
                    {
                        Console.Write($"Books bought: ");
                        foreach (var soldBook in user.SoldBooks)
                        {
                            Console.WriteLine($"{soldBook.Title}, ");
                        }
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("No user found...");
            }
        }

        /// <summary>
        /// Visa text för att logga in eller ut.
        /// </summary>
        /// <param name="choice"></param>
        public static void LogInLogOut(string choice)
        {
            if (choice == "login")
            {
                Console.WriteLine("\nYou have successfully logged in.");
            }
            if (choice == "logout")
            {
                Console.WriteLine("\nYou have successfully logged out. Welcome back.");
            }
        }

        /// <summary>
        /// Visar totalsumman av sålda böcker.
        /// </summary>
        /// <param name="totalSum"></param>
        public static void MoneyEarned(int totalSum)
        {
            Console.WriteLine("\nTOTAL MONEY EARNED BY SOLD BOOKS:");
            Console.WriteLine($"    {totalSum}kr");
        }

        /// <summary>
        /// Visar totalsumman per såld bok.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="bookSum"></param>
        public static void MoneyEarned(string title, int bookSum)
        {
            Console.WriteLine($"SOLD BOOK: {title} MONEY EARNED: {bookSum}");
        }

        /// <summary>
        /// Visa text vid registrering av ny användare.
        /// </summary>
        /// <param name="choice"></param>
        /// <returns>true om ny användare är registrerad, annars false.</returns>
        public static bool Register(string choice)
        {
            if (choice == "password")
            {
                Console.WriteLine("Please check your password. Your passwords are not equal or contains at least 4 letters.");
            }
            if (choice == "name")
            {
                Console.WriteLine("User already exists! Try another user name.");
            }
            if (choice == "new")
            {
                Console.WriteLine("You are now registred in our shop. Please login to start buying books.");
                return true;
            }
            return false;
        }

        /// <summary>
        /// Visa text för SetAmount.
        /// </summary>
        /// <param name="amount"></param>
        public static void SetAmount(int amount = 0)
        {
            if (amount != 0)
            {
                Console.WriteLine($"The book stock is refilled with {amount} books.");
            }
            else
            {
                Console.WriteLine("No book was found...");
            }
        }

        /// <summary>
        /// Visar alla sålda böcker.
        /// </summary>
        public static void SoldItems()
        {
            Console.WriteLine();
            Console.WriteLine("\nSOLD BOOKS:");
            foreach (var soldBook in db.SoldBooks.Include(u => u.Users))
            {
                Console.WriteLine($"{soldBook.Title} - Date: {soldBook.PurchasedDate}");
                foreach (var buyer in soldBook.Users)
                {
                    Console.WriteLine($"    Customer: {buyer.Name}");
                }
            }
        }
        /// <summary>
        /// Visar meddelande om något inte gått som tänkt. 
        /// </summary>
        /// <returns>false</returns>
        public static bool SomethingWentWrong()
        {
            Console.WriteLine("\nSomething went wrong...");
            return false;
        }
    }

}
