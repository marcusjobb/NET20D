using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace tdd_inlamning_1.Models.Tests
{
    [TestClass()]
    public class TriangleTests
    {
        [TestMethod()]
        public void GetAreaTest()
        {
            //Arrange
            var triangle = new Triangle(4, 4, 0);
            var expected = 8;

            //Act
            var actual = Math.Round(triangle.GetArea(), 2, MidpointRounding.ToEven);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetAreaTestShouldFail()
        {
            try
            {
                //Arrange
                var triangle = new Triangle(44, 14, 0);
                triangle.A = 13;
                var expected = 308;

                //Act
                var actual = Math.Round(triangle.GetArea(), 2, MidpointRounding.ToEven);

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
            var triangle = new Triangle(4, 3, 0);
            var expected = 12;

            //Act
            var actual = Math.Round(triangle.GetPerimeter(), 2, MidpointRounding.ToEven);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetPerimeterTestShouldFail()
        {
            try
            {
                //Arrange
                var triangle = new Triangle(41, 34, 0);
                triangle = null;
                var expected = 128.26;

                //Act
                var actual = Math.Round(triangle.GetPerimeter(), 2, MidpointRounding.ToEven);

                //Assert
                Assert.AreEqual(expected, actual);
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}