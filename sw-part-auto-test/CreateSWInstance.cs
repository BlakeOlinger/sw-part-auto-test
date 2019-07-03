
using SolidWorks.Interop.sldworks;
using System;

namespace sw_part_auto_test
{
    class CreateSWInstance
    {
        public static ISldWorks Create()
        {
            try
            {


                return null;
                /*
                if (swType == null)
                    throw new Exception();

                try
                {
                    var app = (ISldWorks)Activator.CreateInstance(swType);
                    if (app == null)
                        throw new Exception();

                    return app;
                } catch (Exception)
                {
                    return null;
                }
                */

            } catch (Exception)
            {
                return null;
            }
            
        }
    }
}
