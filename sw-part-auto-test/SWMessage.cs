using SolidWorks.Interop.sldworks;

namespace sw_part_auto_test
{
    class SWMessage
    {
        public static void PromptUser(ISldWorks app, string message)
        {
            app.SendMsgToUser(message);
        }
    }
}
