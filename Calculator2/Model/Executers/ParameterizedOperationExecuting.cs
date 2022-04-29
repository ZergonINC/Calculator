using Calculator2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model.Executers
{
    public class ParameterizedOperationExecuting
    {
        private IParameterizedOperationExecuting ParametrizedOperation { get; set; }
        
        public ParameterizedOperationExecuting()
        {
            SetOp(this.ParametrizedOperation);
        }

        public ParameterizedOperationExecuting SetOp(IParameterizedOperationExecuting parametrizedOperation)
        {
            this.ParametrizedOperation = parametrizedOperation;
            return this;
        }

        public bool CanDo()
        {
            return this.ParametrizedOperation.CanDo();
        }

        public void Do(string parametr)
        {
            this.ParametrizedOperation.Do(parametr);
        }
    }
}
