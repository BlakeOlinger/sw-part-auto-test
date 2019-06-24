using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw_part_auto_test
{
    class SWOpenPart
    {
        public static ModelDoc2 Open(ISldWorks app,
            DocumentSpecification documentSpecification)
        {
            ModelDoc2 swAssemblyDoc = default(ModelDoc2);

            if ((swAssemblyDoc = app.OpenDoc7(documentSpecification)) == null)
            {
                Out.Ln("Error: Could Not Open Assembly Document");

                return null;
            }
            else
                return swAssemblyDoc;
        }
    }
}
