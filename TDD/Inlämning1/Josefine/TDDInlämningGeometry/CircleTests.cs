using Geometrics;
using NUnit.Framework;
using System;

namespace TDDInlämningGeometry
{
    [TestFixture]
    public class CircleTests
    {
        /// <summary>
        /// Testing area calculation with radius, null, zero and negative
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="expected"></param>
        [TestCase(null)]
        [TestCase(0f)]
        [TestCase(-2f)]
        public void CircleArea_NullZeroAndNegative_ReturnZero(float radius)
        {
            var myCircle = new Circle(radius);
            var actual = myCircle.GetArea();
            Assert.Zero(actual);
        }

        /// <summary>
        /// Testing area calculation with positive radius, with and without decimal
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="expected"></param>
        [TestCase(2f, 12.5664f)]
        [TestCase(0.6f, 1.1309f)]
        public void CircleArea_PositiveAndDecimal_ReturnArea(float radius, float expected)
        {
            var myCircle = new Circle(radius);
            var actual = myCircle.GetArea();
            Assert.That(actual, Is.EqualTo(expected).Within(0.001));
        }
        /// <summary>
        /// Testing perimeter calculation with radius, null, zero and negative
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="expected"></param>
        [TestCase(null)]
        [TestCase(0f)]
        [TestCase(-2f)]
        public void TestCirclePerimeter_NullZeroAndNegative_ReturnZero(float radius)
        {
            var myCircle = new Circle(radius);
            var actual = myCircle.GetPerimeter();
            Assert.Zero(actual);
        }

        /// <summary>
        /// Testing perimeter calculation with positive radius, with and without decimal
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="expected"></param>
        [TestCase(3f, 18.8495f)]
        [TestCase(0.34f, 2.1363f)]
        public void TestCirclePerimeter_PositiveAndDecimal_ReturnPerimeter(float radius, float expected)
        {
            var myCircle = new Circle(radius);
            var actual = myCircle.GetPerimeter();
            Assert.That(actual, Is.EqualTo(expected).Within(0.001));
        }
    }
}