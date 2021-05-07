using Geometrics;
using NUnit.Framework;
using TDDInlämningGeometry.Geometrics;

namespace TDDInlämningGeometry
{
    [TestFixture]
    internal class GemetricCalculatorTests
    {
        /// <summary>
        /// Testing perimeter sum calculation with positive parameters, with and without decimal
        /// </summary>
        /// <param name="tSide"></param>
        /// <param name="sSide"></param>
        /// <param name="radius"></param>
        /// <param name="rLength"></param>
        /// <param name="rHeigth"></param>
        /// <param name="expected"></param>
        [TestCase(8f, 4f, 1f, 3f, 5f, 62.28318f)]
        [TestCase(1.48f, 2.33f, 2.62f, 2.56f, 4.99f, 45.32194f)]
        public void GetPerimeter_PositiveAndDecimal_ReturnPerimeterSum(float tSide, float sSide, float radius, float rLength, float rHeigth, float expected)
        {
            var geoThings = new IGeometricThing[]
            {
                new Triangle(tSide),
                new Square(sSide),
                new Circle(radius),
                new Rectangle(rLength,rHeigth)
            };
            var calc = new GeometricCalculator();
            var actual = calc.GetPerimeter(geoThings);
            Assert.That(actual, Is.EqualTo(expected).Within(0.001));
        }

        /// <summary>
        /// Testing perimeter sum calculation with some zero and negative parameters
        /// </summary>
        /// <param name="tSide"></param>
        /// <param name="sSide"></param>
        /// <param name="radius"></param>
        /// <param name="rLength"></param>
        /// <param name="rHeigth"></param>
        /// <param name="expected"></param>
        [TestCase(3f, 3f, null, 4f, 3f, 35f)]
        [TestCase(0f, 4f, 1f, 3f, 5f, 38.28318f)]
        [TestCase(2f, 0f, 2f, 2f, 4f, 30.56637f)]
        [TestCase(3f, 3f, 0f, 4f, 3f, 35f)]
        [TestCase(4f, 2f, 1f, 0f, 5f, 26.28318f)]
        [TestCase(5f, 1f, 2f, 3f, 0f, 31.56637f)]
        [TestCase(-6f, 3f, 1f, 3f, 5f, 34.28318f)]
        [TestCase(2f, -5f, 2f, 1f, 4f, 28.56637f)]
        [TestCase(3f, 3f, -4f, 4f, 3f, 35f)]
        [TestCase(40f, 20f, 10f, -3f, 50f, 262.83185f)]
        [TestCase(4f, 2f, 2f, 3f, -2f, 32.56637f)]
        public void GetPerimeter_SomeNullZeroAndNegative_ReturnPerimeterSum(float tSide, float sSide, float radius, float rLength, float rHeigth, float expected)
        {
            var geoThings = new IGeometricThing[]
            {
                new Triangle(tSide),
                new Square(sSide),
                new Circle(radius),
                new Rectangle(rLength,rHeigth)
            };
            var calc = new GeometricCalculator();
            var actual = calc.GetPerimeter(geoThings);
            Assert.That(actual, Is.EqualTo(expected).Within(0.001));
        }

        /// <summary>
        /// Testing perimeter sum calculation with only null, zero or negative parameters
        /// </summary>
        /// <param name="tSide"></param>
        /// <param name="sSide"></param>
        /// <param name="radius"></param>
        /// <param name="rLength"></param>
        /// <param name="rHeight"></param>
        /// <param name="expected"></param>
        [TestCase(null, null, null, null, null)]
        [TestCase(0f, 0f, 0f, 0f, 0f)]
        [TestCase(-5f, -1f, -2f, -3f, -2f)]
        public void GetPerimeter_NullZeroAndNegative_ReturnZero(float tSide, float sSide, float radius, float rLength, float rHeight)
        {
            var geoThings = new IGeometricThing[]
            {
                new Triangle(tSide),
                new Square(sSide),
                new Circle(radius),
                new Rectangle(rLength,rHeight)
            };
            var calc = new GeometricCalculator();
            var actual = calc.GetPerimeter(geoThings);
            Assert.Zero(actual);
        }
    }
}