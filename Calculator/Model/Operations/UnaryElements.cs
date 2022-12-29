using Calculator.Interfaces;
using Calculator.Model.Operations.ConvertorsAndValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model.Operations
{
    public class UnaryElements : IParameterizedOperationExecuting
    {
        BaseCalculatorModel _calculator;

        public UnaryElements(BaseCalculatorModel calculator)
        {
            _calculator = calculator;
        }

        public bool CanDo()
        {
            return _calculator.Operator != String.Empty;
        }

        public string Do(string element)
        {
            _calculator.Elements = _calculator.Elements.Append(element).ToList();

            _calculator.Writeback.Push(element);  

            return "";
        }
    }
}
