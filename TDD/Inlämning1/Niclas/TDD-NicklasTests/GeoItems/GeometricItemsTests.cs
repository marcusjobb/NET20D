using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TDD_Nicklas.Interfaces;

namespace TDD_Nicklas.GeoItems.Tests
{
    /// <summary>
    /// Tests the geometric objects and it's methods.
    /// </summary>
    [TestClass()]
    public class GeometricItemsTests
    {
        /// <summary>
        /// [DataRow]("Class name", "Method name", Expected outcome, Parameters of the object.
        /// Test Scenario-ID = "TC_AreaTest_01".
        /// Test Scenario-ID = "TC_PerimeterTest_01".
        /// </summary>
        /// <param name="useClass">Class to test.</param>
        /// <param name="useMethod">Method for calculation.</param>
        /// <param name="expected">Expected outcome.</param>
        /// <param name="values">Parameters needed for method.</param>
        [TestMethod]
        #region Correct tests
        [DataRow("Circle", "GetArea", 28, 3)]
        [DataRow("Circle", "GetPerimeter", 19, 3)]
        [DataRow("Square", "GetArea", 15, 3, 5)]
        [DataRow("Square", "GetPerimeter", 16, 3, 5)]
        [DataRow("Triangle", "GetArea", 21, 6, 7)]
        [DataRow("Triangle", "GetPerimeter", 19, 6, 7)]
        #endregion Correct tests
        #region Incorrect tests
        [DataRow("Circle", "GetArea", 0, default)]
        [DataRow("Circle", "GetArea", 0, null)]
        [DataRow("Circle", "GetArea", 0, -3)]
        [DataRow("Circle", "GetPerimeter", 0, default)]
        [DataRow("Circle", "GetPerimeter", 0, null)]
        [DataRow("Circle", "GetPerimeter", 0, -3)]
        [DataRow("Square", "GetArea", 0, default, 5)]
        [DataRow("Square", "GetArea", 0, null, 5)]
        [DataRow("Square", "GetArea", 0, -3, 5)]
        [DataRow("Square", "GetPerimeter", 0, default, 5)]
        [DataRow("Square", "GetPerimeter", 0, null, 5)]
        [DataRow("Square", "GetPerimeter", 0, -3, 5)]
        [DataRow("Triangle", "GetArea", 0, default, 7)]
        [DataRow("Triangle", "GetArea", 0, null, 7)]
        [DataRow("Triangle", "GetArea", 0, -6, 7)]
        [DataRow("Triangle", "GetPerimeter", 0, default, 7)]
        [DataRow("Triangle", "GetPerimeter", 0, null, 7)]
        [DataRow("Triangle", "GetPerimeter", 0, -6, 7)]
        #endregion Incorrect tests
        public void GeomethricObjectTest(string useClass, string useMethod, float expected, params float[] values)
        {
            const string nameSpace = "TDD_Nicklas.GeoItems";
            const string dll = "TDD-Nicklas";
            var fullPath = $"{nameSpace}.{useClass}, {dll}";
            var classType = Type.GetType(fullPath);
            if (classType != null)
            {
                IGeoObjectable instance;
                if (useClass == "Circle")
                {
                    if (useMethod == "GetPerimeter")
                    {
                        instance = (IGeoObjectable)Activator.CreateInstance(classType, values[0]);
                        Assert.AreEqual(expected, MathF.Round(instance.GetPerimeter()));
                    }
                    else if (useMethod == "GetArea")
                    {
                        instance = (IGeoObjectable)Activator.CreateInstance(classType, values[0]);
                        Assert.AreEqual(expected, MathF.Round(instance.GetArea()));
                    }
                }
                else if (useClass == "Square" || useClass == "Triangle")
                {
                    if (useMethod == "GetPerimeter")
                    {
                        instance = (IGeoObjectable)Activator.CreateInstance(classType, values[0], values[1]);
                        Assert.AreEqual(expected, MathF.Round(instance.GetPerimeter()));
                    }
                    else if (useMethod == "GetArea")
                    {
                        instance = (IGeoObjectable)Activator.CreateInstance(classType, values[0], values[1]);
                        Assert.AreEqual(expected, MathF.Round(instance.GetArea()));
                    }
                }
            }
            else { Assert.Fail(); }
        }
    }
}