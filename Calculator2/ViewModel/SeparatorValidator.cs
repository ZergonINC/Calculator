using Calculator2.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.ViewModel
{
    public class SeparatorValidator : IValidator
    {
        private readonly char separator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
        
        public bool Check(string input) => input.Contains(',');

        public string ReplaceSeparator(string input) => Check(input) ?
            input.Replace(',', separator) :
            input.Replace('.', separator);
    }
}
