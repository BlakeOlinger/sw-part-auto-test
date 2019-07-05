using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolidWorks.Interop.sldworks;
using sw_part_auto_test;

namespace Unit_Test_test_sw_app
{
    [TestClass]
    public class SWDocSpecificationTest
    {
        [TestMethod]
        public void Return_Null_For_Null_Path_Arg()
        {
            string nullPath = null;
            ISldWorks swApp = null;

            var result = SWDocSpecification.GetDocumentSpecification(
                swApp, nullPath);

            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void Return_Null_For_Null_SWApp_Arg()
        {
            var path = "some.file.txt";
            ISldWorks nullSWApp = null;

            var result = SWDocSpecification.GetDocumentSpecification(
                nullSWApp, path);

            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void Return_Null_For_Empty_String_Path_Arg()
        {
            var emptyPath = "";
            ISldWorks swApp = CreateSWInstance.Create(
                SWType.GetFromProgID("SolidWorks.Application.24")
                );

            var result = SWDocSpecification.GetDocumentSpecification(
                swApp, emptyPath);

            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void Return_Null_For_File_Not_Exist()
        {
            var nonFile = "abse.txt";
            ISldWorks swApp = CreateSWInstance.Create(
                SWType.GetFromProgID("SolidWorks.Application.24")
                );

            var result = SWDocSpecification.GetDocumentSpecification(
                swApp, nonFile);

            Assert.AreEqual(null, result);
        }
    }
}
