using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDGeometric.GeometricThings.GeoShapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDGeometric.GeometricThings.GeoShapes.Tests
{
    [TestClass()]
    public class CircleTests
    {
        [TestMethod()]
        [DataRow(8f, 201.06f)]
        [DataRow(0, 0)]
        [DataRow(-8f, 0)]
        public void GetAreaTest(float radius, float expected)
        {
            var circle = new Circle(radius);
            var actual = circle.GetArea();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(8f, 50.27f)]
        [DataRow(0, 0)]
        [DataRow(-8f, 0)]
        public void GetPerimeterTest(float radius, float expected)
        {
            var circle = new Circle(radius);
            var actual = circle.GetPerimiter();
            Assert.AreEqual(expected, actual);
        }
    }
}