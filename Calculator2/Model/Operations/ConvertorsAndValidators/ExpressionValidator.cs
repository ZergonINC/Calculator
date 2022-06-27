using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator2.Model.Operations.ConvertorsAndValidators
{
    public static class ExpressionValidator
    {
        private static readonly string regexPattern = @"^\d*[\.,]?\d*$";

        public static bool Check(string input) => Regex.IsMatch(input, regexPattern);

        public static string GetValidValue(string input) => Regex.Match(input, regexPattern).Value;

        public static bool ValidParentheses(string input)
        {
            int c = 0;
            return !input.Select(i => c += i == '(' ? 1 : i == ')' ? -1 : 0).Any(i => i < 0) && c == 0;
        }
    }
}