using System;

namespace WebbShopAPI.Models
{
    /// <summary>
    /// Class containing data for sold books
    /// </summary>
    public class SoldBooks : CommonBooks
    {
        /// <summary>
        /// At what date and time the book was sold
        /// </summary>
        public DateTime PurchasedDate { get; set; }
        /// <summary>
        /// To whom the book was sold to
        /// </summary>
        public int UserId { get; set; }
    }
}
