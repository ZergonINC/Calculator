using Calculator2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model.Operations
{
    public class Number : IParametrizedOperation
    {
        BaseCalculatorModel _calculator;

        string temp = String.Empty;

        public Number(BaseCalculatorModel calculator)
        {
            _calculator = calculator;
        }

        public bool CanDo()
        {
            return _calculator.Result == String.Empty;
        }

        public bool CanDoLeftOperand() => _calculator.Operator == String.Empty;

        public string Do(string number)
        {
            temp += number;

            temp = NumberValidator.Check(temp) ?
                NumberValidator.GetValidValue(temp) :
                temp.Remove(temp.Length - 1);

            if (CanDoLeftOperand())
            {

                    _calculator.LeftOperand += temp;
                    temp = String.Empty;
                    _calculator.Temp = _calculator.LeftOperand;
                return _calculator.LeftOperand;
            }

                _calculator.RightOperand += temp;
                temp = String.Empty;

            return _calculator.RightOperand;
        }
    }
}
