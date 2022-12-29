using Calculator.Interfaces;
using Calculator.Model.CalculationOperations;
using Calculator.Model.Executers;
using Calculator.Model.Operations.ConvertorsAndValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model.Operations
{
    public class UnaryEqually : IOperationExecuting
    {
        BaseCalculatorModel _calculator;

        public UnaryEqually(BaseCalculatorModel calculator)
        {
            _calculator = calculator;
        }

        public bool CanDo()
        {
            return _calculator.Operator != String.Empty;
        }

        public string Do()
        {
            string arithmeticOperator = _calculator.Writeback.Pop();

            _calculator.FirstOperand = _calculator.Writeback.Pop();

            UnaryExecuting unaryExecuting = new UnaryExecutingBuilder()
                .SetCalculator(_calculator)
                .SetUnaryCalculation(new UnaryCalculation(UnaryOperationsDictionary.arithmeticOperations.GetValueOrDefault(arithmeticOperator)))
                .SetConvertor(new NumberConvertor()).Build();

            unaryExecuting.Run();

            _calculator.Writeback.Push(_calculator.Result);

            return _calculator.Result;
        }
    }
}
