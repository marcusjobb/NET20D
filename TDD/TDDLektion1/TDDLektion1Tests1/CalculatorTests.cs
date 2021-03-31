using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDLektion1;

namespace TDDLektion1.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        Calculator calc = new Calculator();
        [TestMethod()]
        public void AddTest_Add_One_Three()
        {
            var actual = calc.Add(1, 2);
            var expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddTest_Add_One_Five()
        {
            var actual = calc.Add(1, 5);
            var expected = 6;

            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void AddTest_Array_255()
        {
            var actual = calc.Add(new int[] { 2, 5, 5 });
            var expected = 12;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddTest_Array_739()
        {
            var actual = calc.Add(new int[] { 7, 3, 9 });
            var expected = 19;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddTest_Array_null()
        {
            var actual = calc.Add(null);
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DivideTest_10_5()
        {
            var actual = calc.Divide(10, 5);
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DivideTest_8_2()
        {
            var actual = calc.Divide(8, 2);
            var expected = 4;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DivideTest_8_0()
        {
            var actual = calc.Divide(8, 0);
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DivideTest_0_8()
        {
            var actual = calc.Divide(0, 8);
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }
    }
}