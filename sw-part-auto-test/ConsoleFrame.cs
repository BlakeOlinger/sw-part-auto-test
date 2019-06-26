using System;

namespace sw_part_auto_test
{
    class ConsoleFrame
    {
        public static void FrameHeader()
        {
            var appHeader = "   TOPP Cover Automation Application\n";

            Out.Ln(appHeader);
        }

        internal static void DefaultFrame()
        {
            FrameHeader();
        }

        public static void CommandReferenceHeader()
        {
            Out.Ln("q - quit");
            Out.Ln("\n");
        }

        public static string FeatureSelection()
        {
            return "Select a feature to modify.\n" +
                " Cover Diameter: 1\n Cover BC Bool: 2";
        }

        public static void Clear()
        {
            Console.Clear();

            DefaultFrame();
        }
    }
}
