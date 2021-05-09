using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uppgift1TDD.GeometricItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift1TDD.GeometricItems.Tests
{
    [TestClass()]
    public class RectangleTests
    {
        [TestMethod()]
        public void Rectangle_TestsIfAreaCalculationWork()
        {
            var rectangle = new Rectangle(5, 2);
            float expected = 10;
            float actual = rectangle.Area();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Rectangle_TestsIfPerimeterCalculationWork()
        {
            var rectangle = new Rectangle(5, 2);
            float expected = 14;
            float actual = rectangle.Perimeter();
            Assert.AreEqual(expected, actual);
        }
    }
}