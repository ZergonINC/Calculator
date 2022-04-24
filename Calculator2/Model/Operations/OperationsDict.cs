using Calculator2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model.Operations
{
    public static class OperationsDict
    {
        public static readonly Dictionary<string, IArithmetic> arithmeticOperations = new()
        {
            { "+", new Sum() },
            { "-", new Subtraction() },
            { "*", new Multiplication() },
            { "/", new Division() },
        };
    }
}
