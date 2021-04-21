using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace MyFirstEntityframProject.Database
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; } = "Codic2021";
        public int Price { get; set; }
        public int Amount { get; set; }
        
        public List<Category> Categories { get; set; }

        public string Describe()
        {
           return ($"{Title}, {Author}, {Price} kr, available stock {Amount} item(s)");
        }
    }
}