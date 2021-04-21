using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebbShopAPI.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength (200)]
        public string Title { get; set; }
        [Required]
        [MaxLength(200)]
        public string Author { get; set; }
        
        public int? Price { get; set; }
       
        public int? Quantity { get; set; }
        
        public List<BookGenre> Genres { get; set; }

        public override string ToString()
        {

            return $"ID: {Id}\nTitle: {Title}\nAuthor: {Author}\nPrice: {Price}\nQuantity: {Quantity}\n";

        }
    }
}
