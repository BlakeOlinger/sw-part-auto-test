using SolidWorks.Interop.sldworks;
using System;
using System.Threading;

namespace sw_part_auto_test
{
    class MainMenu : ConsoleFrame
    {
        public static void Make(ISldWorks app)
        {
            CoverDTO cover = new CoverDTO();

            DefaultFrame();

            Out.Ln("Attempting to open document...");


            var model = SWOpenPart.Open(app,
                (DocumentSpecification)app.GetOpenDocSpec(
                    "C:\\Users\\bolinger\\Documents\\SW Projects\\Blob\\C-HSSX.blob.SLDPRT"
                )
                );

            var equationManager = SWEquation.GetEquationMgr(model);

            if (equationManager != null)
            {

                try
                {
                    Out.Ln("\nDocument Successfully Opened...");
                    Thread.Sleep(500);
                } catch(ArgumentOutOfRangeException ignore)
                {
                    Out.Ln("Thread Execution Exception");
                }

                Out.Ln("\nDocument Successfully Opened.");

                Console.Clear();

                DefaultFrame();
            }
            
            cover.SetCoverDiameter(
                User.GetConsoleInput("Enter Cover Diameter: ")
                );

            Out.Ln("Cover Diameter: " + cover.GetCoverDiameter());
            
            // Out.Ln(AvailableEquationsDO.availableEquations[0]);

            var newEquation = AvailableEquationsDO.availableEquations[0] +
               " = " + cover.GetCoverDiameter() + "in";

            Out.Ln(newEquation);
            
            SWEquation.AddEquation(
                equationManager,
                newEquation
                );
                
            SWEquation.DisplayEquations(equationManager);

            SWEquation.Build(model);

            UserConsolePrompts.PressAnyKeyToContinue();
            
        }
    }
}
