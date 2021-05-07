using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Inlämning1.Tests
{
    [TestClass()]
    public class RectangleTests
    {
        /// <summary>
        /// Determines if the returned result meets the Assert requirement of being equal to the expected value
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="expected"></param>
        [TestMethod()]
        [DynamicData(nameof(DataForRectangleArea), DynamicDataSourceType.Method)]
        public void GetAreaTest(float height, float width, float expected)
        {
            var rectangle = new Rectangle { Height = height, Width = width };
            float result = rectangle.GetArea();
            Assert.AreEqual(expected, MathF.Round(result));
        }
        /// <summary>
        /// Determines if the returned result meets the Assert requirement of being equal to the expected value
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="expected"></param>
        [TestMethod()]
        [DynamicData(nameof(DataForRectanglePerimeter), DynamicDataSourceType.Method)]
        public void GetPerimeterTest(float height, float width, float expected)
        {
            var rectangle = new Rectangle { Height = height, Width = width };
            float result = rectangle.GetPerimeter();
            Assert.AreEqual(expected, MathF.Round(result));
        }
        /// <summary>
        /// Object data for GetAreaTest
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Object[]> DataForRectangleArea()
        {
            yield return new object[] { 10.2f, 10.8f, 110f };
            yield return new object[] { 7f, -18f, 0 };
            yield return new object[] { null, 4f, 0 };
            yield return new object[] { 8f, 8f, 64f };
        }
        /// <summary>
        /// Object data for GetPerimeterTest
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Object[]> DataForRectanglePerimeter()
        {
            yield return new object[] { 10.9f, 8.6f, 39f };
            yield return new object[] { -10f, 10f, 0 };
            yield return new object[] { 10f, null, 0 };
            yield return new object[] { 4f, 4f, 16f };
        }
    }
}