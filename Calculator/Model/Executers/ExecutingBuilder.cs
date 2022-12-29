using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model.Executers
{
    public class ExecutingBuilder
    {
        Executing executing;

        public ExecutingBuilder() => executing = new Executing();

        public ExecutingBuilder SetCalculator(ICalculator calculator)
        {
            executing.Calculator = calculator;
            return this;
        }

        public ExecutingBuilder SetCalculation(ICalculation model)
        {
            executing.Calculation = model;
            return this;
        }

        public ExecutingBuilder SetConvertor(INumberConvertor numberConvertor)
        {
            executing.NumberConvertor = numberConvertor;
            return this;
        }

        public Executing Build() => executing;
    }
}
