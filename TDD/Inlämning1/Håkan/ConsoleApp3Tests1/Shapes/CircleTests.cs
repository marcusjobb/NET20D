using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConsoleApp3.Shapes.Tests
{
    [TestClass()]
    public class CircleTests
    {
        [TestMethod()]
        [DataRow(1f, 3.14159265359f)]
        [DataRow(2f, 12.566370614359f)]
        [DataRow(3f, 28.274333882308f)]
        public void CalculatesArea_OfCircle_ReturnsArea(float radius, float expected)
        {
            // Arrange
            var circle = new Circle(radius);

            // Act

            var actual = circle.Area();
            // Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(1f, 6.28318530718f)]
        [DataRow(2f, 12.566370614359f)]
        [DataRow(4f, 25.132741228718f)]
        public void CalculatesPerimeter_OfCircle_ReturnsPerimeter(float radius, float expected)
        {
            // Arrange
            var circle = new Circle(radius);

            // Act

            var actual = circle.Perimeter();

            // Assert
            Assert.AreEqual(MathF.Round(expected, 2, MidpointRounding.ToEven), MathF.Round(actual, 2, MidpointRounding.ToEven));
        }
    }
}