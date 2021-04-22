//using System;
//using System.Collections.Generic;
//using System.Text;
//using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
//using WebbShopJesperPersson.Model;

//namespace WebbShopJesperPersson.TestUsers
//{
//    class TestCustomer
//    {
//        public static void Run()
//        {
//            /*Exempel 1:
//            1. Logga in Testuser
//            2. Fråga efter kategorier
//            3. Välj kategori Horror
//            4. Lista böcker i kategorin
//            5. Välj boken Dr Sleep
//            6. Hur många finns tillgängliga?
//            7. Köp bok
//            8. Kontrollera antal böcker som finns tillgängliga
//             */
//            Console.WriteLine("Välkommen till TestCustommer!\n Var god tryck enter efter varje testuppgift");

//            //1
//            var userId = WebbShopAPI.Login("TestCustomer", "Codic2021");
//            Console.WriteLine("1 Logga in.");
//            if(userId == 2)
//            Console.WriteLine($"Inloggingen Lyckades");
//            else
//            Console.WriteLine("Du kunde inte logga in.");

//            //2

//            var categories = WebbShopAPI.GetCategories();
//            Console.WriteLine("\n2. Fråga efter kategori.\nFöljande kategorier finns i databasen: ");
//            foreach (var category in categories)
//                Console.WriteLine(category.Name);

//            Console.WriteLine(WebbShopAPI.Ping(userId));
//            Console.ReadLine();

//            //3
//            categories = WebbShopAPI.GetCategories("Horror");
//            Console.WriteLine("\n3. Sök upp kategorin Horror.");
//            foreach (var category in categories)
//            Console.WriteLine("Printar således ut kategorin: " + category.Name);

//            if(WebbShopAPI.Ping(userId)!=string.Empty)
//                Console.WriteLine(WebbShopAPI.Ping(userId));

//            Console.ReadLine();

//            //4
//            var books = WebbShopAPI.GetCategory(categories[0].Id);
//            Console.WriteLine($"\n4. Lista böckerna i katergorin. Följande böcker tillhör kategorin {categories[0].Name}");
//            foreach (var book in books)
//                Console.WriteLine(book.Title);

//            Console.WriteLine(WebbShopAPI.Ping(userId));
//            Console.ReadLine();

//            //5 + 6
//            books = WebbShopAPI.GetBooks("Doctor Sleep");
//            Console.WriteLine(@"5. Sök efter boken Doctor Sleep.
//6. Visa antal tillgänliga.

//I min kod löser jag den uppgiften på två olika vis och printar ut båda");

//            foreach (var book in books)
//                Console.WriteLine($@"
//Titel: {book.Title}
//Författare: {book.Author}
//Kategori: {book.Category.Name}
//Pris: {book.Price}
//Antal: {book.Amount}");

//            // Alternativt om jag vet om bokens ID
//            var myBook = WebbShopAPI.GetBook(3);
//            Console.WriteLine($@"
//Titel: {myBook.Title}
//Författare: {myBook.Author}
//Kategori: {myBook.Category.Name}
//Pris: {myBook.Price}
//Antal: {myBook.Amount}");

//            Console.WriteLine(WebbShopAPI.Ping(userId));
//            Console.ReadLine();

//            //7.Köp bok
//            Console.WriteLine("\n7. Köp en bok");
//            var myBool = WebbShopAPI.BuyBook(userId, 4);
//            if (myBool)
//            {
//                Console.WriteLine($"Du har nu köpt {myBook.Title} för {myBook.Price} kr.");
//            }
//            else Console.WriteLine($"Köpet gick tyvärr inte igenom. Det kan bero på att lagersaldot är slut. Antal: {myBook.Amount}");

//            Console.WriteLine(WebbShopAPI.Ping(userId));
//            Console.ReadLine();

//            //8.Kontrollera antal böcker som finns tillgängliga
//            Console.WriteLine("\n8. Visa alla tillgänliga böcker.");
//            var newbooksList = new List<Book>();
//            categories = WebbShopAPI.GetCategories();
//            foreach (var category in categories)
//            {
//                newbooksList.AddRange(new List<Book>(WebbShopAPI.GetAvailableBooks(category.Id)));
//            }

//            foreach (var book in newbooksList)
//                Console.WriteLine($"{book.Title}. Antal: {book.Amount} på lager");

//            Console.WriteLine(WebbShopAPI.Ping(userId));
//            Console.ReadLine();

//            WebbShopAPI.LogOut(userId);

//            Console.WriteLine("Test Customer är nu färdigtestat och vi går vidare till admin");
//            Console.ReadLine();
//            Console.Clear();

//        }
//    }
//}