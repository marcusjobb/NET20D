//----------------------------------------------------------------------------------------------
// <copyright file="GeometricCalculatorTests.cs" company="Codic Education">
// By Marcus Medina, 2021 - http://MarcusMedina.Pro 
// This file is subject to the terms and conditions defined in file "license.txt"- GNU3, 
// which is part of this project. </copyright>
// ----------------------------------------------------------------------------------------------

namespace Geothings.Geometry.Tests
{
    using Geothings.Geometry;
    using Geothings.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    /// <summary>
    /// Defines the <see cref="GeometricCalculatorTests" />.
    /// </summary>
    [TestClass()]
    public class GeometricCalculatorTests
    {
        /// <summary>
        /// The GetPerimeterTest.
        /// </summary>
        [TestMethod()]
        public void GetPerimeterTest()
        {
            var calc = new GeometricCalculator();
            var actual = GeometricCalculator.GetPerimeter(new IGeometricThing[]
            {
               new Square(10),
            });
        }

        /// <summary>
        /// Test för att kalla på klasser dynamiskt genom reflection.
        /// </summary>
        /// <param name="useClass">.</param>
        /// <param name="values">.</param>
        [TestMethod]
        [DataRow("Square", 10)]
        public void SquareTest(string useClass, params float[] values)
        {
            var namesp = "Geothings.Geometry"; // Namespace
            var dllName = "Geothings"; // Projektnamn eller DLL namn
            var fullName = $"{namesp}.{useClass}, {dllName}"; // Qualified name  
            var classType = Type.GetType(fullName);
            if (classType != null)
            {
                IGeometricThing instance;
                if (useClass == "Square") // Bara en parameter på constructorn
                    instance = (IGeometricThing)Activator.CreateInstance(classType, values[0]);//ej statisk/abstrakt
                else
                    instance = (IGeometricThing)Activator.CreateInstance(classType, values);//ej statisk/abstrakt
                Assert.AreEqual(-1, instance.GetArea());
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}
