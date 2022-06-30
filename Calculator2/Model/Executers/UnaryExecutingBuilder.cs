using Calculator2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2.Model.Executers
{
    public class UnaryExecutingBuilder
    {
        UnaryExecuting unaryExecuting;

        public UnaryExecutingBuilder() => unaryExecuting = new UnaryExecuting();

        public UnaryExecutingBuilder SetCalculator(ICalculator calculator)
        {
            unaryExecuting.Calculator = calculator;
            return this;
        }

        public UnaryExecutingBuilder SetUnaryCalculation(IUnaryCalculation Model)
        {
            unaryExecuting.UnaryCalculation = Model;
            return this;
        }

        public UnaryExecutingBuilder SetConvertor(INumberConvertor numberConvertor)
        {
            unaryExecuting.NumberConvertor = numberConvertor;
            return this;
        }

        public UnaryExecuting Build() => unaryExecuting;
    }
}