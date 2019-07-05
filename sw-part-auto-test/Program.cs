
using SolidWorks.Interop.sldworks;
using System.IO;

namespace sw_part_auto_test
{
    public class Program
    {
        private static bool isSolidWorksInitialized =
            Config.model != null &&
            Config.equationManager != null;
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

            var swApp = CreateSWInstance.Create(swType);

            if(swApp == null)
            {
                logger.Error("\n ERROR: Could not get reference to " +
                    "SolidWorks App\n - Exiting Program");
                return;
            }

            /*
            Out.Ln("SW Created " + (isSolidWorksInstanceCreated));
            if (isSolidWorksInstanceCreated)
            {
                InitializeSolidWorksInstance();

                Out.Ln(" SW Init " + (isSolidWorksInitialized));

                if (isSolidWorksInitialized)
                    Daemon.Start();
            }
            */

        }

        private static void InitializeSolidWorksInstance()
        {
            var swDocSpecification = (DocumentSpecification)Config.SW_APP
                .GetOpenDocSpec(Config.BLOB_PATH);
            Out.Ln("SW Doc Spec null" + (swDocSpecification == null));

            Config.model = Config.SW_APP.OpenDoc7(swDocSpecification);
            Out.Ln(" file found " + (File.Exists(Config.BLOB_PATH)));

            Out.Ln(" Model null = " + (Config.model == null));
            if(Config.model != null)
                Config.equationManager = Config.model.GetEquationMgr();
        }
    }
}
