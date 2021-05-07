using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssignmentOne.GeoShapes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentOne.GeoShapes.Tests
{
    [TestClass()]
    public class SquareTests
    {
        [TestMethod()]
        [DataRow(8,64)]
        [DataRow(-6, 0)]
        [DataRow(0, 0)]
        [DataRow(2.53f, 6.40f)]
        public void GetAreaTest(float side, float expected)
        {
            var square = new Square(side);
            var actual = square.GetArea();
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        [DataRow(8, 32)]
        [DataRow(-8, 0)]
        [DataRow(2.57f, 10.28f)]
        [DataRow(0, 0)]
        public void GetPerimeterTest(float side, float expected)
        {
            var square = new Square(side);
            var actual = square.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }
    }
}