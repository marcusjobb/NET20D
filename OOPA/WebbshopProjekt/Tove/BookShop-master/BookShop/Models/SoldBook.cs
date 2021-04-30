using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.Models
{
    public class SoldBook
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public DateTime PurchasedDate { get; set; } = DateTime.Now; 
        public int UserId { get; set; }
    }
}
