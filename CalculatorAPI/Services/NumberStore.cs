using System;
using System.Collections.Generic;
using CalculatorAPI.Interfaces;
using CalculatorAPI.Models;

namespace CalculatorAPI.Services
{
    // NumberStore.cs
    public class NumberStore : INumberStore
    {
        private Dictionary<string, List<double>> _numbers = new Dictionary<string, List<double>>();

        public void StoreNumber(string location, double number, int position)
        {
            if (!_numbers.ContainsKey(location))
            {
                _numbers[location] = new List<double>();
            }

            // Ensure list is large enough to store at 'position'
            while (_numbers[location].Count <= position)
            {
                _numbers[location].Add(0);
            }

            _numbers[location][position] = number;
        }

        public void ClearNumbers(string location)
        {
            if (_numbers.ContainsKey(location))
            {
                _numbers[location].Clear();
            }
        }

        public (double, double) GetNumbers(string location)
        {
            if (_numbers.ContainsKey(location) && _numbers[location].Count >= 2)
            {
                return (_numbers[location][0], _numbers[location][1]);
            }

            return (0, 0);
        }
    }

}
