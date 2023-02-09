using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator.Model.Operations.ConvertorsAndValidators
{
    public static class NumberValidator
    {
        private static readonly string regexPattern = @"^\d*[\.,]?\d*$";

        public static bool Check(string input) => Regex.IsMatch(input, regexPattern);

        public static string GetValidValue(string input) => Regex.Match(input, regexPattern).Value;

        public static string GetValidNumericValue(string input)
        {
            double.TryParse(input, out double output);
            return output.ToString();
        }
    }
}
