using Calculator2.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator2.ViewModel
{
    public class NumberValidator : IValidator
    {
        private readonly string regexPattern = @"^(0|[1-9]\d*)([.,]\d*)?";

        public bool Check(string input) => Regex.IsMatch(input, regexPattern);

        public string GetValidValue(string input) => Regex.Match(input, regexPattern).Value;
    }
}
