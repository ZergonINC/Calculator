using Calculator2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model.CalculatingDateModel
{
    public class SubtractionDates : ICalculatingDate
    {
        public TimeSpan Result(DateTime x, DateTime y) => x.Subtract(y);
    }
}
