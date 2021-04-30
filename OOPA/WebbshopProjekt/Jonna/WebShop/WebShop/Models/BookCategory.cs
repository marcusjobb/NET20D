using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    /// <summary>
    /// The BookCategory database table that has relation with Books table
    /// </summary>
    public class BookCategory
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}