namespace WebbShopAPI.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="User" />.
    /// </summary>
    internal class User
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Password.
        /// </summary>
        public string Password { get; set; } = "Codic2021";

        /// <summary>
        /// Gets or sets the LastLogIn.
        /// </summary>
        public DateTime LastLogIn { get; set; }

        /// <summary>
        /// Gets or sets the SessionTimer.
        /// </summary>
        public DateTime SessionTimer { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsActive.
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether IsAdmin.
        /// </summary>
        public bool IsAdmin { get; set; } = false;
    }
}
