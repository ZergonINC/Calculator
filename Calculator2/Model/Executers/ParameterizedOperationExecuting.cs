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
            SetOperation(this.ParametrizedOperation);
        }

        public ParameterizedOperationExecuting SetOperation(IParameterizedOperationExecuting parametrizedOperation)
        {
            this.ParametrizedOperation = parametrizedOperation;
            return this;
        }

        public bool CanDo()
        {
            return this.ParametrizedOperation.CanDo();
        }

        public string Do(string parametr)
        {
            return this.ParametrizedOperation.Do(parametr);
        }
    }
}
