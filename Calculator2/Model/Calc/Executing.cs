using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model
{
    public class Executing : BaseExecuting
    {
        public override void Run()
        {
            double first = NumberConvertor.Convert(Calculator.LeftOperand);
            double second = NumberConvertor.Convert(Calculator.RightOperand);
            Calculator.Result = NumberConvertor.ConvertBack(Calculation.Make(first, second));
        }
    }
}
