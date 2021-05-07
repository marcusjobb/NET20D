using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using tdd_inlamning_1.Models;

namespace tdd_inlamning_1.Tests
{
    [TestClass()]
    public class GeometricCalculatorTests
    {
        [TestMethod()]
        public void GetAreaTest()
        {
            //Arrange
            var calc = new GeometricCalculator();
            var expected = 28.27;

            //Act
            var actual = Math.Round(calc.GetArea(new Circle(3)), 2, MidpointRounding.ToEven);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetAreaTestShouldFail()
        {
            try
            {
                //Arrange
                var calc = new GeometricCalculator();
                var expected = 21124.07;
                expected = 2;

                //Act
                var actual = Math.Round(calc.GetArea(new Circle(82)), 2, MidpointRounding.ToEven);

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
            var calc = new GeometricCalculator();
            var expected = 18.85;

            //Act
            var actual = Math.Round(calc.GetPerimeter(new Circle(3)), 2, MidpointRounding.ToEven);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetPerimeterTestShouldFail()
        {
            try
            {
                //Arrange
                var calc = new GeometricCalculator();
                var expected = 333.301;

                //Act
                var actual = Math.Round(calc.GetPerimeter(new Circle(53)), 2, MidpointRounding.ToEven);

                //Assert
                Assert.AreEqual(expected, actual);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod()]
        public void GetPerimeterTestMultipleObjects()
        {
            //Arrange
            var calc = new GeometricCalculator();
            var expected = 75.4;
            var objs = new Circle[] { new Circle(2), new Circle(3), new Circle(7) };

            //Act
            var actual = Math.Round(objs.Sum(a => a.GetPerimeter()), 2, MidpointRounding.ToEven);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetPerimeterTestMultipleObjectsShouldFail()
        {
            try
            {
                //Arrange
                var calc = new GeometricCalculator();
                var expected = 69.12;
                var objs = new Circle[] { new Circle(4), new Circle(1), new Circle(6) };
                objs = null;

                //Act
                var actual = Math.Round(objs.Sum(a => a.GetPerimeter()), 2, MidpointRounding.ToEven);

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