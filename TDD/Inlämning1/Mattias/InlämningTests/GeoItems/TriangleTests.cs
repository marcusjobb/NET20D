using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Inlämning1.Tests
{
    [TestClass()]
    public class TriangleTests
    {
        /// <summary>
        /// Determines if the returned result meets the Assert requirement of being equal to the expected value
        /// </summary>
        /// <param name="tbase"></param>
        /// <param name="height"></param>
        /// <param name="side"></param>
        /// <param name="expected"></param>
        [TestMethod()]
        [DynamicData(nameof(DataForTriangleArea), DynamicDataSourceType.Method)]
        public void GetAreaTest(float tbase, float height, float side, float expected)
        {
            var triangle = new Triangle { Tbase = tbase, Height = height, Side = side};
            var result = triangle.GetArea();
            Assert.AreEqual(expected, MathF.Round(result));
        }
        /// <summary>
        /// Determines if the returned result meets the Assert requirement of being equal to the expected value
        /// </summary>
        /// <param name="tbase"></param>
        /// <param name="height"></param>
        /// <param name="side"></param>
        /// <param name="expected"></param>
        [TestMethod()]
        [DynamicData(nameof(DataForTrianglePerimeter), DynamicDataSourceType.Method)]
        public void GetPerimeterTest(float tbase, float height, float side, float expected)
        {
            var triangle = new Triangle { Tbase = tbase, Height = height, Side = side};
            var result = triangle.GetPerimeter();
            Assert.AreEqual(expected, MathF.Round(result));
        }
        /// <summary>
        /// Object data for GetAreaTest
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Object[]> DataForTriangleArea()
        {
            yield return new object[] { 3.5f, 4.7f, 3.2f, 8f };
            yield return new object[] { -10f, 12f, 3f, 0 };
            yield return new object[] { null, 4f, 4f, 0 };
            yield return new object[] { 4f, 4f, 4f, 8f };
        }
        /// <summary>
        /// Object data for GetPerimeterTest
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Object[]> DataForTrianglePerimeter()
        {
            yield return new object[] { 3.5f, 4.7f, 3.2f, 10f };
            yield return new object[] { -10f, 12f, 3f, 0 };
            yield return new object[] { null, 4f, 4f, 0 };
            yield return new object[] { 4f, 4f, 4f, 12f };
        }
    }
}