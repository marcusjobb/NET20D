using Geometry.Shapes;
using NUnit.Framework;

namespace Geometry.UnitTests.Shapes
{
    [TestFixture]
    public class TriangleTests
    {
        /// <summary>
        /// This test shows the calculation of the Area of a triangle
        /// Which is calculated with taking Width * Height then dividing it by 2
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="expectedResult"></param>
        [Test]
        [TestCase(10,10,50)]
        [TestCase(25, 25, 312.5)]
        public void TriangleGetArea_TriangleWithBaseAndHeight_ReturnCorrectArea(double width, double height, double expectedResult)
        {
            var triangle = new Triangle {Width = width ,Height = height };
            var result = GeometricCalculator.GetArea(triangle);
            Assert.That(result, Is.EqualTo(expectedResult).Within(0.1));
        }

        /// <summary>
        /// This test shows that if Width or Height is Zero, negative number or null
        /// The calculation will return zero
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="expectedResult"></param>
        [Test]
        [TestCase(0, 10, 0)]
        [TestCase(10, 0, 0)]
        [TestCase(null, 10, 0)]
        [TestCase(0, null, 0)]
        [TestCase(-5, 10, 0)]
        [TestCase(10, -5, 0)]
        public void TriangleGetArea_TriangleWitZeroOrNegativeNumberOrNullBaseAndHeight_ReturnZeroArea(double width, double height, double expectedResult)
        {
            var triangle = new Triangle { Width = width, Height = height };
            var result = GeometricCalculator.GetArea(triangle);
            Assert.That(result, Is.EqualTo(expectedResult).Within(0.1));
        }

        /// <summary>
        /// This test shows the calculation of the perimeter of a triangle
        /// Which is calculated by adding Side 3 times together
        /// </summary>
        /// <param name="side"></param>
        /// <param name="expectedResult"></param>
        [Test]
        [TestCase(5,15)]
        [TestCase(7, 21)]
        [TestCase(9, 27)]
        public void TriangleGetPerimeter_TriangleWithDefinedSide_ReturnPerimeter(double side, double expectedResult)
        {
            var triangle = new Triangle { Side = side };
            var result = GeometricCalculator.GetPerimeter(triangle);
            Assert.That(result, Is.EqualTo(expectedResult).Within(0.1));
        }

        /// <summary>
        /// This test shows that if the Side is zero, negative number or null
        /// Calculation will return zero
        /// </summary>
        /// <param name="side"></param>
        /// <param name="expectedResult"></param>
        [Test]
        [TestCase(0, 0)]
        [TestCase(-5, 0)]
        [TestCase(null, 0)]
        public void TriangleGetPerimeter_TriangleWithSideZeroOrNegativeNumberOrNull_ReturnZeroPerimeter(double side, double expectedResult)
        {
            var triangle = new Triangle { Side = side };
            var result = GeometricCalculator.GetPerimeter(triangle);
            Assert.That(result, Is.EqualTo(expectedResult).Within(0.1));
        }
    }
}