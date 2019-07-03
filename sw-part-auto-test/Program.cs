
using SolidWorks.Interop.sldworks;
using System.IO;

namespace sw_part_auto_test
{
    class Program
    {
        private static bool isSolidWorksInitialized =
            Config.model != null &&
            Config.equationManager != null;
        private static bool isSolidWorksInstanceCreated =
            Config.SW_APP != null;

        static void Main(string[] args)
        {
            var progID = "SolidWorks.Application.24";

            SWType.GetFromProgID(progID);

            /*
             * create working daemon - file listener for explicitly
             * specified .blemp files
             * make simple GUI for just a single equation - cover
             * dia
             */

           // CreateSolidWorksInstance();

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

        private static void CreateSolidWorksInstance()
        {
            Config.SW_APP = CreateSWInstance.Create();
        }
    }
}
