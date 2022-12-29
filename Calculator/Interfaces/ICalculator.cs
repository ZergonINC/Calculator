using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Interfaces
{
    public interface ICalculator
    {
        List<string> Elements { get; set; }

        Stack<string> Writeback { get; set; }

        public string FirstOperand { get; set; }

        public string SecondOperand { get; set; }

        string Operator { get; set; }

        string Result { get; set; }

        string Memory { get; set; }

        int Bracket { get; set; }
    }
}
