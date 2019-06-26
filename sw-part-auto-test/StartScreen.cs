
using System;

namespace sw_part_auto_test
{
    class StartScreen : ConsoleFrame
    {
        internal static void Make(string initialAppMessage)
        {
            FrameHeader();

            Out.Ln("\n" + initialAppMessage);

            Out.Ln("\n  ...Press Enter to Continue.");

            var ignoreUserInput = Console.ReadLine();

            Console.Clear();
        }
    }
}
