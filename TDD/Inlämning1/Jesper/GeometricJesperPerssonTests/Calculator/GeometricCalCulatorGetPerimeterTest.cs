namespace GeometricJesperPerssonTests.Calculator
{
    using GeometricJesperPersson.Calculator;
    using GeometricJesperPersson.Shapes;
    using GeometricJesperPersson.Shapes.Triangles;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass()]
    public class GeometricCalCulatorGetPerimeterTest
    {
        // GetPerimeterTest_01
        [DataTestMethod]
        [DynamicData(nameof(CorrectData), DynamicDataSourceType.Property)]
        public void GetPerimeterTest_CorrectData(GeometricThing obj, float expected)
        {
            GeometricCalculator calc = new GeometricCalculator();
            var actual = calc.GetPerimeter(obj);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> CorrectData
        {
            get
            {
                yield return new object[] { new Rectangle(10, 5), 30f };
                yield return new object[] { new Square(10), 40f };
                yield return new object[] { new Circle(20), 125.66371f };
                yield return new object[] { new RightTriangle(5, 8, 9.4339f), 22.4339f };
                yield return new object[] { new IsosclesTriangle(10, 15), 40f };
                yield return new object[] { new EquilateralTriangle(20), 60f };
            }
        }

        // GetPerimeterTest_02
        [DataTestMethod]
        [DynamicData(nameof(FalseData), DynamicDataSourceType.Property)]
        public void GetPerimeterTest_WrongData(GeometricThing obj, float expected)
        {
            GeometricCalculator calc = new GeometricCalculator();
            var actual = calc.GetPerimeter(obj);
            Assert.AreNotEqual(expected, actual);
        }

        public static IEnumerable<object[]> FalseData
        {
            get
            {
                yield return new object[] { new Rectangle(10, 5), 5f };
                yield return new object[] { new Square(10), 10f };
                yield return new object[] { new Circle(20), 1255.6371f };
                yield return new object[] { new RightTriangle(5, 8, 9.4339f), 28f };
                yield return new object[] { new IsosclesTriangle(10, 15), 71.71068f };
                yield return new object[] { new EquilateralTriangle(20), 170.2051f };
            }
        }

        // GetPerimeterTest_03
        [DataTestMethod]
        [DynamicData(nameof(MinusData), DynamicDataSourceType.Property)]
        public void GetPerimeterTest_MinusData(GeometricThing obj, float expected)
        {
            GeometricCalculator calc = new GeometricCalculator();
            var actual = calc.GetPerimeter(obj);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> MinusData
        {
            get
            {
                yield return new object[] { new Rectangle(-10, -5), 0 };
                yield return new object[] { new Square(-10), 0 };
                yield return new object[] { new Circle(-20), 0 };
                yield return new object[] { new RightTriangle(-5, -8, -9.4339f), 0 };
                yield return new object[] { new IsosclesTriangle(-10, -15), 0 };
                yield return new object[] { new EquilateralTriangle(-20), 0 };
            }
        }

        // GetPerimeterTest_04
        [DataTestMethod]
        [DynamicData(nameof(ZeroData), DynamicDataSourceType.Property)]
        public void GetPerimeterTest_ZeroData(GeometricThing obj, float expected)
        {
            GeometricCalculator calc = new GeometricCalculator();
            var actual = calc.GetPerimeter(obj);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> ZeroData
        {
            get
            {
                yield return new object[] { new Rectangle(0, 0), 0 };
                yield return new object[] { new Square(0), 0 };
                yield return new object[] { new Circle(0), 0 };
                yield return new object[] { new RightTriangle(0, 0, 0), 0 };
                yield return new object[] { new IsosclesTriangle(0, 0), 0 };
                yield return new object[] { new EquilateralTriangle(0), 0 };
            }
        }

        // GetPerimeterTest_05
        [DataTestMethod]
        [DynamicData(nameof(Maxvalue), DynamicDataSourceType.Property)]
        public void GetPerimeterTest_Maxvalue(GeometricThing obj, float expected)
        {
            GeometricCalculator calc = new GeometricCalculator();
            var actual = calc.GetPerimeter(obj);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> Maxvalue
        {
            get
            {
                yield return new object[] { new Rectangle(float.MaxValue + 1, float.MaxValue + 1), 0 };
                yield return new object[] { new Square(float.MaxValue + 1), 0 };
                yield return new object[] { new Circle(float.MaxValue + 1), 0 };
                yield return new object[] { new RightTriangle(float.MaxValue + 1, 0, 0), 0 };
                yield return new object[] { new IsosclesTriangle(float.MaxValue + 1, 0), 0 };
                yield return new object[] { new EquilateralTriangle(float.MaxValue + 1), 0 };
            }
        }

        // GetPerimeterTest_06
        [DataTestMethod]
        [DynamicData(nameof(Minvalue), DynamicDataSourceType.Property)]
        public void GetPerimeterTest_Minvalue(GeometricThing obj, float expected)
        {
            GeometricCalculator calc = new GeometricCalculator();
            var actual = calc.GetPerimeter(obj);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> Minvalue
        {
            get
            {
                yield return new object[] { new Rectangle(float.MinValue, float.MinValue - 1), 0 };
                yield return new object[] { new Square(float.MinValue - 1), 0 };
                yield return new object[] { new Circle(float.MinValue - 1), 0 };
                yield return new object[] { new RightTriangle(float.MinValue - 1, 0, 0), 0 };
                yield return new object[] { new IsosclesTriangle(float.MinValue - 1, 0), 0 };
                yield return new object[] { new EquilateralTriangle(float.MinValue - 1), 0 };
            }
        }

        // GetPerimeterTest_07
        [TestMethod]
        public void GetPerimeterTest_Null()
        {
            GeometricCalculator calc = new GeometricCalculator();
            var actual = calc.GetPerimeter(thing: null);
            const float expected = 0.0f;
            Assert.AreEqual(expected, actual);
        }
    }
}