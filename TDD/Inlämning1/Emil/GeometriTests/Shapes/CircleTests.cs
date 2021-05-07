using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geometri.Shapes.Tests
{
    [TestClass()]
    public class CircleTests
    {
        [TestMethod()]
        [DataRow(1f, 3.14f)]
        public void AreaTest01_CalculateTheAreaByRadius_ReturnArea(float radius, float expected)
        {
            // Arrange
            var circle = new Circle(radius);
            // Act
            var actual = circle.Area();
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(null, 0)]
        public void AreaTest02_CalculateWithNegativeValueAndNull_ReturnZero(float radius, float expected)
        {
            // Arrange
            var circle = new Circle(radius);
            // Act
            var actual = circle.Area();
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(2f, 12.57f)]
        public void PerimeterTest01_CalculateThePerimeterByRAdius_ReturnPerimeter(float radius, float expected)
        {
            // Arrange
            var circle = new Circle(radius);
            // Act
            var actual = circle.Perimeter();
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(-1f, 0)]
        public void PerimeterTest02_CalculateWithNegativeValueAndNull_ReturnZero(float radius, float expected)
        {
            // Arrange
            var circle = new Circle(radius);
            // Act
            var actual = circle.Perimeter();
            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}