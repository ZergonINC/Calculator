using Calculator2.Interfaces;
using Calculator2.Model.Calc;
using Calculator2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model.Operations
{
    public class Equally : IOperation
    {
        SeparatorValidator separatorValidator = new();

        BaseCalculatorModel _calculator;

        public Equally(BaseCalculatorModel calculator)
        {
            _calculator = calculator;
        }

        public bool CanDo()
        {
            return _calculator.LeftOperand != String.Empty && _calculator.Operator != String.Empty && _calculator.RightOperand != String.Empty && _calculator.Result  == String.Empty;
        }

        public void Do()
        {
            _calculator.LeftOperand = separatorValidator.ReplaceSeparator(_calculator.LeftOperand);

            _calculator.RightOperand = separatorValidator.ReplaceSeparator(_calculator.RightOperand);

            Executing executing = new ExecutingBuilder().SetCalculator(_calculator).SetCalculation(new Calculation(OperationsDict.arithmeticOperations.GetValueOrDefault(_calculator.Operator))).SetConvertor(new NumberConvertor()).Build();

            executing.Run();
        }
    }
}
