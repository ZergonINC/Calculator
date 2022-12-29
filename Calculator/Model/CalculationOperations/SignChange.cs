using Calculator.Interfaces;

namespace Calculator.Model.CalculationOperations
{
    public class SignChange : IUnaryArithmetic
    {
        public double Result(double x) => x * (-1);
    }
}
