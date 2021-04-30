using System;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    /// <summary>
    /// The sold books database table, user field is connected to User Table
    /// </summary>
    public class SoldBook
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}