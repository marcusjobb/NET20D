using NUnit.Framework;
using System;

namespace TDD_TinaEriksson
{
    public class CircleTests
    {
        [Test]
        [TestCase(5.5f, 95.03f)]
        [TestCase(3.5f, 38.48f)]
        public void GetAreaTest_PositiveInput_ReturnsArea(float radius, float expected)
        {
            Circle circle = new Circle(radius);
            var actual = circle.GetArea();
            Assert.That(MathF.Round(actual, 2), Is.EqualTo(MathF.Round(expected, 2)));
        }

        [Test]
        [TestCase(-21.321f, 0)]
        [TestCase(0, 0)]
        [TestCase(-1234, 0)]
        public void GetAreaTest_NegativeInput_ReturnsZero(float radius, float expected)
        {
            Circle circle = new Circle(radius);
            var actual = circle.GetArea();
            Assert.That(MathF.Round(actual, 2), Is.EqualTo(MathF.Round(expected, 2)));
        }

        [Test]
        [TestCase(5.5f, 34.56f)]
        [TestCase(10.2f, 64.09f)]
        public void GetParimeterTest_PositiveInput_ReturnsParimeter(float radius, float expected)
        {
            Circle circle = new Circle(radius);
            var actual = circle.GetPerimeter();
            Assert.That(MathF.Round(actual, 2), Is.EqualTo(MathF.Round(expected, 2)));
        }

        [Test]
        [TestCase(-3123.23f, 0)]
        [TestCase(0, 0)]
        [TestCase(-1.0012f, 0)]
        public void GetParimeterTest_NegativeInput_ReturnsZero(float radius, float expected)
        {
            Circle circle = new Circle(radius);
            var actual = circle.GetPerimeter();
            Assert.That(MathF.Round(actual, 2), Is.EqualTo(MathF.Round(expected, 2)));
        }
    }
}