using Geometrics;
using NUnit.Framework;
using System;

namespace TDDInlämningGeometry
{
    [TestFixture]
    internal class TriangleTests
    {
        /// <summary>
        /// Testing area calculation with side and height, null, zero and negative
        /// </summary>
        /// <param name="side"></param>
        /// <param name="height"></param>
        /// <param name="expected"></param>
        [TestCase(null, null)]
        [TestCase(null, 1f)]
        [TestCase(6f, null)]
        [TestCase(0f, 2f)]
        [TestCase(3f, 0f)]
        [TestCase(-2f, 3f)]
        [TestCase(2f, -3f)]
        public void TriangleArea_NullZeroAndNegative_ReturnZero(float side, float height)
        {
            var myTriangle = new Triangle(side, height);
            var actual = myTriangle.GetArea();
            Assert.Zero(actual);
        }

        /// <summary>
        /// Testing area calculation with positive side and height, with and without decimal
        /// </summary>
        /// <param name="side"></param>
        /// <param name="height"></param>
        /// <param name="expected"></param>
        [TestCase(2f, 2f, 2f)]
        [TestCase(12f, 14f, 84f)]
        [TestCase(2.55f, 3.88f, 4.947f)]
        [TestCase(0.68f, 0.56f, 0.1904f)]
        public void TriangleArea_PositiveAndDecimal_ReturnArea(float side, float height, float expected)
        {
            var myTriangle = new Triangle(side, height);
            var actual = myTriangle.GetArea();
            Assert.That(actual, Is.EqualTo(expected).Within(0.001));
        }
        /// <summary>
        /// Testing perimeter calculation with side, null, zero and negative
        /// </summary>
        /// <param name="side"></param>
        /// <param name="expected"></param>
        [TestCase(null)]
        [TestCase(0f)]
        [TestCase(-3f)]
        public void TrianglePerimeter_NullZeroAndNegative_ReturnZero(float side)
        {
            var myTriangle = new Triangle(side);
            var actual = myTriangle.GetPerimeter();
            Assert.Zero(actual);
        }

        /// <summary>
        /// Testing perimeter calculation with positive side, with and without decimal
        /// </summary>
        /// <param name="side"></param>
        /// <param name="expected"></param>
        [TestCase(4f, 12f)]
        [TestCase(2.73f, 8.19f)]
        [TestCase(0.71f, 2.13f)]
        public void TrianglePerimeter_PositiveAndDecimal_ReturnPerimeter(float side, float expected)
        {
            var myTriangle = new Triangle(side);
            var actual = myTriangle.GetPerimeter();
            Assert.That(actual, Is.EqualTo(expected).Within(0.001));
        }
    }
}