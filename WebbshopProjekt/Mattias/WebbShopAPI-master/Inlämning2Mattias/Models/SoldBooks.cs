using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebbShopAPI.Models
{
    /// <summary>
    /// Contains Id, Title, Author, Price, Amount, Category, PurchaseDate, UserId data for a sold book
    /// </summary>
    public class SoldBooks
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public int Category { get; set; }
        public string PurchaseDate { get; set; }
        public int UserId { get; set; }
    }
}
