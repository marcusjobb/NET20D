using Geometry_TDD.Shapes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Geometry_TDD.Tests
{
    /// <summary>
    /// Test class for GetArea(IShape)
    /// </summary>
    [TestClass]
    public class CalculatorTestsArea
    {
        private readonly Calculator calculator = new();

        /// <summary>
        /// Validates GetArea(IShape) returns correct calculation of area
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="expected"></param>
        [DataTestMethod, TestCategory("Area")]
        [DynamicData(nameof(AreaTestCases), DynamicDataSourceType.Method)]
        public void GetAreaTest_ShouldCalculateCorrectly_WhenGivenValidData(IShape shape, float expected)
        {
            var actual = calculator.GetArea(shape);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Validates GetArea(IShape) returns zero when given null object
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="expected"></param>
        [DataTestMethod, TestCategory("Area")]
        [DataRow(null, 0f)]
        public void GetAreaTest_ShouldBeZero_WhenGivenNullObject(IShape shape, float expected)
        {
            var actual = calculator.GetArea(shape);
            Assert.AreEqual(expected, actual);
        }

        private static IEnumerable<object[]> AreaTestCases()
        {
            yield return new object[] { new Rectangle(10, 5), 50f };
            yield return new object[] { new Circle(15), 707f };
            yield return new object[] { new Square(15), 225f };
            yield return new object[] { new Triangle(10, 5), 25f };
        }
    }
}