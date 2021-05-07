using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace tdd_inlamning_1.Models.Tests
{
    [TestClass()]
    public class RectangleTests
    {
        [TestMethod()]
        public void GetAreaTest()
        {
            //Arrange
            var rectangle = new Rectangle(10, 2);
            var expected = 20;

            //Act
            var actual = rectangle.GetArea();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetAreaTestShouldFail()
        {
            try
            {
                //Arrange
                var rectangle = new Rectangle(10, 2);
                var expected = 20;

                //Act
                var actual = rectangle.GetArea() - 1337;

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
            var rectangle = new Rectangle(10, 2);
            var expected = 24;

            //Act
            var actual = rectangle.GetPerimeter();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetPerimeterTestShouldFail()
        {
            try
            {
                //Arrange
                var rectangle = new Rectangle(10, 26);
                var expected = 24;

                //Act
                var actual = rectangle.GetPerimeter();

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