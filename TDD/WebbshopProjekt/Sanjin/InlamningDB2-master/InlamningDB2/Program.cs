using InlamningDB2.Database;
using System;

namespace InlamningDB2
{
    internal static class Program
    {
       internal static void Main()
        {
            
            Seeder.Seed();

            var webbshop = new WebbShopAPI();
            Console.WriteLine("Loggar in Admin");
            int adminId = webbshop.Login("Administrator", "CodicRulez");
            Console.WriteLine("ID = " + adminId);
            Console.WriteLine("-------------------------");

            var list = webbshop.GetCategories();
            Console.WriteLine("Listar alla kategorier");
            foreach (var category in list)
            {

              Console.WriteLine($"{category.Name}");

            }
            Console.WriteLine("-------------------------");

            var listOfComedy = webbshop.GetCategories("com");
            Console.WriteLine("Listar komedi katergori efter sökning");
            foreach (var comedy in listOfComedy)
            {

                Console.WriteLine($"{comedy.Name}");

            }
            Console.WriteLine("-------------------------");

            var listOfGenre = webbshop.GetCategory(1);
            Console.WriteLine("Listar alla skräckböcker");
            foreach (var genere in listOfGenre)
            {

                Console.WriteLine($"{genere.Titel}");
            }
            Console.WriteLine("-------------------------");

            var listOfBooks = webbshop.GetAvailableBooks(3);
            Console.WriteLine("Listar alla tillgängliga sicion-fiction böcker baserat på vad man väljer för ID");
            foreach (var book in listOfBooks)
            {

                Console.WriteLine($"{book.Titel}");
            }
            Console.WriteLine("-------------------------");

            var boook = webbshop.GetBook(2);
            Console.WriteLine("Listar bok efter ID");

            Console.WriteLine($"{boook.Titel}");
            Console.WriteLine("-------------------------");

            listOfBooks = webbshop.GetBooks("Robot");
            Console.WriteLine("Listar bok efter sökord");
            foreach (var book in listOfBooks)
            {

                Console.WriteLine($"{book.Titel}");

            }
            Console.WriteLine("-------------------------");

            listOfBooks = webbshop.GetAuthors("Stephen King");
            Console.WriteLine("Listar bok efter författare");
            foreach (var book in listOfBooks)
            {

                Console.WriteLine($"{book.Titel} {book.Author}");

            }
            Console.WriteLine("-------------------------");

            webbshop.Login("Administrator", "CodicRulez");
            bool trueOrFalse = webbshop.BuyBook(adminId, 2);
            Console.WriteLine("Köper boken Doctor Sleep ");
            Console.WriteLine(trueOrFalse);
            Console.WriteLine("-------------------------");

            trueOrFalse = webbshop.Register("Sanjin","123","123"); // ändra andvändare för att se om det funkar!
            Console.WriteLine("Skapar en andvändare");
            Console.WriteLine(trueOrFalse);
            Console.WriteLine("-------------------------");

            trueOrFalse = webbshop.Addbook(adminId, 7, "SanjinsBok", "Sanjin", 2000, 2);
            Console.WriteLine("Lägger till en bok");
            Console.WriteLine(trueOrFalse);
            Console.WriteLine("-------------------------");

            webbshop.SetAmount(adminId, 2, 5);
            Console.WriteLine("Ändrar antalet tillgängliga böcker");
            Console.WriteLine("-------------------------");


            var listOfUsers = webbshop.ListUsers(adminId);
            Console.WriteLine("Listar alla andvädare");
            foreach (var users in listOfUsers)
            {

                Console.WriteLine($"{users.Name}");

            }
            Console.WriteLine("-------------------------");

            var findUsers = webbshop.FindUsers(adminId,"sa" );
            Console.WriteLine("Listar andvädare efter input");
            foreach (var users in findUsers)
            {

                Console.WriteLine($"{users.Name}");

            }
            Console.WriteLine("-------------------------");

            trueOrFalse = webbshop.UpdateBook(adminId,3,"The Shinng","Stephen King",20000); // kollar om den finns och ändrar priset från 200 - 20.000 
            Console.WriteLine("Ändrar priset på bok");
            Console.WriteLine(trueOrFalse);
            Console.WriteLine("-------------------------");

            trueOrFalse = webbshop.Deletebook(adminId,1); 
            Console.WriteLine("Minskar amount med 1");
            Console.WriteLine(trueOrFalse);
            Console.WriteLine("-------------------------");

            trueOrFalse = webbshop.AddCategory(adminId, "Documentary");
            Console.WriteLine("Lägg till en kategori som inte finns");
            Console.WriteLine(trueOrFalse);
            Console.WriteLine("-------------------------");

            trueOrFalse = webbshop.AddBookToCategory(adminId,4,3);
            Console.WriteLine("Ändrar Cabal till Science Fiction kategorin ");
            Console.WriteLine(trueOrFalse);
            Console.WriteLine("-------------------------");

            trueOrFalse = webbshop.UpdateCategory(adminId,1,"Sport"); /// ändra till något som inte finns
            Console.WriteLine("Ändrar namn på kategori");
            Console.WriteLine(trueOrFalse);
            Console.WriteLine("-------------------------");

            Console.WriteLine(webbshop.Ping(adminId));
            Console.WriteLine("-------------------------");

            trueOrFalse = webbshop.DeleteCategory(adminId, 6); 
            Console.WriteLine("Tar bort Documentary"); // Endast om ingen bok är koppad till den
            Console.WriteLine(trueOrFalse);
            Console.WriteLine("-------------------------");

            trueOrFalse = webbshop.AddUser(adminId, "Madrid", "");
            Console.WriteLine("Testar och lägga till user utan password");
            Console.WriteLine(trueOrFalse);

            trueOrFalse = webbshop.AddUser(adminId, "Madrid", "real");
            Console.WriteLine("Testar att lägga till user med password");
            Console.WriteLine(trueOrFalse);
            Console.WriteLine("-------------------------");

            Console.WriteLine("Loggar ut admin");
            webbshop.Logout(adminId);
            Console.WriteLine("-------------------------");



















































        }
    }
}
