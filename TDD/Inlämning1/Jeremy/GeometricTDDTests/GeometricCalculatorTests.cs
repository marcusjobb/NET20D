using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometricTDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometricTDD.GeometricForms;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GeometricTDD.Tests
{
    [TestClass()]
    public class GeometricCalculatorTests
    {
        [DataTestMethod()]
        [DynamicData(nameof(AreaTestData))]
        public void GetAreaTest(GeometricThing thing, float expected)
        {
            GeometricCalculator calculator = new();
            var actual = calculator.GetArea(thing);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod()]
        [DynamicData(nameof(PerimeterTestData))]
        public void GetPerimeterTest(GeometricThing thing, float expected)
        {
            GeometricCalculator calculator = new();
            var actual = calculator.GetPerimeter(thing);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod()]
        [DynamicData(nameof(PerimeterTestDataArray))]
        public void GetPerimeterTestArray(GeometricThing[] things, float expected)
        {
            GeometricCalculator calculator = new();
            var actual = calculator.GetPerimeter(things);
            Assert.AreEqual(expected, actual);
        }

        // Code from: https://stackoverflow.com/a/47791172
        public static IEnumerable<object[]> AreaTestData
        {
            get
            {
                return new[]
                {
                    new object[]{new Rectangle(2f, 9f), 18f}, // Testa heltal
                    new object[]{new Rectangle(5.5f, 13.25f), 72.875f}, //Testa decimaltal
                    new object[]{new Rectangle(-13.2f, 25f), 330f}, // Negativ höjd
                    new object[]{new Rectangle(13.2f, -25f), 330f}, // Negativ bredd
                    new object[]{new Rectangle(-13.2f, -25f), 330f}, // Två negativa tal
                    new object[]{new Rectangle(0f, 0f), 0f}, // 0

                    new object[]{new Square(13f), 169f}, // Heltal
                    new object[]{new Square(-25.73f), 662.0329f}, // Negativt deciamltal

                    new object[]{new Triangle(3f, 7f), 10.5f}, // Heltal
                    new object[]{new Triangle(3.37f, 13.74f), 23.1519f}, // decimaltal
                    new object[]{new Triangle(-3f, 7f), 10.5f}, // Negativ höjd
                    new object[]{new Triangle(3f, -7f), 10.5f}, // Negativ bredd
                    new object[]{new Triangle(-3f, -7f), 10.5f}, // Två negativa tal
                    new object[]{new Triangle(3f), 0f}, // Bara en bas

                    new object[]{new Circle(4f), 50.2654825f}, // Heltal
                    new object[]{new Circle(2.34f), 17.2021047f}, // Decimaltal
                    new object[]{new Circle(-2.34f), 17.2021047f} // Negativt decimaltal
                };
            }
        }

        public static IEnumerable<object[]> PerimeterTestData
        {
            get
            {
                return new[]
                {
                    new object[]{new Rectangle(2f, 9f), 22f}, // Heltal
                    new object[]{new Rectangle(5.5f, 13.25f), 37.5f}, // Decimaltal
                    new object[]{new Rectangle(-13.2f, 25f), 76.4f}, // Negativ höjd
                    new object[]{new Rectangle(13.2f, -25f), 76.4f}, // Negativ bredd
                    new object[]{new Rectangle(-13.2f, -25f), 76.4f}, // Två negativa tal

                    new object[]{new Square(13f), 52f}, // Heltal
                    new object[]{new Square(-25.73f), 102.92f}, // Negativt deciamltal

                    new object[]{new Triangle(3f), 9f}, // Heltal
                    new object[]{new Triangle(-7f), 21f}, // Negativt heltal

                    new object[]{new Circle(8f), 50.2655f}, // Heltal
                    new object[]{new Circle(-2.34f), 14.7027f} // Negativt decimaltal
                };
            }
        }

        public static IEnumerable<object[]> PerimeterTestDataArray
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                        new GeometricThing[]
                        {
                            new Rectangle(2f, 9f),
                            new Square(3f),
                            new Triangle(4f),
                            new Circle(8f)
                        }, 96.2655f
                    },
                    new object[]
                    {
                        new GeometricThing[]
                        {
                            new Rectangle(10f, 15f),
                            new Rectangle(-2f, -3f)
                        }, 60f
                    }
                };
            }
        }
    }
}