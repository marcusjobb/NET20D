using Geometry_TDD.Shapes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Geometry_TDD.Tests.CalculatorTests
{
    /// <summary>
    /// Test class for GetPerimeter(List&lt;IShape&gt;)
    /// </summary>
    [TestClass]
    public class CalculatorTestsPerimeterList
    {
        private readonly Calculator calculator = new();

        /// <summary>
        /// Validates that GetPerimeter(List&lt;IShape&gt;) returns correct calculation of perimeters
        /// </summary>
        /// <param name="shapes"></param>
        /// <param name="expected"></param>
        [TestMethod, TestCategory("PerimeterList")]
        [DynamicData(nameof(PerimeterListTestCases), DynamicDataSourceType.Method)]
        public void GetPerimeterListTest_ShouldCalculateCorrectly_WhenGivenValidData(List<IShape> shapes, float expected)
        {
            var actual = calculator.GetPerimeter(shapes);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Validates GetPerimeter(List&lt;IShape&gt;) excludes object from calculation when object is null
        /// </summary>
        /// <param name="shapes"></param>
        /// <param name="expected"></param>
        [TestMethod, TestCategory("PerimeterList")]
        [DynamicData(nameof(PerimeterListNullTestCases), DynamicDataSourceType.Method)]
        public void GetPerimeterListTest_ShouldExcludeObjectFromCalculation_WhenObjectIsNull(List<IShape> shapes, float expected)
        {
            var actual = calculator.GetPerimeter(shapes);
            Assert.AreEqual(expected, actual);
        }

        private static IEnumerable<object[]> PerimeterListTestCases()
        {
            yield return new object[] { new List<IShape> { new Rectangle(10, 5), new Square(10), new Triangle(10, 5) }, 100f };
            yield return new object[] { new List<IShape> { new Circle(5), new Square(1), new Triangle(100, 34), new Rectangle(10, 5) }, 365f };
            yield return new object[] { new List<IShape> { new Square(77), new Square(10), new Triangle(120, 45) }, 708f };
            yield return new object[] { new List<IShape> { new Circle(346), new Square(10342), new Triangle(6543, 55) }, 63171f };
        }

        private static IEnumerable<object[]> PerimeterListNullTestCases()
        {
            yield return new object[] { new List<IShape> { null, new Square(10), new Triangle(10, 5) }, 70f };
            yield return new object[] { new List<IShape> { null, new Square(1), new Triangle(100, 34), new Rectangle(10, 5) }, 334f };
            yield return new object[] { new List<IShape> { new Square(5), null, new Triangle(120, 45) }, 380f };
            yield return new object[] { new List<IShape> { new Circle(30), new Square(10342), null }, 41556f };
            yield return new object[] { new List<IShape> { new Rectangle(-5, 2), null, new Triangle(6543, 55) }, 19623f };
            yield return new object[] { new List<IShape> { null, null, null }, 0f };
        }
    }
}