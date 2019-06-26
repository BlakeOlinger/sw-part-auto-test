/*
 * possible use: to provide information for which indexes
 * of AvailableEquations correspond to the index for the
 * CurrentEquationsDDO
 *      example - user action corresponds to a string - this
 *      has a switch that outputs the indexes of
 *      AvaiableEquationsDO
 */

namespace sw_part_auto_test
{
    class FeatureListDictionary
    {
        public static int[] GetEquationsIndexes(string userInput)
        {
            int[] indexes = new int[3];

            switch(userInput)
            {
                case "1":
                    indexes[0] = 0;
                    indexes[1] = 1;
                    indexes[2] = 2;
                    break;
                case "2":
                    indexes[0] = 3;
                    indexes[1] = 4;
                    indexes[2] = 5;
                    break;
            }

            return indexes;
        }
    }
}
