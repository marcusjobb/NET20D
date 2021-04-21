using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inlamn2WebbShop_MLarsson.Models
{
    /// <summary>
    /// Klassen representerar tabellen User i databasen.
    /// </summary>
    public class User
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime SessionTimer { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; } 
        public List<SoldBook> SoldBooks { get; set; }

        public User()
        {
            Password = "Codic2021";
            IsActive = true;
            IsAdmin = false;
        }
        public override string ToString()
        {
            return $"ID: {Id} - {Name}\nPassword: {Password}\nLast Login: {LastLogin}\nUser active: {IsActive}\nIs admin: {IsAdmin}";
        }
    }
}
