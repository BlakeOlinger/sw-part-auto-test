
using System.Collections.Generic;

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

            var app = CreateSWInstance.Create();

            // StartScreen.Make(HelpInformation.initialAppMessage);

            // BlempConfig.LoadConfig();

            
            var swApp = SWApp.initialize(app);

            BlempDaemon.Start(swApp);
            
            
            /*
            var coverDDO = new List<CurrentEquationsDDO>();

            MainMenu.Make(swApp, coverDDO);

            SWSystem.CloseApp(app, true);
            */
        }
    }
}
