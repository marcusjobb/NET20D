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
    public class TriangleTests
    {
        [TestMethod()]
        [DataRow(5.8f, 3f, 8.7f)]
        [DataRow(0, 3f, 0)]
        [DataRow(-5.8f, 3f, 0)]
        public void GetAreaTest(float side, float height, float expected)
        {
            var triangle = new Triangle(side, height);
            var actual = triangle.GetArea();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(5.8f, 3f, 17.4f)]
        [DataRow(0, 3f, 0)]
        [DataRow(-5.8f, 3f, 0)]
        public void GetPerimeterTest(float side, float height, float expected)
        {
            var triangle = new Triangle(side, height);
            var actual = triangle.GetPerimiter();
            Assert.AreEqual(expected, actual);
        }
    }
}