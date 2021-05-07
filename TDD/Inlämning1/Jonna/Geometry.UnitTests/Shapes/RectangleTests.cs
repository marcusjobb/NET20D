using Geometry.Shapes;
using NUnit.Framework;

namespace Geometry.UnitTests.Shapes
{
    [TestFixture]
    public class RectangleTests
    {
        /// <summary>
        /// Calculates the area of a rectangle and with the width and height
        /// The test will pass if the calculation is correct
        /// </summary>
        [Test]
        [TestCase(7,5,35)]
        // 7 * 5 = 35
        [TestCase(6, 4, 24)]
        // 7 * 5 = 24
        [TestCase(5.9, 7.3, 43.0)]
        // 5.9 * 7.3 = 43.07
        public void RectangleGetArea_WithProportionalRectangle_ReturnCorrectArea(double width, double height, double expectedResult)
        {
            var rectangle = new Rectangle {Width = width, Height = height};
            var result = GeometricCalculator.GetArea(rectangle);
            Assert.That(result, Is.EqualTo(expectedResult).Within(0.1));
        }

        /// <summary>
        /// If either Width or Height is zero, negative number or null
        /// Operation returns 0
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="expectedResult"></param>
        [Test]
        [TestCase(0,10,0)]
        [TestCase(10, 0, 0)]
        [TestCase(-5, 10, 0)]
        [TestCase(null, null, 0)]
        public void RectangleGetArea_ZeroOrNegativeNumberOnEitherBaseOrHeight_ReturnZero(double width, double height, double expectedResult)
        {
            var rectangle = new Rectangle { Width = width, Height = height };
            var result = GeometricCalculator.GetArea(rectangle);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// To get the perimeter of the rectangle we add the base two times and height two times
        /// </summary>
        [Test]
        [TestCase(7,5,24)]
        // 7 + 7 + 5 + 5 = 24
        [TestCase(11.3, 9.6, 41.8)]
        // 11.3 + 11.3 + 9.6 + 9.6 = 41,800000000000004
        public void RectangleGetPerimeter_WithProportionateRectangle_ReturnExpectedPerimeter(double width, double height, double expectedResult)
        {
            var rectangle = new Rectangle { Width = width, Height = height };
            var result = GeometricCalculator.GetPerimeter(rectangle);
            Assert.That(result, Is.EqualTo(expectedResult).Within(0.1));
        }

        /// <summary>
        /// This tests displays that if you put zero, negative number or null as value
        /// for width or height, the return will be zero
        /// which will make the tests pass
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="expectedResult"></param>
        [Test]
        [TestCase(0, 10, 0)]
        [TestCase(10, 0, 0)]
        [TestCase(-5, 10, 0)]
        [TestCase(null, null, 0)]
        public void RectangleGetPerimeter_ZeroOrNegativeNumberOnEitherBaseOrHeight_ReturnZero(double width, double height, double expectedResult)
        {
            var rectangle = new Rectangle { Width = width, Height = height };
            var result = GeometricCalculator.GetArea(rectangle);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}