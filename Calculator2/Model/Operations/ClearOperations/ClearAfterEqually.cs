using Calculator2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model.Operations.ClearOperations
{
    public class ClearAfterEqually : IOperationExecuting
    {
        BaseCalculatorModel _calculator;

        public ClearAfterEqually(BaseCalculatorModel calculator)
        {
            _calculator = calculator;
        }

        public bool CanDo()
        {
            return true;
        }

        public string Do()
        {
            _calculator.Elements.Clear();

            _calculator.Writeback.Clear();

            _calculator.FirstOperand = string.Empty;

            _calculator.SecondOperand = string.Empty;

            _calculator.Operator = string.Empty;

            _calculator.Bracket = 0;

            return "0";
        }
    }
}
