using Calculator2.Interfaces;
using Calculator2.Model.CalculationOperations;
using Calculator2.Model.Executers;
using Calculator2.Model.Operations.ConvertorsAndValidators;
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
            return _calculator.Writeback.Count > 2 && !NumberValidator.Check(_calculator.Elements.LastOrDefault(""));
        }

        public bool CanRealize()
        {
            return _calculator.Operator != String.Empty;
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

        public string Realize()
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
