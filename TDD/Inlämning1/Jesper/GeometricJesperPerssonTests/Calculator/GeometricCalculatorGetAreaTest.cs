namespace GeometricJesperPersson.Calculator.Tests
{
    using GeometricJesperPersson.Shapes;
    using GeometricJesperPersson.Shapes.Triangles;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass()]
    public class GeometricCalculatorGetAreaTest
    {
        // GetAreaTest_01
        [DataTestMethod]
        [DynamicData(nameof(CorrectData), DynamicDataSourceType.Property)]
        public void GetAreaTest_CorrectData(GeometricThing obj, float expected)
        {
            GeometricCalculator calc = new GeometricCalculator();
            var actual = calc.GetArea(obj);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> CorrectData
        {
            get
            {
                yield return new object[] { new Rectangle(10, 5), 50f };
                yield return new object[] { new Square(10), 100f };
                yield return new object[] { new Circle(20), 1256.6371f };
                yield return new object[] { new RightTriangle(5, 8, 9.4339f), 20f };
                yield return new object[] { new IsosclesTriangle(10, 15), 70.71068f };
                yield return new object[] { new EquilateralTriangle(20), 173.2051f };
            }
        }

        // GetAreaTest_02
        [DataTestMethod]
        [DynamicData(nameof(FalseData), DynamicDataSourceType.Property)]
        public void GetAreaTest_WrongData(GeometricThing obj, float expected)
        {
            GeometricCalculator calc = new GeometricCalculator();
            var actual = calc.GetArea(obj);
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

        // GetAreaTest_03

        [DataTestMethod]
        [DynamicData(nameof(MinusData), DynamicDataSourceType.Property)]
        public void GetAreaTest_MinusData(GeometricThing obj, float expected)
        {
            GeometricCalculator calc = new GeometricCalculator();
            var actual = calc.GetArea(obj);
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

        // GetAreaTest_04
        [DataTestMethod]
        [DynamicData(nameof(ZeroData), DynamicDataSourceType.Property)]
        public void GetAreaTest_ZeroData(GeometricThing obj, float expected)
        {
            GeometricCalculator calc = new GeometricCalculator();
            var actual = calc.GetArea(obj);
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

        // GetAreaTest_05
        [DataTestMethod]
        [DynamicData(nameof(Maxvalue), DynamicDataSourceType.Property)]
        public void GetAreaTest_MaxValue(GeometricThing obj, float expected)
        {
            GeometricCalculator calc = new GeometricCalculator();
            var actual = calc.GetArea(obj);
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

        // GetAreaTest_06
        [TestMethod]
        public void GetAreaTest_Null()
        {
            GeometricCalculator calc = new GeometricCalculator();
            var actual = calc.GetArea(thing: null);
            const int expected = 0;
            Assert.AreEqual(expected, actual);
        }
    }
}