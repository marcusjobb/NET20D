namespace MoqFTW.Webblogics.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using MoqFTW.Interfaces;
    using MoqFTW.Webblogics;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="WebbshopTests" />.
    /// </summary>
    [TestClass()]
    public class WebbshopTests
    {
        /// <summary>
        /// Defines the Webshop.
        /// </summary>
        internal IWebshop Webshop;

        /// <summary>
        /// The test initialization.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            // Mock a AddItemToCart, returns true always
            var WebbshopMock = new Mock<IWebshop>();
            WebbshopMock.Setup(
                w => w.AddItemToCart
                (
                    It.IsAny<IUser>(), It.IsAny<IItem>()
                )
                ).Returns(true);

            // Mocks a GetCart, returns a list of items
            WebbshopMock.Setup(w => w.GetCart(It.IsAny<IUser>())).Returns
                (
                    new List<IItem>()
                    {
                        new Item { Id = 1, Name = "Kattmat", Price = 25 },
                    }
                );

            // Sets property of available items
            WebbshopMock.SetupProperty(l => l.ItemsAvailable, new List<IItem>
            {
                new Item{Id=1, Name="Kattmat", Price=25}
            }
            );

            Webshop = WebbshopMock.Object;
        }

        /// <summary>
        /// Test AddItemToCart.
        /// </summary>
        [TestMethod()]
        public void AddItemToCartTest()
        {
            var user = new User { Name = "medina", Id = 1337 };
            var item = Webshop.ItemsAvailable.FirstOrDefault();
            Assert.IsTrue(Webshop.AddItemToCart(user, item));
        }

        /// <summary>
        /// Test GetCart.
        /// </summary>
        [TestMethod()]
        public void GetCartTest()
        {
            var user = new User { Name = "medina", Id = 1337 };
            var cart = Webshop.GetCart(user);
            Assert.AreEqual(1, cart.Count);
        }

        /// <summary>
        /// Test GetAvailableItems.
        /// </summary>
        [TestMethod()]
        public void GetAvailableItemsTest()
        {
            var items = Webshop.ItemsAvailable;
            Assert.AreEqual(1, items.Count);
        }
    }
}