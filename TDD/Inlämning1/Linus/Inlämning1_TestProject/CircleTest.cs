namespace ProjectTest
{
    using GeometryProject;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CircleTest
    {
        // Testing if method to get area returns the value it is supposed to return.
        [TestMethod]
        public void TestGetCircleArea()
        {
            var testCircle = new Circle(5f);
            var actual = testCircle.GetArea();
            var expected = 78.54f;
            Assert.AreEqual(expected, actual);
        }

        // Testing if method to get area returns the value it is supposed to return.
        [TestMethod]
        public void TestGetCirclePerimeter()
        {
            var testCircle = new Circle(5f);
            var actual = testCircle.GetPerimeter();
            var expected = 31.42f;
            Assert.AreEqual(expected, actual);
        }

        // Several test cases for GetArea-method. Test to see that method does not crash with invalid inputs.
        [TestMethod]
        [DataRow(-2f)]
        [DataRow(float.MaxValue + 1)]
        [DataRow(0f)]
        public void CircleArea_TestCases(float numTest)
        {
            var testCircle = new Circle(numTest);
            var actual = testCircle.GetPerimeter();
            var expected = 0f;
            Assert.AreEqual(expected, actual);
        }

        // Several test cases for GetPerimeter-method. Test to see that method does not crash with invalid inputs.
        [TestMethod]
        [DataRow(-2f)]
        [DataRow(float.MaxValue + 1)]
        [DataRow(0f)]
        public void CirclePerimeter_TestCases(float numTest)
        {
            var testCircle = new Circle(numTest);
            var actual = testCircle.GetPerimeter();
            var expected = 0f;
            Assert.AreEqual(expected, actual);
        }
    }
}