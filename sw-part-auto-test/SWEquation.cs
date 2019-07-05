using SolidWorks.Interop.sldworks;
using System;

namespace sw_part_auto_test
{
    class SWEquation
    {
        private static readonly NLog.Logger logger =
            NLog.LogManager.GetCurrentClassLogger();
        public static void AddEquation(EquationMgr equationMgr,
            string equation)
        {
            if ((equationMgr.Add(equationMgr.GetCount(), equation)) == 1){

                logger.Debug("\n ERROR: Equation not added to Equation Manager");

            } else
            {
                logger.Debug("\n Equation added successfully");
            }
        }

        
        public static void DeleteEquation(EquationMgr equationManager, int index)
        {
            equationManager.Delete(index);

            if (equationManager.GetCount() != 0)
                logger.Debug("\n ERROR: Could not delete equations");

            logger.Debug("\n Equation Deleted");
        }

        public static void Build(IModelDoc2 model)
        {

            if (model.EditRebuild3()) {
                logger.Debug("\n Rebuild Success");
            }
        }
    }
}
