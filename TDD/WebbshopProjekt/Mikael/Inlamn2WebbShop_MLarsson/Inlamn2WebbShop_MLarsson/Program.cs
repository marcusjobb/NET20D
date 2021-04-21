using System;
using Inlamn2WebbShop_MLarsson.Controllers;
using Inlamn2WebbShop_MLarsson.Database;
using Inlamn2WebbShop_MLarsson.Views;

namespace Inlamn2WebbShop_MLarsson
{
    class Program
    {
        static void Main(string[] args)
        {
            //Skapa databas och fyll på tabeller.
            DatabaseCreator.Create();
            Seeder.Seed();

/*
            //Testa alla metoder, tryck enter mellan varje "Go".
            #region Go1-User
            //#1 Logga in 
            Console.WriteLine("#1");
            int userId = WebbShopAPI.LogInUser("TestClient", "Codic2021");

            //#2 Fråga efter kategorier
            Console.WriteLine("#2");
            var list = WebbShopAPI.GetCategories();
            View.ListCategories(list);

            //#3 Välj kategori Horror
            Console.WriteLine("#3");
            var category = WebbShopAPI.GetCategory(2);
            View.ListCategory(category);

            //#4 Skicka Ping
            Console.WriteLine("#4");
            Console.WriteLine(WebbShopAPI.Ping(2));

            //#5 Lista böcker i kategorin Horror, med fler än 0 i antal.
            Console.WriteLine("#5");
            var bookList = WebbShopAPI.GetAvailableBooks(2);
            View.ListBooks(bookList);

            //#6 Presentera all info boken Dr Sleep
            Console.WriteLine("#6");
            var book = WebbShopAPI.GetBook(3);
            View.ListBooks(book);

            //#7 Köp Dr Sleep
            Console.WriteLine("#7");
            WebbShopAPI.BuyBook(userId, 3);

            //#8 Skicka Ping
            Console.WriteLine("#8");
            Console.WriteLine(WebbShopAPI.Ping(2));

            //#9 Presentera all info boken Dr Sleep för att kontrollera antal
            Console.WriteLine("#9");
            var checkAmount = WebbShopAPI.GetBook(3);
            View.ListBooks(checkAmount);

            //#10 Logga ut användare.
            Console.WriteLine("#10");
            WebbShopAPI.LogOutUser(userId);

            Console.WriteLine("*******************");
            Console.ReadLine();
            #endregion Go1-User


            #region Go2-Admin
            //#11 Logga in administratör
            Console.WriteLine("#11");
            int adminId = WebbShopAPI.LogInUser("Administrator", "CodicRulez");

            //#12 Skapa kategori
            Console.WriteLine("#12");
            WebbShopAPI.AddCategory(adminId, "Facts");

            //#13 Skapa en bok
            Console.WriteLine("#13");
            WebbShopAPI.AddBook(adminId, "A Brief History Of Time", "Stephen Hawking", 200, 5);

            //#14 Skicka Ping
            Console.WriteLine("#14");
            Console.WriteLine(WebbShopAPI.Ping(adminId));

            //#15 Lägg till bok i kategori
            Console.WriteLine("#15");
            WebbShopAPI.AddBookToCategory(adminId, 6, 5);

            //#16 Logga ut användare.
            Console.WriteLine("#16");
            WebbShopAPI.LogOutUser(1);

            Console.WriteLine("*******************");
            Console.ReadLine();

            #endregion Go2-Admin


            #region Go3-Admin
            //#17 Logga in administratör
            Console.WriteLine("#17");
            adminId = WebbShopAPI.LogInUser("Administrator", "CodicRulez");

            //#18 Lägg till ny användare
            Console.WriteLine("#18");
            WebbShopAPI.AddUser(adminId, "CalleG", "Knugen");

            //#19 Logga ut användare.
            Console.WriteLine("#19");
            WebbShopAPI.LogOutUser(adminId);

            Console.WriteLine("*******************");
            Console.ReadLine();

            #endregion Go3-Admin


            #region Go4-User
            //#20 Registrera ny användare
            Console.WriteLine("#20");
            WebbShopAPI.Register("Silvia", "TheQueen", "TheQueen");

            //#21 Logga in 
            Console.WriteLine("#21");
            int _userId = WebbShopAPI.LogInUser("Silvia", "TheQueen");

            //#22 Lista kategorier efter keyword
            Console.WriteLine("#22");
            var cat = WebbShopAPI.GetCategories("h");
            View.ListCategories(cat);

            //#23 Lista böcker efter keyword
            Console.WriteLine("#23");
            var bookKey = WebbShopAPI.GetBooks("C");
            View.ListBooks(bookKey);

            //#24 Köp en bok
            Console.WriteLine("#24");
            WebbShopAPI.BuyBook(_userId, 5);
            WebbShopAPI.BuyBook(_userId, 5);
            WebbShopAPI.BuyBook(_userId, 4);

            //#25 Lista alla böcker utefter författar-keyword 
            Console.WriteLine("#25");
            var authors = WebbShopAPI.GetAuthors("do");
            View.ListBooks(authors);

            //#26 Logga ut användare.
            Console.WriteLine("#26");
            WebbShopAPI.LogOutUser(_userId);

            Console.WriteLine("*******************");
            Console.ReadLine();
            #endregion Go4-User


            #region Go5-Admin
            //#27 Logga in administratör
            Console.WriteLine("#27");
            adminId = WebbShopAPI.LogInUser("Administrator", "CodicRulez");

            //#28 Fyll på nya böcker
            Console.WriteLine("#28");
            WebbShopAPI.SetAmount(adminId, 2, 6);

            //#29 Lista alla användare
            Console.WriteLine("#29");
            var userList = WebbShopAPI.ListUsers(adminId);
            View.ListUsers(userList);

            //#30 Hitta användare baserat på keyword
            Console.WriteLine("#30");
            var userListKey = WebbShopAPI.FindUser(adminId, "te");
            View.ListUsers(userListKey);

            //#31 Uppdatera en bok
            Console.WriteLine("#31");
            WebbShopAPI.UpdateBook(adminId, 2, price: 150);

            //#32 Uppdatera en kategori
            Console.WriteLine("#32");
            WebbShopAPI.UpdateCategory(adminId, 2, "Thriller");

            //#33 Skapa kategori
            Console.WriteLine("#33");
            WebbShopAPI.AddCategory(adminId, "Children");

            //#34 Ta bort kategori
            Console.WriteLine("#34");
            WebbShopAPI.DeleteCategory(adminId, 6);

            //#35 Ta bort bok
            Console.WriteLine("#35");
            WebbShopAPI.DeleteBook(adminId, 4);

            //#36 Lista alla sålda böcker
            Console.WriteLine("#36");
            VGWebbShopAPI.SoldItems(adminId);

            //#37 Visa totalsumma av sålda böcker
            Console.WriteLine("#37");
            VGWebbShopAPI.MoneyEarned(adminId);

            //#38 Visa den användare som köpt flest böcker.
            Console.WriteLine("#38");
            var customer = VGWebbShopAPI.BestCustomer(adminId);
            View.ListUser(customer);

            //#39
            Console.WriteLine("#39");
            VGWebbShopAPI.Promote(adminId, 2);

            //#40
            Console.WriteLine("#40");
            VGWebbShopAPI.Demote(adminId, 2);

            //#41
            Console.WriteLine("#41");
            VGWebbShopAPI.InactivateUser(adminId, 2);

            //#42
            Console.WriteLine("#42");
            VGWebbShopAPI.ActivateUser(adminId, 2);

            //#43
            Console.WriteLine("#43");
            //Logga ut användare.
            WebbShopAPI.LogOutUser(adminId);
            #endregion Go5-Admin*/
        }
    }
}
