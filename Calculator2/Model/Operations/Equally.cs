using Calculator2.Interfaces;
using Calculator2.Model.CalculationOperations;
using Calculator2.Model.Executers;
using Calculator2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model.Operations
{
    public class Equally : IOperationExecuting
    {
        BaseCalculatorModel _calculator;

        public Equally(BaseCalculatorModel calculator)
        {
            _calculator = calculator;
        }

        public bool CanDo()
        {
            return _calculator.BinaryExample.Count > 2 && !NumberValidator.Check(_calculator.Elements.LastOrDefault(""));
        }

        public bool CanRealize()
        {
            return _calculator.Operator != String.Empty;
        }

        public string Do()
        {
            string arithmeticOperator = _calculator.BinaryExample.Pop();

            _calculator.SecondOperand = _calculator.BinaryExample.Pop();

            _calculator.FirstOperand = _calculator.BinaryExample.Pop();

            Executing executing = new ExecutingBuilder()
                .SetCalculator(_calculator)
                .SetCalculation(new Calculation(OperationsDict.arithmeticOperations.GetValueOrDefault(arithmeticOperator)))
                .SetConvertor(new NumberConvertor()).Build();

            executing.Run();

            _calculator.BinaryExample.Push(_calculator.Result);

            return _calculator.Result;
        }

        public void Realize()
        {
            //если не пригодиться удалить
        }
    }
}
