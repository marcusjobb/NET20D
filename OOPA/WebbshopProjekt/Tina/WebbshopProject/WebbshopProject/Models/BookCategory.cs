using System.ComponentModel.DataAnnotations;

namespace WebbshopProject.Models
{
    public class BookCategory
    {
        /// <summary>
        /// Gets and sets the id of the bookCategory.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets and sets the name of the bookCategory.
        /// </summary>
        public string Name { get; set; }
    }
}
