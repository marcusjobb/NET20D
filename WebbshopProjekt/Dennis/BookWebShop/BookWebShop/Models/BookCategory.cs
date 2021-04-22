using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookWebShop.Models
{
    public class BookCategory
    {
        /// <summary>
        /// Class for the BookCategory model.
        /// </summary>

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }
}