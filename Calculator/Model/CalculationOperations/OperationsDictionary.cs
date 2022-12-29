using Calculator.Interfaces;
using Calculator.Model.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model.CalculationOperations
{
    public static class OperationsDictionary
    {
        public static readonly Dictionary<string, IArithmetic> arithmeticOperations = new()
        {
            { "+", new Sum() },
            { "-", new Subtraction() },
            { "*", new Multiplication() },
            { "/", new Division() },
            { "^", new Power() },
        };
    }
}
