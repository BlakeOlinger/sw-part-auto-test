
namespace sw_part_auto_test
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * create working daemon - file listener for explicitly
             * specified .blemp files
             * make simple GUI for just a single equation - cover
             * dia
             */

            CreateSolidWorksInstance();

            if (Config.SW_APP != null)
            {
                //
                // initializes only - reads and populates just once
                  Blemp.LoadDDO();

                // opens test - hard coded part model
                // - may add this and below to config itself -
                // won't be able to beyond testing
                Config.model = Config.SW_APP.OpenDoc7(
                    Config.BLOB_PATH
                    );

                // equation manager functionality comes from ModelDoc2
                Config.equationManager = Config.model.GetEquationMgr();

                 Daemon.Start();
            }

            /*
            var coverDDO = new List<CurrentEquationsDDO>();

            MainMenu.Make(swApp, coverDDO);

            SWSystem.CloseApp(app, true);
            */
        }

        private static void CreateSolidWorksInstance()
        {
            Config.SW_APP = CreateSWInstance.Create();
        }
    }
}
