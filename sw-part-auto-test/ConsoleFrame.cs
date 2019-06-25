using System;

namespace sw_part_auto_test
{
    class ConsoleFrame
    {
        private static void FrameHeader()
        {
            var appHeader = "   TOPP Cover Automation Application";

            Out.Ln(appHeader);
        }
        public static string StartScreen()
        {
            FrameHeader();

            Out.Ln("\n" + HelpInformation.initialAppMessage);

            UserConsolePrompts.PressAnyKeyToContinue();

            return null;
        }

        internal static void InitialFrame()
        {
            FrameHeader();
        }
    }
}
