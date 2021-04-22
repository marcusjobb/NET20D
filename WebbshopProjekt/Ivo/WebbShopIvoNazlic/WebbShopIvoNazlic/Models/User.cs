using System;
using System.ComponentModel.DataAnnotations;

namespace WebbShopIvoNazlic.Models
{
    /// <remarks>
    /// Users table
    /// </remarks>
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public DateTime LastLogin { get; set; }

        public DateTime SessionTimer { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsAdmin { get; set; } = false;

        public override string ToString()
        {
            return $"{Id}: {Name} (Active={IsActive})";
        }

    }
}
