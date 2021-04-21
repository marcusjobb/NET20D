using System;
using WebbShop.Models;

namespace WebbutikFrontend.Views.SoldBooksMenu
{
    public static class BestCustomer
    {
        /// <summary>
        /// The best customer view for the sold books menu.
        /// </summary>
        public static void View((User customer, int books) best)
        {
            Console.WriteLine($"\n\tBest customer: {best.customer.Name}" +
                    $" with {best.books} books bought!");
        }
    }
}
