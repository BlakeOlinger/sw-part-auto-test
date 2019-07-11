
using System;
using SolidWorks.Interop.sldworks;

namespace sw_part_auto_test
{
    public class Program
    {
        public static readonly string PROG_ID = "SolidWorks.Application.24";
        private static readonly NLog.Logger logger =
            NLog.LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {

            LiveUpdateTest();

            var swType = SWType.GetFromProgID(PROG_ID);

            if (swType == null)
            {
                logger.Error("\n ERROR: GetFromProgID returned null\n" +
                    " - Exiting Program");

                promptToExitProgram();

                return;
            }

            ISldWorks swApp = CreateSWInstance.Create(swType);

            if (swApp == null)
            {
                logger.Error("\n ERROR: Could not get reference to " +
                    "SolidWorks App\n - Exiting Program");

               promptToExitProgram();

                return;
            }

            var path = "C:\\Users\\bolinger\\Desktop\\test install\\toppAppDBdaemon\\blob\\C-HSSX.blob.SLDPRT";

            DocumentSpecification documentSpecification =
                SWDocSpecification.GetDocumentSpecification(swApp, path);

            if (documentSpecification == null)
            {
                logger.Error("\n ERROR: Could not Get Document Specification for file: " +
                    path + "\n - Exiting Program");

                promptToExitProgram();

                return;
            }

            logger.Debug("\n Getting Model from Document Specification");

            ModelDoc2 model = (ModelDoc2)swApp.OpenDoc7(
                documentSpecification);

            if (model == null)
            {
                logger.Error("\n ERROR: Could not get Model from " +
                    "Document Specification\n - Exiting Program");

                promptToExitProgram();

                return;
            }

            Config.model = model;

            logger.Debug("\n Getting Equation Manager from Model");

            EquationMgr equationManager = model.GetEquationMgr();

            if (equationManager == null)
            {
                logger.Error("\n ERROR: Could not get Equation Manager from Model\n" +
                    " - Exiting Program");

                promptToExitProgram();

                return;
            }

            Config.equationManager = equationManager;

            logger.Debug("\n SolidWorks App Instance Initialized - Starting Microservice Daemon");

            Daemon.Start();

            promptToExitProgram();

            logger.Debug("\n Closing Open SolidWorks Documents" +
                "\n - Exiting Microservice");
            swApp.CloseAllDocuments(true);
        }

        private static void LiveUpdateTest()
        {
            Console.WriteLine("Live Update Test Success!");
        }

        private static void promptToExitProgram()
        {
            /*
            Console.WriteLine(" - Press Any Key to Continue...");
            var userInput = Console.Read();
            */
        }
    }
}
