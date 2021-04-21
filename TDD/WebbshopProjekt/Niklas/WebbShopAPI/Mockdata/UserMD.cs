using WebbShopAPI.Data;
using WebbShopAPI.Models;

namespace WebbShopAPI.Mockdata
{
    /// <summary>
    /// Adds mockdata to the database.
    /// </summary>
    public class UserMD
    {
        /// <summary>
        /// Populates database with 10 test users.
        /// </summary>
        /// <returns>True if passed.</returns>
        public static bool NewUsers()
        {
            try
            {
                using (var db = new DBContext())
                {
                    var user1 = new User { FirstName = "Stephen", Surname = "Testson", Username = "Test1", Password = "Password" };
                    var user2 = new User { FirstName = "Rune", Surname = "Stenhäll", Username = "Test2", Password = "Password" };
                    var user3 = new User { FirstName = "Ragnar", Surname = "Stark", Username = "Test3", Password = "Password" };
                    var user4 = new User { FirstName = "Greta", Surname = "Tunberg", Username = "Test4", Password = "Password" };
                    var user5 = new User { FirstName = "Katla", Surname = "Eriksson", Username = "Test5", Password = "Password" };
                    var user6 = new User { FirstName = "Egil", Surname = "Lejonhjärta", Username = "Test6", Password = "Password" };
                    var user7 = new User { FirstName = "Jonathan", Surname = "Lejonhjärta", Username = "Test7", Password = "Password" };
                    var user8 = new User { FirstName = "Mundi", Surname = "Jonsson", Username = "Test8", Password = "Password" };
                    var user9 = new User { FirstName = "Edward", Surname = "Blom", Username = "Test9", Password = "Password" };
                    var user10 = new User { FirstName = "Ernst ", Surname = "Kirchsteiger", Username = "Test10", Password = "Password" };

                    db.Update(user1);
                    db.Update(user2);
                    db.Update(user3);
                    db.Update(user4);
                    db.Update(user5);
                    db.Update(user6);
                    db.Update(user7);
                    db.Update(user8);
                    db.Update(user9);
                    db.Update(user10);
                    db.SaveChanges();
                    return true;
                }
            }
            catch { return false; }
        }

        /// <summary>
        /// Mock-user 1 buys 1 book.
        /// </summary>
        public static void User1BuysBooks()
        {
            using (var db = new DBContext())
            {
                var api = new WebShopAPI();
                var userID1 = WebShopAPI.GetUserID("Test1");
                var bookID1 = WebShopAPI.GetBookID("Cabal (Nightbreed)");
                WebShopAPI.Login("Test1", "Password");
                api.BuyBook(userID1, bookID1);
                new WebShopAPI().LogOut(userID1);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Mock-user 2 buys 5 books.
        /// </summary>
        public static void User2BuysBooks()
        {
            using (var db = new DBContext())
            {
                var api = new WebShopAPI();
                var userID2 = WebShopAPI.GetUserID("Test2");
                var bookID1 = WebShopAPI.GetBookID("Cabal (Nightbreed)");
                var bookID2 = WebShopAPI.GetBookID("Past Tense");
                var bookID3 = WebShopAPI.GetBookID("Blue Moon");
                var bookID4 = WebShopAPI.GetBookID("One Shot");
                var bookID5 = WebShopAPI.GetBookID("Night School");
                WebShopAPI.Login("Test2", "Password");
                api.BuyBook(userID2, bookID1);
                api.BuyBook(userID2, bookID2);
                api.BuyBook(userID2, bookID3);
                api.BuyBook(userID2, bookID4);
                api.BuyBook(userID2, bookID5);
                new WebShopAPI().LogOut(userID2);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Mock-user 3 buys 3 books.
        /// </summary>
        public static void User3BuysBooks()
        {
            using (var db = new DBContext())
            {
                var api = new WebShopAPI();
                var userID3 = WebShopAPI.GetUserID("Test3");
                var bookID1 = WebShopAPI.GetBookID("Cabal (Nightbreed)");
                var bookID2 = WebShopAPI.GetBookID("Past Tense");
                var bookID3 = WebShopAPI.GetBookID("The Affair");
                WebShopAPI.Login("Test3", "Password");
                api.BuyBook(userID3, bookID1);
                api.BuyBook(userID3, bookID2);
                api.BuyBook(userID3, bookID3);
                new WebShopAPI().LogOut(userID3);
                db.SaveChanges();
            }
        }
    }
}
