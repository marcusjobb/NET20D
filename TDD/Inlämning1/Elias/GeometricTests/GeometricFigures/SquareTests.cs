namespace Geometric.Figures.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class SquareTests
    {
        [TestMethod()]
        public void GetArea_PositiveNumber_Calculated()
        {
            var square = new Square(side: 6.6F);
            var expected = 43.56F;
            var actual = square.GetArea();
            Assert.AreEqual(expected, actual, 0.00001);
        }

        [TestMethod()]
        public void GetPerimeter_PositiveNumber_Calculated()
        {
            var square = new Square(side: 8.3F);
            var expected = 33.2F;
            var actual = square.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }
    }
}