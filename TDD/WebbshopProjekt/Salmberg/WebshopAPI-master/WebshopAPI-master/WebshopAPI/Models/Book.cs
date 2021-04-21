using System.ComponentModel.DataAnnotations;

namespace WebshopAPI.Models
{
    /// <summary>
    /// Model class for Book table
    /// </summary>
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public int Price { get; set; }

        public int Amount { get; set; }

        public int CategoryId { get; set; }
    }
}