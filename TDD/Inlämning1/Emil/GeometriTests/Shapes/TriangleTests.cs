using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geometri.Shapes.Tests
{
    [TestClass()]
    public class TriangleTests
    {
        [TestMethod()]
        [DataRow(1f, 0.43f)]
        public void AreaTest01_CalculateAreaBySide_ReturnArea(float side, float expected)
        {
            // Arrange
            var triangle = new Triangle(side);
            // Act
            var actual = triangle.Area();
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(null, 0f)]
        public void AreaTest02_CalculateAreaBySideWithNegativeAndNullVAlues_ReturnZero(float side, float expected)
        {
            // Arrange
            var triangle = new Triangle(side);
            // Act
            var actual = triangle.Area();
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(1f, 3f)]
        public void PerimeterTest01_CalculatePerimeterBySide_ReturnPerimeter(float side, float expected)
        {
            // Arrange
            var triangle = new Triangle(side);
            // Act
            var actual = triangle.Perimeter();
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(-1f, 0f)]
        public void PerimeterTest02_CalculatePerimeterBySideWithNegativeAndNullValues_ReturnZero(float side, float expected)
        {
            // Arrange
            var triangle = new Triangle(side);
            // Act
            var actual = triangle.Perimeter();
            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}