using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDDgeometric.Models.Tests
{
    [TestClass()]
    public class SquareTests
    {
        //Tests GetArea method for Square objects with negative input, should return zero
        [TestMethod()]
        [DataRow(0,0)]
        [DataRow(-1, 0)]
        [DataRow(-100, 0)]
        [DataRow(float.MaxValue, 0)]
        public void GetArea_Negative_ShouldReturnZero(float inputData, float expected)
        {
            var calc = new Square(inputData);
            var actual = calc.GetArea();
            Assert.AreEqual(expected, actual);
        }

        //Tests GetArea method for Square objects with positive input, should return the square area
        [TestMethod()]
        [DataRow (4.7f, 22.09f)]
        [DataRow(5, 25)]
        public void GetArea_Positive_ShouldReturnArea(float inputData, float expected)
        {
            var calc = new Square(inputData);
            var actual = calc.GetArea();
            Assert.AreEqual(expected, actual);
        }

        //Tests GetPerimiter method for Square objects with negative input, should return zero
        [TestMethod()]
        [DataRow (0,0)]
        [DataRow(-4, 0)]
        [DataRow(float.MaxValue, 0)]
        public void GetPerimiter_Negative_ShouldReturnZero(float inputData, float expected)
        {
            var calc = new Square(inputData);
            var actual = calc.GetPerimiter();
            Assert.AreEqual(expected, actual);
        }

        //Tests GetPerimiter method for Square objects with positive input, should return the square perimiter
        [TestMethod()]
        [DataRow(4, 16)]
        [DataRow(1.7f, 6.8f)]
        public void GetPerimiter_Positive_ShouldReturnPerimiter(float inputData, float expected)
        {
            var calc = new Square(inputData);
            var actual = calc.GetPerimiter();
            Assert.AreEqual(expected, actual);
        }
    }
}