using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebbShopAPI.Models
{
    public class BookCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Books> Books { get; set; }
    }
}
