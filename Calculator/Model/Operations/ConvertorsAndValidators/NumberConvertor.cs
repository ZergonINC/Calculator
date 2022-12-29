using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model.Operations.ConvertorsAndValidators
{
    public class NumberConvertor : INumberConvertor
    {
        public double Convert(string value)
        {
            double.TryParse(value, out double result);
            return result;
        }

        public string ConvertBack(double value) => $"{value}";
    }
}
