//using System;
//using System.Collections.Generic;
//using System.Text;
//using Microsoft.Data.SqlClient.Server;

//namespace WebbShopJesperPersson.TestUsers
//{
//    class TestAdmin
//    {
//        public static void Run()
//        {
//            /* Exempel 2:
//           1. Logga in som Admin
//           2. Skapa kategori
//           3. Flytta en bok dit
//           4. logga ut.
//           */
//            Console.WriteLine("Här kommer Admin-user att testas. Var god tryck enter efter varje testuppgift");
//            Console.WriteLine("Exempel 2:");
//            //1.
//            Console.WriteLine("1.");
//            var adminId = WebbShopAPI.Login("Administrator", "CodicRulez");
//            if(adminId == 1)
//            Console.WriteLine($"Inloggning fungerade\n");
//            else Console.WriteLine("Det fungerade inte att logga in");

//            Console.ReadLine();

//            //2
//            Console.WriteLine("2. Skapa en kategori: ");

//            if (WebbShopAPIAdmin.AddCategory(adminId,"Drama"))
//                Console.WriteLine("Kategorin Drama är nu skapat");

//            else Console.WriteLine("Kategorin kunde ej skapas. Det kan vara så att den redan finns. Titta i databas.");

//            Console.WriteLine(WebbShopAPI.Ping(adminId) + "\n");
//            Console.ReadLine();

//            //3.
//            bool myBool = false;
//            var myCategory = WebbShopAPI.GetCategories("Drama");
//            if (myCategory.Count != 0)
//            {
//                var myBook = WebbShopAPI.GetAvailableBooks(1);
//                if (myBook.Count != 0)
//                    myBool = WebbShopAPIAdmin.AddBookToCategory(adminId, myBook[0].Id, myCategory[0].Id);

//                if (myBool) Console.WriteLine($"{myBook[0].Title} har nu ändrat katergori till {myCategory[0].Name}");
//                else Console.WriteLine($"{ myBook[0].Title} Kunde inte byta kategori");
//            }

//            Console.WriteLine(WebbShopAPI.Ping(adminId) + "\n");
//            Console.ReadLine();

//            //4.
//            WebbShopAPI.LogOut(adminId);
//            Console.WriteLine("Du har loggat ut");
//            Console.ReadLine();
//            Console.Clear();

//            /*
//            Exempel 3:
//            1. Logga in som Admin
//            2. Skapa en användare

//            */

//            // 1.
//            Console.WriteLine("Fortsättning av testAdmin");
//            Console.WriteLine("Exempel 3: ");
//            Console.WriteLine("1. logga in som Admin");

//            adminId = WebbShopAPI.Login("Administrator", "CodicRulez");
//            if (adminId == 1)
//                Console.WriteLine($"Inloggning fungerade\n");
//            else Console.WriteLine("Det fungerade inte att logga in");

//            Console.ReadLine();

//            //2.
//            Console.WriteLine("2. Skapa en användare:");
//            var name = "Jesper";
//            var password = "login123";
//            if (WebbShopAPIAdmin.AddUser(adminId, name, password))
//                Console.WriteLine($"{name} är skapad som ny användare");

//            else
//                Console.WriteLine($"Det fungerande inte det här. {name} kanske redan existerar som användare?");

//            Console.WriteLine(WebbShopAPI.Ping(adminId) + "\n");
//            Console.ReadLine();

//            //3.  Sålda böcker
//            Console.WriteLine("3. Visa sålda böcker:");
//            var list = WebbShopAPIAdmin.SoldItems(adminId);

//            foreach (var book in list)
//            {
//                Console.WriteLine(book.Title + " "+ "- såld");
//            }

//            Console.WriteLine(WebbShopAPI.Ping(adminId) + "\n");
//            Console.ReadLine();

//            // Tjänade pengar
//            Console.WriteLine("4. Visa hur mycket pengar som tjänats:");
//            var money = WebbShopAPIAdmin.MoneyEarned(1);
//            Console.WriteLine($"du har tjänat {money}");
//            Console.WriteLine(WebbShopAPI.Ping(adminId) + "\n");
//            Console.ReadLine();

//            // bästa kunden
//            Console.WriteLine("5. Visa bästa kunden: ");
//            var bestcustommer = WebbShopAPIAdmin.BestCustomer(1);
//            if (bestcustommer != null)
//                Console.WriteLine($"Din bästa kund heter: {bestcustommer.Name}");
//            else Console.WriteLine("Du har inte sålt någon bok och har således ingen bästakund.");

//            Console.WriteLine(WebbShopAPI.Ping(adminId) + "\n");
//            Console.ReadLine();

//            var webbshop = new WebbShopAPI();
//            //Köp en bok
//            Console.WriteLine("6. Köp en bok:");
//            if (WebbShopAPI.BuyBook(adminId, 1))
//            {
//                Console.WriteLine("Grattis till Boken");
//            }
//            else
//                Console.WriteLine("Köpet gick inte igenom. Kollar lagerstatus.");

//            //Loggar ut
//            WebbShopAPI.LogOut(adminId);

//        }
//    }
//}