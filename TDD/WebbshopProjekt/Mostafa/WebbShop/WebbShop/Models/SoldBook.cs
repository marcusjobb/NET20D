using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebbShop.Models
{
    public class SoldBook
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int? CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public Book Book { get; set; }
        public int Price { get; set; }
        public DateTime PurchasedDate { get; set; }
        public int? UserID { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }
    }
}
