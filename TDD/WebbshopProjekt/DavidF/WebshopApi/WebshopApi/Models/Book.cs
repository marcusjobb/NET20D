using System.ComponentModel.DataAnnotations;

namespace WebshopApi.Models
{
    /// <summary>
    /// Klasse som är modell till Book
    /// </summary>
    public class Book
    {
        [Key]
        public int ID { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public Category Category { get; set; }
    }
}