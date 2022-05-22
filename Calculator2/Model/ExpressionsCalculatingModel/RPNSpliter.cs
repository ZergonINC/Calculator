using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator2.Model.ExpressionsCalculatingModel
{
    public class RPNSpliter
    {
        string pattern = @"(\-)|(\/)|(\*)|(\^)|(\+)|(\()|(\))";

        public string[] TrySplit(string parametr)
        {
            return Regex.Split(parametr, pattern);
        }
    }
}
