using System;
using System.Collections.Generic;
using System.Text;

namespace MyBackend.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Klassen skapar modell för kategorier
    /// </summary>
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
