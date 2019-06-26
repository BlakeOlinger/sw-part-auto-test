using System;
using System.Collections.Generic;
using System.Text;

namespace sw_part_auto_test
{
    class CoverDTO
    {
        private string coverDiameter;
        private string BCbool;

        public void SetCoverDiameter(string diameter)
        {
            coverDiameter = diameter;
        }

        public string GetCoverDiameter()
        {
            return coverDiameter;
        }

        public void SetBCbool(string hasBC)
        {
            BCbool = hasBC;
        }

        public string GetBCbool()
        {
            return BCbool;
        }
    }
}
