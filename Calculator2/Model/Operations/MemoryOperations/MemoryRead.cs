using Calculator2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model.Operations.MemoryOperations
{
    public class MemoryRead : IOperationExecuting
    {
        BaseCalculatorModel _calculator;

        public MemoryRead(BaseCalculatorModel calculator)
        {
            _calculator = calculator;
        }

        public bool CanDo()
        {
            return true;
        }

        public bool CanRealize()
        {
            return true;
        }

        public string Do()
        {
            return _calculator.Memory;
        }

        public string Realize()
        {
            return "";//
        }
    }
}
