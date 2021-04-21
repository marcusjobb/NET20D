using System;
using System.ComponentModel.DataAnnotations;

namespace WebbShopInlamningsUppgift.Models
{
    /// <summary>
    /// Represents sold items (books) in database
    /// </summary>
    public class SoldBooks
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public int BookCategoryId { get; set; }
        public BookCategory BookCategory { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int UsersId { get; set; }
        public Users Users { get; set; }
    }
}
