using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebbShopAPI.Models
{
  public class SoldBook
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        [MaxLength(200)]
        public string Author { get; set; }
        
        public int GenreId { get; set; }
        
        public int? Price { get; set; }
        
        public DateTime PurchasedDate { get; set; }
        public List<BookGenre> Genres { get; set; }
        public List<User> Users { get; set; }
    }
}