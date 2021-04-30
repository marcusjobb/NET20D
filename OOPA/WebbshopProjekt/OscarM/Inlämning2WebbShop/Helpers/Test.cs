using Inlämning2WebbShop.Models;
using System;
using System.Collections.Generic;

namespace Inlämning2WebbShop.Helpers
{
    internal static class Test
    {
        private static WebbShopAPI api = new WebbShopAPI();

        /// <summary>
        /// testar alla metoder i WebShopAPI klassen.
        /// </summary>
        public static void TestApiMethods()
        {
            PrintTextInBlue("Hämtar alla kategorier:");
            var listOfCategorys = api.GetCategories();
            PrintListIfNotEmpty(listOfCategorys);
            PrintAsterics();

            PrintTextInBlue("Hämtar alla kategorier på sökordet(Sci)");
            listOfCategorys = api.GetCategories("Sci");
            PrintListIfNotEmpty(listOfCategorys);
            PrintAsterics();

            PrintTextInBlue("Hämtar Böcker baserat på Kategori(Horror)");
            var books = api.GetCategory(2);
            PrintListIfNotEmpty(books);
            PrintAsterics();

            PrintTextInBlue("Hämtar skräckböcker som har amount > 1");
            var availableBooks = api.GetAvailableBooks(2);
            PrintListIfNotEmpty(availableBooks);
            PrintAsterics();

            PrintTextInBlue("Hämtar boken The Shining");
            var book = api.GetBook(3);
            CheckIfNull(book);
            PrintAsterics();

            PrintTextInBlue("Hämtar böcker baserat på sökordet (The)");
            books = api.GetBooks("The");
            PrintListIfNotEmpty(books);
            PrintAsterics();

            PrintTextInBlue("Hämtar alla böcker skrivna av Stephen King");
            var booksByAuthor = api.GetAuthors("Stephen King");
            PrintListIfNotEmpty(booksByAuthor);
            PrintAsterics();

            PrintTextInBlue("Registrerar användare (Homer Simpson)");
            Console.WriteLine(api.Register("Homer Simpson", "123", "123"));
            PrintAsterics();

            PrintTextInBlue("Loggar in användare (Homer Simpson)");
            Console.WriteLine(api.Login("Homer Simpson", "123"));
            PrintAsterics();

            PrintTextInBlue("Lägger till en ny bok (The Wolf of Wallstreet) och en befintlig bok (The shining)");
            api.Login("Administrator", "CodicRulez");
            Console.WriteLine(api.AddBook(1, 0, "The Wolf of Wallstreet", "Jordan Belfort", 199, 5));
            Console.WriteLine(api.AddBook(1, 3, "", "", 0, 0));
            PrintTextInYellow(api.Ping(1));
            PrintAsterics();

            PrintTextInBlue("Lägger till genren Humor till boken The Wolf of Wallstreet");
            Console.WriteLine(api.AddBookToCategory(1, 5, 1));
            PrintAsterics();

            PrintTextInBlue("Köper bok (The Wolf of Wallstreet) till Homer Simpson)");
            api.Login("Homer Simpson", "123");
            Console.WriteLine(api.BuyBook(3, 5));
            PrintTextInYellow(api.Ping(3));
            PrintAsterics();

            PrintTextInBlue("Sätter amount på boken I Robot till 10");
            api.SetAmount(1, 1, 10);
            Console.WriteLine(api.GetBook(1));
            PrintTextInYellow(api.Ping(1));
            PrintAsterics();

            PrintTextInBlue("Listar alla användare");
            var userList = api.ListUsers(1);
            PrintListIfNotEmpty(userList);
            PrintAsterics();

            PrintTextInBlue("Söker användare på sökord");
            userList = api.FindUsers(1, "Homer Simpson");
            PrintListIfNotEmpty(userList);
            PrintAsterics();

            PrintTextInBlue("Ändrar boken Doktor Sleep till Harry potter");
            Console.WriteLine(api.UpdateBook(1, 2, "Harry Potter", "JK Rowling", 299));
            PrintTextInYellow(api.Ping(1));
            PrintAsterics();

            PrintTextInBlue("Tar bort en bok Cabal");
            Console.WriteLine(api.DeleteBook(1, 4));
            PrintAsterics();

            PrintTextInBlue("Lägger till kategorin Dystopi");
            Console.WriteLine(api.AddCategory(1, "Dystopi"));
            PrintAsterics();

            PrintTextInBlue("Updaterar Kategorin Humor till Biografi");
            Console.WriteLine(api.UpdateCategory(1, 1, "Biografi"));
            PrintTextInYellow(api.Ping(1));
            PrintAsterics();

            PrintTextInBlue("Tar bort kategorin Romance, och testar att ta bort kategorin Skräck");
            Console.WriteLine(api.DeleteCategory(1, 4));
            Console.WriteLine(api.DeleteCategory(1, 2));
            PrintAsterics();

            PrintTextInBlue("Skapar två nya användare (Peter Griffin(eget lösenord)) och (Sven Svensson (default lösen))");
            Console.WriteLine(api.AddUser(1, "Peter Griffin", "99"));
            Console.WriteLine(api.AddUser(1, "Sven Svensson"));
            PrintAsterics();

            PrintTextInBlue("Skriver ut alla böcker som har blivit sålda");
            var listOfSoldBooks = api.SoldItems(1);
            PrintListIfNotEmpty(listOfSoldBooks);
            PrintTextInYellow(api.Ping(1));
            PrintAsterics();

            PrintTextInBlue("Skriver ut hur mycket pengar webbshoppen har tjänat");
            Console.WriteLine(api.MoneyEarned(1));
            PrintAsterics();

            PrintTextInBlue("Skriver ut den användare som handlat mest böcker");
            var user = api.BestCustomer(1);
            CheckIfNull(user);
            PrintAsterics();

            PrintTextInBlue("Uppgraderar användaren Homer Simpson till Admin");
            Console.WriteLine(api.Promote(1, 3));
            PrintTextInYellow(api.Ping(1));
            PrintAsterics();

            PrintTextInBlue("Nedgraderar användaren Homer Simpson från Admin");
            Console.WriteLine(api.Demote(1, 3));
            PrintAsterics();

            PrintTextInBlue("Inaktiverar användaren Sven Svensson");
            Console.WriteLine(api.InactivateUser(1, 5));
            PrintAsterics();

            PrintTextInBlue("Aktiverar användaren Sven Svensson");
            Console.WriteLine(api.ActivateUser(1, 5));
            PrintTextInYellow(api.Ping(1));
            PrintAsterics();

            PrintTextInBlue("Loggar ut Administrator");
            api.Logout(1);
            PrintAsterics();
        }

        /// <summary>
        /// kollar om en bok är null och skriver isåfall ut ett meddelande att boken inte finns,
        /// annars skrivs boken ut.
        /// </summary>
        /// <param name="book"></param>
        private static void CheckIfNull(Book book)
        {
            if (book == null)
            {
                PrintTextInRed("No book was found!");
            }
            else if (book != null)
            {
                Console.WriteLine(book);
            }
        }

        /// <summary>
        /// kollar om en user är null och skriver isåfall ut ett meddelande att usern inte finns,
        /// annars skrivs usern ut.
        /// </summary>
        /// <param name="book"></param>
        private static void CheckIfNull(User user)
        {
            if (user == null)
            {
                PrintTextInRed("No user was found!");
            }
            else if (user != null)
            {
                Console.WriteLine(user);
            }
        }

        /// <summary>
        /// skriver ut en string i blå färg.
        /// </summary>
        /// <param name="text"></param>
        private static void PrintTextInBlue(string text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Skriver ut en string i röd färg
        /// </summary>
        /// <param name="text"></param>
        private static void PrintTextInRed(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// skriver ut en string i gul färg
        /// </summary>
        /// <param name="text"></param>
        private static void PrintTextInYellow(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// skriver ut några *
        /// </summary>
        private static void PrintAsterics()
        {
            Console.WriteLine("* * * * * * * * * * * * * * ");
        }

        /// <summary>
        /// skriver ut användarna i en användarlista ifall inte listan är tom.
        /// är listan tom skrivs ett meddelande att inga användare hittas.
        /// </summary>
        /// <param name="userList"></param>
        private static void PrintListIfNotEmpty(List<User> userList)
        {
            if (userList.Count > 0)
            {
                foreach (var user in userList)
                {
                    Console.WriteLine(user);
                }
            }
            else
            {
                PrintTextInRed("Inga användare hittade!");
            }
        }

        /// <summary>
        /// skriver ut böckerna i en boklista ifall inte listan är tom.
        /// är listan tom skrivs ett meddelande att inga böcker hittas.
        /// </summary>
        private static void PrintListIfNotEmpty(List<Book> bookList)
        {
            if (bookList.Count > 0)
            {
                foreach (var book in bookList)
                {
                    Console.WriteLine(book);
                }
            }
            else
            {
                PrintTextInRed("Inga böcker hittade!");
            }
        }

        /// <summary>
        /// skriver ut kategorierna i en kategorilista ifall inte listan är tom.
        /// är listan tom skrivs ett meddelande att inga kategorier hittas.
        /// </summary>
        private static void PrintListIfNotEmpty(List<BookCategory> categoryList)
        {
            if (categoryList.Count > 0)
            {
                foreach (var category in categoryList)
                {
                    Console.WriteLine(category);
                }
            }
            else
            {
                PrintTextInRed("Inga kategorier hittade!");
            }
        }

        /// <summary>
        /// skriver ut de sålda böckerna ifrån en SoldBooks lista ifall inte listan är tom.
        /// är listan tom skrivs ett meddelande att inga sålda böcker hittas.
        /// </summary>
        private static void PrintListIfNotEmpty(List<SoldBook> soldBooks)
        {
            if (soldBooks.Count > 0)
            {
                foreach (var book in soldBooks)
                {
                    Console.WriteLine(book);
                }
            }
            else
            {
                PrintTextInRed("Inga sålda böcker hittade!");
            }
        }
    }
}