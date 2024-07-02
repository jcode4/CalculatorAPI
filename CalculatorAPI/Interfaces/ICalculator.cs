namespace CalculatorAPI.Interfaces
{
    public interface ICalculator
    {
        List<string> GetAvailableOperations(string location);
        double PerformCalculation(string location, string operation);
      }
}
