namespace GeometricJesperPersson.Calculator.Tests
{
    using GeometricJesperPersson.Shapes;
    using GeometricJesperPersson.Shapes.Triangles;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class GeometricCalculatorGetPerimeterArrayTests
    {
        public GeometricThing[] arrayOfGeo = {new Square(5), new Circle(2.0690142602f), new RightTriangle(4, 5, 6),
                new IsosclesTriangle(6,5), new EquilateralTriangle(5), new Rectangle(4, 5) };

        public GeometricThing[] arrayOfGeoMax = {new Square(float.MaxValue/5), new Circle(5), new RightTriangle(4, 5, 6),
                new IsosclesTriangle(6,5), new EquilateralTriangle(float.MaxValue/5), new Rectangle(float.MaxValue/3, 5) };

        public GeometricThing[] arrayOfGeoOneIsMinus = {new Square(-5), new Circle(2.0690142602f), new RightTriangle(4, 5, 6),
                new IsosclesTriangle(6,5), new EquilateralTriangle(5), new Rectangle(4, 5) };

        // GetPerimeterTest_Array_01
        [TestMethod]
        public void GetPerimeterTest_Array()
        {
            GeometricCalculator calc = new GeometricCalculator();
            var actual = calc.GetPerimeter(arrayOfGeo);
            const float expected = 97f;
            Assert.AreEqual(expected, actual);
        }

        // // GetPerimeterTest_Array_02
        [TestMethod]
        public void GetPerimeterTest_Array_OneFigureIsMinus()
        {
            GeometricCalculator calc = new GeometricCalculator();
            var actual = calc.GetPerimeter(arrayOfGeoOneIsMinus);
            const float expected = 0.0f;
            Assert.AreEqual(expected, actual);
        }

        // GetPerimeterTest_Array_03
        [TestMethod]
        public void GetPerimeterTest_ArrayMax()
        {
            GeometricCalculator calc = new GeometricCalculator();
            var actual = calc.GetPerimeter(arrayOfGeoMax);
            const float expected = 0.0f;
            Assert.AreEqual(expected, actual);
        }

        // GetPerimeterTest_Array_04
        [TestMethod]
        public void GetPerimeterTest_Array_IsNULL()
        {
            GeometricCalculator calc = new GeometricCalculator();
            GeometricThing[] empty = null;
            var actual = calc.GetPerimeter(empty);
            const float expected = 0.0f;
            Assert.AreEqual(expected, actual);
        }
    }
}