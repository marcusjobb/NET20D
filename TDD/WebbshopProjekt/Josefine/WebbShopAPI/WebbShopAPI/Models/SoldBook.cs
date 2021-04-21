using System;
using System.ComponentModel.DataAnnotations;

namespace WebbShopAPI.Models
{
    public class SoldBook
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public BookCategory BookCategories { get; set; }
        public int Price { get; set; }
        public DateTime PurchasedDate { get; set; }
        public User Users { get; set; }
    }
}
