using Inlamningsuppgift1TDD.GeometricThings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inlamningsuppgift1TDD.Tests
{
    [TestClass()]
    public class GeometricCalculatorTests
    {
        /// <summary>
        /// Deklarerar en variabel av klassen GeometricCalculator.
        /// </summary>
        private GeometricCalculator geoCalc;

        /// <summary>
        /// Deklarerar en array av klassen GeometricThing.
        /// </summary>
        private GeometricThing[] arrayOfThings;

        /// <summary>
        /// Deklarerar en array av klassen GeometricThing.
        /// </summary>
        private GeometricThing[] arrayOfNull;

        //Metoden anropas innan varje test och instansierar klasserna och tilldelar objekten värden
        [TestInitialize]
        public void Setup()
        {
            geoCalc = new GeometricCalculator();
            arrayOfThings = new GeometricThing[]
            {
                new Circle { Radius = 3.3f },
                new Triangle { Tbase = 2.5f, Height = 4, Side = 4.5f },
                new Square { Side = 7.5f},
                new Rectangle {Width = 2.2f, Height = 4.4f }
            };

            arrayOfNull = null;
        }

        //Anropas efter varje test och tilldelar arrayen värdet null
        [TestCleanup]
        public void TearDown()
        {
            arrayOfThings = null;
        }

        //Testar GetPerimeter-metoden i GeometricCalculator-klassen med en array av geometriska figurer med positiva värden
        [TestMethod()]
        public void GetPerimeterOfThingsInArray_AnArrayWithPositiveValues_ReturnSumOfPerimeter()
        {
            float expected = 75.42f;
            float actual = geoCalc.GetPerimeter(arrayOfThings);
            Assert.AreEqual(expected, actual);
        }

        //Testar GetPerimeter-metoden i GeometricCalculator-klassen med en array av null
        [TestMethod()]
        public void GetPerimeterOfThingsInArray_AnArrayOfNull_ReturnZero()
        {
            float expected = 0;
            float actual = geoCalc.GetPerimeter(arrayOfNull);
            Assert.AreEqual(expected, actual);
        }

        //Testar GetArea-metoden i GeometricCalculator-klassen med en array av geometriska figurer med positiva värden
        [TestMethod()]
        public void GetAreaOfThingsInArray_AnArrayWithPositiveValues_ReturnSumOfArea()
        {
            float expected = 105.12f;
            float actual = geoCalc.GetArea(arrayOfThings);
            Assert.AreEqual(expected, actual);
        }

        //Testar GetArea-metoden i GeometricCalculator-klassen med en array av null
        [TestMethod()]
        public void GetAreaOfThingsInArray_AnArrayOfNull_ReturnZero()
        {
            float expected = 0;
            float actual = geoCalc.GetArea(arrayOfNull);
            Assert.AreEqual(expected, actual);
        }
    }
}