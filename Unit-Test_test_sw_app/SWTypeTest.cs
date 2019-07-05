using Microsoft.VisualStudio.TestTools.UnitTesting;
using sw_part_auto_test;
using System;

namespace Unit_Test_test_sw_app
{
    [TestClass]
    public class SWTypeTest
    {
        [TestMethod]
        public void Return_Null_For_Null_String_Arg()
        {
            string progID = null;

            Type result = SWType.GetFromProgID(progID);

            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void Return_Null_For_Empty_String_Arg()
        {
            string progID = "";

            Type result = SWType.GetFromProgID(progID);

            Assert.AreEqual(null, result);
        }
    }
}
