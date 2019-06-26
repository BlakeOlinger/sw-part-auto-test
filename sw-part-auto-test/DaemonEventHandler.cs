
using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Threading;

namespace sw_part_auto_test
{
    class DaemonEventHandler
    {
        public static void Scheduler(string userInput,
            List<CurrentEquationsDDO> coverDDO,
            EquationMgr equationManager,
            ModelDoc2 model
            )
        {
            int[] index = new int[3];

            do
            {
                
                switch (userInput)
                {
                    case "q":
                        break;
                    case "1":
                        index = FeatureListDictionary.GetEquationsIndexes(userInput);

                        // processUserInput isn't capable of multiple instances
                        // of the same input - tries to remake same equation
                        // over and over - either check if made or delete all
                        // over and over - may be easier to just delete all
                        // every request to start - would need to fetch dynamic
                        // index otherwise
                        coverDDO = FeatureEventHandler.ProcessUserInput(
                            coverDDO, equationManager, model,
                            AvailableEquationsDO.GetAll[index[0]],
                            AvailableEquationsDO.GetAll[index[1]],
                            AvailableEquationsDO.GetAll[index[2]]
                        );

                        // allows user to quit
                        if (coverDDO == null)
                        {
                            userInput = "q";
                        }
                        else
                        {
                            // obviously need to change -
                            userInput = "init";
                        }

                        break;

                    default:
                    userInput = User.GetConsoleInput(
                        ConsoleFrame.FeatureSelection()
                        );
                        break;
                }

                // Scheduler(userInput);
            } while (userInput != "q");
        }
    }
}
