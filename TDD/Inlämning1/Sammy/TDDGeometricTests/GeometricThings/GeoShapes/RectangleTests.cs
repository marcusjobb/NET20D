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
    public class RectangleTests
    {
        [TestMethod()]
        [DataRow(6, 4, 24)]
        [DataRow(0, 4, 0)]
        [DataRow(6.4f, 4.6f, 29.44f)]
        [DataRow(-6.4f, -4.6f, 0)]

        public void GetAreaTest(float height, float length, float expected)
        {
            var rectangle = new Rectangle(height, length);
            var actual = rectangle.GetArea();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(6, 4, 20)]
        [DataRow(0, 4, 0)]
        [DataRow(6.4f, 4.6f, 22)]
        [DataRow(-6.4f, -4.6f, 0)]
        public void GetPerimitertest(float height, float length, float expected)
        {
            var rectangle = new Rectangle(height, length);
            var actual = rectangle.GetPerimiter();
            Assert.AreEqual(expected, actual);
        }
    }
}