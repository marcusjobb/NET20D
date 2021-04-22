using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InlamningDB2.Models
{
   public class Books
    {
        [Key]
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }

        public int? CategoryId { get; set; }

        // [ForeignKey("Categoryid")]
        public BookCategory Category { get; set; }

    }
}
