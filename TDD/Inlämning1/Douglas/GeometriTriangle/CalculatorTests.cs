namespace Geometri.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Geometri;

    [TestClass()]
    public class CalculatorTests
    {
        /// <summary>
        /// Testar skicka in null i Area.
        /// </summary>
        [TestMethod()]
        public void AreaTest()
        {
            var calc = new Calculator();

            var actual = calc.Area(null);
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Testar olika värden på de Geometriska figurernas area.
        /// </summary>
        [TestMethod()]
        public void Area_ValuesTest()
        {
            var calc = new Calculator();
            var testData = new Shape[]
            {
                new Circle {Diameter = 2, Radius = 5},
                new Triangle {Height = 10, Width = 5},
                new Rectangle {Height = 20, Width = 30},
                new Square {Height = 25, Width = 25}
            };

            var actual = calc.Area(testData);
            var expected = 1353.539816339745;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Area_Values_NullTest()
        {
            var calc = new Calculator();
            var testData = new Shape[]
            {
                new Circle {Diameter = 2, Radius = 5},
                new Triangle {Height = 10, Width = 5},
                new Rectangle {Height = 20, Width = 30},
                new Square {Height = 25, Width = 25},
                null
            };

            var actual = calc.Area(testData);
            var expected = 1353.539816339745;

            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Testar skicka in null i omkrets.
        /// </summary>
        [TestMethod()]
        public void OmkretsTest()
        {
            var calc = new Calculator();

            var actual = calc.Omkrets(null);
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Testar olika värden på de Geometriska figurernas omkrets.
        /// </summary>
        [TestMethod()]
        public void Omkrets_ValuesTest()
        {
            var calc = new Calculator();
            var testData = new Shape[]
                {
                    new Square  {  Height  =  10,  Width  =  10  },
                    new Triangle { Height = 10, Width = 10},
                    new Circle { Diameter = 2, Radius = 5},
                    new Rectangle {Height = 5, Width = 10}
                };

            var actual = calc.Omkrets(testData);
            var expected = 162.83185307179588;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Omkrets_Values_NullTest()
        {
            var calc = new Calculator();
            var testData = new Shape[]
                {
                    new Square  {  Height  =  10,  Width  =  10  },
                    new Triangle { Height = 10, Width = 10},
                    new Circle { Diameter = 2, Radius = 5},
                    new Rectangle {Height = 5, Width = 10},
                    null
                };

            var actual = calc.Omkrets(testData);
            var expected = 162.83185307179588;

            Assert.AreEqual(expected, actual);
        }
    }
}