namespace TDDInlamning1_MLarsson.GeometricThings.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class TriangleTests
    {
        [TestMethod()]
        [DataRow(0f, 4f, 0f)]
        [DataRow(-6f, 4f, 0f)]
        [DataRow(-6f, -4f, 0f)]
        [DataRow(null, null, 0f)]
        public void GetArea_TriangleTest_NegativeResult(float tbase, float height, float expected)
        {
            GeometricThing triangle = new Triangle(tbase, height);
            var actual = triangle.GetArea();
            Assert.AreEqual(expected, actual, 0.0001);
        }

        [TestMethod()]
        [DataRow(6f, 4f, 12f)]
        [DataRow(6.12345f, 4.12345f, 12.6249f)]
        public void GetArea_TriangleTest_PositiveResult(float tbase, float height, float expected)
        {
            GeometricThing triangle = new Triangle(tbase, height);
            var actual = triangle.GetArea();
            Assert.AreEqual(expected, actual, 0.0001);
        }
        [TestMethod()]
        [DataRow(-6f, 4f, 0f)]
        [DataRow(null, null, 0f)]
        public void GetPerimeter_TriangleTest_NegativeResult(float tbase, float height, float expected)
        {
            GeometricThing triangle = new Triangle(tbase, height);
            var actual = triangle.GetPerimeter();
            Assert.AreEqual(expected, actual, 0.0001);
        }

        [TestMethod()]
        [DataRow(6f, 4f, 14f)]
        [DataRow(0f, 4f, 8f)]
        [DataRow(6.123456789f, 4.123456789f, 14.3704f)]
        public void GetPerimeter_TriangleTest_PositiveResult(float tbase, float height, float expected)
        {
            GeometricThing triangle = new Triangle(tbase, height);
            var actual = triangle.GetPerimeter();
            Assert.AreEqual(expected, actual, 0.0001);
        }
    }
}