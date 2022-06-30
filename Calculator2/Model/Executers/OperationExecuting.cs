using Calculator2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model.Executers
{
    public class OperationExecuting
    {
        private IOperationExecuting Operation { get; set; }

        public OperationExecuting()
        {
            SetOperation(this.Operation);
        }

        public OperationExecuting SetOperation(IOperationExecuting operation)
        {
            this.Operation = operation;
            return this;
        }

        public bool CanDo()
        {
            return this.Operation.CanDo();
        }
        public bool CanRealize()
        {
            return this.Operation.CanRealize();
        }

        public string Do()
        {
             return this.Operation.Do();
        }

        public string Realize()
        {
            return this.Operation.Realize();
        }
    }
}
