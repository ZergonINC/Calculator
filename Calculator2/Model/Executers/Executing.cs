using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model.Executers
{
    public class Executing : BaseExecuting
    {
        public override void Run()
        {
            double second = NumberConvertor.Convert(Calculator.BinaryExample.Pop());
            double first = NumberConvertor.Convert(Calculator.BinaryExample.Pop());
            Calculator.Result = NumberConvertor.ConvertBack(Calculation.Make(first, second));
        }
    }
}
