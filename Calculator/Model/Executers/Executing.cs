using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model.Executers
{
    public class Executing : BaseExecuting
    {
        public override void Run()
        {
            double first = NumberConvertor.Convert(Calculator.FirstOperand);
            double second = NumberConvertor.Convert(Calculator.SecondOperand);
            Calculator.Result = NumberConvertor.ConvertBack(Calculation.Make(first, second));
        }
    }
}
