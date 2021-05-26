namespace MoqFTW.Webblogics
{
    using MoqFTW.Interfaces;
    using System.Collections.Generic;

    /// <summary>
    /// The current Webshop instance.
    /// </summary>
    public class Webshop : IWebshop
    {
        /// <summary>
        /// Gets or sets the list of items available.
        /// </summary>
        public List<IItem> ItemsAvailable { get; set; }

        /// <summary>
        /// Gets or sets the Cart items.
        /// </summary>
        private List<IItem> Cart { get; set; }

        /// <summary>
        /// Adds given item to cart.
        /// </summary>
        /// <param name="user">The user<see cref="IUser"/>.</param>
        /// <param name="item">The item<see cref="IItem"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool AddItemToCart(IUser user, IItem item)
        {
            return false;
        }

        /// <summary>
        /// Gets a list of <see cref="IItem"/>s of things the user added to the cart.
        /// </summary>
        /// <param name="user">The user<see cref="IUser"/>.</param>
        /// <returns>The <see cref="List{IItem}"/>.</returns>
        public List<IItem> GetCart(IUser user)
        {
            return Cart;
        }
    }
}