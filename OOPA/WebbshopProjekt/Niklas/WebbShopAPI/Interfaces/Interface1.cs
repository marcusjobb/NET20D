using System;
using WebbShopAPI.Models;

namespace WebbShopAPI.Interfaces
{
    interface IBuyLoggable
    {
        public User BoughtBy { get; set; }
        public int Price { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
