using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDDgeometric.Models.Tests
{
    [TestClass()]
    public class RectangleTests
    {
        //Tests GetArea method for rectangle objects with negative input, should return zero
        [TestMethod()]
        [DataRow(0, 0, 0)]
        [DataRow(-4, -2, 0)]
        [DataRow(float.MaxValue, float.MaxValue, 0)]
        public void GetArea_Negative_ShouldReturnZero(float inputData1, float inputData2, float expected)
        {
            var calc = new Rectangle(inputData1, inputData2);
            var actual = calc.GetArea();
            Assert.AreEqual(expected, actual);
        }

        //Tests GetArea method for rectangle objects with positive input, should return area of rectangle
        [TestMethod()]
        [DataRow(4, 2, 8)]
        [DataRow(4.4f, 2.5f, 11)]
        [DataRow(16.6f, 3.3f, 54.78f)]
        public void GetArea_Positive_ShouldReturnArea(float inputData1, float inputData2, float expected)
        {
            var calc = new Rectangle(inputData1, inputData2);
            var actual = calc.GetArea();
            Assert.AreEqual(expected, actual);
        }

        //Tests GetPermiter method for rectangle objects with negative input, should return zero
        [TestMethod()]
        [DataRow(0, 0, 0)]
        [DataRow(-1.5f, 5, 0)]
        [DataRow(7, -5.4f, 0)]
        [DataRow(float.MaxValue, float.MaxValue, 0)]
        public void GetPerimiter_Negative_ShouldReturnZero(float inputData1, float inputData2, float expected)
        {
            var calc = new Rectangle(inputData1, inputData2);
            var actual = calc.GetPerimiter();
            Assert.AreEqual(expected, actual);
        }

        //Tests GetArea method for rectangle objects with positive input, should return area of rectangle
        [TestMethod()]
        [DataRow(4, 4, 16)]
        [DataRow(4.2f, 4.9f, 18.2f)]
        public void GetPerimiter_Positive_ShouldReturnPerimiter(float inputData1, float inputData2, float expected)
        {
            var calc = new Rectangle(inputData1, inputData2);
            var actual = calc.GetPerimiter();
            Assert.AreEqual(expected, actual);
        }
    }
}