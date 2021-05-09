#pragma warning disable S4144 // Methods should not have identical implementations

using NUnit.Framework;
using System;

namespace Shapes___inlämning_TDD
{
    [TestFixture]
    public class CircleTest
    {
        /// <summary>
        /// Testing negative or zero values with the calculateArea method
        /// </summary>
        /// <param name="radius">Taking the radius of the circle</param>
        /// <param name="expected">Expected result</param>
        [TestCase(0, 0)]
        [TestCase(-1, 0)]
        [TestCase(-100, 0)]
        public void CalculateArea_NegativeOrZeroValues_ReturnZero(

            float radius,
            float expected)
        {
            //Arrange
            Circle circle = new Circle(radius);
            //Act
            var actual = circle.CalculateArea();
            //Assert
            Assert.That
                (Math.Round(actual, 4, MidpointRounding.ToEven),
                Is.EqualTo
                (Math.Round(expected, 4, MidpointRounding.ToEven)));
        }

        /// <summary>
        /// Testing positive values with the calculateArea method
        /// </summary>
        /// <param name="radius">Taking the radius of the circle</param>
        /// <param name="expected">Expected result</param>
        [TestCase(1, 3.1416f)]
        [TestCase(5, 78.5398f)]
        public void CalculateArea_PositiveValues_ReturnArea(
            float radius,
            float expected)
        {
            //Arrange
            Circle circle = new Circle(radius);
            //Act
            var actual = circle.CalculateArea();
            //Assert
            Assert.That
                (Math.Round(actual, 4, MidpointRounding.ToEven),
                Is.EqualTo
                (Math.Round(expected, 4, MidpointRounding.ToEven)));
        }
        /// <summary>
        /// Testing neagtive or zero values with the GetPerimeter method
        /// </summary>
        /// <param name="radius">Taking the radius of the circle</param>
        /// <param name="expected">Expected result</param>
        [TestCase(0, 0)]
        [TestCase(-1, 0)]
        [TestCase(-100, 0)]
        public void GetPerimeter_NegativeOrZeroValues_ReturnZero(

            float radius,
            float expected)
        {
            //Arrange
            Circle circle = new Circle(radius);
            //Act
            var actual = circle.GetPerimeter();
            //Assert
            Assert.That
                (MathF.Round(actual, 2, MidpointRounding.ToEven),
                Is.EqualTo
                (MathF.Round(expected, 2, MidpointRounding.ToEven)));
        }

        /// <summary>
        /// Testing positive values with the GetPerimeter method
        /// </summary>
        /// <param name="radius">Taking the radius of the circle</param>
        /// <param name="expected">Expected result</param>
        [TestCase(1, 6.28f)]
        [TestCase(5, 31.42f)]
        public void GetPerimeter_PositiveValues_ReturnArea(
            float radius,
            float expected)
        {
            //Arrange
            Circle circle = new Circle(radius);
            //Act
            var actual = circle.GetPerimeter();
            //Assert
            Assert.That
                (MathF.Round(actual, 2, MidpointRounding.ToEven),
                Is.EqualTo
                (MathF.Round(expected, 2, MidpointRounding.ToEven)));
        }
    }
}

#pragma warning restore S4144 // Methods should not have identical implementations