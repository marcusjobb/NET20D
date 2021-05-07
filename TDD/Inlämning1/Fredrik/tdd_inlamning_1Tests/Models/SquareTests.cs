using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace tdd_inlamning_1.Models.Tests
{
    [TestClass()]
    public class SquareTests
    {
        [TestMethod()]
        public void GetAreaTest()
        {
            //Arrange
            var square = new Square(3);
            var expected = 9;

            //Act
            var actual = square.GetArea();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetAreaTestShouldFail()
        {
            try
            {
                //Arrange
                var square = new Square(3);
                var expected = 9.001;

                //Act
                var actual = square.GetArea();

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
            var square = new Square(3);
            var expected = 12;

            //Act
            var actual = square.GetPerimeter();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetPerimeterTestShouldFail()
        {
            try
            {
                //Arrange
                var square = new Square(3);
                var expected = 12;

                //Act
                var actual = square.GetPerimeter() + 1;

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