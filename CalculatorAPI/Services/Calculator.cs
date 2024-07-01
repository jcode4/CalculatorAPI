using CalculatorAPI.Interfaces;
namespace CalculatorAPI.Services
{
    public class Calculator : ICalculator
    {
        private readonly INumberStore _numberStore;

        public Calculator(INumberStore numberStore)
        {
            _numberStore = numberStore;
        }
        public double Add(double x, double y, string location) 
        {
            var numbers = _numberStore.GetNumbersForLocation(location);
            // Perform the addition using the retrieved numbers.
            return x + y;
        }
        public double Subtract(double x, double y, string location) 
        {
            var numbers = _numberStore.GetNumbersForLocation(location);

            return x - y;
        }
        public double Multiply(double x, double y, string location)
        {
            var numbers = _numberStore.GetNumbersForLocation(location);

            return x * y;
        }
        public double Divide(double x, double y, string location)
        {
            var numbers = _numberStore.GetNumbersForLocation(location);

            if (y == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return x / y;

        }
    }
}
