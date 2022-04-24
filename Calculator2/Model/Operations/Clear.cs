using Calculator2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model
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

        public void Do()
        {
            _calculator.LeftOperand = "";
            _calculator.RightOperand = "";
            _calculator.Result = "";
            _calculator.Operator = "";
            _calculator.Temp = "";
        }
    }
}
