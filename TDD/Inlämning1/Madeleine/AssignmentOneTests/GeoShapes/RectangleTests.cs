using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssignmentOne.GeoShapes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentOne.GeoShapes.Tests
{
    [TestClass()]
    public class RectangleTests
    {
        [TestMethod()]
        [DataRow(5,3,15)]
        [DataRow(0, 0, 0)]
        [DataRow(2, 3, 6)]
        [DataRow(-2, -3, 0)]
        [DataRow(1.33f, 6.42f, 8.54f)]
        public void GetAreaTest(float height, float length, float expected)
        {
            var rectangle = new Rectangle(height, length);
            var actual = rectangle.GetArea();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(3.25f, 2.33f, 11.16f)]
        [DataRow(12.87f, 6.26f, 38.26f)]
        [DataRow(0, 0, 0)]
        [DataRow(0, 4, 0)]
        [DataRow(-1, -4, 0)]
        public void GetPerimeterTest(float height, float length, float expected)
        {
            var rectangle = new Rectangle(height, length);
            var actual = rectangle.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }
    }
}