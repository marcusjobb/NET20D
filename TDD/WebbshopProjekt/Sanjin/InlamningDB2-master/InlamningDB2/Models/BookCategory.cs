using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InlamningDB2.Models
{
   public class BookCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
