using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inlamn2WebbShop_MLarsson.Models
{
    /// <summary>
    /// Klassen representerar tabellen SoldBook i databasen.
    /// </summary>
    public class SoldBook
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public DateTime PurchasedDate { get; set; }
        public List<Category> Categories { get; set; }
        public List<User> Users { get; set; }

    }
}
