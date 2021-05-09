using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uppgift1TDD.GeometricItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift1TDD.GeometricItems.Tests
{
    [TestClass()]
    public class SquareTests
    {
        [TestMethod()]
        public void Square_TestsIfAreaCalculationWork()
        {
            var square = new Square(2);
            float expected = 4;
            float actual = square.Area();
            Assert.AreEqual(expected,actual);
        }

        [TestMethod()]
        public void Square_TestsIfPerimeterCalculationWork()
        {
            var square = new Square(2);
            float expected = 8;
            float actual = square.Perimeter();
            Assert.AreEqual(expected, actual);
        }
    }
}