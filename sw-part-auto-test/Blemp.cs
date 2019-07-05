using System;
using System.IO;

namespace sw_part_auto_test
{
    class Blemp
    {
        private static readonly NLog.Logger logger =
            NLog.LogManager.GetCurrentClassLogger();
        public static string LoadDDO(string path)
        {
            try
            {
               var rawBlempString = File.ReadAllText(path);

                return rawBlempString;
            } catch(ArgumentNullException exception)
            {
                logger.Error(exception, "\n ERROR: path argument cannot be null");

                return null;
            } catch (ArgumentException exception)
            {
                logger.Error(exception, "\n ERROR: path argument either empty or otherwise invalid");

                return null;
            } catch (FileNotFoundException exception)
            {
                logger.Error(exception, "\n ERROR: File " + path + " Not Found");

                return null;
            } catch (Exception exception)
            {
                logger.Error(exception, "\n ERROR: Could not read file");
                return null;
            }
        }

        public static void PopulateDDO(string DDOdata)
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
