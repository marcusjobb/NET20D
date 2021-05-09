using NUnit.Framework;
using System;

namespace Shapes___inlämning_TDD
{
    [TestFixture]
    internal class GeoMetricCalculatorTest
    {
        /// <summary>
        /// Testing the GetPerimeter method of the GeoMetricCalculator.
        /// Creates invalid array containing null objects
        /// </summary>
        [Test]
        public void GetPerimeter_ArrayContainingNullObjects_ReturnZero()
        {
            //Arrange
            const float expected = 0f;
            var geoThings = new IGeometricThing[4];
            GeoMetricCalculator geoCalc = new();
            //Act
            var actual = geoCalc.GetPerimeter(geoThings);
            //Assert
            Assert.That(MathF.Round(actual, 2), Is.EqualTo(MathF.Round(expected, 2)));
        }

        /// <summary>
        /// Testing the GetPerimeter method of the GeoMetricCalculator.
        /// Creates valid shapes and tries to add them together
        /// </summary>
        [Test]
        public void GetPerimeter_ArrayWithValidShapes_ReturnTotalPerimeter()
        {
            //Arrange
            const float expected = 132.28f;
            var geoThings = new IGeometricThing[]
                {
                new Triangle(10, 8.660254037f),
                new Square(15),
                new Rectangle(8,10),
                new Circle(1)
                };

            GeoMetricCalculator geoCalc = new();
            //Act
            var actual = geoCalc.GetPerimeter(geoThings);
            //Assert
            Assert.That(MathF.Round(actual, 2), Is.EqualTo(MathF.Round(expected, 2)));
        }

        /// <summary>
        /// Testing the GetPerimeter method of the GeoMetricCalculator.
        /// Array is null.
        /// </summary>
        [Test]
        public void GetPerimeter_NullArray_ReturnZero()
        {
            //Arrange
            const float expected = 0f;
            GeoMetricCalculator geoCalc = new();
            //Act
            var actual = geoCalc.GetPerimeter(null);
            //Assert
            Assert.That(MathF.Round(actual, 2), Is.EqualTo(MathF.Round(expected, 2)));
        }
    }
}