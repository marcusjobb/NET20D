using System;
using System.ComponentModel.DataAnnotations;

namespace BookWebShop.Models
{
    public class SoldBook
    {
        /// <summary>
        /// Class for the SoldBook model.
        /// </summary>

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int Price { get; set; }

        public BookCategory Category { get; set; }

        public DateTime PurchaseDate { get; set; }

        public User UsrId { get; set; }
    }
}