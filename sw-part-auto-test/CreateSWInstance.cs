
using SolidWorks.Interop.sldworks;
using System;

namespace sw_part_auto_test
{
    class CreateSWInstance
    {
        private ISldWorks app;
        public static ISldWorks Create()
        {
            try
            {
                Out.Ln("Creating SW App...");

                Out.Ln("Getting SW App Type...");
                var swType = Type.GetTypeFromProgID("SldWorks.Application.24");
                if (swType == null)
                    throw new Exception();
                Out.Ln("...Success");

                try
                {
                    Out.Ln("Instantiating SW App...");
                    var app = (ISldWorks)Activator.CreateInstance(swType);
                    if (app == null)
                        throw new Exception();
                    Out.Ln("...Success");

                    return app;
                } catch(Exception ignore)
                {
                    Out.Ln("Error: Failed to Create SW App Instance");

                    return null;
                }

            } catch(Exception ignore) 
            {
                Console.WriteLine("Error: Could not define SW App type");

                return null;
            }
        }
    }
}
