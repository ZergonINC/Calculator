using Calculator2.Interfaces;
using Calculator2.Model.CalculationOperations;
using Calculator2.Model.Executers;
using Calculator2.Model.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model.ExpressionsCalculatingModel
{
    public class CalculatingExpression : IOperationExecuting
    {
        BaseCalculatorModel _expressionCalculator;

        RPNConverter converter = new();

        public CalculatingExpression(BaseCalculatorModel expressionCalculator)
        {
            _expressionCalculator = expressionCalculator;
        }

        public bool CanDo()
        {
            return _expressionCalculator.Operator != String.Empty;
        }

        public bool CanRealize()
        {
            return _expressionCalculator.Elements.Count > 2;
        }

        public string Do()
        {
            Stack<string> temp = new();

            foreach (var token in _expressionCalculator.Elements)
            {
                if (!NumberValidator.Check(token))
                {
                    _expressionCalculator.SecondOperand = temp.Pop();
                    _expressionCalculator.FirstOperand = temp.Pop();

                    Executing executing = new ExecutingBuilder()
                        .SetCalculator(_expressionCalculator)
                        .SetCalculation(new Calculation(OperationsDict.arithmeticOperations.GetValueOrDefault(token)))
                        .SetConvertor(new NumberConvertor()).Build();

                    executing.Run();

                    temp.Push(_expressionCalculator.Result);
                }
                else temp.Push(token);
            }

            _expressionCalculator.Result = temp.Pop().ToString();

            return _expressionCalculator.Result;
        }

        public void Realize()
        {
            List<string> RPNElements = converter.ToRPN(_expressionCalculator.Elements);

            _expressionCalculator.Elements = RPNElements;
        }
    }
}