using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WebShopAssignment;
using WebShopAssignment.Helpers;
using WebShopAssignment.Models;
using WebShopFrontend.View;

namespace WebShopFrontend.Controller
{
    public class UserBook
    {
        public static WebShopAPI api = new WebShopAPI();
        /// <summary>
        /// Sök efter bok
        /// </summary>
        /// <param name="userId"></param>
        public static void SearchForBook(int userId)
        {
            api.Ping(userId);

            Console.WriteLine("Sök efter: ");
            string input = Console.ReadLine();

            var books = api.GetBooks(input);
            foreach (var b in books)
            {
                Console.WriteLine($"Nr: {b.Id}. Titel: {b.Title}");
            }

            if (books.Count == 0)
            {
                Messages.DoesNotExist();
                Console.Clear();
                return;
            }
            else
            {
                Console.WriteLine("Vilken vill du välja?");

                int choice = Convert.ToInt32(Console.ReadLine());
                var book = api.GetBook(choice);

                UserHelper.PrintAllInformation(book);

                Console.WriteLine("Vill du köpa denna?");
                Console.WriteLine("Ja/Nej");
                string answer = Console.ReadLine().ToLower();

                if (answer == "ja" || answer == "j")
                {
                    api.BuyBook(userId, book.Id);
                    Console.WriteLine("Boken är nu köpt.");
                    Thread.Sleep(2000);
                    Console.Clear();

                }

                else if (answer == "nej" || answer == "n")
                {
                    Console.Clear();
                    return;
                }

                else
                {
                    Messages.WrongInput();
                    Console.Clear();
                    return;
                }
            }

        }
        /// <summary>
        /// Skriv ut böcker i en viss kategori
        /// </summary>
        /// <param name="choice"></param>
        /// <param name="userId"></param>
        public static void GetBooksInCategory(int choice, int userId)
        {
            var listOfBooks = api.GetCategory(choice);
            if (listOfBooks.Count == 0)
            {
                Messages.DoesNotExist();
                Console.Clear();
                return;
            }

            Console.WriteLine("Böcker i vald kategori: ");
            foreach (var b in listOfBooks)
            {
                Console.WriteLine($"{b.Id} {b.Title}");
            }

            Console.WriteLine("Vilket bok vill du få mer information om?");
            int input = Convert.ToInt32(Console.ReadLine());

            var book = api.GetBook(input);
            UserHelper.PrintAllInformation(book);

            Console.WriteLine("Vill du köpa denna?");
            Console.WriteLine("Ja/Nej");
            string answer = Console.ReadLine().ToLower();
            if (answer == "ja" || answer == "j")
            {
                api.BuyBook(userId, book.Id);
                Console.WriteLine("Boken är nu köpt.");
                Thread.Sleep(2000);
                Console.Clear();
            }
            else if (answer == "nej" || answer == "n")
            {
                Console.Clear();
                return;
            }
            else
            {
                Console.Clear();
                return;
            }

        }
        /// <summary>
        /// Skriv ut böcker som finns i lager
        /// </summary>
        /// <param name="userId"></param>
        public static void GetBooksInStock(int userId)
        {
            api.Ping(userId);

            Console.WriteLine("Dessa böcker finns i lager: ");
            var books = api.GetAvailableBooks();
            foreach (var b in books)
            {
                Console.WriteLine($"{b.Id} Titel: {b.Title}. Antal: {b.Amount}");
            }

            Console.WriteLine("Vilken vill du kolla på?");
            int input = Convert.ToInt32(Console.ReadLine());
            var book = api.GetBook(input);

            if (book == null)
            {
                Messages.DoesNotExist();
                Console.Clear();
                return;
            }

            UserHelper.PrintAllInformation(book);

            Console.WriteLine("Vill du köpa denna?");
            Console.WriteLine("Ja/Nej");
            string answer = Console.ReadLine().ToLower();

            if (answer == "ja" || answer == "j")
            {
                api.BuyBook(userId, book.Id);
                Console.WriteLine("Boken är nu köpt.");
                Thread.Sleep(2000);
                Console.Clear();
            }
            else if (answer == "nej" || answer == "n")
            {
                Console.Clear();
                return;
            }
            else
            {
                Messages.WrongInput();
                Console.Clear();
                return;
            }

        }
        /// <summary>
        /// Sök böcker från en viss författare
        /// </summary>
        /// <param name="userId"></param>
        public static void GetBooksFromAuthor(int userId)
        {
            api.Ping(userId);

            Console.WriteLine("Sök efter: ");
            string input = Console.ReadLine();
            var authors = api.GetAuthors(input);
            foreach (var a in authors)
            {
                Console.WriteLine($"{a.Id} {a.Title}");
            }

            if (authors.Count == 0)
            {
                Messages.DoesNotExist();
                Console.Clear();
                return;
            }

            Console.WriteLine("Vilken vill du kolla på?");
            int input2 = Convert.ToInt32(Console.ReadLine());
            var book = api.GetBook(input2);
            
            UserHelper.PrintAllInformation(book);

            Console.WriteLine("Vill du köpa denna?");
            Console.WriteLine("Ja/Nej");
            string answer = Console.ReadLine().ToLower();

            if (answer == "ja" || answer == "j")
            {
                api.BuyBook(userId, book.Id);
                Console.WriteLine("Boken är nu köpt.");
                Thread.Sleep(2000);
                Console.Clear();
            }
            else if (answer == "nej" || answer == "n")
            {
                Console.Clear();
                return;
            }
            else
            {
                return;
            }
        }
    }
}
