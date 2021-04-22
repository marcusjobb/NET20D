using WebbShopFrontInlamning.Helpers;
using WebbShopFrontInlamning.Views;
using WebbShopInlamningsUppgift;

namespace WebbShopFrontInlamning.Controllers
{
    /// <summary>
    /// Controls the purchase functionality
    /// </summary>
    class Purchase
    {
        /// <summary>
        /// Runs the purchase functionality page
        /// </summary>
        /// <param name="userId"></param>
        public void Run(int userId)
        {
            PurchaseViews.StartPage();

            bool keepGoing = true;
            while (keepGoing)
            {
                new Book().FindAllAvailableBooks();
                MessageViews.DisplaySelectMessage();
                MessageViews.DisplayReturnMessage();
                var bookId = InputHelper.ParseInput();
                if (bookId == 0)
                {
                    break;
                }

                PurchaseViews.DisplayPurchaseMeny();
                MessageViews.DisplayReturnMessage();
                var input = InputHelper.ParseInput();
                if (input == 0)
                {
                    break;
                }

                switch (input)
                {
                    case 1:
                        ViewDetails(bookId);
                        break;
                    case 2:
                        PurchaseBook(userId, bookId);
                        keepGoing = false;
                        break;
                    default:
                        MessageViews.DisplayNonAvailableMessage();
                        break;
                }
            }
        }

        /// <summary>
        /// Allows you to view details for a specific book
        /// </summary>
        /// <param name="bookId"></param>
        public void ViewDetails(int bookId)
        {
            WebbShopAPI api = new WebbShopAPI();
            var bookDetails = api.GetBook(bookId);
            if(bookDetails != string.Empty)
            {
                BookViews.DisplayDetails(bookDetails);
                return;
            }

            MessageViews.DisplayErrorMessage();
        }

        /// <summary>
        /// Allows you to purchase chosen book
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        public void PurchaseBook(int userId, int bookId)
        {
            WebbShopAPI api = new WebbShopAPI();
            if(userId != 0 && bookId != 0)
            {
                var result = api.BuyBook(userId, bookId);
                if (result)
                {
                    MessageViews.DisplaySuccessMessage();
                    return;
                }
            }
            PurchaseViews.DisplayErrorMessage();
        }
    }
}
