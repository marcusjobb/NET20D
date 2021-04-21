using System;

namespace WebshopApi.Helpers
{
    public static class Tester
    {
        /// <summary>
        /// Testar ett urval av metoder från klassen WebbShoppAPI och skriver ut resultatet i consolen
        /// </summary>
        public static void Test()
        {
            WebbShopAPI api = new WebbShopAPI();

            int userID = 0, categoryID = 0, bookID = 0;

            userID = api.Login("TestClient", "Codic2021");
            Console.WriteLine($"(1). Logging in user with UserID {userID}");

            Console.WriteLine("----------");

            Console.WriteLine("(2). Getting book categories");
            foreach (var b in api.GetCategories())
            {
                Console.WriteLine(" " + b.Name);
            }

            Console.WriteLine("----------");

            Console.WriteLine("(3). Getting category 'Horror'");

            foreach (var b in api.GetCategories("Horror"))
            {
                Console.WriteLine(" " + b.Name);
                categoryID = b.ID;
            }

            Console.WriteLine("----------");

            Console.WriteLine("(4). Getting books with category 'Horror'");

            foreach (var b in api.GetCategory(categoryID))
            {
                Console.WriteLine(" " + b.Title);
            }

            Console.WriteLine("----------");

            Console.WriteLine("(5). Getting book 'Doctor Sleep'");
            foreach (var b in api.GetBooks("Doctor Sleep"))
            {
                Console.WriteLine($"  Title:{b.Title} Amount:{b.Amount}");
                bookID = b.ID;
            }

            Console.WriteLine("----------");
            Console.WriteLine("(6). Buying book 'Doctor Sleep'");

            if (api.BuyBook(userID, bookID))
            {
                Console.WriteLine(" book brought sucessfully");
            }

            Console.WriteLine("----------");

            Console.WriteLine("(7). Controlling available books:");
            foreach (var b in api.GetAvailableBooks())
            {
                Console.WriteLine($"  Title: {b.Title} Amount:{b.Amount}");
            }

            Console.WriteLine("----------");

            userID = api.Login("Administrator", "CodicRulez");
            Console.WriteLine($"(8). Logging in user with UserID {userID} (thats admin bruh)");

            Console.WriteLine("----------");
            Console.WriteLine("(9). Adding category");

            if (api.AddCategory(userID, "DavidRulez"))
            {
                Console.WriteLine(" Category 'DavidRulez is added");
            }

            foreach (var b in api.GetCategories("DavidRulez")) // getting CategoryID
            {
                categoryID = b.ID;
            }

            foreach (var b in api.GetBooks("The Shinning")) // getting bookID
            {
                bookID = b.ID;
            }

            Console.WriteLine("----------");
            Console.WriteLine("(10). Adding book to category:");

            if (api.AddBookToCategory(userID, bookID, categoryID))
            {
                Console.WriteLine($" BookID {bookID} added to CategoryID {categoryID}");
            }

            Console.WriteLine("----------");
            Console.WriteLine("(11). Creating new user:");

            if (api.AddUser(userID, "user2", "123"))
            {
                Console.WriteLine(" User: user2 was added");
            }

            Console.WriteLine("----------");
            Console.WriteLine($"(12). Money earned is {api.MoneyEarned(userID)}");

            Console.WriteLine("----------");
            Console.WriteLine($"(13). Best Customer is customerID: {api.BestCustomer(userID)}");
        }
    }
}