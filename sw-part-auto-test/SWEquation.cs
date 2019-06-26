using SolidWorks.Interop.sldworks;
using System;
using System.Threading;

namespace sw_part_auto_test
{
    class SWEquation
    {
        public static void DisplayEquations(EquationMgr equationMgr)
        {
            Out.Ln("Attempting to open Equatin Manager...");           

            if(equationMgr == null)
            {
                Out.Ln("Failed to open equation manager");
            } else
            {
                Out.Ln("Displaying Equations:");

                var equationsCount = equationMgr.GetCount();
                
                if (equationsCount == 0)
                {
                    Out.Ln("Could not get equations.");
                }
                else
                {
                    for (var i = 0; i < equationsCount; ++i)
                    {
                        Out.Ln(
                            " Equation(" + (i + 1) + ") = " +
                            equationMgr.Equation[i] +
                            "\n Value = " +
                            equationMgr.Value[i] +
                            "\n Index = " +
                            equationMgr.Status
                            );
                    }
                }
            }
        }

        public static string GetEquation(EquationMgr equationMgr , int index)
        {
            if(EquationIndexValidation(equationMgr, index))
            {
                return "Could not get equation";
            } else
            {
                return equationMgr.Equation[index];
            }
        }

        public static void SetEquation(EquationMgr equationMgr, string equation,
            double value, int index)
        {
            if(equationMgr == null || equation == null)
            {
                Out.Ln("Could not Set Equation, missing arguments");
            } else
            {
                var equationBase = equation;
                string newEquation;

                if (equationMgr.SetEquationAndConfigurationOption(
                    index,
                    (newEquation = "\"O.D.@Sketch1\"= 24in"),
                    2,
                    null
                    ) != 1)
                {
                    Out.Ln("Failed to apply new values to equation");
                }

                Out.Ln(newEquation);
            }
        }

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

        /*
        public static void DeleteEquation(EquationMgr equationMgr, int index)
        {
            equationMgr.Delete(index);
        }
        */

        private static bool EquationIndexValidation(EquationMgr equationMgr,
            int index)
        {
            return equationMgr == null || equationMgr.GetCount() == 0 ||
                index > equationMgr.GetCount() || index < 0;
        }

        public static EquationMgr GetEquationMgr(ModelDoc2 model)
        {
            if(model == null)
            {
                Out.Ln("Document Model not available");

                return null;
            } else
            {
                return model.GetEquationMgr();
            }
        }

        public static void Build(IModelDoc2 model)
        {

            if (model.EditRebuild3()) {
                Out.Ln("Rebuild Returned Success");
            }
        }
    }
}
