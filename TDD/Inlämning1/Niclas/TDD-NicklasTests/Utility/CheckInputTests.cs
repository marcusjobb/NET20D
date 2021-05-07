using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDD_Nicklas.Utility.Tests
{
    /// <summary>
    /// Tests the validation class with its methods
    /// to see if it can handle different inputs than intended.
    /// </summary>
    [TestClass()]
    public class CheckInputTests
    {
        /// <summary>
        /// Tests regular input and checks against Assert.IsTrue.
        /// </summary>
        /// <param name="input">Input to be tested.</param>
        [TestMethod()]
        [DataRow(1)]
        public void IsValidNumberTest1(float input)
        {
            var success = CheckInput.IsValidNumber(input);
            Assert.IsTrue(success);
        }

        /// <summary>
        /// Tests irregular input and checks against Assert.IsFalse.
        /// </summary>
        /// <param name="input">Input to be tested.</param>
        [TestMethod()]
        [DataRow(-1)]
        [DataRow(null)]
        [DataRow(default)]
        [DataRow(float.MaxValue)]
        [DataRow(float.MinValue)]
        public void IsValidNumberTest2(float input)
        {
            var success = CheckInput.IsValidNumber(input);
            Assert.IsFalse(success);
        }
    }
}