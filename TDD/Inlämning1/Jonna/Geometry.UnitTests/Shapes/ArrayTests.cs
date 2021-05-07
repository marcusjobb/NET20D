using Geometry.Shapes;
using NUnit.Framework;

namespace Geometry.UnitTests.Shapes
{
    [TestFixture]
    internal class ArrayTests
    {
        /// <summary>
        /// This test will take one of every shape and calculate their individual perimeter
        /// Then add up the total perimeter of all shapes together
        /// </summary>
        /// <param name="squareSide"></param>
        /// <param name="rectangleWidth"></param>
        /// <param name="rectangleHeight"></param>
        /// <param name="triangleSide"></param>
        /// <param name="circleRadius"></param>
        /// <param name="expectedResult"></param>
        [Test]
        //All Shapes matches criteria for calculating their perimeter
        //So total perimeter of all shapes is 116.4
        [TestCase(
        10, 
        10,5, 
        5 , 
        5,
        116.4)
        ]
        //All Shapes matches criteria for calculating their perimeter
        //So total perimeter of all shapes is 259.2
        [TestCase(
            12,
            7, 13,
            11,
            22,
            259.2)
        ]
        public void ArrayGetPerimeter_DifferentGeometricThingsWithValidInput_ReturnCombinedPerimeter(
            double squareSide, 
            double rectangleWidth, double rectangleHeight,
            double triangleSide,
            double circleRadius,
            double expectedResult)
        {
            var square = new Square { Side = squareSide };
            var rectangle = new Rectangle { Width = rectangleWidth, Height = rectangleHeight };
            var triangle = new Triangle {Side = triangleSide};
            var circle = new Circle {Radius = circleRadius};
            var shapes = new GeometricThing[] { square, rectangle, circle, triangle };

            var result = GeometricCalculator.GetPerimeter(shapes);

            Assert.That(result, Is.EqualTo(expectedResult).Within(0.1));
        }

        /// <summary>
        /// This test will show that it will only calculate the perimeter of shapes passed in the array
        /// that matches the individual criteria to get the perimeter
        /// Shapes that will return 0 perimeter are shapes that are zero, negative number or null
        /// </summary>
        /// <param name="squareSide"></param>
        /// <param name="rectangleWidth"></param>
        /// <param name="rectangleHeight"></param>
        /// <param name="triangleSide"></param>
        /// <param name="circleRadius"></param>
        /// <param name="expectedResult"></param>
        [Test]
        //Only the Square is valid here, so the total perimeter is 40
        [TestCase(
            10,
            -5, 5,
            null,
            0,
            40)
        ]
        //Only the Rectangle is valid here, so total perimeter is 20
        [TestCase(
            -5,
            5, 5,
            null,
            0,
            20)
        ]
        //Only the triangle is valid here, so total perimeter is 15
        [TestCase(
            -10,
            -5, 5,
            5,
            0,
            15)
        ]
        //Only the circle is valid here, so total perimeter is 31.4
        [TestCase(
            null,
            -5, 5,
            null,
            5,
            31.4)
        ]
        public void ArrayGetPerimeter_OnlyOneShapeWithValidInput_ReturnPerimeterFromValidShape(
            double squareSide,
            double rectangleWidth, double rectangleHeight,
            double triangleSide,
            double circleRadius,
            double expectedResult)
        {
            var square = new Square { Side = squareSide };
            var rectangle = new Rectangle { Width = rectangleWidth, Height = rectangleHeight };
            var triangle = new Triangle { Side = triangleSide };
            var circle = new Circle { Radius = circleRadius };
            var shapes = new GeometricThing[] { square, rectangle, circle, triangle };

            var result = GeometricCalculator.GetPerimeter(shapes);

            Assert.That(result, Is.EqualTo(expectedResult).Within(0.1));
        }
    }
}
