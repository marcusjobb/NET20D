using System;
using System.ComponentModel.DataAnnotations;

namespace WebbShopApi.Models
{
    /// <summary>
    /// Defines the <see cref="User" />.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the UserId.
        /// </summary>
        [Key]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Password.
        /// Default: "Codic2021"
        /// </summary>
        public string Password { get; set; } = "Codic2021";

        /// <summary>
        /// Gets or sets the LastLogin.
        /// </summary>
        public DateTime LastLogin { get; set; }

        /// <summary>
        /// Gets or sets the SessionTimer.
        /// </summary>
        public DateTime SessionTimer { get; set; }

        /// <summary>
        /// Gets or sets the IsActiove.
        /// </summary>
        public bool IsActiove { get; set; } = true;

        /// <summary>
        /// Gets or sets the IsAdmin.
        /// </summary>
        public bool IsAdmin { get; set; } = false;
    }
}
