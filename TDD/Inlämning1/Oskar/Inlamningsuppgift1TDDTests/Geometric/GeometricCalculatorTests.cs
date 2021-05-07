namespace Inlamningsuppgift1TDD.Geometric.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using Inlamningsuppgift1TDD.Geometric.Triangles;
    [TestClass()]
    public class GeometricCalculatorTests
    {
        private GeometricCalculator calc;

        /// <summary>
        /// Initializes the test. The awake method for the tests.
        /// </summary>
        [TestInitialize]
        public void TestSetup()
        {
            calc = new GeometricCalculator();
        }

        /// <summary>
        /// Testing the GetArea method of GeometricCalcultor with objects of different geometrics.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="expected"></param>
        [DataTestMethod, TestCategory("Area")]
        [DynamicData(nameof(AreaData), DynamicDataSourceType.Property)]
        public void GetAreaTest(IGeometric obj, float expected)
        {
            Assert.AreEqual(expected, calc.GetArea(obj));
        }

        /// <summary>
        /// A property containing different objects. Used for testing area.
        /// </summary>
        public static IEnumerable<object[]> AreaData
        {
            get
            {
                yield return new object[] { null, 1f }; //fail
                yield return new object[] { null, 0f }; //pass
                yield return new object[] { new Rectangle(10, 5), 2f }; //fail
                yield return new object[] { new Rectangle(10, 5), 50f }; //pass
                yield return new object[] { new Square(10), 1f }; //fail
                yield return new object[] { new Square(10), 100f }; //pass
                yield return new object[] { new IsoscelesTriangle(10, 5), 10f }; //fail
                yield return new object[] { new IsoscelesTriangle(10, 5), 25f }; //pass
                yield return new object[] { new Circle(20), 1256.1f }; //fail
                yield return new object[] { new Circle(20), 1256.64f }; //pass
            }
        }

        /// <summary>
        /// Testing the overloaded GetPerimeter method of GeometricCalcultor with objects of different geometrics.
        /// Testing the IGemotetric obj overload.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="expected"></param>
        [DataTestMethod, TestCategory("Perimeter")]
        [DynamicData(nameof(PerimeterData), DynamicDataSourceType.Property)]
        public void GetPerimeterTest(IGeometric obj, float expected)
        {
            Assert.AreEqual(expected, calc.GetPerimeter(obj));
        }

        /// <summary>
        ///  A property containing different objects. Used for testing perimeter.
        /// </summary>
        public static IEnumerable<object[]> PerimeterData
        {
            get
            {
                yield return new object[] { null, 1f }; //fail
                yield return new object[] { null, 0f }; //pass
                yield return new object[] { new Rectangle(10, 5), 2f }; //fail
                yield return new object[] { new Rectangle(10, 5), 30f }; //pass
                yield return new object[] { new Square(10), 1f }; //fail
                yield return new object[] { new Square(10), 40f }; //pass
                yield return new object[] { new EquilateralTriangle(10), 10f }; //fail
                yield return new object[] { new EquilateralTriangle(10), 30f }; //pass
                yield return new object[] { new Circle(20), 18.1f }; //fail
                yield return new object[] { new Circle(20), 125.66f }; //pass
            }
        }

        /// <summary>
        /// Testing the overloaded GetPerimeter method of GeometricCalcultor with objects of different geometrics.
        /// Testing the IGemotetric[] obj overload.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="expected"></param>
        [DataTestMethod, TestCategory("Total perimeters")]
        [DynamicData(nameof(PerimetersData), DynamicDataSourceType.Property)]
        public void GetPerimetersTest(IGeometric[] obj, float expected)
        {
            Assert.AreEqual(expected, calc.GetPerimeter(obj));
        }

        /// <summary>
        /// A property containing different object arrays. Used for testing total perimeter of objects.
        /// </summary>
        public static IEnumerable<object[]> PerimetersData
        {
            get
            {
                //fail
                yield return new object[]
                {
                    new IGeometric[]
                    {
                        null,
                        null,
                    },
                    20f,
                };

                //pass
                yield return new object[]
                {
                    new IGeometric[]
                    {
                        null,
                        null,
                    },
                    0f,
                };

                //fail
                yield return new object[]
                {
                    new IGeometric[]
                    {
                        new Rectangle(10, 5),
                        new Rectangle(10, 10)
                    },
                    40f,
                };

                //pass
                yield return new object[]
                {
                    new IGeometric[]
                    {
                        new Rectangle(10, 5),
                        new Rectangle(10, 10)
                    },
                    70f,
                };

                //fail
                yield return new object[]
                {
                    new IGeometric[]
                    {
                        new Rectangle(10, 5),
                        new Square(1000),
                        new EquilateralTriangle(30),
                        new Circle(50),
                    },
                    30f,
                };

                //pass
                yield return new object[]
                {
                    new IGeometric[]
                    {
                        new Rectangle(10, 5),
                        new Square(1000),
                        new EquilateralTriangle(30),
                        new Circle(50),
                    },
                    4434.16f,
                };
            }
        }
    }
}