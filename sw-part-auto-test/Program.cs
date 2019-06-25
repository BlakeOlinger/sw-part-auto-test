using SolidWorks.Interop.sldworks;
using System;
using System.Globalization;

namespace sw_part_auto_test
{
    class Program
    {
        static void Main(string[] args)
        {

            
            var app = CreateSWInstance.Create();

            Out.Ln("Attempting to open assembly...");

            
            var model = SWOpenPart.Open(app,
                (DocumentSpecification)app.GetOpenDocSpec(
                    "C:\\Users\\bolinger\\Documents\\SW Projects\\Blob\\C-HSSX.blob.SLDPRT"
                )
                );

            var equationManager = SWEquation.GetEquationMgr(model);
            
            // var newEquation = "\"O.D.@Sketch1\"= 42in";

            // SWEquation.AddEquation(equationManager, newEquation);

            // SWEquation.DisplayEquations(model.GetEquationMgr());

            // SWEquation.Build(model);

            
            // SWSystem.CloseApp(app, true);
        }
    }
}
