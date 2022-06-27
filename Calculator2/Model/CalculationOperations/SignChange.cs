using Calculator2.Interfaces;

namespace Calculator2.Model.CalculationOperations
{
    public class SignChange : IUnaryArithmetic
    {
        public double Result(double x) => x * (-1);
    }
}
