using System;
using System.ComponentModel.DataAnnotations;

namespace WebbShopEmil.Models
{
    /// <summary>
    /// Intializing an intance of a user.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Get or set Id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Get or set Name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Get or set Password.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Get or set LastLogin.
        /// </summary>
        public DateTime LastLogin { get; set; }

        /// <summary>
        /// Get or set SessionTimer.
        /// </summary>
        public DateTime SessionTimer { get; set; }

        /// <summary>
        /// Get or set IsActive.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Get or set IsAdmin.
        /// </summary>
        public bool IsAdmin { get; set; }
    }
}