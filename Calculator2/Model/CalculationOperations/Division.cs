using Calculator2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model.Operations
{
    public class Division : IArithmetic
    {
        public double Result(double x, double y) => x / y;
    }
}
