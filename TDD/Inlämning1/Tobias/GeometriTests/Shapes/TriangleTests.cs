using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geometri.Shapes.Tests
{
    [TestClass()]
    public class TriangleTests
    {
        [TestMethod()]
        [DataRow(1f, 0.43f)]
        public void AreaTest01_CalculateAreaBySide_ReturnsArea(
            float side,float expected)
        {
            //Arrange
            var triangle = new Triangle(side);
            //Act
            var actual = triangle.Area();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(null, 0f)]
        public void AreaTest02_CalculateAreaBySideWithNegativeAndNullValues_ReturnsZero(
            float side, float expected)
        {
            //Arrange
            var triangle = new Triangle(side);
            //Act
            var actual = triangle.Area();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(1f,3f)]
        public void PerimeterTest01_CalculatePerimeterBySide_ReturnsPerimeter(
            float side, float expected)
        {
            //Arrange
            var triangle = new Triangle(side);
            //Act
            var actual = triangle.Perimeter();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(-1f, 0f)]
        public void PerimeterTest02_CalculatePerimeterBySideWithNegativeAndNullValues_ReturnsZero(
           float side, float expected)
        {
            //Arrange
            var triangle = new Triangle(side);
            //Act
            var actual = triangle.Perimeter();
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}