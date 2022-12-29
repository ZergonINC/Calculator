using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model.Operations.MemoryOperations
{
    public class MemorySave : IParameterizedOperationExecuting
    {
        BaseCalculatorModel _calculator;

        public MemorySave(BaseCalculatorModel calculator)
        {
            _calculator = calculator;
        }

        public bool CanDo()
        {
            return true;
        }

        public string Do(string memory)
        {
            _calculator.Memory = memory;

            return _calculator.Memory;
        }
    }
}
