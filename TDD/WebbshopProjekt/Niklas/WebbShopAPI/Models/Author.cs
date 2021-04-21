using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebbShopAPI.Interfaces;

namespace WebbShopAPI.Models
{
    /// <summary>
    /// Author of the books.
    /// Containing: ID, first name, surname, full name, published books.
    /// </summary>
    public class Author : INamable, IModelable
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string FullName { get => $"{FirstName} {Surname}"; }
        public List<Book> PublishedBooks { get; set; }
    }
}
