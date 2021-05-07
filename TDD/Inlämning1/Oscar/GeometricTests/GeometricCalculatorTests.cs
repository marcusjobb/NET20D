using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TDDInlämning1;

namespace GeometricTests
{
    class GeometricCalculatorTests
    {
        private GeometricCalculator calc = new GeometricCalculator();
        GeometricThing[] validArray = new GeometricThing[]
        {
            new Triangle(4,6),
            new Circle(3),
            new Rectangle(4,2),
            new Square(5)
        };
        private GeometricThing[] emptyArray = new GeometricThing[0];
        private GeometricThing[] nullArray;
        private GeometricThing[] someNullValues = new GeometricThing[]
        {
            null,
            new Circle(3),
        };

        
        /// <summary>
        /// skickar in en korrekt array av shapes för att testa GetPerimiter metoden.
        /// </summary>
        [Test]
        public void GetPerimiterTest_Valid_ReturnsSumOfAllPerimiters()
        {
            var actual = Math.Round(calc.GetPerimeter(validArray), 2);
            var expected = 62.84;
            Assert.That(actual, Is.EqualTo(expected).Within(0.02));
        }
        /// <summary>
        /// skickar in en felaktig null array för att testa GetPerimiter metoden.
        /// </summary>
        [Test]
        public void GetPerimiterTest_InvalidNullArray_ReturnsZero()
        {
            var actual = calc.GetPerimeter(nullArray);
            var expected = 0;
            Assert.AreEqual(actual, expected);
        }
        /// <summary>
        /// skickar in en felaktig tom array för att testa GetPerimiter metoden.
        /// </summary>
        [Test]
        public void GetPerimiterTest_InvalidEmptyArray_ReturnsZero()
        {
            var actual = calc.GetPerimeter(emptyArray);
            var expected = 0;
            Assert.AreEqual(actual, expected);
        }
        /// <summary>
        /// skickar in en felaktig arrat med null värden inuti, för att testa GetPerimiter.
        /// </summary>
        [Test]
        public void GetPerimiterTest_InvalidNullValuesInsideArray_ReturnsZero()
        {
            var actual = Math.Round(calc.GetPerimeter(someNullValues));
            var expected = 0;
            Assert.AreEqual(actual, expected);
        }
    }
}
