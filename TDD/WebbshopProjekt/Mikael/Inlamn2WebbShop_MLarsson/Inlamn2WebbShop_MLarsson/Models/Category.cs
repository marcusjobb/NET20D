using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inlamn2WebbShop_MLarsson.Models
{
    /// <summary>
    /// Klassen representerar tabellen Category i databasen.
    /// </summary>
    public class Category
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
        public List<SoldBook> SoldBooks { get; set; }
        
    }
}
