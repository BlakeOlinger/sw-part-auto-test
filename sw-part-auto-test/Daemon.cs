using System;
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
            
            var blempDDOpath = "C:\\Users\\bolinger\\Desktop\\test install\\programFiles\\blemp\\DDO.blemp";
            var programStatePath = "C:\\Users\\bolinger\\Desktop\\test install\\programFiles\\config\\SWmicroservice.config";
            var programState = "0";

            string current = null;
           string compare = null;

            logger.Debug("\n Microservice Daemon Started");

            do {
                
            var rawBlempString = Blemp.LoadDDO(blempDDOpath);
                
                if (rawBlempString == null)
                {
                    logger.Error("\n ERROR: Unable to load Blemp DDO");
                    return;
                }

                if (string.Compare(rawBlempString, "") != 0)
                {
                    logger.Debug("\n - Raw blemp data - " + rawBlempString +
                                    "\n - Press Any Key to Continue...");
                }

                // Console.Read();

                string blempString = "";

                try
                {
                    blempString = File.ReadAllText(blempDDOpath);
                } catch (IOException exception)
                {
                    logger.Error(exception, "Error Could Not Read DDO.blemp");
                }

                if (string.Compare(
                    blempString == null ? "" : blempString ,
                    "") != 0)
                {
                    Blemp.PopulateDDO(rawBlempString);

                    logger.Debug(" - DDO Count - " + Config.DDO.Count +
                                "\n - Press Any Key to Continue...");
                    
                   // Console.Read();
                    try
                    {
                        compare = Config.DDO[1];
                        
                        logger.Debug(" - compare & DDO[1] - " + compare
                            + "   " + Config.DDO[1] +
                                "\n - Press Any Key to Continue...");
                        
                       // Console.Read();

                        if (string.Compare(current, compare) != 0)
                        {
                            
                            current = compare;
                            
                            string equation = Config.DDO[0] + Config.DDO[1] +
                                Config.DDO[2];
                            
                            logger.Debug(" - Equation to SW - " + equation +
                                "\n - Press Any Key to Continue...");
                            
                            //Console.Read();

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
