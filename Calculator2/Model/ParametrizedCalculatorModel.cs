using Calculator2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model
{
    public class ParametrizedCalculatorModel
    {
        private IParametrizedOperation ParametrizedOperation { get; set; }
        
        public ParametrizedCalculatorModel()
        {
            SetOp(this.ParametrizedOperation);
        }

        public ParametrizedCalculatorModel SetOp(IParametrizedOperation parametrizedOperation)
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
