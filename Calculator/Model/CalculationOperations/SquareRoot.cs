using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model.CalculationOperations
{
    public class SquareRoot : IUnaryArithmetic
    {
        public double Result(double x) => Math.Sqrt(x);
    }
}
