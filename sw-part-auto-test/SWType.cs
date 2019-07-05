using System;

namespace sw_part_auto_test
{
    public class SWType
    {
        private static readonly NLog.Logger logger =
            NLog.LogManager.GetCurrentClassLogger();

       public static Type GetFromProgID(string progID)
        {

           logger.Debug("\n Getting SolidWorks Type from ProgID - " +
                    progID);

            try
            {
                try
                {
                    if(progID == null ||
                        string.Compare(progID, "") == 0)
                    {
                        throw new ArgumentException();
                    }
                } catch(ArgumentException exception)
                {
                    logger.Error(exception, "\n Invalid Argument: " +
                        "ProgID was either empty or null");

                    return null;
                }

                var swType = Type.GetTypeFromProgID("SldWorks.Application.24");

                if (swType == null)
                    throw new Exception();

                logger.Debug("\n Returning Type for ProgID: " +
                    progID);

                return swType;
            } catch(Exception exception)
            {
                logger.Error(exception, "\n ERROR: Could not Get Type from ProgID: " +
                    progID);

                return null;
            }
            
        }
    }
}
