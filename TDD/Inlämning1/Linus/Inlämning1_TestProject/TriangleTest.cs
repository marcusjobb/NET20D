namespace ProjectTest
{
    using GeometryProject.GeoModels.Triangles;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TriangleTest
    {
        // Testing if method to get area returns the value it is supposed to return.
        [TestMethod]
        public void TestGetTriangleArea()
        {
            var testTriangel = new EquailateralTriangle(5);
            var actual = testTriangel.GetArea();
            var expected = 10.82f;
            Assert.AreEqual(expected, actual);
        }

        // Testing if method to get perimeter returns the value it is supposed to return.
        [TestMethod]
        public void TestGetTrianglePerimeter()
        {
            var testTriangel = new EquailateralTriangle(15);
            var actual = testTriangel.GetPerimeter();
            var expected = 45f;
            Assert.AreEqual(expected, actual);
        }

        // Several test cases for GetArea-method. Test to see that method does not crash with invalid inputs.
        [TestMethod]
        [DataRow(-10f)]
        [DataRow(float.MaxValue + 1)]
        [DataRow(0f)]
        public void TestCases_TriangleArea(float side)
        {
            var testTriangel = new EquailateralTriangle(side);
            var actual = testTriangel.GetArea();
            var expected = 0f;
            Assert.AreEqual(expected, actual);
        }

        // Several test cases for GetPerimeter-method. Test to see that method does not crash with invalid inputs.
        [TestMethod]
        [DataRow(-10f)]
        [DataRow(float.MaxValue + 1)]
        [DataRow(0f)]
        public void TestCases_TrianglePerimeter(float side)
        {
            var testTriangel = new EquailateralTriangle(side);
            var actual = testTriangel.GetPerimeter();
            var expected = 0f;
            Assert.AreEqual(expected, actual);
        }
    }
}