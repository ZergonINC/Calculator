using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Interfaces
{
    public interface ICalculatorModel
    {
        List<double> Elements { get; set; }

        Stack<string> Writeback { get; set; }

        public double FirstOperand { get; set; }

        public double SecondOperand { get; set; }

        string Operator { get; set; }

        double Result { get; set; }

        string Memory { get; set; }
    }
}
