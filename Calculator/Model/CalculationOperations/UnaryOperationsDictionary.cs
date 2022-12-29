using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model.CalculationOperations
{
    public static class UnaryOperationsDictionary
    {
        public static readonly Dictionary<string, IUnaryArithmetic> arithmeticOperations = new()
        {
            { "±", new SignChange() },
            { "√", new SquareRoot() },
            { "|", new Fraction() }
        };
    }
}
