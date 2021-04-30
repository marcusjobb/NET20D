using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstEntityframProject.Database
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Book> Books { get; set; }
        public List<SoldBook> SoldBooks { get; set; }

        public string Describe()
        {
            return ($"{Name}");
        }

    }
}