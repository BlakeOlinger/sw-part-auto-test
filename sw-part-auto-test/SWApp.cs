using SolidWorks.Interop.sldworks;
using System;
using System.Threading;

namespace sw_part_auto_test
{
    class SWApp
    {
        private EquationMgr equationManager;
        private ModelDoc2 model;

        public ModelDoc2 GetModel()
        {
            return model;
        }

        public EquationMgr GetEquationManager()
        {
            return equationManager;
        }
        public static SWApp initialize(ISldWorks app)
        {
            var swApp = new SWApp();

            Out.Ln("Attempting to open document...");

            swApp.model = SWOpenPart.Open(app,
                (DocumentSpecification)app.GetOpenDocSpec(
                    "C:\\Users\\bolinger\\Documents\\SW Projects\\Blob\\C-HSSX.blob.SLDPRT"
                )
                );

            swApp.equationManager = SWEquation.GetEquationMgr(swApp.model);

            if (swApp.equationManager != null)
            {

                try
                {
                    Out.Ln("Document Successfully Opened...");
                    Thread.Sleep(500);
                }
                catch (ArgumentOutOfRangeException ignore)
                {
                    Out.Ln("Thread Execution Exception");
                }

                Out.Ln("Document Successfully Opened.");

                Console.Clear();

                ConsoleFrame.DefaultFrame();
            }

            return swApp;
        }
    }
}
