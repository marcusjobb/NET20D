//----------------------------------------------------------------------------------------------
// <copyright file="MailCheckTests.cs" company="Codic Education">
// By Marcus Medina, 2021 - http://MarcusMedina.Pro 
// This file is subject to the terms and conditions defined in file "license.txt"- GNU3, 
// which is part of this project. </copyright>
// ----------------------------------------------------------------------------------------------

namespace MailCheck.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines the <see cref="MailCheckTests" />.
    /// </summary>
    [TestClass()]
    public class MailCheckTests
    {
        /// <summary>
        /// The CheckPasswordTest_ALotOfTests.
        /// </summary>
        /// <param name="tst">The tst<see cref="string"/>.</param>
        /// <param name="expected">The expected<see cref="bool"/>.</param>
        [TestMethod()]
        [DataRow(null, false)]
        [DataRow("", false)]
        [DataRow("Katt4!", false)]
        [DataRow("Kattsvans32KattsvansKattsvans!", false)]
        [DataRow("Kattsvans11!", true)]
        [DataRow("Kattsvans.", false)]
        [DataRow("kattsvans33.", false)]
        [DataRow("KATTSVANS43.", false)]
        public void CheckPasswordTest_ALotOfTests(string tst, bool expected)
        {
            var test = new MailCheck();
            var actual = test.CheckPassword(tst);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The SwePhoneCheckTest.
        /// </summary>
        /// <param name="tst">The tst<see cref="string"/>.</param>
        /// <param name="expected">The expected<see cref="bool"/>.</param>
        [TestMethod()]
        [DataRow(null, false)]
        [DataRow("+46000000000", false)]
        [DataRow("+46720000000", true)]
        public void SwePhoneCheckTest(string tst, bool expected)
        {
            var test = new MailCheck();
            var actual = test.SwePhoneCheck(tst);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The TestEmail.
        /// </summary>
        /// <param name="tst">The tst<see cref="string"/>.</param>
        /// <param name="expected">The expected<see cref="bool"/>.</param>
        [TestMethod()]
        [DataRow(null, false)]
        [DataRow("", false)]
        [DataRow("marcus medina@codic.se", false)]
        [DataRow("@", false)]
        [DataRow("marcus-codic.se", false)]
        [DataRow("marcusmarcusmarcusmarcusmarcusmarcusmarcusmarcusmarcusmarcus@codic.se", false)]
        [DataRow("marcusmarcusmarcusmarcusmarcusmarcusmarcusmarcus_@codic.se", true)]
        [DataRow("marcus@@codic.se", false)]
        [DataRow("Marcus@Codic.se", false)]
        [DataRow("marcus@codic", false)]
        [DataRow("marcus@codic.", false)]
        [DataRow("m.arcus-70@_codic_.se", true)]
        [DataRow("spöke@ghost.se", false)]
        public void TestEmail(string tst, bool expected)
        {
            var test = new MailCheck();
            var actual = test.CheckMail(tst);
            Assert.AreEqual(expected, actual);
        }
    }
}
