using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Interfaces
{
    public interface IDateModel
    {
        DateTime FirstDate { get; set; }

        DateTime SecondDate { get; set; }
    }
}
