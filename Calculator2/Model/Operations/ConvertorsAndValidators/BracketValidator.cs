using Calculator2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model.Operations.ConvertorsAndValidators
{
    public class BracketValidator : IOperationExecuting
    {
        BaseCalculatorModel _calculator;

        public BracketValidator(BaseCalculatorModel calculator)
        {
            _calculator = calculator;
        }

        public bool CanDo()
        {
            return _calculator.Bracket >= 0;
        }

        public string Do()
        {
            _calculator.Bracket = _calculator.Elements.Select(i => _calculator.Bracket += i == "(" ? 1 : i == ")" ? -1 : 0)
                .LastOrDefault();

            return _calculator.Bracket > 0 ? "( = " + _calculator.Bracket.ToString() : "0";
        }
    }
}
