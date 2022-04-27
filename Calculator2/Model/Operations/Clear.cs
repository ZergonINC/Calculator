using Calculator2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model.Operations
{
    public class Clear : IOperation
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
            _calculator.LeftOperand = String.Empty;
            _calculator.RightOperand = String.Empty;
            _calculator.Result = String.Empty;
            _calculator.Operator = String.Empty;
            _calculator.Temp = String.Empty;

            return "0";
        }
    }
}
