using System;
using System.Globalization;
using System.IO;
using System.Threading;

namespace sw_part_auto_test
{
    class Daemon
    {
        private static readonly NLog.Logger logger =
            NLog.LogManager.GetCurrentClassLogger();
        public static void Start()
        {
            // var devBlempDDOpath = "C:\\Users\\bolinger\\Documents\\Visual Studio 2019\\Projects\\sw-part-auto-test\\sw-part-auto-test\\programFiles\\blemp\\DDO.blemp";
            // var devProgramStatePath = "C:\\Users\\bolinger\\Documents\\Visual Studio 2019\\Projects\\sw-part-auto-test\\sw-part-auto-test\\programFiles\\config\\SWmicroservice.config";
            var blempDDOpath = "programFiles\\blemp\\DDO.blemp";
            var programStatePath = "programFiles\\config\\SWmicroservice.config";
            var programState = "1";

            string current = null;
           string compare = null;

            logger.Debug("\n Microservice Daemon Started");

            do {

            var rawBlempString = Blemp.LoadDDO(blempDDOpath);

                if(rawBlempString == null)
                {
                    logger.Error("\n ERROR: Unable to load Blemp DDO");
                    return;
                }

                Blemp.PopulateDDO(rawBlempString);
                
                if (Config.DDO.Count > 0)
                {
                    try
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
                    } catch(ArgumentOutOfRangeException){ }
                }
                

               Thread.Sleep(300);

               programState = GetProgramState(programStatePath);

                if(programState == null)
                {
                    logger.Error("\n ERROR: Could not read program state");

                    return;
                }

           } while (string.Equals(programState, "0"));

            logger.Debug("\n Microservice Daemon Exiting");
        }

        private static string GetProgramState(string path)
        {
            try
            {
                var programState = File.ReadAllText(path).Substring(0, 1);

                return programState;
            }
            catch (ArgumentNullException exception)
            {
                logger.Error(exception, "\n ERROR: path argument cannot be null");

                return null;
            }
            catch (ArgumentException exception)
            {
                logger.Error(exception, "\n ERROR: path argument either empty or otherwise invalid");

                return null;
            }
            catch (FileNotFoundException exception)
            {
                logger.Error(exception, "\n ERROR: File " + path + " Not Found");

                return null;
            }
            catch (Exception exception)
            {
                logger.Error(exception, "\n ERROR: Could not read file");
                return null;
            }
        }
    }
}
