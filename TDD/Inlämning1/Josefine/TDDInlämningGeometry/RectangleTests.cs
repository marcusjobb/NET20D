using Geometrics;
using NUnit.Framework;
using System;

namespace TDDInlämningGeometry
{
    [TestFixture]
    public class RectangleTests
    {
        /// <summary>
        /// Testing area calculation with length and heigth, null, zero and negative
        /// </summary>
        /// <param name="length"></param>
        /// <param name="height"></param>
        /// <param name="expected"></param>
        [TestCase(null, null)]
        [TestCase(null, 8f)]
        [TestCase(10f, null)]
        [TestCase(0f, 4f)]
        [TestCase(3f, 0f)]
        [TestCase(-5f, 4f)]
        [TestCase(3f, -2f)]
        public void RectangleArea_NullZeroAndNegative_ReturnZero(float length, float height)
        {
            var myRactangle = new Rectangle(length, height);
            var actual = myRactangle.GetArea();
            Assert.Zero(actual);
        }

        /// <summary>
        /// Testing area calculation with positive length and heigth, with and without decimal
        /// </summary>
        /// <param name="length"></param>
        /// <param name="height"></param>
        /// <param name="expected"></param>
        [TestCase(5f, 6f, 30f)]
        [TestCase(5.87f, 4.46f, 26.1802f)]
        [TestCase(0.33f, 0.27f, 0.0891f)]
        public void RectangleArea_PositiveAndDecimal_ReturnArea(float length, float height, float expected)
        {
            var myRactangle = new Rectangle(length, height);
            var actual = myRactangle.GetArea();
            Assert.That(actual, Is.EqualTo(expected).Within(0.001));
        }
        /// <summary>
        /// Testing perimeter calculation with length and heigth, null, zero and negative
        /// </summary>
        /// <param name="length"></param>
        /// <param name="height"></param>
        /// <param name="expected"></param>
        [TestCase(null, 14f)]
        [TestCase(3f, null)]
        [TestCase(0f, 8f)]
        [TestCase(5f, 0f)]
        [TestCase(-3f, 7f)]
        [TestCase(2f, -6f)]
        public void RectanglePerimeter_NullZeroAndNegative_ReturnZero(float length, float height)
        {
            var myRectangle = new Rectangle(length, height);
            var actual = myRectangle.GetPerimeter();
            Assert.Zero(actual);
        }

        /// <summary>
        /// Testing perimeter calculation with positive length and heigth, with and without decimal
        /// </summary>
        /// <param name="length"></param>
        /// <param name="height"></param>
        /// <param name="expected"></param>
        [TestCase(3f, 5f, 16f)]
        [TestCase(2.45f, 4.78f, 14.46f)]
        [TestCase(0.23f, 0.56f, 1.58f)]
        public void RectanglePerimeter_PositiveAndDecimal_ReturnPerimeter(float length, float height, float expected)
        {
            var myRectangle = new Rectangle(length, height);
            var actual = myRectangle.GetPerimeter();
            Assert.That(actual, Is.EqualTo(expected).Within(0.001));
        }
    }
}