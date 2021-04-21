using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebbShopAPI.Models
{
    /// <summary>
    ///  Min BookGenre Tabell
    /// </summary>
    public class BookGenre
    {
        [Key]
        public int GenreId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Genre { get; set; }

        [MaxLength(200)]
        public List<Book> Books { get; set; } // Om jag vill koppla fler categorier
        public List<SoldBook> SoldBooks { get; set; }
    }
}