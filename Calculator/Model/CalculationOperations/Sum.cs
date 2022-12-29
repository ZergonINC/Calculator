using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model.Operations
{
    public class Sum : IArithmetic
    {
        public double Result(double x, double y) => x + y;
    }
}
