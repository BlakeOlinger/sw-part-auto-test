using System.IO;

namespace sw_part_auto_test
{
    class Blemp
    {
        public static void LoadDDO()
        {
            
            string DDOdata = File.ReadAllText(
                Config.BLEMP_DDO_PATH
                );
                
            PopulateDDO(DDOdata);
        }

        private static void PopulateDDO(string DDOdata)
        {
            string[] equationSegments = DDOdata.Split("$");

            if (equationSegments.Length > 0)
            {
                for (var i = 0; i < equationSegments.Length; ++i)
                {
                    Config.DDO.Add(equationSegments[i]);
                }
            }
        }
    }
}
