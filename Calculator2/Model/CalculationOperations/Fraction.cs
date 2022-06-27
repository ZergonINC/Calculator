using Calculator2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model.CalculationOperations
{
    public class Fraction : IUnaryArithmetic
    {
        public double Result(double x) => 1 / x;
    }
}
