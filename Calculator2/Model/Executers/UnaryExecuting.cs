using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model.Executers
{
    public class UnaryExecuting : BaseExecuting
    {
        public override void Run()
        {
            double first = NumberConvertor.Convert(Calculator.FirstOperand);
            Calculator.Result = NumberConvertor.ConvertBack(UnaryCalculation.Make(first));
        }
    }
}
