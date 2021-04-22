using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using WebShopAssignment;
using WebShopAssignment.Helpers;
using WebShopFrontend.Helpers;
using WebShopFrontend.View;

namespace WebShopFrontend.Controller.AdminController
{
    public class AdminBook
    {
        public static WebShopAPI api = new WebShopAPI();
        /// <summary>
        /// anropar metoden som lägger till bok i databasen
        /// </summary>
        /// <param name="adminId"></param>
        public static void AddsBook(int adminId)
        {
            UserHelpers.IsUserActice(adminId);

            Console.WriteLine("Skriv in titeln: ");
            string title = Console.ReadLine();
            Console.WriteLine("Författare: ");
            string author = Console.ReadLine();
            Console.WriteLine("Pris: ");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Antal böcker i lager: ");
            int amount = Convert.ToInt32(Console.ReadLine());

            var added = api.AddBook(adminId, title, author, price, amount);
            if (!added)
            {
                Messages.WrongInput();
                Console.Clear();

                return;
            }
            Console.WriteLine("Tillagd");
            Console.Clear();

        }
        /// <summary>
        /// Sätter nytt antal böcker i lager
        /// </summary>
        /// <param name="adminId"></param>
        public static void SetsAmount(int adminId)
        {

            UserHelpers.IsUserActice(adminId);

            Console.WriteLine("Sök efter bok du vill ändra antal på");
            var list = api.GetAllBooks();
            foreach (var l in list)
            {
                Console.WriteLine($"{l.Id}: {l.Title}");
            }
            int input = Convert.ToInt32(Console.ReadLine());
            var book = api.GetBook(input);

            if (book == null)
            {
                Messages.DoesNotExist();
                Console.Clear();

                return;
            }

            Console.WriteLine("Vilket antal ska det i lager? ");
            try
            {
                int amount = Convert.ToInt32(Console.ReadLine());
                api.SetAmount(adminId, book.Id, amount);
            }
            catch
            {
                Messages.WrongInput();
                Console.Clear();

                return;
            }

        }

        /// <summary>
        /// Uppdaterar informationen om en bok
        /// </summary>
        /// <param name="adminId"></param>
        public static void UpdatesBook(int adminId)
        {
            UserHelpers.IsUserActice(adminId);

            Console.WriteLine("Sök efter boken du vill uppdatera: ");
            string input = Console.ReadLine();
            var books = api.GetBooks(input);
            foreach (var b in books)
            {
                Console.WriteLine($"Nr:{b.Id} Titel:{b.Title}");
            }
            if (books.Count == 0)
            {
                Messages.DoesNotExist();
                Console.Clear();

                return;
            }

            Console.WriteLine("Vilken vill du uppdatera?");
            int choice = Convert.ToInt32(Console.ReadLine());
            var book = api.GetBook(choice);

            Console.WriteLine("Ange titel: ");
            string title = Console.ReadLine();
            Console.WriteLine("Författare: ");
            string author = Console.ReadLine();
            Console.WriteLine("Pris: ");
            int price = Convert.ToInt32(Console.ReadLine());

            var updated = api.UpdateBook(adminId, book.Id, title, author, price);
            if (!updated)
            {
                Messages.WrongInput();
                Console.WriteLine("Du skickas tillbaka till menyn.");
                Thread.Sleep(2000);
                Console.Clear();

                return;
            }

            Console.WriteLine("Uppdaterad.");
            Thread.Sleep(2000);
            Console.Clear();
        }

        /// <summary>
        /// Tar bort en bok som saknar antal i lager
        /// </summary>
        /// <param name="adminId"></param>
        public static void DeleteBook(int adminId)
        {
            
            UserHelpers.IsUserActice(adminId);

            Console.WriteLine("Vilken bok vill du ta bort? ");
            var books = api.GetAllBooks();
            foreach (var b in books)
            {
                Console.WriteLine($"{b.Id} Titel: {b.Title}. Antal: {b.Amount}");
            }

            int input = Convert.ToInt32(Console.ReadLine());
            var book = api.GetBook(input);

            if (book == null)
            {
                Messages.DoesNotExist();
                Console.Clear();

                return;
            }

            var del = api.DeleteBook(adminId, book.Id);

            if (!del)
            {
                Messages.WrongInput();
                Console.Clear();

                return;
            }

            Console.WriteLine("Borttagen.");
            Thread.Sleep(2000);
            Console.Clear();
        }

        /// <summary>
        /// Lägger till kategori på bok
        /// </summary>
        /// <param name="adminId"></param>
        public static void AddCategoryToBook(int adminId)
        {
           
            UserHelpers.IsUserActice(adminId);

            Console.WriteLine("Vilken bok vill du lägga till kategori på? ");
            var books = api.GetAllBooks();
            foreach (var b in books)
            {
                UserHelper.PrintAllInformation(b);

            }

            int bookInput = Convert.ToInt32(Console.ReadLine());
            var book = api.GetBook(bookInput);

            if (book == null)
            {
                Messages.DoesNotExist();
                Console.Clear();

                return;
            }

            Console.WriteLine("Vilken kategori ska denna ha? ");
            var categories = api.GetCategories();
            foreach (var c in categories)
            {
                Console.WriteLine($"{c.Id} {c.Name}");
            }
            int categoryInput = Convert.ToInt32(Console.ReadLine());

            var category = categories.FirstOrDefault(c => c.Id == categoryInput);

            if (category == null)
            {
                Messages.WrongInput();
                Console.Clear();
                return;
            }

            var added = api.AddBookToCategory(adminId, book.Id, category.Id);
            if (!added)
            {
                Messages.WrongInput();
                Console.Clear();
                return;
            }
            Console.WriteLine("Uppdaterad");
            Thread.Sleep(2000);
            Console.Clear();
        }

    }
}
