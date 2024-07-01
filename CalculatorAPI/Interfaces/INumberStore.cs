using CalculatorAPI.Models;

namespace CalculatorAPI.Interfaces
{
    public interface INumberStore
    {
        void StoreNumber(NumberRequestModel model);
        List<(double Number, string Supplier, int Position)> GetNumbersForLocation(string location);
        void ClearNumbersForLocation(string location);
        double CalculateForLocation(string location, ICalculator calculator, string operation);
    }

}
