using System.ComponentModel.DataAnnotations;

namespace WebshopAPI.Models
{
    /// <summary>
    /// Model class for BookCategory table
    /// </summary>
    public class BookCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}