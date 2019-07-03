using SolidWorks.Interop.sldworks;

namespace sw_part_auto_test
{
    class SWEquation
    {

        public static void AddEquation(EquationMgr equationMgr,
            string equation)
        {
            if ((equationMgr.Add(equationMgr.GetCount(), equation)) == 1){
                Out.Ln("Equation Was Not Added");
            } else
            {
                Out.Ln("Equation Successfully Added");
            }
        }

        
        public static void DeleteEquation(EquationMgr equationManager, int index)
        {
            equationManager.Delete(index);
        }

        public static void Build(IModelDoc2 model)
        {

            if (model.EditRebuild3()) {
                Out.Ln("Rebuild Returned Success");
            }
        }
    }
}
