using Calculator2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model.Executers
{
    public abstract class BaseExecuting
    {
        public virtual ICalculator Calculator { get; set; }

        public virtual ICalculation Calculation { get; set; }

        public virtual INumberConvertor NumberConvertor { get; set; }

        public abstract void Run();

    }
}
