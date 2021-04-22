using System.ComponentModel.DataAnnotations;

namespace WebbShopAPI.Models
{
    /// <summary>
    /// Class for common data between 2 or more classes
    /// </summary>
    public class Common
    {
        /// <summary>
        /// The identification number of the item
        /// </summary>
        [Key]
        public int Id { get; set; }
    }
}
