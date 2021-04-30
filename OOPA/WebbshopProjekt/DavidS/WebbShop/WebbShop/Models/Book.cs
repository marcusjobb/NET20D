using System.ComponentModel.DataAnnotations;

namespace WebbShop.Models
{
    public class Book
    {
        /// <summary>
        /// Gets and sets the id of the <see cref="Book"/>.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets and sets the title of the <see cref="Book"/>.
        /// </summary>
        [MaxLength(50)]
        public string Title { get; set; }

        /// <summary>
        /// Gets and sets the author of the <see cref="Book"/>.
        /// </summary>
        [MaxLength(50)]
        public string Author { get; set; }

        /// <summary>
        /// Gets and sets the <see cref="BookCategory"/>
        /// of the <see cref="Book"/>.
        /// </summary>
        public BookCategory Category { get; set; }

        /// <summary>
        /// Gets and sets the price of the <see cref="Book"/>.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Gets and sets the amount of the <see cref="Book"/>.
        /// </summary>
        public int Amount { get; set; }
    }
}
