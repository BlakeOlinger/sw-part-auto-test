using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace sw_part_auto_test
{
    class BlempDaemon
    {
        public static void Start(SWApp swApp)
        {
            var equationManager = swApp.GetEquationManager();
            var model = swApp.GetModel();
            var format = new NumberFormatInfo();

            string current = "40";

            do
                {

                BlempConfig.LoadConfig();
                string compare = BlempConfigDDO.ddo[1];

                // Out.Ln(string.Compare(current, compare));

                
                if (string.Compare(current, compare) != 0)
                {
                    current = compare;

                    Out.Ln("Daemon Detected Change");
                 
                    string equation = BlempConfigDDO.ddo[0] +
                        BlempConfigDDO.ddo[1] +
                        BlempConfigDDO.ddo[2];
                    Out.Ln("New Equation: " + equation);

                    SWEquation.AddEquation(
                        equationManager,
                        equation
                        );

                    SWEquation.Build(
                        model
                        );
                    SWEquation.DeleteEquation(equationManager, 0);
                }
                

                Thread.Sleep(300);
            } while (true);
        }


    }
}
