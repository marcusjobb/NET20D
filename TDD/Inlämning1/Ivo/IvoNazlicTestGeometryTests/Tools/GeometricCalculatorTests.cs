using IvoNazlicTestGeometry.GeometryObjects;
using IvoNazlicTestGeometry.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IvoNazlicTestGeometry.Tools.Tests
{
    [TestClass()]
    public class GeometricCalculatorTests
    {

        [TestMethod()]
        public void GetCircumferenceTest()
        {
            var calc = new GeometricCalculator();
            var actual = calc.GetCircumference(new IGeometricThing[]
            {
               new Square(10),
               new Circle(2),
               new Rectangle(2, 4),
               new Triangle(4)
            });

            var expected = 40 + 6.2832f + 12 + 12;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCircumferenceTest0()
        {
            var calc = new GeometricCalculator();
            var actual = calc.GetCircumference(new IGeometricThing[]
            {
               new Square(0.0f),
               new Circle(0.0f),
               new Rectangle(0, 0.0f),
               new Triangle(0)
            });

            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCircumferenceTestNull()
        {
            var calc = new GeometricCalculator();
            var actual = calc.GetCircumference(new IGeometricThing[]{null});
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }


    }
}