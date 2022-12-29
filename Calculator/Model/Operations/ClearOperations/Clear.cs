using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model.Operations.ClearOperations
{
    public class Clear : IOperationExecuting
    {
        BaseCalculatorModel _calculator;

        public Clear(BaseCalculatorModel calculator)
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

            _calculator.Result = string.Empty;

            _calculator.Operator = string.Empty;

            _calculator.FirstOperand = string.Empty;

            _calculator.SecondOperand = string.Empty;

            _calculator.Bracket = 0;

            return "0";
        }
    }
}
