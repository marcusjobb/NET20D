using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebbShop.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public int Ammount { get; set; }
        public int? CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public BookCategory Category { get; set; }
    }
}
