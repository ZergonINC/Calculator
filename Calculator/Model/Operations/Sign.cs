using Calculator.Interfaces;
using Calculator.Model.Operations.ConvertorsAndValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model.Operations
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
            return !NumberValidator.Check(_calculator.Elements.LastOrDefault(""));
        }

        public bool CanDoSign(string sign)//подумать объединить ли методы
        {
            return !NumberValidator.Check(sign) && !NumberValidator.Check(_calculator.Elements.LastOrDefault(""));
        }

        public string Do(string sign)
        {
            _calculator.Operator = sign;

            if (CanDoSign(sign))
                _calculator.Elements.RemoveAt(_calculator.Elements.Count - 1);

            _calculator.Elements = _calculator.Elements.Append(_calculator.Operator).ToList();

            return String.Join(" ", _calculator.Elements);
        }
    }
}
