using Geometry.Shapes;
using NUnit.Framework;

namespace Geometry.UnitTests.Shapes
{
    [TestFixture]
    public class CircleTests
    {
        /// <summary>
        /// This tests shows if a correct calculation of the area of a circle
        /// With taking Radius * Radius * Pi
        /// Test will pass if the result is correct
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="expectedResult"></param>
        [Test]
        [TestCase(7, 153.9)]
        [TestCase(9, 254.4)]
        [TestCase(11, 380.1)]
        public void CircleGetArea_CircleWithDefinedRadius_ReturnExpectedArea(double radius, double expectedResult)
        {
            var circle = new Circle { Radius = radius };
            var result = GeometricCalculator.GetArea(circle);
            Assert.That(result, Is.EqualTo(expectedResult).Within(0.1));
        }

        /// <summary>
        /// This test shows in the calculation of Area of a Circle
        /// If Radius is Zero ,negative number or null
        /// The calculation will return zero
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="expectedResult"></param>
        [Test]
        [TestCase(0,0)]
        [TestCase(-5, 0)]
        [TestCase(null, 0)]
        public void CircleGetArea_CircleWithZeroOrNegativeNumberOrNull_ReturnZeroArea(double radius, double expectedResult)
        {
            var circle = new Circle { Radius = radius };
            var result = GeometricCalculator.GetArea(circle);
            Assert.That(result, Is.EqualTo(expectedResult).Within(0.1));
        }

        /// <summary>
        /// This test calculates the perimeter of a circle
        /// Which is 2 * Radius * Pi
        /// Test will pass if the calculation is correct
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="expectedResult"></param>
        [Test]
        [TestCase(7, 43.9)]
        [TestCase(9, 56.5)]
        [TestCase(11, 69.1)]

        public void CircleGetPerimeter_CircleWithDefinedRadius_ReturnExpectedPerimeter(double radius, double expectedResult)
        {
            var circle = new Circle { Radius = radius };
            var result = GeometricCalculator.GetPerimeter(circle);
            Assert.That(result, Is.EqualTo(expectedResult).Within(0.1));
        }

        /// <summary>
        /// This test shows if you try to calculate the Perimeter of a circle
        /// But if the radius is zero, negative number or null the calculation
        /// will return 0
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="expectedResult"></param>
        [Test]
        [TestCase(0, 0)]
        [TestCase(-5, 0)]
        [TestCase(null, 0)]
        public void CircleGetPerimeter_CircleWithZeroOrNegativeNumberOrNull_ReturnZeroArea(double radius, double expectedResult)
        {
            var circle = new Circle { Radius = radius };
            var result = GeometricCalculator.GetPerimeter(circle);
            Assert.That(result, Is.EqualTo(expectedResult).Within(0.1));
        }
    }
}