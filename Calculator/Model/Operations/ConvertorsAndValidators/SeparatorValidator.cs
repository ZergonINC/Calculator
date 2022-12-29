using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model.Operations.ConvertorsAndValidators
{
    public static class SeparatorValidator
    {
        private static readonly char separator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

        public static bool Check(string input) => input.Contains(',');

        public static string ReplaceSeparator(string input) => Check(input) ?
            input.Replace(',', separator) :
            input.Replace('.', separator);
    }
}
