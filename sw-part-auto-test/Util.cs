using System;
using System.Collections.Generic;
using System.Text;

namespace sw_part_auto_test
{
    class Util
    {
        public static string GetEquationBase(string equation)
        {
            return equation.Substring(0,
                (equation.Length - equation.IndexOf("=") + 1));
        }
    }
}
