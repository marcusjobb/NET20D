namespace Geometric.Figures.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class RectangleTests
    {
        [TestMethod()]
        public void GetArea_PositiveNumber_Calculated()
        {
            var rectangle = new Rectangle(height: 2.7F, rBase: 4.5F);
            var expected = 12.15F;
            var actual = rectangle.GetArea();
            Assert.AreEqual(expected, actual, 0.00001);
        }

        [TestMethod()]
        public void GetPerimeter_PositiveNumber_Calculated()
        {
            var rectangle = new Rectangle(height: 1.5F, rBase: 7.2F);
            var expected = 17.4F;
            var actual = rectangle.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }
    }
}