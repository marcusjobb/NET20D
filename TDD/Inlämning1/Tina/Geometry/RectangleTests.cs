using NUnit.Framework;
using System;

namespace TDD_TinaEriksson
{
    public class RectangleTests
    {
        [Test]
        [TestCase(4.0f, 2.0f, 8.0f)]
        [TestCase(6.45f, 3.35f, 21.61f)]
        public void GetAreaTest_PositiveInput_ReturnsArea(float width, float height, float expected)
        {
            // Arrange
            Rectangle rectangle = new Rectangle(width, height);
            // Act
            var actual = rectangle.GetArea();
            // Assert
            Assert.That(MathF.Round(actual, 2), Is.EqualTo(MathF.Round(expected, 2)));
        }

        [Test]
        [TestCase(-1.23f, -23.34f, 0)]
        [TestCase(-1.745f, -1.345f, 0)]
        [TestCase(0, -132f, 0)]
        public void GetAreaTest_NegativeInput_ReturnsZero(float width, float height, float expected)
        {
            Rectangle rectangle = new Rectangle(width, height);
            var actual = rectangle.GetArea();
            Assert.That(MathF.Round(actual, 2), Is.EqualTo(MathF.Round(expected, 2)));
        }

        [Test]
        [TestCase(4.0f, 2.5f, 13.0f)]
        [TestCase(6.0f, 3.5f, 19.0f)]
        public void GetParimeterTest_PositiveInput_ReturnsParimeter(float width, float height, float expected)
        {
            Rectangle rectangle = new Rectangle(width, height);
            var actual = rectangle.GetPerimeter();
            Assert.That(MathF.Round(actual, 2), Is.EqualTo(MathF.Round(expected, 2)));
        }

        [Test]
        [TestCase(-1.3f, -3.5f, 0)]
        [TestCase(-0.95f, -3.675f, 0)]
        [TestCase(-432, 0, 0)]
        public void GetParimeterTest_NegativeInput_ReturnsZero(float width, float height, float expected)
        {
            Rectangle rectangle = new Rectangle(width, height);
            var actual = rectangle.GetPerimeter();
            Assert.That(MathF.Round(actual, 2), Is.EqualTo(Math.Round(expected, 2)));
        }
    }
}
