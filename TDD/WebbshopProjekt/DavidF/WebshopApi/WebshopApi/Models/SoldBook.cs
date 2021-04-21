using System;
using System.ComponentModel.DataAnnotations;

namespace WebshopApi.Models
{
    /// <summary>
    /// Klasse som är modell till SoldBook
    /// </summary>
    public class SoldBook
    {
        [Key]
        public int ID { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public Category Category { get; set; }
        public int Price { get; set; }
        public DateTime PurchasedDate { get; set; }
        public User User { get; set; }
    }
}