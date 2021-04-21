using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebbShopJesperPersson.Model
{
    public class BookCategory
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public List<Book> Books { get; set; }
        public List<SoldBook> SoldBooks { get; set; }
    }
}