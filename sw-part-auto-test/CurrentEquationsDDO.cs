
using System;

namespace sw_part_auto_test
{
    // DDO - Dynamic Data Object
    // used to keep track of temparary
    // equations - their current index and value
    class CurrentEquationsDDO
    {
        private int index;
        private string userInput;
        private string equation;
        private string equationEnd;

        public string NewEquation()
        {
            return equation + " " + userInput + equationEnd;
        }

        public CurrentEquationsDDO(int index, string userInput,
            string equation, string equationEnd)
        {
            this.index = index;
            this.userInput = userInput;
            this.equation = equation;
            this.equationEnd = equationEnd;
        }

        public CurrentEquationsDDO(int index, string userInput,
            string equation)
        {
            this.index = index;
            this.userInput = userInput;
            this.equation = equation;
        }

        internal void SetUserInput(string userInput)
        {
            this.userInput = userInput;
        }

        public void SetEquation(string equation)
        {
            this.equation = equation;
        }

        internal void SetEquationEnd(string equationEnd)
        {
            this.equationEnd = equationEnd;
        }

        internal void SetIndex(int index)
        {
            this.index = index;
        }

        internal int GetIndex()
        {
            return index;
        }

        internal string GetUserInput()
        {
            return userInput;
        }

        internal string GetEquation()
        {
            return equation;
        }

        internal string GetEquationEnd()
        {
            return equationEnd;
        }
        
    }
}
