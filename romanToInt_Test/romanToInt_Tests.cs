using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using rnumeral_CodeTest;

namespace romanToInt_Test
{
    [TestClass]
    public class romanToInt_Tests
    {
        [TestMethod]
        public void assert_values()
        {
            string incorrect = "MMZ";            
            string nineteen_ninetynine = "MCMXCIX";
            int expected = 1999;            
            int actual = Program.romanNum_toInteger(nineteen_ninetynine);
            Assert.AreEqual(expected, actual, 0, "MCMXCIX not returning 1999");

            expected = -1;
            actual = Program.romanNum_toInteger(incorrect);
            Assert.AreEqual(expected, actual, 0, "Incorrect Values not failing");
        }

        [TestMethod]
        public void checkRepitition()
        {
            string repitition = "XXXX";
            int expected = -1;
            int actual = Program.romanNum_toInteger(repitition);
            Assert.AreEqual(expected, actual, 0, "incorrect repitition");
        }

        [TestMethod]
        public void checkSubtraction()
        {
            string correct_sub = "IX";
            string incorrect_sub = "VX";
            int expected = 9;
            int actual = Program.romanNum_toInteger(correct_sub);
            Assert.AreEqual(expected, actual, 0, "incorrect subtraction");

            expected = -1;
            actual = Program.romanNum_toInteger(incorrect_sub);
            Assert.AreEqual(expected, actual, 0, "incorrect subtraction");
        }

        [TestMethod]
        public void checkLength()
        {
            string toolong = "XXXXXXXXXXXXXXXX";
            int expected = -1;
            int actual = Program.romanNum_toInteger(toolong);
            Assert.AreEqual(expected, actual, 0, "error in length check");
        }
    }
}
