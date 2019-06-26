using SolidWorks.Interop.sldworks;
using System.Collections.Generic;

namespace sw_part_auto_test
{
    class MainMenu : ConsoleFrame
    {
        public static void Make(SWApp swApp)
        {
            var cover = new CoverDTO();
            var model = swApp.GetModel();
            var equationManager = swApp.GetEquationManager();
            var coverDDO = new List<CurrentEquationsDDO>();

            /*
            cover.SetCoverDiameter(
                User.GetConsoleInput("\nEnter Cover Diameter: ")
                );

            Out.Ln("Cover Diameter: " + cover.GetCoverDiameter());
            
            Out.Ln(AvailableEquationsDO.availableEquations[0]);

            var newEquation = AvailableEquationsDO.availableEquations[0] +
               " = " + cover.GetCoverDiameter() + "in";

            Out.Ln(newEquation);
            
            SWEquation.AddEquation(
                equationManager,
                newEquation
                );
                
            SWEquation.DisplayEquations(equationManager);

            SWEquation.Build(model);
            */
            
            
            // make into class.method that takes list<t> argument and
            // returns list<t>
            var userInput = User.GetConsoleInput("\nDoes the cover have a Bolt Circle?" +
                "\nEnter 1 for yes, else for no:");

            cover.SetBCbool(
                userInput
                );

             coverDDO[0].SetUserInput(userInput);

            
            Out.Ln(cover.GetBCbool());
            
            Out.Ln(AvailableEquationsDO.availableEquations[1]);
            Out.Ln(AvailableEquationsDO.availableEquations[2]);
            

            var newBCEquation = AvailableEquationsDO.availableEquations[1] +
                " " + cover.GetBCbool() + AvailableEquationsDO.availableEquations[2];

            
            coverDDO[0].SetEquation(
                AvailableEquationsDO.availableEquations[1]
                );
            coverDDO[0].SetEquationEnd(
                AvailableEquationsDO.availableEquations[2]
                );
                
            Out.Ln(newBCEquation);

            SWEquation.AddEquation(
                equationManager,
                newBCEquation
                );

            SWEquation.DisplayEquations(equationManager);

            var index = equationManager.GetCount() - 1;

            /*
            Out.Ln("equation: " + SWEquation.GetEquation(
                equationManager, index
                ));
                */

            coverDDO.Add(new CurrentEquationsDDO(
                index,
                userInput,
                AvailableEquationsDO.availableEquations[1],
                AvailableEquationsDO.availableEquations[2]
                ));

            /*
            coverDDO[0].SetIndex(
                index
                );
                
            
            Out.Ln(
                coverDDO[0].GetIndex()
                );
            Out.Ln(coverDDO[0].GetEquation());
            Out.Ln(coverDDO[0].GetUserInput());
            Out.Ln(coverDDO[0].GetEquationEnd());
            */

            SWEquation.Build(model);

            UserConsolePrompts.PressAnyKeyToContinue();
            

        }
    }
}
