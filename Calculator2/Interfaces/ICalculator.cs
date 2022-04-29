using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Interfaces
{
    public interface ICalculator
    {
        string LeftOperand { get; set; }

        string RightOperand { get; set; }

        string Operator { get; set; }

        string Result { get; set; }
    }
}
