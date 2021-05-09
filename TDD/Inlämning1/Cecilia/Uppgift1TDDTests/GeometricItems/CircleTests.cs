using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uppgift1TDD.GeometricItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift1TDD.GeometricItems.Tests
{
    [TestClass()]
    public class CircleTests
    {
        [TestMethod()]
        public void Circle_TestsIfAreaCalculationWork()
        {
            var circle = new Circle(5);
            float expected = 78.54f;
            float actual = circle.Area();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Circle_TestsIfPerimeterCalculationWork()
        {
            var circle = new Circle(5);
            float expected = 20.708f;
            float actual = circle.Perimeter();
            Assert.AreEqual(expected, actual, 0.05);
        }
    }
}