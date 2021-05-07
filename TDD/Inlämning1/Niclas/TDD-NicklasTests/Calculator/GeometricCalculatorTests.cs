using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TDD_Nicklas.GeoItems;
using TDD_Nicklas.Interfaces;

namespace TDD_Nicklas.Calculator.Tests
{
    /// <summary>
    /// Checks if the GeometricCalculator that adds geometric objects
    /// total area/perimeter together correctly with no crashes.
    /// </summary>
    [TestClass()]
    public class GeometricCalculatorTest2
    {
        private readonly GeometricCalculator Gc = new();

        /// <summary>
        /// Tests the GeometricCalculator's methods with
        /// different inputs as their property values.
        /// </summary>
        [TestMethod]
        [DataRow("Area", 3, 10, 10, 12, 12, 222)]
        [DataRow("Area", -3, 10, -10, 12, -12, 0)]
        [DataRow("Area", null, 10, null, 12, null, 0)]
        [DataRow("Area", default, 10, default, 12, default, 0)]
        [DataRow("Area", float.MaxValue, 10, float.MaxValue, 12, float.MaxValue, 0)]
        [DataRow("Area", float.MinValue, 10, float.MinValue, 12, float.MinValue, 0)]
        [DataRow("Perimeter", 3, 10, 10, 12, 12, 97)]
        [DataRow("Perimeter", -3, 10, -10, 12, -12, 0)]
        [DataRow("Perimeter", null, 10, null, 12, null, 0)]
        [DataRow("Perimeter", default, 10, default, 12, default, 0)]
        [DataRow("Perimeter", float.MaxValue, 10, float.MaxValue, 12, float.MaxValue, 0)]
        [DataRow("Perimeter", float.MinValue, 10, float.MinValue, 12, float.MinValue, 0)]
        public void GeoCalcTest1(string useMethod, float radius, float tBase, float tHeight, float sHight, float sWidht, float expected)
        {
            var geoCollection = new IGeoObjectable[]
            {
                    new Circle(radius),
                    new Triangle(tBase, tHeight),
                    new Square(sHight, sWidht)
            };

            if (useMethod == "Area")
            {
                Assert.AreEqual(expected, MathF.Round(Gc.GetTotalArea(geoCollection)));
            }
            else if (useMethod == "Perimeter")
            {
                Assert.AreEqual(expected, MathF.Round(Gc.GetTotalPerimeter(geoCollection)));
            }
        }

        /// <summary>
        /// Test null value as one of the objects in the array.
        /// </summary>
        [TestMethod]
        [DataRow("Area", 3, 10, 10, 12, 12, 0)]
        [DataRow("Perimeter", 3, 10, 10, 12, 12, 0)]
        public void GeoCalcTest2(string useMethod, float radius, float tBase, float tHeight, float sHight, float sWidht, float expected)
        {
            var geoCollection = new IGeoObjectable[]
            {
                new Circle(radius),
                new Triangle(tBase, tHeight),
                new Square(sHight, sWidht),
                null
            };

            if (useMethod == "Area")
            {
                Assert.AreEqual(expected, MathF.Round(Gc.GetTotalArea(geoCollection)));
            }
            else if (useMethod == "Perimeter")
            {
                Assert.AreEqual(expected, MathF.Round(Gc.GetTotalPerimeter(geoCollection)));
            }
        }

        /// <summary>
        /// Test default value as one of the objects in the array.
        /// </summary>
        [TestMethod]
        [DataRow("Area", 3, 10, 10, 12, 12, 0)]
        [DataRow("Perimeter", 3, 10, 10, 12, 12, 0)]
        public void GeoCalcTest3(string useMethod, float radius, float tBase, float tHeight, float sHight, float sWidht, float expected)
        {
            var geoCollection = new IGeoObjectable[]
            {
                new Circle(radius),
                new Triangle(tBase, tHeight),
                new Square(sHight, sWidht),
                default
            };

            if (useMethod == "Area")
            {
                Assert.AreEqual(expected, MathF.Round(Gc.GetTotalArea(geoCollection)));
            }
            else if (useMethod == "Perimeter")
            {
                Assert.AreEqual(expected, MathF.Round(Gc.GetTotalPerimeter(geoCollection)));
            }
        }

        /// <summary>
        /// Tests if the calculator's methods
        /// can handle a null value instead of an array.
        /// </summary>
        [TestMethod]
        [DataRow("Area", 0)]
        [DataRow("Perimeter", 0)]
        public void GeoCalcTest4(string useMethod, float expected)
        {
            if (useMethod == "Area")
            {
                Assert.AreEqual(expected, MathF.Round(Gc.GetTotalArea(null)));
            }
            else if (useMethod == "Perimeter")
            {
                Assert.AreEqual(expected, MathF.Round(Gc.GetTotalPerimeter(null)));
            }
        }

        /// <summary>
        /// Tests if the calculator's methods
        /// can handle a default value instead of an array.
        /// </summary>
        [TestMethod]
        [DataRow("Area", 0)]
        [DataRow("Perimeter", 0)]
        public void GeoCalcTest5(string useMethod, float expected)
        {
            if (useMethod == "Area")
            {
                Assert.AreEqual(expected, MathF.Round(Gc.GetTotalArea(default)));
            }
            else if (useMethod == "Perimeter")
            {
                Assert.AreEqual(expected, MathF.Round(Gc.GetTotalPerimeter(default)));
            }
        }
    }
}