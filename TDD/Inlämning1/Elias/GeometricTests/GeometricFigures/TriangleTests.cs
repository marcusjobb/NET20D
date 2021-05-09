namespace Geometric.Figures.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class TriangleTests
    {
        [TestMethod()]
        public void GetArea_PositiveNumber_Calculated()
        {
            var triangle = new Triangle(height: 2.2F, tBase: 4.7F);
            var expected = 5.17F;
            var actual = triangle.GetArea();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetPerimeter_PositiveNumber_Calculated()
        {
            var triangle = new Triangle(height: 1.7F, tBase: 5.3F);
            var expected = 15.9F;
            var actual = triangle.GetPerimeter();
            Assert.AreEqual(expected, actual, 0.00001);
        }
    }
}