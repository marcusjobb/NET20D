#pragma warning disable S4144 // Methods should not have identical implementations

using NUnit.Framework;
using System;

namespace Shapes___inlämning_TDD
{
    [TestFixture]
    public class SquareTest
    {
        /// <summary>
        /// Testing for CalculateArea of the square shape. Takes negative or zero values
        /// </summary>
        /// <param name="side">Takes a side of the square</param>
        /// <param name="expected">Expected result</param>
        [TestCase(0f, 0f)]
        [TestCase(-1f, 0f)]
        public void CalculateArea_NegativeOrZeroValues_ReturnZero(
            float side,
            float expected)
        {
            //Arrange
            Square square = new Square(side);
            //Act
            var actual = square.CalculateArea();
            //Assert
            Assert.That(Math.Round(actual, 4), Is.EqualTo(Math.Round(expected, 4)));
        }

        /// <summary>
        /// Testing for CalculateArea of the square shape. Takes positive values
        /// </summary>
        /// <param name="side">Takes a side of the square</param>
        /// <param name="expected">Expected result</param>
        [TestCase(5, 25)]
        [TestCase(4, 16)]
        [TestCase(0.5f, 0.25f)]
        [TestCase(0.4f, 0.16f)]
        [TestCase(20.3f, 412.09f)]
        [TestCase(0.3f, 0.09f)]
        [TestCase(49.4f, 2440.36f)]
        [TestCase(2.3f, 5.29f)]
        public void CalculateArea_PositiveValues_ReturnArea(
            float side,
            float expected)
        {
            //Arrange
            Square square = new Square(side);
            //Act
            var actual = square.CalculateArea();
            //Assert
            Assert.That(Math.Round(actual, 4), Is.EqualTo(Math.Round(expected, 4)));
        }
        /// <summary>
        /// Testing the GetPerimeter method of the square. Takes negative or zero values.
        /// </summary>
        /// <param name="side">takes a side of the square</param>
        /// <param name="expected">expected result</param>
        [TestCase(0, 0)]
        [TestCase(-2.45f, 0)]
        [TestCase(-47, 0)]
        [TestCase(-1, 0)]
        [TestCase(-10, 0)]
        public void GetPerimeter_NegativeOrZeroValues_ReturnZero(
            float side,
            float expected)
        {
            //Arrange
            Square square = new Square(side);
            //Act
            var actual = square.GetPerimeter();
            //Assert
            Assert.That
                (MathF.Round(actual, 4, MidpointRounding.ToEven),
                Is.EqualTo
                (MathF.Round(expected, 4, MidpointRounding.ToEven)));
        }

        /// <summary>
        /// Testing GetPerimeter method of the square. Takes positive values
        /// </summary>
        /// <param name="side">Side measurement of the square</param>
        /// <param name="expected">Expected result</param>
        [TestCase(17.4225f, 69.69f)]
        [TestCase(10.45f, 41.8f)]
        [TestCase(6, 24)]
        [TestCase(1, 4)]
        [TestCase(11, 44)]
        public void GetPerimeter_PositiveValues_ReturnPerimeter(
            float side,
            float expected)
        {
            //Arrange
            Square square = new Square(side);
            //Act
            var actual = square.GetPerimeter();
            //Assert
            Assert.That
                (MathF.Round(actual, 4, MidpointRounding.ToEven),
                Is.EqualTo
                (MathF.Round(expected, 4, MidpointRounding.ToEven)));
        }
    }
}

#pragma warning restore S4144 // Methods should not have identical implementations