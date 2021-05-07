namespace TDDInlamning1_MLarsson.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TDDInlamning1_MLarsson;
    using TDDInlamning1_MLarsson.GeometricThings;

    [TestClass()]
    public class GeometricCalculatorTests
    {
        private readonly GeometricCalculator geoCal = new GeometricCalculator();

        [TestMethod()]
        public void GetArea_ReciveNullObjectTest()
        {
            GeometricThing empty = null;
            var actual = geoCal.GetArea(empty);
            const float expected = 0;
            Assert.AreEqual(expected, actual, 0.0001);
        }

        [TestMethod()]
        [DataRow(new float[] { 5f, 6f, 5f, 6f, 6f, 10f }, 258.0973f)]
        [DataRow(new float[] { 0f, 0f, 5f, 6f, 6f, 10f }, 228.0973f)]
        public void GetArea_SumArrayTest(float[] arr, float expected)
        {
            var geoThings = new GeometricThing[] {
                new Rectangle(arr[0], arr[1]),
                new Triangle(arr[2], arr[3]),
                new Circle(arr[4]),
                new Square(arr[5]) };
            var actual = geoCal.GetArea(geoThings);
            Assert.AreEqual(expected, actual, 0.0001);
        }

        [TestMethod()]
        public void GetAreaTest_NullArray()
        {
            const float expected = 0;
            var actual = geoCal.GetArea(new GeometricThing[] { });
            Assert.AreEqual(expected, actual, 0.0001);
        }

        [TestMethod()]
        public void GetPerimeter_ReciveNullObjectTest()
        {
            GeometricThing empty = null;
            var actual = geoCal.GetPerimeter(empty);
            const float expected = 0;
            Assert.AreEqual(expected, actual, 0.0001);
        }

        [TestMethod()]
        [DataRow(new float[] { 5f, 6f, 5f, 6f, 6f, 7f }, 104.6991f)]
        [DataRow(new float[] { 0f, 0f, 5f, 6f, 6f, 7f }, 82.6991f)]
        public void GetPerimeter_SumArrayTest(float[] arr, float expected)
        {
            var geoThings = new GeometricThing[] {
                new Rectangle(arr[0], arr[1]),
                new Triangle(arr[2], arr[3]),
                new Circle(arr[4]),
                new Square(arr[5]) };
            var actual = geoCal.GetPerimeter(geoThings);
            Assert.AreEqual(expected, actual, 0.0001);
        }

        [TestMethod()]
        public void GetPerimeterTest_NullArray()
        {
            const float expected = 0;
            var actual = geoCal.GetPerimeter(new GeometricThing[] { });
            Assert.AreEqual(expected, actual, 0.0001);
        }
    }
}
