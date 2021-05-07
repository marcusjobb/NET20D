namespace ProjectTest
{
    using GeometryProject;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RectangleTest
    {
        // Testing if method to get area returns the value it is supposed to return.
        [TestMethod]
        public void TestGetRectangleArea()
        {
            var testRectangle = new Rectangle(5f, 10f);
            var actual = testRectangle.GetArea();
            var expected = 50f;
            Assert.AreEqual(expected, actual);
        }

        // Testing if method to get perimeter returns the value it is supposed to return.
        [TestMethod]
        public void TestGetRectanglePerimeter()
        {
            var testRectangle = new Rectangle(5f, 10f);
            var actual = testRectangle.GetPerimeter();
            var expected = 30f;
            Assert.AreEqual(expected, actual);
        }

        // Several test cases for GetArea-method. Test to see that method does not crash with invalid inputs.
        [TestMethod]
        [DataRow(5f, -10f)]
        [DataRow(5f, float.MaxValue + 1)]
        [DataRow(0, 10)]
        public void TestCases_RectangleArea(float hight, float width)
        {
            var testRectangle = new Rectangle(hight, width);
            var actual = testRectangle.GetArea();
            var expected = 0f;
            Assert.AreEqual(expected, actual);
        }

        // Several test cases for GetPerimeter-method. Test to see that method does not crash with invalid inputs.
        [TestMethod]
        [DataRow(-5f, 10f)]
        [DataRow(5f, float.MaxValue + 1)]
        [DataRow(0, 10)]
        public void TestCases_RectanglePerimeter(float hight, float width)
        {
            var testRectangle = new Rectangle(hight, width);
            var actual = testRectangle.GetPerimeter();
            var expected = 0f;
            Assert.AreEqual(expected, actual);
        }
    }
}