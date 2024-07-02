using CalculatorAPI.Interfaces;
namespace CalculatorAPI.Services
{
    // Calculator.cs
    public class Calculator : ICalculator
    {
        private readonly INumberStore _numberStore;

        public Calculator(INumberStore numberStore)
        {
            _numberStore = numberStore;
        }

        public List<string> GetAvailableOperations(string location)
        {
            var operations = new List<string>();
            var (num1, num2) = _numberStore.GetNumbers(location);

            if (num1 != 0 && num2 != 0)
            {
                operations.Add("Add");
                operations.Add("Subtract");
                operations.Add("Multiply");
                if (num2 != 0)
                    operations.Add("Divide");
            }

            return operations;
        }

        public double PerformCalculation(string location, string operation)
        {
            var (num1, num2) = _numberStore.GetNumbers(location);

            switch (operation)
            {
                case "Add":
                    return num1 + num2;
                case "Subtract":
                    return num1 - num2;
                case "Multiply":
                    return num1 * num2;
                case "Divide":
                    if (num2 != 0)
                        return num1 / num2;
                    else
                        throw new ArgumentException("Cannot divide by zero");
                default:
                    throw new ArgumentException("Invalid operation");
            }
        }
    }
}
