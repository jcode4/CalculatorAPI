using System;
using System.Collections.Generic;
using CalculatorAPI.Interfaces;
using CalculatorAPI.Models;

namespace CalculatorAPI.Services
{
    
    public class NumberStore : INumberStore
    {
        private readonly Dictionary<string, List<(double Number, string Supplier, int Position)>> _storedNumbers;

        public NumberStore()
        {
            _storedNumbers = new Dictionary<string, List<(double, string, int)>>();
        }

        // Example: StoreNumber("Seattle", 5.0, "UserA", 1);
        public void StoreNumber(NumberRequestModel model)
        {
            if (!_storedNumbers.ContainsKey(model.Location))
            {
                _storedNumbers[model.Location] = new List<(double, string, int)>();
            }

            _storedNumbers[model.Location].Add((model.Number, model.Supplier, model.Position));
        }

        public List<(double Number, string Supplier, int Position)> GetNumbersForLocation(string location)
        {
            return _storedNumbers.ContainsKey(location) ? _storedNumbers[location] : new List<(double, string, int)>();
        }

        public void ClearNumbersForLocation(string location)
        {
            if (_storedNumbers.ContainsKey(location))
            {
                _storedNumbers.Remove(location);
            }
        }

        public double CalculateForLocation(string location, ICalculator calculator, string operation)
        {
            var numbers = GetNumbersForLocation(location);

            if (numbers.Count < 2)
            {
                // Handle insufficient numbers (you can customize the error message)
                return double.NaN; // or throw a custom exception
            }

            var lastIndex = numbers.Count - 1;
            var lastRecord = numbers[lastIndex];
            var previousRecord = numbers[lastIndex - 1]; // Get the second-to-last item

            // Use the actual values from the records
            var lastValue = lastRecord.Number;
            var previousValue = previousRecord.Number;

            // Perform the operation based on the input
            switch (operation)
            {
                case "add":
                    return calculator.Add(previousValue, lastValue, location);
                case "subtract":
                    return calculator.Subtract(previousValue, lastValue, location);
                case "multiply":
                    return calculator.Multiply(previousValue, lastValue, location);
                case "divide":
                    return calculator.Divide(previousValue, lastValue, location);
                default:
                    throw new ArgumentException("Invalid operation specified.");
            }
        }

      

    }
}
