using System;

namespace sw_part_auto_test
{
    class User
    {
        public static string GetConsoleInput(string inputRequest)
        {
            ConsoleFrame.Clear();
            ConsoleFrame.CommandReferenceHeader();

            Out.Ln(inputRequest);
            
            return Console.ReadLine();
        }
    }
}
