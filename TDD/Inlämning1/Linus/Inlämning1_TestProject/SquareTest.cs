namespace ProjectTest
{
    using GeometryProject.GeoModels;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SquareTest
    {
        // Testing if method to get area returns the value it is supposed to return.
        [TestMethod]
        public void TestGetSquareArea()
        {
            var testSquare = new Square(5f);
            var actual = testSquare.GetArea();
            var expected = 25f;
            Assert.AreEqual(expected, actual);
        }

        // Testing if method to get perimeter returns the value it is supposed to return.
        [TestMethod]
        public void TestGetSquarePerimeter()
        {
            var testSquare = new Square(5f);
            var actual = testSquare.GetPerimeter();
            var expected = 20f;
            Assert.AreEqual(expected, actual);
        }

        // Several test cases for GetArea-method. Test to see that method does not crash with invalid inputs.
        [TestMethod]
        [DataRow(-5f)]
        [DataRow(float.MaxValue + 20)]
        [DataRow(0)]
        public void TestCases_SquareArea(float numTest)
        {
            var testSquare = new Square(numTest);
            var actual = testSquare.GetArea();
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        // Several test cases for GetPerimeter-method. Test to see that method does not crash with invalid inputs.
        [TestMethod]
        [DataRow(-5f)]
        [DataRow(float.MaxValue + 20)]
        [DataRow(0)]
        public void TestCases_SquarePerimeter(float numTest)
        {
            var testSquare = new Square(numTest);
            var actual = testSquare.GetPerimeter();
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }
    }
}