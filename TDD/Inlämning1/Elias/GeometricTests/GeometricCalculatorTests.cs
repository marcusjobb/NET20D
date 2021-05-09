namespace Geometric.Tests
{
    using Geometric.Figures;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class GeometricCalculatorTests
    {
        [TestMethod()]
        public void GetPerimeter_PositiveNumber_Calculated()
        {
            var geo = new GeometricCalculator();
            var array = new Shape[]
            {
                new Triangle(height:3F, tBase:7.8F ),
                new Square(side:5.4F),
                new Circle(radius:3.6F),
                new Rectangle(height:2.3F, rBase:7.9F)
            };

            var expected = 88.0194671058465096F;
            var actual = geo.GetPerimeter(array);
            Assert.AreEqual(expected, actual);
        }
    }
}