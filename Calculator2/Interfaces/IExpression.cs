using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Interfaces
{
    public interface IExpression
    {
        public string Expression { get; set; }

        public string[] RPN { get; set; }
    }
}
