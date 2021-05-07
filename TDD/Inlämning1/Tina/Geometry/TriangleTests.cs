using NUnit.Framework;
using System;

namespace TDD_TinaEriksson
{
    public class TriangleTests
    {
        [Test]
        [TestCase(2.0f, 4.0f, 4.0f)]
        [TestCase(2.5f, 4.8f, 6.0f)]
        public void GetAreaTest_PositiveInput_ReturnsArea(float trianglebase, float height, float expected)
        {
            // Arrange
            Triangle triangle = new Triangle(trianglebase, height);
            // Act
            var actual = triangle.GetArea();
            // Assert
            Assert.That(MathF.Round(actual, 2), Is.EqualTo(MathF.Round(expected, 2)));
        }
        [Test]
        [TestCase(-1.1f, -2.3f, 0)]
        [TestCase(0.0f, 0.0f, 0)]
        [TestCase(-1.5f, 0, 0)]
        public void GetAreaTest_NegativeInput_ReturnsZero(float triangleBase, float height, float expected)
        {
            // Arrange
            Triangle triangle = new Triangle(triangleBase, height);
            // Act
            var actual = triangle.GetArea();
            // Assert
            Assert.That(MathF.Round(actual, 2), Is.EqualTo(MathF.Round(expected, 2)));
        }

        [Test]
        [TestCase(3.0f, 4.5f, 12.0f)]
        [TestCase(4.01f, 12.1f, 28.21f)]
        public void GetPerimeterTest_PositiveInput_ReturnsParimeter(float triangleBase, float height, float expected)
        {
            Triangle triangle = new Triangle(triangleBase, height);
            var actual = triangle.GetPerimeter();
            Assert.That(MathF.Round(actual, 2), Is.EqualTo(MathF.Round(expected, 2)));
        }

        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(-0.721f, -12f, 0)]
        [TestCase(-1.1234f, 0, 0)]
        public void GetParimeterTest_NegativeInput_ReturnsZero(float triangleBase, float height, float expected)
        {
            Triangle triangle = new Triangle(triangleBase, height);
            var actual = triangle.GetPerimeter();
            Assert.That(MathF.Round(actual, 2), Is.EqualTo(Math.Round(expected, 2)));
        }
    }
}
