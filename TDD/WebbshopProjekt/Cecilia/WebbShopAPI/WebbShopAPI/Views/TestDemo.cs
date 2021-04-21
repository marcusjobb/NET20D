using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Text;
using WebbShopAPI.Helpers;

namespace WebbShopAPI.Views
{
    class TestDemo
    {
        public void Demo()
        {
            var seed = new Seeder();
            bool run = true;
            seed.AddData();

            while (run)
            {
                Console.WriteLine("API Demo" +
                "\n1. Exempel - Kund" +
                "\n2. Exempel - Admin" +
                "\n3. Avsluta" +
                "\n------------------------------");

                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        KundDemo();
                        break;

                    case 2:
                        AdminDemo();
                        break;

                    case 3:
                        run = false;
                        break;
                }
            }
        }

        private void KundDemo()
        {
            var api = new WebbshopAPI();
            var hm = new HelperMethods();
            string cName = "TestCustomer5";
            string cPassword = "Codic2021";

            Console.WriteLine($"Kund registrerar sig:" +
                $"\nNamn: {cName}" +
                $" Lösenord: {cPassword}" +
                $"\n");

            if (api.Register(cName, cPassword, cPassword) == true)
                Console.WriteLine("Kund registrerad");
            else
                Console.WriteLine("Något gick fel, testa igen!");

            Console.WriteLine("------------------------------");

            Console.WriteLine($"Inloggning" +
                $"Namn: {cName}" +
                $" Lösenord: {cPassword}" +
                $"\n");

            int customer = api.Login(cName, cPassword);
            if (customer > 0)
                Console.WriteLine("Kund inloggad");
            else
                Console.WriteLine("Något gick fel, testa igen!");

            Console.WriteLine("------------------------------");

            Console.WriteLine($"Lista med kategorier:");

            hm.SessionCheck(customer);
            api.GetCategories();

            Console.WriteLine("------------------------------");

            Console.WriteLine($"Lista över kategorier med sökning H:");

            hm.SessionCheck(customer);
            api.GetCategories("H");

            Console.WriteLine("------------------------------");

            Console.WriteLine($"Lista med böcker från vald kategori:" +
                $"\nKunden valde: Science Fiction");

            hm.SessionCheck(customer);
            api.GetCategory(3);

            Console.WriteLine("------------------------------");

            Console.WriteLine($"Lista med böcker som finns tillgängliga från vald kategori:" +
                $"\nKunden valde: Horror");

            hm.SessionCheck(customer);
            api.GetAvailableBooks(1);

            Console.WriteLine("------------------------------");

            Console.WriteLine($"Information om vald bok:" +
                $"\nKunden valde: Doctor Sleep");

            hm.SessionCheck(customer);
            api.GetBook(3);

            Console.WriteLine("------------------------------");

            Console.WriteLine($"Listar böcker vars titel innehåller sökning: Sh");

            hm.SessionCheck(customer);
            api.GetBooks("Sh");

            Console.WriteLine("------------------------------");

            Console.WriteLine($"Listar böcker vars författares namn innehåller sökning: King");

            hm.SessionCheck(customer);
            api.GetAuthors("King");

            Console.WriteLine("------------------------------");

            Console.WriteLine($"Information om vald bok:" +
                $"\nKunden valde boken I Robot");

            if (api.BuyBook(customer, 4) == true)
                Console.WriteLine("Köp gick igenom!");

            else Console.WriteLine("Köp gick inte igenom");

            Console.WriteLine("------------------------------");

            Console.WriteLine($"Utloggning:" +
                $"\nKollar om kund är inloggad med ping:");
            api.Ping(customer);

            Console.WriteLine("Kund loggar ut");
            api.Logout(customer);

            Console.WriteLine("Kollar om kund är inloggad med ping:");
            api.Ping(customer);

            Console.WriteLine("------------------------------");

        }

        private void AdminDemo()
        {
            var api = new WebbshopAPI();

            string aName = "Administrator";
            string aPassword = "CodicRulez";

            Console.WriteLine($"Inloggning" +
                $"Namn: {aName}" +
                $" Lösenord: {aPassword}" +
                $"\n");

            int admin = api.Login(aName, aPassword);
            if (admin > 0)
                Console.WriteLine("Admin inloggad");
            else
                Console.WriteLine("Något gick fel, testa igen!");

            Console.WriteLine("------------------------------");

            Console.WriteLine($"Lista med alla användare:");

            api.ListUsers(admin);

            Console.WriteLine("------------------------------");

            string userName = "TestCustomer3";
            string userPassword = "Codic2021";

            Console.WriteLine($"Admin lägger till användare" +
                $"Namn: {userName}" +
                $" Lösenord: {userPassword}" +
                $"\n");

            if (api.AddUser(admin, userName, userPassword) == true)
                Console.WriteLine("Användare skapad");
            else
                Console.WriteLine("Något gick fel, testa igen!");

            Console.WriteLine("------------------------------");

            Console.WriteLine($"Lista med alla användare vars namn innehåller Test:");

            api.FindUser(admin, "Test");

            Console.WriteLine("------------------------------");

            Console.WriteLine($"Uppdaterar bok (The Shinning byter namn till The Shining och ändrar pris):");

            api.UpdateBook(admin, 2, "The Shining", "Stephen King", 350);

            Console.WriteLine("------------------------------");

            Console.WriteLine($"Ändrar antal för boken I Robot:");

            api.SetAmount(admin, 4, 6);

            Console.WriteLine("------------------------------");

            Console.WriteLine($"Lägger till bok:");

            api.AddBook(admin, "Jaws", "Peter Benchley", 120, 2);

            Console.WriteLine("------------------------------");

            Console.WriteLine($"Lägger till kategori Novels:");

            api.AddCategory(admin, "Novels");

            Console.WriteLine("------------------------------");

            Console.WriteLine($"Lägger till boken Jaws i kategori Novels:");

            api.AddBookToCategory(admin, 5, 5);

            Console.WriteLine("------------------------------");

            Console.WriteLine($"Information om boken Jaws");

            api.GetBook(5);

            Console.WriteLine("------------------------------");

            Console.WriteLine($"Tar bort boken Jaws:");

            api.DeleteBook(admin, 5);

            Console.WriteLine("------------------------------");

            Console.WriteLine($"Uppdaterar kategori Novels:");

            api.UpdateCategory(admin, 5, "History");

            Console.WriteLine("------------------------------");

            Console.WriteLine($"Tar bort kategori History:");

            api.DeleteCategory(admin, 5);

            Console.WriteLine("------------------------------");

            api.Logout(admin);

        }
    }
}
