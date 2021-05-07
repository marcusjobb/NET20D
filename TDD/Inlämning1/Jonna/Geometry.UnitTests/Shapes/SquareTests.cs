using Geometry.Shapes;
using NUnit.Framework;

namespace Geometry.UnitTests.Shapes
{
    [TestFixture]
    public class SquareTests
    {
        /// <summary>
        /// This test takes side * side and equals the area of a square
        /// </summary>
        [Test]
        [TestCase(5,25)]
        [TestCase(7, 49)]
        [TestCase(7.4, 54.7)]
        public void SquareGetArea_SquareWithSide_ReturnCorrectArea(double Side, double expectedResult)
        {
            var square = new Square {Side = Side};
            var result = GeometricCalculator.GetArea(square);
            Assert.That(result, Is.EqualTo(expectedResult).Within(0.1));
        }

        /// <summary>
        /// If a side is zero,negative number or null
        /// Return 0 in result for Area
        /// </summary>
        [Test]
        [TestCase(0,0)]
        [TestCase(-5, 0)]
        [TestCase(null, 0)]
        public void SquareGetArea_SquareWithZeroOrNegativeNumberOrNullSide_ReturnZeroArea(double Side, double expectedResult)
        {
            var square = new Square { Side = Side };
            var result = GeometricCalculator.GetArea(square);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// This test takes the side and add it 4 times to get the perimeter of a square
        /// </summary>
        [Test]
        [TestCase(5,20)]
        [TestCase(6.3, 25.2)]
        public void SquareGetPerimeter_WithProportionateSquare_ReturnExpectedPerimeter(double Side, double expectedResult)
        {
            var square = new Square { Side = Side };
            var result = GeometricCalculator.GetPerimeter(square);
            Assert.That(result, Is.EqualTo(expectedResult).Within(0.1));
        }

        /// <summary>
        /// If a side is zero,negative number or null
        /// Return 0 in result for Perimeter
        /// </summary>
        [Test]
        [TestCase(0, 0)]
        [TestCase(-5, 0)]
        [TestCase(null, 0)]
        public void SquareGetPerimeter_SquareWithZeroOrNegativeNumberOrNullSide_ReturnZeroPerimeter(double Side, double expectedResult)
        {
            var square = new Square { Side = Side };
            var result = GeometricCalculator.GetPerimeter(square);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}