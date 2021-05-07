using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDDgeometric.Models.Tests
{
    [TestClass()]
    public class IsocelesTriangleTests
    {
        //Tests GetArea method for IsocelesTriangle objects with negative input, should return zero
        [TestMethod()]
        [DataRow (0, 0)]
        [DataRow(-1, 0)]
        [DataRow(-1.5f, 0)]
        [DataRow(float.MaxValue, 0)]
        public void GetArea_Negative_ShouldReturnZero(float inputData, float expected)
        {
            var calc = new IsocelesTriangle(inputData);
            var actual = calc.GetArea();
            Assert.AreEqual(expected, actual);
        }

        //Tests GetArea method for IsocelesTriangle objects with negative input, should return area of triangle
        [TestMethod()]
        [DataRow(5, 10.83f)]
        [DataRow(7.3f, 23.08f)]
        public void GetArea_Positive_ShouldReturnArea(float inputData, float expected)
        {
            var calc = new IsocelesTriangle(inputData);
            var actual = calc.GetArea();
            Assert.AreEqual(expected, actual);
        }

        //Tests GetPerimiter method for IsocelesTriangle objects with negative input, should return zero
        [TestMethod()]
        [DataRow(0, 0)]
        [DataRow(-1, 0)]
        [DataRow(-1.5f, 0)]
        [DataRow(float.MaxValue, 0)]
        public void GetPerimiter_Negative_ShouldReturnZero(float inputData, float expected)
        {
            var calc = new IsocelesTriangle(inputData);
            var actual = calc.GetPerimiter();
            Assert.AreEqual(expected, actual);
        }

        //Tests GetPerimiter method for IsocelesTriangle objects with negative input, should return perimiter of triangle
        [TestMethod()]
        [DataRow(5, 15)]
        [DataRow(4.5f, 13.5f)]
        public void GetPerimiter_Positive_ShouldReturnArea(float inputData, float expected)
        {
            var calc = new IsocelesTriangle(inputData);
            var actual = calc.GetPerimiter();
            Assert.AreEqual(expected, actual);
        }
    }
}