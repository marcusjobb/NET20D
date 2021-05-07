using Geometry_TDD.Shapes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Geometry_TDD.Tests
{
    /// <summary>
    /// Test class for GetPerimeter(IShape)
    /// </summary>
    [TestClass]
    public class CalculatorTestsPerimeter
    {
        private readonly Calculator calculator = new();

        /// <summary>
        /// Validates GetPerimeter(IShape) returns correct calculation of perimeter
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="expected"></param>
        [DataTestMethod, TestCategory("Perimeter")]
        [DynamicData(nameof(PerimeterTestCases), DynamicDataSourceType.Method)]
        public void GetPerimeterTest_ShouldCalculateCorrectly_WhenGivenValidData(IShape shape, float expected)
        {
            var actual = calculator.GetPerimeter(shape);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Validates GetPerimeter(IShape) returns zero when given null object
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="expected"></param>
        [DataTestMethod, TestCategory("Perimeter")]
        [DataRow(null, 0f)]
        public void GetPerimeterTest_ShouldBeZero_WhenGivenNullObject(IShape shape, float expected)
        {
            var actual = calculator.GetPerimeter(shape);
            Assert.AreEqual(expected, actual);
        }

        private static IEnumerable<object[]> PerimeterTestCases()
        {
            yield return new object[] { new Rectangle(10, 5), 30f };
            yield return new object[] { new Circle(15), 94f };
            yield return new object[] { new Square(15), 60f };
            yield return new object[] { new Triangle(10, 5), 30f };
        }
    }
}