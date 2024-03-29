﻿using Calculator.Interfaces;
using Calculator.Model.CalculationOperations;
using Calculator.Model.Executers;
using Calculator.Model.ExpressionsCalculatingModel;
using Calculator.Model.Operations;
using Calculator.Model.Operations.ConvertorsAndValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model.AdvancedCalculatingModel
{
    public class AdvancedEqually : IOperationExecuting
    {
        BaseCalculatorModel _advancedCalculator;

        RPNConverter converter = new();

        public AdvancedEqually(BaseCalculatorModel advancedCalculator)
        {
            _advancedCalculator = advancedCalculator;
        }

        public bool CanDo()
        {
            return _advancedCalculator.Operator != String.Empty;
        }

        public string Do()
        {
            List<string> RPNElements = converter.ToRPN(_advancedCalculator.Elements);

            Stack<string> temp = new();

            foreach (var token in RPNElements)
            {
                if (!NumberValidator.Check(token))
                {
                    _advancedCalculator.SecondOperand = temp.Pop();
                    _advancedCalculator.FirstOperand = temp.Pop();

                    Executing executing = new ExecutingBuilder()
                        .SetCalculator(_advancedCalculator)
                        .SetCalculation(new Calculation(OperationsDictionary.arithmeticOperations.GetValueOrDefault(token)))
                        .SetConvertor(new NumberConvertor()).Build();

                    executing.Run();

                    temp.Push(_advancedCalculator.Result);
                }
                else temp.Push(token);
            }

            _advancedCalculator.Result = temp.Pop().ToString();

            return _advancedCalculator.Result;
        }
    }
}