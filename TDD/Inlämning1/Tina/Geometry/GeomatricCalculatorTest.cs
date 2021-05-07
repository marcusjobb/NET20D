using GeomatryTests;
using NUnit.Framework;
using System;

namespace TDD_TinaEriksson
{
    public class GeomatricCalculatorTest
    {
        [Test]
        public void GetPerimeterOfSeveralShapes_PositiveInput_ReturnsPerimeter()
        {
            // Arrange
            var geoThings = new IGeomatricThing[]
            {
                new Triangle(10, 8.660254037f),
                new Square(12.0f),
                new Circle(6.0f),
            };

            var expected = 113.02f;
            var geoCal = new GeomatricCalculator();
            // Act
            var actual = geoCal.CalculatePerimeter(geoThings);

            // Assert
            Assert.That(MathF.Round(actual, 2), Is.EqualTo(MathF.Round(expected, 2)));
        }

        [Test]
        public void GetPerimeterOfSeveralShapes_NegativeInput_ReturnsZero()
        {
            // Arrange
            var geoThings = new IGeomatricThing[]
            {
                new Square(0),
                new Circle(-13563f),
            };
            var expected = 0;
            var geoCal = new GeomatricCalculator();
            
            // Act
            var actual = geoCal.CalculatePerimeter(geoThings);

            // Assert
            Assert.That(MathF.Round(actual, 2), Is.EqualTo(MathF.Round(expected, 2)));
        }
    }
}
