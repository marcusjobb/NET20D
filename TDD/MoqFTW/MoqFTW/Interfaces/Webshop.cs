namespace MoqFTW.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// The current webshop instance.
    /// </summary>
    public interface IWebshop
    {
        /// <summary>
        /// Gets or sets the list of Items Available.
        /// </summary>
        public List<IItem> ItemsAvailable { get; set; }

        /// <summary>
        /// The method for adding items to the cart.
        /// </summary>
        /// <param name="user">The user<see cref="IUser"/>.</param>
        /// <param name="item">The item<see cref="IItem"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool AddItemToCart(IUser user, IItem item);

        /// <summary>
        /// Gets a list of the of items in the user cart.
        /// </summary>
        /// <param name="user">The user<see cref="IUser"/>.</param>
        /// <returns>The <see cref="List{IItem}"/>.</returns>
        public List<IItem> GetCart(IUser user);
    }
}