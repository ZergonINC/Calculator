using Calculator2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model.Operations.ClearOperations
{
    public class Clear : IOperationExecuting
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

        public bool CanRealize()
        {
            return true;
        }

        public string Do()
        {
            _calculator.Elements.Clear();

            _calculator.BinaryExample.Clear();

            _calculator.Result = string.Empty;

            _calculator.Operator = string.Empty;

            _calculator.FirstOperand = string.Empty;

            _calculator.SecondOperand = string.Empty;

            return "0";
        }

        public void Realize()
        {
            _calculator.Elements.Clear();

            _calculator.BinaryExample.Clear();

            _calculator.FirstOperand = string.Empty;

            _calculator.SecondOperand = string.Empty;

            _calculator.Operator = string.Empty;
        }
    }
}
