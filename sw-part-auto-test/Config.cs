using SolidWorks.Interop.sldworks;
using System.Collections.Generic;

namespace sw_part_auto_test
{
     internal class Config
    {
        internal static ISldWorks SW_APP;
        internal static readonly string SW_MS_CONFIG_PATH =
            ".\\programFiles\\config\\SWmicroservice.config";
        internal static readonly string BLEMP_CONFIG_PATH =
            ".\\programFiles\\blemp\\config.blemp";
        internal static readonly string BLEMP_DDO_PATH =
            ".\\programFiles\\blemp\\DDO.blemp";
        internal static readonly string BLOB_PATH =
            ".\\toppAppDBdaemon\\blob\\C-HSSX.blob.SLDPRT";
        internal static List<string> DDO = new List<string>();
        internal static ModelDoc2 model;
        internal static EquationMgr equationManager;
        internal static string programState = "1";
    }
}
