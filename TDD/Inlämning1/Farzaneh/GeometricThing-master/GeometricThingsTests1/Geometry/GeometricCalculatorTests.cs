namespace GeometricThings.Geometry.Tests
{
    using GeometricThings.Extensions;
    using GeometricThings.Geometry;
    using GeometricThings.Interface;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    /// <summary>
    /// Defines the <see cref="GeometricCalculatorTests" />.
    /// </summary>
    [TestClass()]
    public class GeometricCalculatorTests
    {
        /// <summary>
        /// Tests The GetArea(IGeometricThing) method by valid and invalid amount
        /// </summary>
        /// <param name="expectedValue">The expectedValue<see cref="float"/>.</param>
        /// <param name="useClass">The useClass<see cref="string"/>.</param>
        /// <param name="values">The values<see cref="float[]"/>.</param>
        [TestMethod()]
        [DataRow(0, "Circle", null)]
        [DataRow(0, "Square", null)]
        [DataRow(0, "Rectangle", null, null)]
        [DataRow(0, "Triangle", null, null)]
        [DataRow(0, "Circle", 0)]
        [DataRow(0, "Square", 0)]
        [DataRow(0, "Rectangle", 0, 0)]
        [DataRow(0, "Triangle", 0, 0)]
        [DataRow(0, "Circle", -2)]
        [DataRow(0, "Square", -2)]
        [DataRow(0, "Rectangle", -2, -1)]
        [DataRow(0, "Triangle", -2, -1)]
        [DataRow(50.2655F, "Circle", 4)]
        [DataRow(1.4983F, "Square", 1.22404F)]
        [DataRow(9.3865F, "Rectangle", 2.400007F, 3.91101F)]
        [DataRow(0.0002F, "Triangle", 2.0003F, 0.000214F)]


        public void GetAreaTest(float expectedValue, string useClass, params float[] values)
        {
            var nameSapace = "GeometricThings.Geometry";
            var dllName = "GeometricThings";
            var fullName = $"{nameSapace}.{useClass},{dllName}";
            var classType = Type.GetType(fullName);
            if (classType != null)
            {
                IGeometricThing instance;
                if (useClass == "Square" || useClass == "Circle")
                {
                    instance = (IGeometricThing)Activator.CreateInstance(classType, values[0]);
                }
                else
                {
                    instance = (IGeometricThing)Activator.CreateInstance(classType, values[0], values[1]);
                }

                Assert.AreEqual(expectedValue, instance.GetArea().NiceRound());
            }
            else
            {
                Assert.Fail();
            }
        }

        /// <summary>
        /// Tests The GetPerimeter(IGeometricThing) method by valid and invalid amount
        /// </summary>
        /// <param name="expectedValue">The expectedValue<see cref="float"/>.</param>
        /// <param name="useClass">The useClass<see cref="string"/>.</param>
        /// <param name="values">The values<see cref="float[]"/>.</param>
        [TestMethod()]
        [DataRow(0, "Circle", null)]
        [DataRow(0, "Square", null)]
        [DataRow(0, "Rectangle", null, null)]
        [DataRow(0, "Triangle", null, null)]
        [DataRow(0, "Circle", 0)]
        [DataRow(0, "Square", 0)]
        [DataRow(0, "Rectangle", 0, 0)]
        [DataRow(0, "Triangle", 0, 0)]
        [DataRow(0, "Circle", -2)]
        [DataRow(0, "Square", -2)]
        [DataRow(0, "Rectangle", -2, -1)]
        [DataRow(0, "Triangle", -2, -1)]
        [DataRow(25.1327F, "Circle", 4)]
        [DataRow(4.8962F, "Square", 1.22404F)]
        [DataRow(12.6220F, "Rectangle", 2.400007F, 3.91101F)]
        [DataRow(4.0008F, "Triangle", 2.0003F, 0.000214F)]

        public void GetPerimeterTest(float expectedValue, string useClass, params float[] values)
        {
            var nameSapace = "GeometricThings.Geometry";
            var dllName = "GeometricThings";
            var fullName = $"{nameSapace}.{useClass},{dllName}";
            var classType = Type.GetType(fullName);
            if (classType != null)
            {
                IGeometricThing instance;
                if (useClass == "Square" || useClass == "Circle")
                {
                    instance = (IGeometricThing)Activator.CreateInstance(classType, values[0]);
                }
                else
                {
                    instance = (IGeometricThing)Activator.CreateInstance(classType, values[0], values[1]);
                }

                Assert.AreEqual(expectedValue, instance.GetPerimeter().NiceRound());
            }
            else
            {
                Assert.Fail();
            }
        }

        /// <summary>
        /// Tests The GetPerimeter(IGeometricThing[]) method by valid and invalid amount
        /// </summary>
        /// <param name="expectedValue">The expectedValue<see cref="float"/>.</param>
        /// <param name="values">The values<see cref="float[]"/>.</param>
        [TestMethod()]
        [DataRow(0, 0, 0, 0, 0, 0, 0)]
        [DataRow(4, 1, null, -2, 3, 0, 3)]
        [DataRow(46.6518F, 1.22404F, 4, 2.400007F, 3.91101F, 2.0003F, 0.000214F)]

        public void GetPerimeterTest1(float expectedValue, params float[] values)
        {
            var calculator = new GeometricCalculator();
            var actual = calculator.GetPerimeter(new IGeometricThing[]
            {
                new Square(values[0]),
                new Circle(values[1]),
                new Rectangle(values[2],values[3]),
                new Triangle(values[4],values[5])
            }
                );

            Assert.AreEqual(actual.NiceRound(), expectedValue);
        }
    }
}
