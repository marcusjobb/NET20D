using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uppgift1TDD.GeometricItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift1TDD.GeometricItems.Tests
{
    [TestClass()]
    public class TriangleTests
    {
        [TestMethod()]
        public void Triangle_TestsIfAreaCalculationWork()
        {
            var triangle = new Triangle(4,4);
            float expected = 8;
            float actual = triangle.Area();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Triangle_TestsIfAreaCalculationWorkf()
        {
            var triangle = new Triangle(2, -5);
            float expected = 0;
            float actual = triangle.Area();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Triangle_TestsIfPerimeterCalculationWork()
        {
            var triangle = new Triangle(4,4);
            float expected = 12;
            float actual = triangle.Perimeter();
            Assert.AreEqual(expected, actual);
        }
    }
}