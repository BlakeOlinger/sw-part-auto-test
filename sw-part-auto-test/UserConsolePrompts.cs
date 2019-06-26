using System;

namespace sw_part_auto_test
{
    class UserConsolePrompts
    {
        public static void PressAnyKeyToContinue()
        {
            var prompt = "\n ... Press any key continue.";

            var userInput = User.GetConsoleInput(prompt);

        }

    }
}
