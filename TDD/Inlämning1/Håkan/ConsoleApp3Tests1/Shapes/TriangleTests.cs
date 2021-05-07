using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConsoleApp3.Shapes.Tests
{
    [TestClass()]
    public class TriangleTests
    {
        [TestMethod()]
        [DataRow(1f, 0.8660f, 0.433f)]
        [DataRow(2f, 1.7320f, 1.7320f)]
        public void CalculatesArea_OfTriangle_ReturnsArea(float width, float height, float expected)
        {
            var triangle = new Triangle(height, width);
            var actual = triangle.Area();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// MidpointRounding evens the decimals to closest even decimal number.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="expected"></param>
        [TestMethod()]
        [DataRow(1f, 0.8660f, 3f)]
        [DataRow(2f, 1.7320f, 6f)]
        [DataRow(4f, 3.4641f, 12f)]
        public void CalculatesPerimeter_OfTriangle_ReturnsPerimeter(float width, float height, float expected)
        {
            var triangel = new Triangle(height, width);
            var actual = triangel.Perimeter();

            Assert.AreEqual(MathF.Round(expected, 2, MidpointRounding.ToEven), MathF.Round(actual, 2, MidpointRounding.ToEven));
        }
    }
}