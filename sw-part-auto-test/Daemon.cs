using System.Globalization;
using System.IO;
using System.Threading;

namespace sw_part_auto_test
{
    class Daemon
    {
        public static void Start()
        {
            var format = new NumberFormatInfo();

            string current = null;
            string compare = null;

            do
                {

                Blemp.LoadDDO();

                if (Config.DDO.Count > 0)
                {
                    compare = Config.DDO[1];



                    if (string.Compare(current, compare) != 0)
                    {
                        current = compare;

                        // may cause problems 
                        // - equation may not be read properly by
                        // SW
                        string equation = Config.DDO.ToString();

                        SWEquation.AddEquation(
                            Config.equationManager,
                            equation
                            );

                        SWEquation.Build(
                            Config.model
                            );

                        SWEquation.DeleteEquation(
                            Config.equationManager
                            , 0);
                    }
                }
                

                Thread.Sleep(300);

                GetProgramState();
            } while (string.Equals(Config.programState, "0"));
        }

        private static void GetProgramState()
        {
            var programState = File.ReadAllText(
                Config.SW_MS_CONFIG_PATH
                );

            Config.programState = programState.Substring(0, 1);
        }
    }
}
