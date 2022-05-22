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
            return NumberValidator.Check(_calculator.Elements[^1]);
        }

        public string Do(string sign)
        {
            _calculator.Operator = sign;

            if (!CanDo())
                _calculator.Elements.RemoveAt(_calculator.Elements.Count - 1);

            _calculator.Elements = _calculator.Elements.Append(_calculator.Operator).ToList();

            return String.Join(" ", _calculator.Elements);
        }
    }
}
