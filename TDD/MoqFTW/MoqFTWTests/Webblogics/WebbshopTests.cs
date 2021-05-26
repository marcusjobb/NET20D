using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoqFTW.Interfaces;
using MoqFTW.Webblogics;
using System;
using System.Collections.Generic;
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

            Webshop = WebbshopMock.Object;
        }

        [TestMethod()]
        public void AddItemToCartTest()
        {
            var user = new User { Name = "medina", Id = 1337 };
            var item = new Item { Id = 1, Name = "Kattmat", Price = 25 };
            //Webshop = new Webbshop();
            Assert.IsTrue(Webshop.AddItemToCart(user, item));
        }
    }
}