using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model.Executers
{
    public class UnaryCalculation : IUnaryCalculation
    {
            private IUnaryArithmetic unaryArithmetic { get; set; }

            public UnaryCalculation(IUnaryArithmetic unaryArithmetic) => this.unaryArithmetic = unaryArithmetic;

            public double Make(double x) => unaryArithmetic.Result(x);
    }
}
