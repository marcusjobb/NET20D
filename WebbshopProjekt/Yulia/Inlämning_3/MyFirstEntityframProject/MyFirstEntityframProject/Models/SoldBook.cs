
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace MyFirstEntityframProject.Database
{
    public class SoldBook
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; } = "Codic2021";
        public int Price { get; set; }
        public DateTime PurchasedDate { get; set; }
        public List<Category> Categories { get; set; }
        public List<User> Users { get; set; }
     
    }
}