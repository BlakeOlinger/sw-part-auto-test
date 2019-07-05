
using SolidWorks.Interop.sldworks;
using System;

namespace sw_part_auto_test
{
    public class CreateSWInstance
    {
        private static readonly NLog.Logger logger =
            NLog.LogManager.GetCurrentClassLogger();
        public static ISldWorks Create(Type swType)
        {
            try
            {
                logger.Debug("\n Creating reference to SolidWorks instance");

                var app = (ISldWorks)Activator.CreateInstance(swType);

                logger.Debug("\n Returning referenced instance: " + app);

                return app;
            } catch(Exception exception)
            {
                logger.Error(exception, "\n ERROR: Could not create reference\n" +
                    " To SolidWorks instance");
                return null;
            }
        }
    }
}
