using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace tdd_inlamning_1.Models.Tests
{
    [TestClass()]
    public class CircleTests
    {
        [TestMethod()]
        public void GetAreaTest()
        {
            //Arrange
            var circle = new Circle(3);
            var expected = 28.27;

            //Act
            var actual = Math.Round(circle.GetArea(), 2, MidpointRounding.ToEven);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetAreaTestShouldFail()
        {
            try
            {
                //Arrange
                var circle = new Circle(3);
                var expected = 28.27;

                //Act
                var actual = Math.Round(circle.GetPerimeter(), 2, MidpointRounding.ToEven);

                //Assert
                Assert.AreEqual(expected, actual);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod()]
        public void GetPerimeterTest()
        {
            //Arrange
            var circle = new Circle(3);
            var expected = 18.85;

            //Act
            var actual = Math.Round(circle.GetPerimeter(), 2, MidpointRounding.ToEven);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetPerimeterTestShouldFail()
        {
            try
            {
                //Arrange
                var circle = new Circle(3);
                var expected = 18.85;

                //Act
                var actual = Math.Round(circle.GetArea(), 2, MidpointRounding.ToEven);

                //Assert
                Assert.AreEqual(expected, actual);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}