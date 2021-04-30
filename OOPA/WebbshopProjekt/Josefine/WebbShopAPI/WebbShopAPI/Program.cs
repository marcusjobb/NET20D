using System;
using WebbShopJoR;
using WebbShopJoR.Helper;

namespace WebbShopAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var seed = new Seeder();
            seed.AddData();

            var user = API.Login("TestCustomer", "CodicRulez");
            var admin = API.Login("Administrator", "CodicRulez");
            API.Logout(user);

            var myBookId = 4;
            var myCathegoryId = 1;
            var searchWord = "in";
            var myAmount = 5;

            Console.WriteLine(".....All Categorys.....");
            Show.ShowCathegorys(API.GetCategories());

            Console.WriteLine("\n.....Search categorys containing.....");
            Show.ShowCathegorys(API.GetCategories("or"));

            Console.WriteLine("\n.....Search books with category id.....");
            Show.ShowBooks(API.GetBooksInCategory(myCathegoryId));

            Console.WriteLine("\n.....Search books with category id and available.....");
            Show.ShowBooks(API.GetAvailableBooks(myCathegoryId));

            Console.WriteLine("\n.....Search book with id.....");
            Show.ShowBook(API.GetBook(myBookId));

            Console.WriteLine("\n.....Search books.....");
            Show.ShowBooks(API.GetBooks(searchWord));

            Console.WriteLine("\n.....Search author.....");
            Show.ShowBooks(API.GetAuthors(searchWord));

            API.Ping(2);

            Console.WriteLine("\n.....Is book bought.....");
            Console.WriteLine(API.BuyBook(user, myBookId));

            Console.WriteLine("\n.....Is user registered.....");
            Console.WriteLine(API.Register("Josefine", "isFantastic", "isFantastic"));

            Console.WriteLine("\n.....Is book added.....");
            Console.WriteLine(API.AddBook(admin, 0, "Patterns in the mind", "Ray Jackendoff", 220, myAmount));

            API.SetAmount(admin, myBookId, myAmount);

            Console.WriteLine("\n.....List users.....");
            Show.ShowUsers(API.ListUsers(admin));

            Console.WriteLine("\n.....Find user.....");
            Show.ShowUsers(API.FindUsers(admin, searchWord));

            API.Ping(admin);

            Console.WriteLine("\n.....Is book updated.....");
            Console.WriteLine(API.UpdateBook(admin, 4, "Cabal (Nigthbreed)", "Clive Barker", 230));

            Console.WriteLine("\n.....Is book deleted.....");
            Console.WriteLine(API.DeleteBook(admin, myBookId));

            Console.WriteLine("\n.....Is category added.....");
            Console.WriteLine(API.AddCategory(admin, "Linguistics"));

            Console.WriteLine("\n.....Is book added to category.....");
            Console.WriteLine(API.AddBookToCategory(admin, 5, 5));

            Console.WriteLine("\n.....Is category updated.....");
            Console.WriteLine(API.UpdateCategory(admin, 3, "Fantasy"));

            Console.WriteLine("\n.....Is category deleted.....");
            Console.WriteLine(API.DeleteCategory(admin, myCathegoryId));

            Console.WriteLine("\n.....Is user added.....");
            Console.WriteLine(API.AddUser(admin, "JosefineR", "isWonderful"));

            //Jag har tvekat på att satsa på VG eller inte och tänkte inte göra det
            //först för att jag ville lägga tid på annat. Men sedan skrev jag alla metoder
            //men lyckades aldrig får BestCustomer att fungera. Därför har jag inte lagt in
            //någon av de metoderna i testflödet. Jag fattar att det inte är clean code att ha
            //kvar en ofungerande metod, men jag har kvar den för att kanske göra om den senare.

        }
    }
}
