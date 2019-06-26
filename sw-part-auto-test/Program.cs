
using System.Collections.Generic;

namespace sw_part_auto_test
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
             * TODO - Begin to define .blemp.config and .blemp templates
             * and ui frames - .blemp will have to track index as modified
             * to keep track of what equations correspond to user input
             * 
             * blemp.confing - create file and create data object correlating
             * the equations to indexes - hard code now do via .blemp.config
             * file later
             * 
             * initial ui frame - create basic proof of concept ui frame
             * allowing user to select initial configuration settings -
             * has hatch, holes, BCs, etc.
             * 
             * later - create file interface with .blemp to store configurations
             * and parts as configurations - no need for heavy .sw files - only
             * need base blob and an appropriately named .blemp file
             * 
             * later - populate templates to choose from based on simple directory
             * based database - publish to cloud before imposing template mandates
             * 
             * later - enforce unknown configurations to be saved as new .blemp
             * files and sync .blemp - only - with cloud database
             */

            var app = CreateSWInstance.Create();

            // StartScreen.Make(HelpInformation.initialAppMessage);

            var swApp = SWApp.initialize(app);

            var coverDDO = new List<CurrentEquationsDDO>();

            MainMenu.Make(swApp, coverDDO);

            SWSystem.CloseApp(app, true);
        }
    }
}
