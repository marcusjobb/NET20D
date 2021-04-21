using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inlamningsuppgift2WebbShopAPI.Models
{
    /// <summary>
    /// Model of the SoldBook object.
    /// This is a model of an object used within entity framework to mirror rows of sold books in the SoldBooks table.
    /// </summary>
    public class SoldBook
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public BookCategory Category { get; set; }
        public int Price { get; set; }
        public DateTime PurchasedDate { get; set; }
        //public virtual User UserId { get; set; }
        //public User UserId {get; set;}

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
