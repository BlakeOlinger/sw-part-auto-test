using Microsoft.VisualStudio.TestTools.UnitTesting;
using sw_part_auto_test;

namespace Unit_Test_test_sw_app
{
    [TestClass]
    public class MainTest
    {

        [TestMethod]
        public void True_For_Correct_ProgID()
        {
            var progID = "SolidWorks.Application.24";

            Assert.AreEqual(progID, Program.PROG_ID);
        }
    }
}
