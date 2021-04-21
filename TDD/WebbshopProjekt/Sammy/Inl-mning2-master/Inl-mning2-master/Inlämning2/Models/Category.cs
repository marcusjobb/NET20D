using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inlämning2.Models
{
    /// <summary>
    /// Klassen för kategori
    /// </summary>
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
