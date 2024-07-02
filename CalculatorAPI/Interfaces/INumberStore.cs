using CalculatorAPI.Models;

namespace CalculatorAPI.Interfaces
{
    public interface INumberStore
    {

        void StoreNumber(string location, double number, int position);
        void ClearNumbers(string location);
        (double, double) GetNumbers(string location);
      }

}
