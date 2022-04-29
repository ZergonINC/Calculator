using Calculator2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model.Operations
{
    public class Sign : IParameterizedOperationExecuting
    {
        BaseCalculatorModel _calculator;

        public Sign(BaseCalculatorModel calculator)
        {
            _calculator = calculator;
        }

        public bool CanDo()
        {
            return _calculator.Operator == String.Empty;
        }

        public void Do(string sign)
        {
            _calculator.Operator = sign;
        }
    }
}
