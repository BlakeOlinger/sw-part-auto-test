using SolidWorks.Interop.sldworks;
using System.Collections;

namespace sw_part_auto_test
{
     internal class Config
    {
        internal static ISldWorks SW_APP;
        internal static readonly string BLEMP_CONFIG_PATH =
            ".\\programFiles\\blemp\\config.blemp";
        internal static readonly string BLEMP_DDO_PATH =
            ".\\programFiles\\blemp\\DDO.blemp";
        internal static readonly string BLOB_PATH =
            ".\\toppAppDBdaemon\\blob\\C-HSSX.blob.SLDPRT";
        internal static ArrayList DDO = new ArrayList();
        internal static ModelDoc2 model;
        internal static EquationMgr equationManager;
    }
}
