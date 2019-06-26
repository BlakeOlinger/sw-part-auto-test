using System;

namespace sw_part_auto_test
{
    class UserConsolePrompts
    {
        /*
        public static void ClearConsoleConfirm()
        {
            var prompt = "Would you like to clear the screen?";
            prompt += " yes (y), no (n)";
            var userInput = User.GetConsoleInput(prompt);

            if(userInput == "y")
            {
                Console.Clear();

                ConsoleFrame.DefaultFrame();
            }
        }
        */
        public static void PressAnyKeyToContinue()
        {
            var prompt = "\n ... Press any key continue.";

            var userInput = User.GetConsoleInput(prompt);

        }

    }
}
