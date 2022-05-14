using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Interfaces
{
    public interface ICalculatingDate
    {
        TimeSpan Result(DateTime x, DateTime y);
    }
}
