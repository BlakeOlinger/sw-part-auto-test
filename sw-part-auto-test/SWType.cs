﻿using System;
using System.Collections.Generic;
using System.Text;

namespace sw_part_auto_test
{
    class SWType
    {
        private static readonly NLog.Logger logger =
            NLog.LogManager.GetCurrentClassLogger();

       internal static Type GetFromProgID(string progID)
        {
            

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

            return null;
        }
    }
}
