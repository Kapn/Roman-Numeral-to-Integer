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
    }
}
