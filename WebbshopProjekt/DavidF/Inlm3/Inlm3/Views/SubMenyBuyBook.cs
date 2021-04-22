using Inlm3.Controllers;
using Inlm3.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using WebshopApi.Models;

namespace Inlm3.Views
{
    /// <summary>
    /// Klass som hanterar subMenyn som hanterar visandet för att sälja böcker mm.
    /// </summary>
    internal class SubMenyBuyBook
    {
        private Controller controll = new Controller();

        /// <summary>
        /// Index för denna submeny
        /// </summary>
        public void Index(int userID)
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                Console.WriteLine("1. Get categories");
                Console.WriteLine("2. Serach category with keyword");
                Console.WriteLine("3. Get books with category");
                Console.WriteLine("4. Get Available Books");
                Console.WriteLine("5. Information about a book");
                Console.WriteLine("6. Serach books with keyword in title");
                Console.WriteLine("7. Serach books with keyword in author");
                Console.WriteLine("8. Buy book");
                Console.WriteLine("9. Main Meny");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        GetCategories();
                        Helper.NextStep();
                        break;

                    case "2":
                        GetCategoriesSerach();
                        Helper.NextStep();
                        break;

                    case "3":
                        GetBooksCategory();
                        Helper.NextStep();
                        break;

                    case "4":
                        GetAvailableBooks();
                        Helper.NextStep();
                        break;

                    case "5":
                        GetBook();
                        Helper.NextStep();
                        break;

                    case "6":
                        GetBooks();
                        Helper.NextStep();
                        break;

                    case "7":
                        GetAuthors();
                        Helper.NextStep();
                        break;

                    case "8":
                        BuyBook(userID);
                        Helper.NextStep();
                        break;

                    case "9":
                        keepGoing = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Listar alla kategorier
        /// </summary>
        public void GetCategories()
        {
            foreach (var c in controll.GetCategories())
            {
                Console.WriteLine(c.Name + " " + c.ID);
            }
        }

        /// <summary>
        /// Listar alla kategorier utifrån sökning
        /// </summary>
        public void GetCategoriesSerach()
        {
            Console.Write("Please enter your keyword: ");

            IEnumerable<Category> list = controll.GetCategoriesSearch();

            if (list.Count() != 0)
            {
                foreach (var c in list)
                {
                    Console.WriteLine($"Name: {c.Name} id: {c.ID}");
                }
            }
            else
            {
                Console.WriteLine("No results where found with this keyword, please try again");
            }
        }

        /// <summary>
        /// Listar alla böcker utifrån kategoriID
        /// </summary>
        public void GetBooksCategory()
        {
            Console.Write("Please enter your categoryID: ");

            IEnumerable<Book> list = controll.GetCategory();

            if (list.Count() != 0)
            {
                foreach (var b in list)
                {
                    Console.WriteLine($"{b.Title} {b.Author} amount: {b.Amount}");
                }
            }
            else
            {
                Console.WriteLine("No results where found with this ID, please try again");
            }
        }

        /// <summary>
        /// Listar alla tillgängliga böcker
        /// </summary>
        public void GetAvailableBooks()
        {
            Console.WriteLine("These books are available: ");
            foreach (var b in controll.GetAvailableBooks())
            {
                Console.WriteLine($"Title: {b.Title} amount: {b.Amount} ID: {b.ID}");
            }
        }

        /// <summary>
        /// visar en bok baserat på bookID
        /// </summary>
        public void GetBook()
        {
            Console.Write("Please enter the bookID: ");

            IEnumerable<Book> list = controll.GetBook();

            if (list.Count() != 0)
            {
                foreach (var b in list)
                {
                    Console.WriteLine($"Title: {b.Title}");
                    Console.WriteLine($"Author: {b.Author}");
                    Console.WriteLine($"Category: {b.Category}");
                    Console.WriteLine($"Price: {b.Price}");
                    Console.WriteLine($"Amount: {b.Amount}");
                    Console.WriteLine($"ID: {b.ID}");
                }
            }
            else
            {
                Console.WriteLine("No results where found with this ID, please try again");
            }
        }

        /// <summary>
        /// Visar böcker baserat på sökning i titel
        /// </summary>
        public void GetBooks()
        {
            Console.WriteLine("Please enter your keyword: ");

            var list = controll.GetBooks();
            if(list.Count() != 0)
            {
                foreach (var b in list)
                {
                    Console.WriteLine($"Title: {b.Title} ID: {b.ID}");
                }
            }
            else
            {
                Console.WriteLine("Something went wrong, please try again");
            }


        }

        /// <summary>
        /// Visar böcker baserat på sökning i förtfattare
        /// </summary>
        public void GetAuthors()
        {
            Console.WriteLine("Please enter your keyword: ");

            var list = controll.GetBooks();
            if (list.Count() != 0)
            {

            

            foreach (var b in list)
            {
                Console.WriteLine($"Title: {b.Title} Author: {b.Author} ID: {b.ID}");
            }
            }
            else
            {
                Console.WriteLine("something went wrong, please try again");
            }
        }

        /// <summary>
        /// Köper en bok.
        /// </summary>
        public void BuyBook(int userID)
        {
            Console.WriteLine("Please enter the bookID for the book you want to buy.");
            Console.Write("BookID: ");
            if (controll.BuyBook(userID))
            {
                Console.WriteLine("Book sucessfully brought!");
            }
            else
            {
                Console.WriteLine("Something went wrong, please try again");
            }
        }

        /// <summary>
        /// Lägger till en bok.
        /// </summary>
        public void AddBook(int userID)
        {
            Console.WriteLine("Please write the information below to add a book");

            if (controll.AddBook(userID))
            {
                Console.WriteLine("The book was sucessfully added");
            }
            else
            {
                Console.WriteLine("Something went wrong, please try again");
            }
        }

        /// <summary>
        /// Sätter antalet böcker på en bok baserat på bookID.
        /// </summary>
        public void SetAmount(int userID)
        {
            Console.WriteLine("Please write the bookID and amount:");
            if (controll.SetAmount(userID))
            {
                Console.WriteLine("Amount sucessfully set");
            }
            else
            {
                Console.WriteLine("Something went wrong, please try again");
            }
        }

        /// <summary>
        /// Updaterar en bok.
        /// </summary>
        public void UpdateBook(int userID)
        {
            Console.WriteLine("Please write the information below to update a book");

            if (controll.AddBook(userID))
            {
                Console.WriteLine("The book was sucessfully updated");
            }
            else
            {
                Console.WriteLine("Something went wrong, please try again");
            }
        }

        /// <summary>
        /// Raderar en bok
        /// </summary>
        public void DeleteBook(int userID)
        {
            Console.WriteLine("Please write the information below to delete a book");

            if (controll.DeleteBook(userID))
            {
                Console.WriteLine("The book was sucessfully deleted");
            }
            else
            {
                Console.WriteLine("Something went wrong, please try again");
            }
        }

        /// <summary>
        /// Lägger till en ny kategori
        /// </summary>
        public void AddCategory(int userID)
        {
            Console.WriteLine("Please write the information below to add a category");
            if (controll.AddCategory(userID))
            {
                Console.WriteLine("The category was sucessfully added!");
            }
            else
            {
                Console.WriteLine("Something went wrong, please try again");
            }
        }

        /// <summary>
        /// Lägger till en bok till en kategori
        /// </summary>
        public void AddBookToCategory(int userID)
        {
            Console.WriteLine("Please write the information below to add a book to category");
            if (controll.AddBookToCategory(userID))
            {
                Console.WriteLine("The book was sucessfully added!");
            }
            else
            {
                Console.WriteLine("Something went wrong, please try again");
            }
        }

        /// <summary>
        /// Updaterar en kategori
        /// </summary>
        public void UpdateCategory(int userID)
        {
            Console.WriteLine("Please enter the information below to update a category");

            if (controll.UpdateCategory(userID))
            {
                Console.WriteLine("Category was sucessfully updated!");
            }
            else
            {
                Console.WriteLine("Something went wrong, please try again!");
            }
        }

        /// <summary>
        /// Raderar en kategori
        /// </summary>
        public void DeleteCategory(int userID)
        {
            Console.WriteLine("Please write the information below too delete a category");
            if (controll.DeleteCategory(userID))
            {
                Console.WriteLine("The category was sucessfully deleted!");
            }
            else
            {
                Console.WriteLine("Something went wrong, please try again");
            }
        }

        /// <summary>
        /// Visar sålda items
        /// </summary>
        public void SoldItems(int userID)
        {
            Console.WriteLine("These are all the sold books");
            var list = controll.SoldItems(userID);

            if (list.Count() != 0)
            {
                foreach (var b in list)
                {
                    Console.WriteLine($"Title: {b.Title} Date purchased:{b.PurchasedDate}");
                }
            }
            else
            {
                Console.WriteLine("something went wrong, please try again");
            }
        }
    }
}