using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InlamningDB2.Models
{
   public class Soldbooks
    {
        [Key]
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Author { get; set; }
        public BookCategory Category { get; set; }
        public DateTime PurchasedDate { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public int? CategoryId { get; set; }

        public User  User{ get; set; }

    }
}
