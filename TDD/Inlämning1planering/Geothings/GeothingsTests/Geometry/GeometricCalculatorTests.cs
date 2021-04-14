using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geothings.Geometry;
using Geothings.Interfaces;

namespace Geothings.Geometry.Tests
{
    [TestClass()]
    public class GeometricCalculatorTests
    {
        [TestMethod()]
        [DataRow()]
        public void GetPerimeterTest()
        {
            var calc = new GeometricCalculator();
            var actual = calc.GetPerimeter(new GemetricThing[]
            {
               new Square(10),
            });
        }
    }
}