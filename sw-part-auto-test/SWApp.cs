using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Text;
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

            ConsoleFrame.DefaultFrame();

            // Need to make this 'attempting to connect to DB...'
            // use a local git repo connected to remote as DB
            // change from this path to an install folder directory
            // have a dev folder and a deployed folder that is a
            // relative path
            // have a DB check that checks for a git config file
            // if not go through DB (git) set-up and request
            // user name and email - then have a DB initialize and install
            // dialogue out to console
            // will likely include git login as well
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
