using Microsoft.VisualStudio.TestTools.UnitTesting;
using sw_part_auto_test;
using System;

namespace Unit_Test_test_sw_app
{
    [TestClass]
    public class ValidationTest
    {
        [TestMethod]
        public void ThrowArgumentExceptionForProgIDEmptyString()
        {
            var emptyProgID = "";

            Assert.ThrowsException<ArgumentException>(() =>
            Validation
            .ThrowArgumentExceptionIfEmptyArg(
                emptyProgID));
        }

        [TestMethod]
        public void ThrowArgumentExceptionForNullArgument()
        {
            string nullProgID = null;

            Assert.ThrowsException<ArgumentException>(() =>
            Validation.
            ThrowArgumentExceptionIfNullArg(
                nullProgID));
        }
    }
}
