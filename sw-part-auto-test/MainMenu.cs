using System.Collections.Generic;

namespace sw_part_auto_test
{
    class MainMenu : ConsoleFrame
    {
        public static void Make(SWApp swApp, List<CurrentEquationsDDO> coverDDO)
        {
            var model = swApp.GetModel();
            var equationManager = swApp.GetEquationManager();

            // all the daemon has to do is return the appropriate indexes
            // for the equation list - which I could do with
            // featurelistdictionary
            //
            // DaemonEventHandler - may be obsolete
            // ^ not true
            // need the daemon to dispatch so the other
            // handlers don't have to all be able to do everything
            // absolutely anything receiving user input must
            // be handled by daemon


            string userInput = "init";
            DaemonEventHandler.Scheduler(
                userInput,
                coverDDO,
                equationManager,
                model
                );

            // every frame after the initial must have this header
            // every instance of user input must be able to select any
            // from the command menu
            // ConsoleFrame.CommandReferenceHeader();
            /*
            int[] index = new int[3];

             send to daemon
            index = FeatureListDictionary.GetEquationsIndexes(userInput);

             Out.Ln(userInput);
           
             send to daemon
            coverDDO = FeatureEventHandler.ProcessUserInput(
                coverDDO, equationManager, model,
                AvailableEquationsDO.GetAll[index[0]],
                AvailableEquationsDO.GetAll[index[1]],
                AvailableEquationsDO.GetAll[index[2]]
                );
            
            UserConsolePrompts.PressAnyKeyToContinue();

            ConsoleFrame.Clear();

            ConsoleFrame.CommandReferenceHeader();

            send to daemon
            userInput = User.GetConsoleInput("Type q to quit, " +
                "enter another command\n" +
                "  ...or press any key to return to the menu.");
                */
        }
    }
}
