using Geometrics;
using NUnit.Framework;
using System;

namespace TDDInlämningGeometry
{
    [TestFixture]
    public class SquareTests
    {
        /// <summary>
        /// Testing area calculation with side, null, zero and negative
        /// </summary>
        /// <param name="side"></param>
        /// <param name="expected"></param>
        [TestCase(null)]
        [TestCase(0f)]
        [TestCase(-2f)]
        public void SquareArea_NullZeroAndNegative_ReturnZero(float side)
        {
            var mySquare = new Square(side);
            var actual = mySquare.GetArea();
            Assert.Zero(actual);
        }

        /// <summary>
        /// Testing area calculation with positive side, with and without decimal
        /// </summary>
        /// <param name="side"></param>
        /// <param name="expected"></param>
        [TestCase(2f, 4f)]
        [TestCase(0.9f, 0.81f)]
        [TestCase(0.1f, 0.01f)]
        public void SquareArea_PositiveAndDecimal_ReturnArea(float side, float expected)
        {
            var mySquare = new Square(side);
            var actual = mySquare.GetArea();
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
        public void SquarePerimeter_NullZeroAndNegative_ReturnZero(float side)
        {
            var mySquare = new Square(side);
            var actual = mySquare.GetPerimeter();
            Assert.Zero(actual);
        }

        /// <summary>
        /// Testing perimeter calculation with positive side, with and without decimal
        /// </summary>
        /// <param name="side"></param>
        /// <param name="expected"></param>
        [TestCase(4f, 16f)]
        [TestCase(1.3f, 5.2f)]
        public void SquarePerimeter_PositiveAndDecimal_ReturnPerimeter(float side, float expected)
        {
            var mySquare = new Square(side);
            var actual = mySquare.GetPerimeter();
            Assert.That(actual, Is.EqualTo(expected).Within(0.001));
        }
    }
}