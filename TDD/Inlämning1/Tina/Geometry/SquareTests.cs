using NUnit.Framework;
using System;

namespace TDD_TinaEriksson
{
    public class SquareTests
    {
        [Test]
        [TestCase(1.5f, 2.25f)]
        [TestCase(4.0f, 16.0f)]
        public void GetAreaTest_PositiveInput_ReturnsArea(float side, float expected)
        {
            // Arrange
            Square square = new Square(side);

            // Act
            var actual = square.GetArea();

            // Assert
            Assert.That(MathF.Round(actual, 2), Is.EqualTo(MathF.Round(expected, 2)));
        }

        [Test]
        [TestCase(-1.0f, 0)]
        [TestCase(-10.0f, 0)]
        [TestCase(0.00001f, 0)]
        public void GetAreaTest_NegativeInput_ReturnsZero(float side, float expected)
        {
            // Arrange
            Square square = new Square(side);

            // Act
            var actual = square.GetArea();

            // Assert
            Assert.That(MathF.Round(actual, 2), Is.EqualTo(MathF.Round(expected, 2)));
        }

        [Test]
        [TestCase(1f, 4f)]
        [TestCase(2.5f, 10.0f)]
        public void GetParimeterTest_PositiveInput_ReturnsPerimeter(float side, float expected)
        {
            // Arrange
            Square square = new Square(side);

            // Act
            var actual = square.GetPerimeter();

            // Assert
            Assert.That(MathF.Round(actual, 2), Is.EqualTo (MathF.Round(expected, 2)));
        }

        [Test]
        [TestCase(-4.5f, 0)]
        [TestCase(0.00f, 0)]
        [TestCase(-123.211f, 0)]
        public void GetParimeterTest_NegativeInput_ReturnsZero(float side, float expected)
        {
            Square square = new Square(side);
            var actual = square.GetPerimeter();
            Assert.That(MathF.Round(actual, 2), Is.EqualTo(MathF.Round(expected, 2)));
        }

    }
}