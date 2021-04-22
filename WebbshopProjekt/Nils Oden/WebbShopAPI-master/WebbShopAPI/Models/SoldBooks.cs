using System;
using System.Collections.Generic;
using System.Text;

namespace WebbShopAPI.Models
{
    /// <summary>
    /// Denna klassen jobbar mot dbo.SoldBooks tabellen i databasen.
    /// </summary>
    public class SoldBooks
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public DateTime PurchasedDate { get; set; }
        public int CategoryId { get; set; }
        public int UserID { get; set; }
    }
}
