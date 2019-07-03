using System.Globalization;
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
                // TODO refactor to utilize Config.DDO
                if (BlempConfigDDO.ddo.Length > 0 &&
                    BlempConfigDDO.ddo[0] != " ")
                {
                    compare = BlempConfigDDO.ddo[1];
                }

                
                if (string.Compare(current, compare) != 0)
                {
                    current = compare;

                    string equation = //BlempConfigDDO.ddo[0] +
                       // BlempConfigDDO.ddo[1] +
                       // BlempConfigDDO.ddo[2];

                    SWEquation.AddEquation(
                        equationManager,
                        equation
                        );

                    SWEquation.Build(
                        model
                        );
                    SWEquation.DeleteEquation(equationManager, 0);
                }
                

                Thread.Sleep(300);

                // TODO - refactor to read from SWmicroservice.config
                // while first character = "0"
                // add program state to config
            } while ();
        }


    }
}
