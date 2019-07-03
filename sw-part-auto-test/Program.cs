
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
            /*
             * create working daemon - file listener for explicitly
             * specified .blemp files
             * make simple GUI for just a single equation - cover
             * dia
             */

            CreateSolidWorksInstance();

            if (isSolidWorksInstanceCreated)
            {
                InitializeSolidWorksInstance();

                if (isSolidWorksInitialized)
                    Daemon.Start();
            }

        }

        private static void InitializeSolidWorksInstance()
        {
            Config.model = Config.SW_APP.OpenDoc7(
                                Config.BLOB_PATH
                                );

            Config.equationManager = Config.model.GetEquationMgr();
        }

        private static void CreateSolidWorksInstance()
        {
            Config.SW_APP = CreateSWInstance.Create();
        }
    }
}
