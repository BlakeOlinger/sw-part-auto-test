using System;
using System.Collections.Generic;
using System.Text;

namespace sw_part_auto_test
{
    public class Validation
    {
        public static void ThrowArgumentExceptionIfEmptyArg(
            string input)
        {
            if (string.Equals(input, ""))
                throw new ArgumentException();
        }

        public static void ThrowArgumentExceptionIfNullArg(
            string input)
        {
            if (input == null)
                throw new ArgumentException();
        }
    }
}
