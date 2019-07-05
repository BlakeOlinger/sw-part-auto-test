using Microsoft.VisualStudio.TestTools.UnitTesting;
using sw_part_auto_test;
using System;

namespace Unit_Test_test_sw_app
{
    [TestClass]
    public class CreateSWInstanceTest
    {
        [TestMethod]
        public void Return_Null_For_Null_Arg()
        {
            Type nullType = null;

            var result = CreateSWInstance.Create(nullType);

            Assert.AreEqual(null, result);
        }
    }
}
