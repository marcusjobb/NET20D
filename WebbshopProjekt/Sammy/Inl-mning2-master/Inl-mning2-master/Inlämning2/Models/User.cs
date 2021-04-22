using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Inlämning2.Models
{
    /// <summary>
    /// Klassen för användare och administratör
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
        public List<SoldBook> SoldBooks { set; get; }
        
        public User()
        {
            Password = "Codic2021";
            IsActive = true;
            IsAdmin = false;
        }
        
    }
}
