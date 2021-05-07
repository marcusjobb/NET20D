using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Inlämning1.Tests
{
    [TestClass()]
    public class GeometricCalculatorTests
    {
        /// <summary>
        /// Inserts an Array of object shapes and checks each individual shapes Areas total value
        /// </summary>
        [TestMethod()]
        public void GetAreaTestArray()
        {
            IGeometricThing[] shape = new IGeometricThing[]
            {
                new Circle { Radius = -3 },
                new Square { Side = 3.3f },
                new Triangle { Tbase = 4, Height = 6, Side = default},
                new Rectangle { Height = 10, Width = 77},
                null,
                default
            };
            var result = GeometricCalculator.GetArea(shape);
            Assert.AreEqual(793, MathF.Round(result));
        }
        /// <summary>
        /// Inserts an Array of object shapes and checks each individual shapes Perimeters total value
        /// </summary>
        [TestMethod()]
        public void GetPerimeterTestArray()
        {
            IGeometricThing[] shape = new IGeometricThing[]
            {
                new Circle { Radius = -3 },
                new Square { Side = 3.3f },
                new Triangle { Tbase = 4, Height = 6, Side = default},
                new Rectangle { Height = 10, Width = 77},
                null,
                default
            };
            var result = GeometricCalculator.GetPerimeter(shape);
            Assert.AreEqual(187, MathF.Round(result));
        }
    }
}