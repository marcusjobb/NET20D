using BookShopFrontEnd.Utility;
using BookShopFrontEnd.Views;
using WebbShopAPI;

namespace BookShopFrontEnd.Controllers
{
    /// <summary>
    /// Make calls for the store function in the application.
    /// </summary>
    public class StoreController
    {
        /// <summary>
        /// Lets the user buy a book from the book-store.
        /// The user gets to chose to search books by category/author or by all books.
        /// </summary>
        public static void BuyBook()
        {
            var bookList = Store.BuyBook();
            var userInput = Helper.GetInputForOptions(1, bookList.Count);
            int index = userInput - 1;
            var loggedUserID = UserController.LoggedUserID;
            var success = new WebShopAPI().BuyBook(loggedUserID, bookList[index].ID);
            ExtractedView.SuccessDBCalls(success);
            MenuController.MainMenu();
        }
    }
}
