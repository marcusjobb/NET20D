using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoqFTW.Interfaces;
using MoqFTW.Webblogics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoqFTW.Webblogics.Tests
{
    [TestClass()]
    public class WebbshopTests
    {
        IWebshop Webshop;

        [TestInitialize]
        public void Setup()
        {
            var WebbshopMock = new Mock<IWebshop>();
            WebbshopMock.Setup(
                w => w.AddItemToCart
                (
                    It.IsAny<IUser>(), It.IsAny<IItem>()
                )
                ).Returns(true);

            WebbshopMock.Setup(w => w.GetCart(It.IsAny<IUser>())).Returns
                (
                    new List<IItem>()
                    {
                        new Item { Id = 1, Name = "Kattmat", Price = 25 },
                    }
                );

            WebbshopMock.SetupProperty(l => l.ItemsAvailable, new List<IItem>
            {
                new Item{Id=1, Name="Kattmat", Price=25}
            }
            );

            Webshop = WebbshopMock.Object;
        }

        [TestMethod()]
        public void AddItemToCartTest()
        {
            var user = new User { Name = "medina", Id = 1337 };
            var item = Webshop.ItemsAvailable.FirstOrDefault();
            Assert.IsTrue(Webshop.AddItemToCart(user, item));
        }

        [TestMethod()]
        public void GetCartTest()
        {
            var user = new User { Name = "medina", Id = 1337 };
            var cart = Webshop.GetCart(user);
            Assert.AreEqual(1, cart.Count);
        }

        [TestMethod()]
        public void GetAvailableItems()
        {
            var items = Webshop.ItemsAvailable;
            Assert.AreEqual(1, items.Count);
        }
    }
}