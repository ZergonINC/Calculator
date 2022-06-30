using Calculator2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator2.Model.ExpressionsCalculatingModel
{
    public class RPNConverter //Reverse Polish notation - RPN
    {
        public List<string> ToRPN(List<string> expressionElements)
        {
            List<string> postFixResult = new();

            Stack<string> operators = new();

            foreach (string element in expressionElements)
            {
                if (IsOperator(element))
                {
                    string top;
                    while (operators.Count > 0 &&
                        (top = operators.Peek()) != "(" &&
                        PrecedenceDifference(top, element) >= 0)
                    {
                        postFixResult.Add(operators.Pop());
                    }
                    operators.Push(element);
                }
                else if (element == "(") operators.Push(element);
                else if (element == ")")
                {
                    string top;
                    while (operators.Count > 0 && (top = operators.Pop()) != "(")
                    {
                        postFixResult.Add(top);
                    }
                }
                else postFixResult.Add(element);
            }
            while (operators.Count > 0) postFixResult.Add(operators.Pop());

            return postFixResult;
        }

        private bool IsOperator(string _operator) => "+-*/^".Contains(_operator);

        private int PrecedenceDifference(string _operator1, string _operator2) => GetPrecedence(_operator1) - GetPrecedence(_operator2);

        private int GetPrecedence(string _operator)
        {
            return _operator switch
            {
                "+" or "-" => 2,
                "*" or "/" => 3,
                "^" => 4,
                _ => throw new Exception($"Invalid operator: {_operator}"),
            };
        }
    }
}
