using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Inlämning1.Tests
{
    [TestClass()]
    public class SquareTests
    {
        /// <summary>
        /// Determines if the returned result meets the Assert requirement of being equal to the expected value
        /// </summary>
        /// <param name="side"></param>
        /// <param name="expected"></param>
        [TestMethod()]
        [DynamicData(nameof(DataForSquareArea), DynamicDataSourceType.Method)]
        public void GetAreaTest(float side, float expected)
        {
            var square = new Square { Side = side };
            float result = square.GetArea();
            Assert.AreEqual(expected, result);
        }
        /// <summary>
        /// Determines if the returned result meets the Assert requirement of being equal to the expected value
        /// </summary>
        /// <param name="side"></param>
        /// <param name="expected"></param>
        [TestMethod()]
        [DynamicData(nameof(DataForSquarePerimeter), DynamicDataSourceType.Method)]
        public void GetPerimeterTest(float side, float expected)
        {
            var square = new Square { Side = side };
            float result = square.GetPerimeter();
            Assert.AreEqual(expected, result);
        }
        /// <summary>
        /// Object data for GetAreaTest
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Object[]> DataForSquareArea()
        {
            yield return new object[] { 2.5f, 6.25f };
            yield return new object[] { -1153f, 0f };
            yield return new object[] { null, default };
            yield return new object[] { 4f, 16f };
        }
        /// <summary>
        /// Object data for GetPerimeterTest
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Object[]> DataForSquarePerimeter()
        {
            yield return new object[] { 2.5f, 10f };
            yield return new object[] { -1153f, 0f };
            yield return new object[] { null, default };
            yield return new object[] { 4f, 16f };
        }
    }
}