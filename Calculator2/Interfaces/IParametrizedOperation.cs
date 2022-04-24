using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Interfaces
{
    public interface IParametrizedOperation
    {
        bool CanDo();

        void Do(string parametr);
    }
}
