#pragma warning disable S4144 // Methods should not have identical implementations

using NUnit.Framework;
using System;

namespace Shapes___inlämning_TDD
{
    [TestFixture]
    public class TriangleTest
    {
        /// <summary>
        /// Testing for calculateArea method for triangle. Takes only negative or zero values
        /// </summary>
        /// <param name="baseMeasure">Base measurement</param>
        /// <param name="heightMeasure">Height measurement</param>
        /// <param name="expected">Expected result</param>
        [TestCase(0, 5, 0)]
        [TestCase(0, 0, 0)]
        [TestCase(5, 0, 0)]
        [TestCase(-1, 5, 0)]
        [TestCase(-10, -5, 0)]
        public void CalculateArea_NegativeOrZeroValues_ReturnZero(
            float baseMeasure,
            float heightMeasure,
            float expected)
        {
            //Arrange
            Triangle triangle = new Triangle(baseMeasure, heightMeasure);
            //Act
            var actual = triangle.CalculateArea();
            //Assert
            Assert.That
                (MathF.Round(actual, 4, MidpointRounding.ToEven),
                Is.EqualTo
                (Math.Round(expected, 4, MidpointRounding.ToEven)));
        }

        /// <summary>
        /// Testing for calculateArea method for triangle. Takes only positive values
        /// </summary>
        /// <param name="baseMeasure">Base measurement</param>
        /// <param name="heightMeasure">Height measurement</param>
        /// <param name="expected">Expected result</param>
        [TestCase(10, 5, 25f)]
        [TestCase(1, 10, 5f)]
        [TestCase(100, 100, 5000f)]
        public void CalculateArea_PositiveValues_ReturnArea(
            float baseMeasure,
            float heightMeasure,
            float expected)
        {
            //Arrange
            Triangle triangle = new Triangle(baseMeasure, heightMeasure);
            //Act
            var actual = triangle.CalculateArea();
            //Assert
            Assert.That
                (MathF.Round(actual, 4, MidpointRounding.ToEven),
                Is.EqualTo
                (MathF.Round(expected, 4, MidpointRounding.ToEven)));
        }
        /// <summary>
        /// Testing for getPerimeter method for triangle. Takes only negative or zero values
        /// </summary>
        /// <param name="baseMeasure">Base measurement</param>
        /// <param name="heightMeasure">Height measurement</param>
        /// <param name="expected">Expected result</param>
        [TestCase(0, 5, 0)]
        [TestCase(0, 0, 0)]
        [TestCase(5, 0, 0)]
        [TestCase(-1, 5, 0)]
        [TestCase(-10, -5, 0)]
        public void GetPerimeter_NegativeOrZeroValues_ReturnZero(
            float baseMeasure,
            float heightMeasure,
            float expected)
        {
            //Arrange
            Triangle triangle = new Triangle(baseMeasure, heightMeasure);
            //Act
            var actual = triangle.GetPerimeter();
            //Assert
            Assert.That
                (MathF.Round(actual, 4, MidpointRounding.ToEven),
                Is.EqualTo
                (Math.Round(expected, 4, MidpointRounding.ToEven)));
        }

        /// <summary>
        /// Testing for getPerimeter method for triangle. Takes only positive values
        /// </summary>
        /// <param name="baseMeasure">Base measurement</param>
        /// <param name="heightMeasure">Height measurement</param>
        /// <param name="expected">Expected result</param>
        [TestCase(10, 8.660254037f, 30)]
        [TestCase(1, 0.8660254037f, 3)]
        [TestCase(100, 86.60254037f, 300)]
        public void GetPerimeter_PositiveValues_ReturnPerimeter(
            float baseMeasure,
            float heightMeasure,
            float expected)
        {
            //Arrange
            Triangle triangle = new Triangle(baseMeasure, heightMeasure);
            //Act
            var actual = triangle.GetPerimeter();
            //Assert
            Assert.That
                (MathF.Round(actual, 4, MidpointRounding.ToEven),
                Is.EqualTo
                (Math.Round(expected, 4, MidpointRounding.ToEven)));
        }
    }
}

#pragma warning restore S4144 // Methods should not have identical implementations