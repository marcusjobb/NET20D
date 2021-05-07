using Inlämning1.Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inlämning1.Shapes.Tests
{
    [TestClass()]
    public class RectangleTests
    {
        [TestMethod()]
        public void RectangleTest()
        {
            // Arrange
            var expected = 25;
            // Act
            var fyrkant = new Rectangle(height: 5, widht: 5);
            var acctual = GeometricCalculator.GetArea(fyrkant);
            //Assert
            Assert.AreEqual(expected, acctual);
        }
    }
}