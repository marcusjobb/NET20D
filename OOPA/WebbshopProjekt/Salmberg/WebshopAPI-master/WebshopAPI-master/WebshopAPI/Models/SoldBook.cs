using System;
using System.ComponentModel.DataAnnotations;

namespace WebshopAPI.Models
{
    /// <summary>
    /// Model class for SoldBook table
    /// </summary>
    public class SoldBook
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public int CategoryId { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}