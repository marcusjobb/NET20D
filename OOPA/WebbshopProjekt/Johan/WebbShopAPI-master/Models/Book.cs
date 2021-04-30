using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopAPI.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }

        public int Price { get; set; }
        public int Amount { get; set; }

        [ForeignKey ("CategoryId")]
        public BookCategory Category { get; set; }

        public int? CategoryId { get; set; }

    }
}
