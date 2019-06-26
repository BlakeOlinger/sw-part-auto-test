using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw_part_auto_test
{
    class FeatureEventHandler
    {
        public static List<CurrentEquationsDDO> ProcessUserInput(
            List<CurrentEquationsDDO> list, EquationMgr equationManager,
            ModelDoc2 model, string equation,
            string equationEnd, string userPrompt)
        { 
            var userInput = User.GetConsoleInput(userPrompt);

            var newEquation =
                equation +
                " " + userInput +
                equationEnd;

            // Out.Ln(newEquation);

            SWEquation.AddEquation(
                equationManager,
                newEquation
                );

           // SWEquation.DisplayEquations(equationManager);

            var index = equationManager.GetCount() - 1;

            list.Add(new CurrentEquationsDDO(
                index,
                userInput,
                equation,
                equationEnd
                ));

            SWEquation.Build(model);

            return list;
        }
    }
}
