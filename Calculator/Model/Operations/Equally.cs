using Calculator.Interfaces;
using Calculator.Model.CalculationOperations;
using Calculator.Model.Executers;
using Calculator.Model.Operations.ConvertorsAndValidators;
using Calculator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model.Operations
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
            return _calculator.Writeback.Count > 2 && !NumberValidator.Check(_calculator.Elements.LastOrDefault(""));
        }

        public string Do()
        {
            string arithmeticOperator = _calculator.Writeback.Pop();

            _calculator.SecondOperand = _calculator.Writeback.Pop();

            _calculator.FirstOperand = _calculator.Writeback.Pop();

            Executing executing = new ExecutingBuilder()
                .SetCalculator(_calculator)
                .SetCalculation(new Calculation(OperationsDictionary.arithmeticOperations.GetValueOrDefault(arithmeticOperator)))
                .SetConvertor(new NumberConvertor()).Build();

            executing.Run();

            _calculator.Writeback.Push(_calculator.Result);

            return _calculator.Result;
        }
    }
}
