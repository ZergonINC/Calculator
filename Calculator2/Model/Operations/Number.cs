using Calculator2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model.Operations
{
    public class Number : IParameterizedOperationExecuting
    {
        BaseCalculatorModel _calculator;

        public Number(BaseCalculatorModel calculator)
        {
            _calculator = calculator;
        }

        public bool CanDo()
        {
            return _calculator.Result == String.Empty;
        }

        public bool CanDoLeftOperand() => _calculator.Operator == String.Empty;

        public void Do(string number)
        {
            if (CanDoLeftOperand())
            {
                _calculator.LeftOperand = number;
                return;
            }
            _calculator.RightOperand = number;
        }
    }
}
