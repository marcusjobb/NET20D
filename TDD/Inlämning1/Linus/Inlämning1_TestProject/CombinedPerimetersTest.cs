namespace ProjectTests
{
    using GeometryProject;
    using GeometryProject.GeoModels;
    using GeometryProject.GeoModels.Triangles;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CombinedPerimetersTest
    {
        // Test to see that the perimeter of all shapes combined is correct.
        [TestMethod]
        public void TestGetPerimeters()
        {
            var geometricalFigures = new GeometricThing[] { new EquailateralTriangle(side: 5f), new Square(side: 5f), new Rectangle(hight: 5f, width: 10f), new Circle(radius: 5f) };
            var calc = new GeometricCalculator();
            var actual = calc.GetPerimeters(geometricalFigures);
            var expected = 96.42f;
            Assert.AreEqual(expected, actual);
        }

        // Test to see that a minus value on one of the shapes is returned as float default value instead of crash.
        [TestMethod]
        public void TestPerimeters_MinusValue()
        {
            var geometricalFigures = new GeometricThing[] { new EquailateralTriangle(side: -5f), new Square(side: 5f), new Rectangle(hight: 5f, width: 10f), new Circle(radius: 5f) };
            var calc = new GeometricCalculator();
            var actual = calc.GetPerimeters(geometricalFigures);
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        // Test to see that a value above float.max is returned as float default value instead of crash.
        [TestMethod]
        public void TestPerimeters_MaxValue()
        {
            var geometricalFigures = new GeometricThing[] { new EquailateralTriangle(side: float.MaxValue), new Square(side: 5f), new Rectangle(hight: 5f, width: 10f), new Circle(radius: 5f) };
            var calc = new GeometricCalculator();
            var actual = calc.GetPerimeters(geometricalFigures);
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        // Test to see that a empty array returns float default value instead of crash.
        [TestMethod]
        public void TestPerimeters_Empty()
        {
            var geometricalFigures = new GeometricThing[] { };
            var calc = new GeometricCalculator();
            var actual = calc.GetPerimeters(geometricalFigures);
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        // Test to see that a null-array returns float default value instead of null error.
        [TestMethod]
        public void TestPerimeters_Null()
        {
            var geometricalFigures = new GeometricThing[] { new EquailateralTriangle(side: float.MaxValue), new Square(side: 5f), new Rectangle(hight: 5f, width: 10f), new Circle(radius: 5f) };
            geometricalFigures = null;
            var calc = new GeometricCalculator();
            var actual = calc.GetPerimeters(geometricalFigures);
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }
    }
}