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
            return _calculator.Operator == String.Empty;
        }

        public string Do(string number)
        {
            _calculator.Elements = _calculator.Elements.Append(number).ToList();

            _calculator.BinaryExample.Push(number);

            if (!CanDo())
            {
                _calculator.BinaryExample.Push(_calculator.Operator);
                _calculator.Operator = String.Empty;
            }

            return String.Join(" ", _calculator.Elements);    
        }
    }
}