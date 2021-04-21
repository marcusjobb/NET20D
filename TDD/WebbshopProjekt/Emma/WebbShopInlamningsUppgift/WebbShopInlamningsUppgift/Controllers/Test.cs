using System;

namespace WebbShopInlamningsUppgift.Controllers
{
    /// <summary>
    /// Test allows you to run a test-scenario with an imaginary user
    /// </summary>
    class Test
    {
        /// <summary>
        /// Runs a test-scenario
        /// </summary>
        public static void Run()
        {
            var api = new WebbShopAPI();

            Console.Write("Logged in as: ");
            int userId = api.Login("TestCustomer", "Codic2021");
            Console.WriteLine(userId);

            //---------------------------------------------------

            Console.WriteLine("Searching all categories: ");
            var listOfCategories = api.GetCategories();
            if (listOfCategories.Count > 0)
            {
                foreach (var category in listOfCategories)
                {
                    Console.WriteLine(category.Genere);
                }
            }

            //---------------------------------------------------

            Console.WriteLine("Searching all categories with \"or\"-keyword: ");
            listOfCategories = api.GetCategories("or");
            if (listOfCategories.Count > 0)
            {
                foreach (var category in listOfCategories)
                {
                    Console.WriteLine(category.Genere);
                }
            }

            //---------------------------------------------------

            Console.WriteLine("Searching for all books with category \"Horror\": ");
            var listOfBooks = api.GetCategories(2);
            if (listOfBooks.Count > 0)
            {
                foreach (var book in listOfBooks)
                {
                    Console.WriteLine(book.Title);
                }
            }

            var respons = api.Ping(userId);
            if(respons.Length > 0)
            {
                Console.WriteLine(respons);
            }

            //---------------------------------------------------

            Console.WriteLine("Searching for all available books with category \"Horror\": ");
            var listOfAvailableBooks = api.GetAvailableBooks(2);
            foreach (var book in listOfAvailableBooks)
            {
                Console.WriteLine($"{book.Title}, Amount: {book.Amount}");
            }

            //---------------------------------------------------

            Console.WriteLine("Information around all books with genere \"Horror\"");
            var description = api.GetBook(4);
            Console.WriteLine(description);

            //---------------------------------------------------

            Console.WriteLine("Searching for books matching search word \"shi\"");
            listOfBooks = api.GetBooks("shi");
            foreach (var book in listOfBooks)
            {
                Console.WriteLine(book.Title);
            }

            respons = api.Ping(userId);
            if (respons.Length > 0)
            {
                Console.WriteLine(respons);
            }

            //---------------------------------------------------

            Console.WriteLine("Searching for books matching Author \"Stephen King\"");
            listOfBooks = api.GetAuthor("Stephen King");
            foreach (var book in listOfBooks)
            {
                Console.WriteLine(book.Title);
            }

            //---------------------------------------------------

            Console.WriteLine("Selected book to purchase: \"Doctor Sleep\"");
            var succeed = api.BuyBook(userId, 2);
            if (succeed)
            {
                Console.WriteLine("Purchase made");
            }

            //---------------------------------------------------

            api.Logout(userId);
        }
    }
}
