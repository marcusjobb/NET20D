using System.ComponentModel.DataAnnotations;

namespace BookWebShop.Models
{
    public class Book
    {
        /// <summary>
        /// Class for the Book model.
        /// </summary>

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int Price { get; set; }

        public int Amount { get; set; }

        public BookCategory Category { get; set; }
    }
}