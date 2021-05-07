using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConsoleApp3.Shapes.Tests
{
    [TestClass()]
    public class SquareTests
    {
        [TestMethod()]
        [DataRow(1f, 1f)]
        [DataRow(2f, 4f)]
        [DataRow(4f, 16f)]
        public void Area_Calculation_OfSides_ReturnsArea(float side, float expected)
        {
            // Act
            var square = new Square(side);
            // Arrange
            var actual = square.Area();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(1f, 4f)]
        [DataRow(2f, 8f)]
        public void Perimeter_CalculatesSquarePerimeter_ReturnsPerimeter(float side, float expected)
        {
            var square = new Square(side);
            var actual = square.Perimeter();
            Assert.AreEqual(MathF.Round(expected, 2, MidpointRounding.ToEven), MathF.Round(actual, 2, MidpointRounding.ToEven));
        }
    }
}