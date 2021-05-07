using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssignmentOne.GeoShapes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentOne.GeoShapes.Tests
{
    [TestClass()]
    public class CircleTests
    {

        [TestMethod()]
        [DataRow(0,0)]
        [DataRow(7, 153.94f)]
        [DataRow(7.3f, 167.42f)]
        [DataRow(-1, 0)]
        public void GetAreaTest(float radius, float expected)
        {
            var circle = new Circle(radius);
            var actual = circle.GetArea();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(7.3f, 45.87f)]
        [DataRow(2, 12.57f)]
        [DataRow(-3, 0)]
        [DataRow(0, 0)]
        public void GetPerimeterTest(float radius, float expected)
        {
            var circle = new Circle(radius);
            var actual = circle.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }
    }
}