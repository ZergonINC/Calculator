using Calculator2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model
{
    public class CalculatorModel
    {
        private IOperation Operation { get; set; }

        public CalculatorModel()
        {
            SetOp(this.Operation);
        }

        public CalculatorModel SetOp(IOperation operation)
        {
            this.Operation = operation;
            return this;
        }

        public bool CanDo()
        {
            return this.Operation.CanDo();
        }

        public string Do()
        {
            return this.Operation.Do();
        }
    }
}
