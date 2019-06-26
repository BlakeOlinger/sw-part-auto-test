using System;

namespace sw_part_auto_test
{
    class ConsoleFrame
    {
        public static void FrameHeader()
        {
            var appHeader = "   TOPP Cover Automation Application";

            Out.Ln(appHeader);
        }

        internal static void DefaultFrame()
        {
            FrameHeader();
        }

        public static void CommandReferenceHeader()
        {

        }
    }
}
