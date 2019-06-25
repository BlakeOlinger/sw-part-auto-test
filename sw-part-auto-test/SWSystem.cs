using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw_part_auto_test
{
    class SWSystem
    {
        public static void CloseApp(ISldWorks sldWorks,
            bool includeUnsaved)
        {
            sldWorks.CloseAllDocuments(includeUnsaved);
        }
    }
}
