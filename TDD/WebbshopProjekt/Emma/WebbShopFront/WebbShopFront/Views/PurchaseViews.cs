using System;

namespace WebbShopFrontInlamning.Views
{
    /// <summary>
    /// Displays view for Purchase
    /// </summary>
    class PurchaseViews
    {
        /// <summary>
        /// Displays start page of purchase
        /// </summary>
        public static void StartPage()
        {
            Console.WriteLine();
            Console.WriteLine("What are you in the mood for?");
            Console.WriteLine("These books are available right now!");
        }

        /// <summary>
        /// Displays an error message if user is not logged in
        /// </summary>
        public static void DisplayErrorMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Oops, you need to login to proceed with your purchase!");
        }

        /// <summary>
        /// Displays an option to view or purchase
        /// </summary>
        public static void DisplayPurchaseMeny()
        {
            Console.WriteLine();
            Console.WriteLine("1. View details");
            Console.WriteLine("2. Purchase");
        }
    }
}
