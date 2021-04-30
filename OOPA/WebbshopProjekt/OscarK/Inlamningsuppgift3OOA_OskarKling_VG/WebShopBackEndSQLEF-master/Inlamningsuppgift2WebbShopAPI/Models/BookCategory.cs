using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inlamningsuppgift2WebbShopAPI.Models
{
    /// <summary>
    /// Model of the BookCategory object.
    /// This is a model of an object used within entity framework to mirror rows of book categories in the BookCategories table.
    /// </summary>
    public class BookCategory
    {
        [Key]
        public int Id { get; set; }
        public string Category { get; set; }

    }
}
