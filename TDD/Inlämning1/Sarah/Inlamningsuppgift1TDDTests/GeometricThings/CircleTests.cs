using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inlamningsuppgift1TDD.Tests
{
    [TestClass()]
    public class CircleTests
    {
        /// <summary>
        /// Deklarerar en variabel av klassen Circle.
        /// </summary>
        private Circle circle;

        //Anropas innan varje test som instansierar klassen Circle
        [TestInitialize]
        public void Setup()
        {
            circle = new Circle();
        }

        //Anropas efter varje test och tilldelar variabeln circle värdet null
        [TestCleanup]
        public void TearDown()
        {
            circle = null;
        }

        //Testar GetArea-metoden i Circle-klassen med positiva värden (ental och decimaltal)
        [TestMethod()]
        [DataRow(2, 12.56f)]
        [DataRow(1.15f, 4.15f)]
        public void GetAreaOfCircle_PositiveValue_ReturnArea(float radius, float expected)
        {
            circle.Radius = radius;
            var actual = circle.GetArea();
            Assert.AreEqual(expected, actual);
        }

        //Testar GetArea-metoden i Circle-klassen med negativa värden (noll och negativt decimaltal)
        [TestMethod()]
        [DataRow(0, 0)]
        [DataRow(-0.5f, 0)]
        public void GetAreaOfCircle_NegativeOrZeroValue_ReturnZero(float radius, float expected)
        {
            circle.Radius = radius;
            var actual = circle.GetArea();
            Assert.AreEqual(expected, actual);
        }

        //Testar GetPerimeter-metoden i Circle-klassen med positiva värden (ental och decimaltal)
        [TestMethod()]
        [DataRow(0.5f, 3.14f)]
        [DataRow(4.55f, 28.57f)]
        public void GetPerimeterOfCircle_PositiveValue_ReturnPerimeter(float radius, float expected)
        {
            circle.Radius = radius;
            var actual = circle.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }

        //Testar GetPerimeter-metoden i Circle-klassen med negativa värden (noll och negativt decimaltal)
        [TestMethod()]
        [DataRow(0, 0)]
        [DataRow(-3.3f, 0)]
        public void GetPerimeterOfCircle_NegativeOrZeroValue_ReturnZero(float radius, float expected)
        {
            circle.Radius = radius;
            var actual = circle.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }
    }
}