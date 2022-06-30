using Calculator2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model.Executers
{
    public class Calculation : ICalculation
    {
        private IArithmetic arithmetic { get; set; }

        public Calculation(IArithmetic arithmetic) => this.arithmetic = arithmetic;

        public double Make(double x, double y) => arithmetic.Result(x, y);
    }
}
