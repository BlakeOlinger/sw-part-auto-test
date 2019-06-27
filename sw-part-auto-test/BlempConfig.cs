using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace sw_part_auto_test
{
    class BlempConfig
    {
        public static void LoadConfig()
        {
            string configText = File.ReadAllText(
                "C:\\Users\\bolinger\\Documents\\SW Projects\\Blob\\C-HSSX.blemp"
                );
            Out.Ln(configText);

            PopulateDDO(configText);
        }

        private static void PopulateDDO(string input)
        {
           // Out.Ln(input);
            string[] strings = input.Split("$");

            Out.Ln(strings.Length);
            for (var i = 0; i < strings.Length; ++i)
            {
                Out.Ln(strings[i]);
                BlempConfigDDO.ddo[i] = strings[i];
            }
        }
    }
}
