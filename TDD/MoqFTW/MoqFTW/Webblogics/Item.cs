namespace MoqFTW.Webblogics
{
    using MoqFTW.Interfaces;

    /// <summary>
    /// Defines the <see cref="Item" /> based on IItem.
    /// </summary>
    public class Item : IItem
    {
        /// <summary>
        /// Gets or sets the Id of the item.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Name of the item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Price of the item.
        /// </summary>
        public double Price { get; set; }
    }
}