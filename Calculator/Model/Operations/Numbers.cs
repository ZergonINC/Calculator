using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model.Operations
{
    public class Numbers : IParameterizedOperationExecuting
    {
        BaseCalculatorModel _calculator;

        public Numbers(BaseCalculatorModel calculator)
        {
            _calculator = calculator;
        }

        public bool CanDo()
        {
            return _calculator.Operator != String.Empty;
        }

        public string Do(string number)
        {
            _calculator.Elements = _calculator.Elements.Append(number).ToList();

            _calculator.Writeback.Push(number);

            if (CanDo())
            {
                _calculator.Writeback.Push(_calculator.Operator);
                _calculator.Operator = String.Empty;
            }

            return String.Join(" ", _calculator.Elements);    
        }
    }
}