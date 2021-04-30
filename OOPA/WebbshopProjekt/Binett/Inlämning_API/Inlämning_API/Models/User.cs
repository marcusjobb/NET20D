using System;
using System.ComponentModel.DataAnnotations;

namespace Inlämning_API.Models
{
    /// <summary>
    /// Initializing an instance of a User
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Password
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets Lastlogin
        /// </summary>
        public DateTime LastLogin { get; set; }

        /// <summary>
        /// Gets or sets Sessiontimer
        /// </summary>
        public DateTime SessionTimer { get; set; }

        /// <summary>
        /// Gets or sets Isactive
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets IsAdmin
        /// </summary>
        public bool IsAdmin { get; set; }
    }
}