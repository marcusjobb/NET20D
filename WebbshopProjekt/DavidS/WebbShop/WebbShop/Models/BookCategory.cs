using System.ComponentModel.DataAnnotations;

namespace WebbShop.Models
{
    public class BookCategory
    {
        /// <summary>
        /// Gets and sets the id of the <see cref="BookCategory"/>.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets and sets the name of the <see cref="BookCategory"/>.
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
