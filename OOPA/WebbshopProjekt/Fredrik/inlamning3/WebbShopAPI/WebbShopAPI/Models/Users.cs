using System;

namespace WebbShopAPI.Models
{
    /// <summary>
    /// Class for managing users
    /// </summary>
    public class Users : CommonUserAttr
    {
        /// <summary>
        /// When the user was last signed in (date and time)
        /// </summary>
        public DateTime LastLogin { get; set; }
        /// <summary>
        /// When the user was last active, must be set each 5 minute or it's invalidated.
        /// </summary>
        public DateTime SessionTimer { get; set; }
        /// <summary>
        /// If the user is activated (enabled) or not
        /// </summary>
        public bool IsActive { get; set; } = true;
        /// <summary>
        /// If the user is an administrator or not
        /// </summary>
        public bool IsAdmin { get; set; } = false;
    }
}
