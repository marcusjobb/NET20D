namespace Geometric.Figures.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class CircleTests
    {
        [TestMethod()]
        public void GetArea_PositiveNumber_Calculated()
        {
            var circle = new Circle(radius: 2.4F);
            var expected = 18.09557368467720768F;
            var actual = circle.GetArea();
            Assert.AreEqual(expected, actual, 0.00001);
        }

        [TestMethod()]
        public void GetPerimeter_PositiveNumber_Calculated()
        {
            var circle = new Circle(radius: 3.6F);
            var expected = 22.6194671058465096F;
            var actual = circle.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }
    }
}