using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geometri.Shapes.Tests
{
    [TestClass()]
    public class SquareTests
    {
        [TestMethod()]
        [DataRow(2f, 4f)]
        public void AreaTest01_CalculateAreBySide_ReturnsTheArea(float side, float expected)
        {
            // Arrange
            var square = new Square(side);
            // Act
            var actual = square.Area();
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(-1f, 0f)]
        public void AreaTest02_CalculateAreBySideWithNegativeAndNullVAlues_ReturnsTheArea(float side, float expected)
        {
            // Arrange
            var square = new Square(side);
            // Act
            var actual = square.Area();
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(1f, 4f)]
        public void PerimeterTest01_CalculatePerimeterBySide_ReturnsPerimeter(float side, float expected)
        {
            // Arrange
            var square = new Square(side);
            // Act
            var actual = square.Perimeter();
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(-1f, 0f)]
        public void PerimeterTest02_CalculatePerimeterBySideWithNegativeAndNullVAlues_ReturnsPerimeter(float side, float expected)
        {
            // Arrange
            var square = new Square(side);
            // Act
            var actual = square.Perimeter();
            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}