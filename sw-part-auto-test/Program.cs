
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

            var path = "some/file.path";

            DocumentSpecification documentSpecification =
                SWDocSpecification.GetDocumentSpecification(swApp, path);

            if(documentSpecification == null)
            {
                logger.Error("\n ERROR: Could not Get Document Specification for file: " +
                    path + "\n - Exiting Program");
                return;
            }


            /*
             * var swDocSpecification = (DocumentSpecification)Config.SW_APP
                .GetOpenDocSpec(Config.BLOB_PATH);
                */

           // Daemon.Start();


        }

        private static void InitializeSolidWorksInstance()
        {

            Out.Ln(" Model null = " + (Config.model == null));
            if(Config.model != null)
                Config.equationManager = Config.model.GetEquationMgr();
        }
    }
}
