
using SolidWorks.Interop.sldworks;
using System.IO;

namespace sw_part_auto_test
{
    public class Program
    {
        public static readonly string PROG_ID = "SolidWorks.Application.24";
        private static readonly NLog.Logger logger =
            NLog.LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {

            var swType = SWType.GetFromProgID(PROG_ID);

            if (swType == null)
            {
                logger.Error("\n ERROR: GetFromProgID returned null\n" +
                    " - Exiting Program");
                return;
            }

            ISldWorks swApp = CreateSWInstance.Create(swType);

            if(swApp == null)
            {
                logger.Error("\n ERROR: Could not get reference to " +
                    "SolidWorks App\n - Exiting Program");
                return;
            }

           // var devPath = "C:\\Users\\bolinger\\Documents\\Visual Studio 2019\\Projects\\sw-part-auto-test\\sw-part-auto-test\\toppAppDBdaemon\\blob\\C-HSSX.blob.SLDPRT";
            var path = "toppAppDBdaemon\\blob\\C-HSSX.blob.SLDPRT";

            DocumentSpecification documentSpecification =
                SWDocSpecification.GetDocumentSpecification(swApp, path);

            if(documentSpecification == null)
            {
                logger.Error("\n ERROR: Could not Get Document Specification for file: " +
                    path + "\n - Exiting Program");
                return;
            }

            logger.Debug("\n Getting Model from Document Specification");

            ModelDoc2 model = (ModelDoc2)swApp.OpenDoc7(
                documentSpecification);

            if(model == null)
            {
                logger.Error("\n ERROR: Could not get Model from " +
                    "Document Specification\n - Exiting Program");
                return;
            }

            Config.model = model;

            logger.Debug("\n Getting Equation Manager from Model");

            EquationMgr equationManager = model.GetEquationMgr();

            if(equationManager == null)
            {
                logger.Error("\n ERROR: Could not get Equation Manager from Model\n" +
                    " - Exiting Program");
                return;
            }

            Config.equationManager = equationManager;

            logger.Debug("\n SolidWorks App Instance Initialized - Starting Microservice Daemon");

            Daemon.Start();


           logger.Debug("\n Closing Open SolidWorks Documents" +
               "\n - Exiting Microservice");
           swApp.CloseAllDocuments(true);
        }
    }
}
