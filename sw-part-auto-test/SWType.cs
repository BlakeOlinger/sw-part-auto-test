using System;
using System.Collections.Generic;
using System.Text;

namespace sw_part_auto_test
{
    public class SWType
    {
        private static readonly NLog.Logger logger =
            NLog.LogManager.GetCurrentClassLogger();

       public static Type GetFromProgID(string progID)
        {

           try
            {
                Validation.
                    ThrowArgumentExceptionIfEmptyArg(
                    progID);

                Validation.
                    ThrowArgumentExceptionIfNullArg(
                    progID);

                var swType = Type.GetTypeFromProgID("SldWorks.Application.24");


                // TODO - make return type Validation.method and test
                // test this SWType method that returns nulls when expected
                if (swType == null)
                    throw new Exception();

            } catch (ArgumentException exception)
            {
                logger.Error(exception,
                    " Argument cannot be empty or null");

                return null;
            } catch (Exception exception)
            {
                logger.Error(exception, " Could not get Type of ProgID");
            }


            // TODO - Wrap in a (Type Class.method(string progID)) that
            // catches ARgumentException for null progID,
            // throws exception for returns null
            // and throws for a return that isn't System.RuntimeType
            // MAKE tests testing the method for these cases
            // MAKE proper logging available rather than simple console.out
            //   var swType = Type.GetTypeFromProgID("SldWorks.Application.24");
            //   Out.Ln(" SW Type is null " + (swType == null));
            // return null for ProgID not found or error loading the Type
            // Exception - ArgumentException if ProgID is null

            //   Out.Ln(" SW Type Info: " + swType.GetType());
            // return System.RuntimeType for valid SW ProgID
            
        }
    }
}
