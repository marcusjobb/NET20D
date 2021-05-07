namespace TDDInlamning1_MLarsson.GeometricThings.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class RectangleTests
    {
        [TestMethod()]
        [DataRow(0f, 2f, 0f)]
        [DataRow(-5f, 2f, 0f)]
        [DataRow(-5f, -2f, 0f)]
        [DataRow(null, null, 0f)]
        public void GetArea_RectangleTest_NegativeResult(float width, float height, float expected)
        {
            GeometricThing rectangle = new Rectangle(width, height);
            var actual = rectangle.GetArea();
            Assert.AreEqual(expected, actual, 0.0001);
        }

        [TestMethod()]
        [DataRow(3f, 2f, 6f)]
        [DataRow(5.1234567f, 2.1234567f, 10.8794f)]
        public void GetArea_RectangleTest_PostiveResult(float width, float height, float expected)
        {
            GeometricThing rectangle = new Rectangle(width, height);
            var actual = rectangle.GetArea();
            Assert.AreEqual(expected, actual, 0.0001);
        }
        [TestMethod()]
        [DataRow(-5f, 2f, 0f)]
        [DataRow(-5f, -2f, 0f)]
        [DataRow(null, null, 0f)]
        public void GetPerimeter_RectangleTest_NegativeResult(float width, float height, float expected)
        {
            GeometricThing rectangle = new Rectangle(width, height);
            var actual = rectangle.GetPerimeter();
            Assert.AreEqual(expected, actual, 0.0001);
        }

        [TestMethod()]
        [DataRow(3f, 2f, 10f)]
        [DataRow(0f, 2f, 4f)]
        [DataRow(5.12345f, 2.12345f, 14.4938f)]
        public void GetPerimeter_RectangleTest_PositiveResult(float width, float height, float expected)
        {
            GeometricThing rectangle = new Rectangle(width, height);
            var actual = rectangle.GetPerimeter();
            Assert.AreEqual(expected, actual, 0.0001);
        }
    }
}