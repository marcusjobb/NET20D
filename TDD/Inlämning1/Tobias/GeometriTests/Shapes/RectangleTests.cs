using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geometri.Shapes.Tests
{
    [TestClass()]
    public class RectangleTests
    {
        [TestMethod()]
        [DataRow(1f,1f,1f)]
        public void AreaTest01_CalcutesAreaByHeigthAndWidth_ReturnsArea(
            float heigth,float width,float expected)
        {
            //Arrange
            var rectangle = new Rectangle(heigth,width);
            //Act
            var actual = rectangle.Area();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(null, 1f, 0f)]
        public void AreaTest02_CalcutesAreaByHeigthAndWidthWithNegativeValuesAndNull_ReturnsArea(
           float heigth, float width, float expected)
        {
            //Arrange
            var rectangle = new Rectangle(heigth, width);
            //Act
            var actual = rectangle.Area();
            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        [DataRow(1f,1f,4f)]
        public void PerimeterTest01_CalculatePerimeterByHeigthAndWidth_ReturnsPerimeter(
            float heigth,float width,float expected)
        {
            //Arrange
            var rectangle = new Rectangle(heigth, width);
            //Act
            var actual = rectangle.Perimeter();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(1f, null, 0f)]
        public void PerimeterTest02_CalculatePerimeterByHeigthAndWidthWithNegtiveValueAndNull_ReturnsPerimeter(
            float heigth, float width, float expected)
        {
            //Arrange
            var rectangle = new Rectangle(heigth, width);
            //Act
            var actual = rectangle.Perimeter();
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}