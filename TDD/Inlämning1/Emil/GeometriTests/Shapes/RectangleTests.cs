using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geometri.Shapes.Tests
{
    [TestClass()]
    public class RectangleTests
    {
        [TestMethod()]
        [DataRow(1f, 1f, 1f)]
        public void AreaTest01_CalculateAreaByHeightAndWidth_ReturnsArea(
            float height, float width, float expected)
        {
            // Arrange
            var rectangle = new Rectangle(height, width);
            // Act
            var actual = rectangle.Area();
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(null, -1f, 0f)]
        public void AreaTest02_CalculateAreaByHeightAndWidthWithNegativeValuesAndNull_ReturnsArea(
            float height, float width, float expected)
        {
            // Arrange
            var rectangle = new Rectangle(height, width);
            // Act
            var actual = rectangle.Area();
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(1f, 1f, 4f)]
        public void PerimeterTest01_CalculatePerimeterByHeightAndWidth_RetrunsPerimeter(
            float height, float width, float expected)
        {
            // Arrange
            var rectangle = new Rectangle(height, width);
            // Act
            var actual = rectangle.Perimeter();
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(1f, null, 0f)]
        public void PerimeterTest02_CalculatePerimeterByHeightAndWidthAndWidthWithNegativeValueNull_RetrunsPerimeter(
         float height, float width, float expected)
        {
            // Arrange
            var rectangle = new Rectangle(height, width);
            // Act
            var actual = rectangle.Perimeter();
            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}