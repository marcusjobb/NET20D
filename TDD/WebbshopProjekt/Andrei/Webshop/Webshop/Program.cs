using System;
using System.Collections.Generic;
using WebbShopApi.Database;

namespace WebbShopApi
{
    class Program
    {
        /// <summary>
        /// Mian method
        /// </summary>
        static void Main(string[] args)
        {
            Seeder.Seed();
            Example1();
            Example2();
            Example3();
        }

        /// <summary>
        /// example 1
        /// </summary>
        private static void Example1()
        {
            LogInAsTestUser();
            GetCategories();
            GetHorrorsBooks();
            GetBook("DrSleep");
            GetBook("Sleep");
            GetAmount(1);
            BuyBook(1);
            GetAmount(1);
        }

        /// <summary>
        /// example 2
        /// </summary>
        private static void Example2()
        {
            LoginAsAdmin();
            CreateCategory();
            MoveBookToNewCategory();
        }

        /// <summary>
        /// example 3
        /// </summary>
        private static void Example3()
        {
            LoginAsAdmin();
            WebbShopAPI.AddUser(2, "Test", "Test");
        }

        /// <summary>
        /// move book with id 1 to category with id 3
        /// </summary>
        private static void MoveBookToNewCategory()
        {
            Console.WriteLine("TEST: move book to new category ");
            Console.WriteLine();
            if (WebbShopAPI.AddBookToCategory(2, 1, 3))
            {
                Console.WriteLine("Book moved");
            }
            else
            {
                Console.WriteLine("Error");
            }
            Continue();
        }

        /// <summary>
        /// create "Test category"
        /// </summary>
        private static void CreateCategory()
        {
            Console.WriteLine("TEST: create category ");
            Console.WriteLine();
            if (WebbShopAPI.AddCategory(2, "Test category"))
            {
                Console.WriteLine("Category created");
            }
            else
            {
                Console.WriteLine("Error");
            }
            Continue();
        }

        /// <summary>
        /// Login as admin
        /// </summary>
        private static void LoginAsAdmin()
        {
            Console.WriteLine("TEST: Login as an admin ");
            Console.WriteLine();
            if (WebbShopAPI.Login("CodicRulez", "Codic2021") != 0)
            {
                Console.WriteLine("You are logged in as an admin CodicRulez");
            }
            else
            {
                Console.WriteLine("Error: you can't loggin");
            }
            Continue();
        }

        /// <summary>
        /// Buy a book
        /// </summary>
        /// <param name="bookId"></param>
        private static void BuyBook(int bookId)
        {
            Console.WriteLine("TEST: Buy book");
            Console.WriteLine();
            int userId = 1;
            if (WebbShopAPI.BuyBook(userId, bookId))
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Error");
            }
            Continue();
        }

        /// <summary>
        /// Get amount 
        /// </summary>
        /// <param name="id"></param>
        private static void GetAmount(int id)
        {
            Console.WriteLine($"TEST: Get amount by id {id}");
            Console.WriteLine();
            var book = WebbShopAPI.GetBook(1, id);
            Console.WriteLine($"{book.Name} - {book.Amount}st");
            Continue();
        }

        /// <summary>
        /// Get book info with keyword
        /// </summary>
        /// <param name="v"></param>
        private static void GetBook(string v)
        {
            Console.WriteLine($"TEST: List books contains {v}");
            Console.WriteLine();
            var books = WebbShopAPI.GetBooks(1, v);
            foreach (var b in books)
            {
                Console.WriteLine(b.Name);
            }
            Continue();
        }
        /// <summary>
        /// get horrors book
        /// </summary>
        private static void GetHorrorsBooks()
        {
            Console.WriteLine("TEST: List horror books");
            Console.WriteLine();
            var books = WebbShopAPI.GetCategory(1, 1);
            foreach (var b in books)
            {
                Console.WriteLine(b.Name);
            }
            Continue();
        }

        /// <summary>
        /// get categories
        /// </summary>
        private static void GetCategories()
        {
            Console.WriteLine("TEST: List all categories");
            Console.WriteLine();
            var categories = WebbShopAPI.GetCategories();
            foreach (var c in categories)
            {
                Console.WriteLine(c.Name);
            }
            Continue();
        }

        /// <summary>
        /// ask user to press enter to continue
        /// </summary>
        private static void Continue()
        {
            Console.WriteLine();
            Console.WriteLine("Press ENTER to continue ...");
            Console.ReadLine();
            Console.Clear();
        }

        /// <summary>
        /// login as a test user
        /// </summary>
        private static void LogInAsTestUser()
        {
            Console.WriteLine("TEST: Login as a test user Codic2021");
            Console.WriteLine();
            if (WebbShopAPI.Login("Codic2021", "Codic2021") != 0)
            {
                Console.WriteLine("You are logged in as test user Codic2021;");
            }
            else
            {
                Console.WriteLine("Error: you can't loggin");
            }
            Continue();
        }
    }
}
