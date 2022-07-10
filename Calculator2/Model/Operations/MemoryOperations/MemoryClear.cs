using Calculator2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model.Operations.MemoryOperations
{
    public class MemoryClear : IOperationExecuting
    {
        BaseCalculatorModel _calculator;

        public MemoryClear(BaseCalculatorModel calculator)
        {
            _calculator = calculator;
        }

        public bool CanDo()
        {
            return true;
        }

        public string Do()
        {
            _calculator.Memory = String.Empty;

            return "0";
        }
    }
}
