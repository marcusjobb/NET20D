using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopAssignment.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public int CategoryId { get; set; }

    }
}
