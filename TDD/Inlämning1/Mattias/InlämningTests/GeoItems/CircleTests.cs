using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Inlämning1.Tests
{
    [TestClass()]
    public class CircleTests
    {
        /// <summary>
        /// Determines if the returned result meets the Assert requirement of being equal to the expected value
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="expected"></param>
        [TestMethod()]
        [DynamicData(nameof(DataForCircleArea), DynamicDataSourceType.Method)]
        public void GetAreaTest(float radius, float expected)
        {
            var circle = new Circle { Radius = radius };
            float result = circle.GetArea();
            Assert.AreEqual(expected, MathF.Round(result));
        }
        /// <summary>
        /// Determines if the returned result meets the Assert requirement of being equal to the expected value
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="expected"></param>
        [TestMethod()]
        [DynamicData(nameof(DataForCirclePerimeter), DynamicDataSourceType.Method)]
        public void GetPerimeterTest(float radius, float expected)
        {
            var circle = new Circle { Radius = radius };
            float result = circle.GetPerimeter();
            Assert.AreEqual(expected, MathF.Round(result));
        }
        /// <summary>
        /// Object data for GetAreaTest
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Object[]> DataForCircleArea()
        {
            yield return new object[] { 5.9f, 109f };
            yield return new object[] { -4f, 0 };
            yield return new object[] { null, 0 };
            yield return new object[] { 8, 201 };
        }
        /// <summary>
        /// Object data for GetPerimeterTest
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Object[]> DataForCirclePerimeter()
        {
            yield return new object[] { 5.9f, 37f };
            yield return new object[] { -4f, 0 };
            yield return new object[] { null, 0 };
            yield return new object[] { 8, 50 };
        }
    }
}